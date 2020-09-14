using System;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp1
{

    /// <summary>
    /// 请求参数model
    /// </summary>
    [Serializable]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("townSearchRequest")]
    public  class TownSearchRequest
    {

        private string _appId;

        private string _appVersion;

        private TownSearch _townsearch;

        /// <summary>
        /// appId
        /// </summary>

        [XmlElement("appId")]
        public string AppId
        {
            get
            {
                return this._appId;
            }
            set
            {
                this._appId = value;
            }
        }
        /// <summary>
        /// appVersion
        /// </summary>
        [XmlElement("appVersion")]
        public string AppVersion
        {
            get
            {
                return this._appVersion;
            }
            set
            {
                this._appVersion = value;
            }
        }
        /// <summary>
        /// townsearch
        /// </summary>
        [XmlElement("townsearch")]
        public TownSearch TownSearch
        {
            get
            {
                return this._townsearch;
            }
            set
            {
                this._townsearch = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public  class TownSearch
    {

        private string _country;

        private string _town;

        private int _postcode;
        /// <summary>
        /// country
        /// </summary>
        [XmlElement("country")]
        public string Country
        {
            get
            {
                return this._country;
            }
            set
            {
                this._country = value;
            }
        }
        /// <summary>
        /// town
        /// </summary>
        [XmlElement("town")]
        public string Town
        {
            get
            {
                return this._town;
            }
            set
            {
                this._town = value;
            }
        }
        /// <summary>
        /// postcode
        /// </summary>
        [XmlElement("postcode")]
        public int Postcode
        {
            get
            {
                return this._postcode;
            }
            set
            {
                this._postcode = value;
            }
        }
    }


}
