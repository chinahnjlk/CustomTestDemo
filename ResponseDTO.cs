using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class ResponseDto
    {
        public SingleObj searchResults { get; set; }
    }

    public class ResponseDtos
    {
        public MutilObj searchResults { get; set; }
    }


    public class MutilObj
    {
        public List<Searchresult> searchResult { get; set; }
    }

    public class SingleObj
    {
        public Searchresult searchResult { get; set; }
    }




    public class Searchresult
    {
        public string searchItem { get; set; }
        public string searchPCEndRange { get; set; }
        public string searchPCStartRange { get; set; }
        public string searchTown { get; set; }
    }


}


