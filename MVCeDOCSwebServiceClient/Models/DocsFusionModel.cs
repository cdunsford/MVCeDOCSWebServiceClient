using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCeDOCSwebServiceClient.Models
{
    public class DocsFusionModel
    {
        public string[] LoginLibs { get; set; }
        public int LoginLibsCount { get; set; }
        public string LoginLibrary { get; set; }
        public string UserDST { get; set; }
    }
}