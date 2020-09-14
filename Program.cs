using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        private static string Result { get; set; } = string.Empty;

        private static string Results { get; set; } = string.Empty;

        private static string Params { get; set; }
        static void Main(string[] args)
        {
            //ListToXmlTest();
            XmlDocument xmlDocuments = new XmlDocument();
            XmlDocument xmlDocument = new XmlDocument();

            var userPassword = "";
            var userName = "";
            string url = "";

            TownSearchRequest townSearchRequest = new TownSearchRequest
            {
                AppId = "PC",
                AppVersion = "1.0",
                TownSearch = new TownSearch
                {
                    Country = "IN",
                    Postcode = 411057,
                    Town = "PUNE"
                }
            };

            Params = SerializeToXml(townSearchRequest, typeof(TownSearchRequest));


            WebHeaderCollection headerCollection = new WebHeaderCollection
            {
                {
                    "Authorization", string.Format("Basic {0}" , Convert.ToBase64String(Encoding.Default.GetBytes(string.Format("{0}:{1}", userName, userPassword))))
                }
            };

            Result = HttpPostByXml(url, Params, headerCollection);

            Results = @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?><searchResults>
                   <searchResult>
                    <searchItem>1</searchItem>
                    <searchPCEndRange>411057</searchPCEndRange>
                    <searchPCStartRange>411057</searchPCStartRange>
                    <searchTown>HINJEWADI</searchTown>
                    </searchResult>
            <searchResult>
                    <searchItem>1</searchItem>
                    <searchPCEndRange>411057</searchPCEndRange>
                    <searchPCStartRange>411057</searchPCStartRange>
                    <searchTown>HINJEWADI</searchTown>
                    </searchResult>
            </searchResults>";


            xmlDocument.LoadXml(Result);
            xmlDocuments.LoadXml(Results);


            if (xmlDocument != null)
            {
                var count = xmlDocument.SelectNodes("searchResults").Item(0).ChildNodes.Count;

            }
            var json = JsonConvert.SerializeXmlNode(xmlDocument);
            var jsons = JsonConvert.SerializeXmlNode(xmlDocuments);

            Console.WriteLine(json);
            Console.WriteLine(jsons);


            var objs = JsonConvert.DeserializeObject<ResponseDto>(jsons);
            var obj = JsonConvert.DeserializeObject<ResponseDtos>(json);

            Console.ReadKey();

        }

        /// <summary>
        /// Post 提交 xml格式的请求
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="parmas"></param>
        /// <param name="headerCollection"></param>
        /// <returns></returns>
        public static string HttpPostByXml(string uri, string parmas, WebHeaderCollection headerCollection)
        {
            string result = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "text/xml";
            request.Headers.Add(headerCollection);
            var paramsBytes = Encoding.Default.GetBytes(parmas);
            Stream streamRequest = request.GetRequestStream();
            streamRequest.Write(paramsBytes, 0, paramsBytes.Length);
            streamRequest.Flush();
            streamRequest.Close();
            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    var streamResponse = webResponse.GetResponseStream();
                    if (streamResponse != null)
                    {
                        using (StreamReader reader = new StreamReader(streamResponse))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
                else
                {
                    result = ((int)webResponse.StatusCode).ToString();
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return result;
        }

        /// <summary>
        /// 实体序列号 为xml字符串
        /// </summary>
        /// <param name="srcObject"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string SerializeToXml(object srcObject, Type type)
        {
            type = type != null ? type : srcObject.GetType();
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);
            XmlSerializer xs = new XmlSerializer(type);
            StringBuilder stb = new StringBuilder();
            XmlWriter xw = XmlWriter.Create(stb, new XmlWriterSettings() { Encoding = Encoding.UTF8, IndentChars = "\t" });
            xs.Serialize(xw, srcObject, xsn);
            return stb.ToString();
        }




        public static void ListToXmlTest()
        {
            //获取用户列表
            List<UserInfo> userList = GetUserList();

            //将实体对象转换成XML
            string xmlResult = XmlSerialize(userList);

            //将XML转换成实体对象
            List<UserInfo> deResult = DESerializer<List<UserInfo>>(xmlResult);
        }

        public static List<UserInfo> GetUserList()
        {
            List<UserInfo> userList = new List<UserInfo>();
            userList.Add(new UserInfo() { ID = 1, Name = "张三", CreateTime = DateTime.Now });
            userList.Add(new UserInfo() { ID = 2, Name = "李四", CreateTime = DateTime.Now });
            userList.Add(new UserInfo() { ID = 2, Name = "王五" });
            return userList;
        }



        public static string XmlSerialize<T>(T obj)
        {
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    Type t = obj.GetType();
                    XmlSerializer serializer = new XmlSerializer(obj.GetType());
                    serializer.Serialize(sw, obj);
                    sw.Close();
                    return sw.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("将实体对象转换成XML异常", ex);
            }
        }

        public static T DESerializer<T>(string strXML) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("将XML转换成实体对象异常", ex);
            }
        }
    }


    public class UserInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        [XmlElement("Id")]
        public int ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>

        public DateTime? CreateTime { get; set; }
    }
}





