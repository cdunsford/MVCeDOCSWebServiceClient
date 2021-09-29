using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace MVCeDOCSwebServiceClient.DataAccess
{
    public class Connection
    {
        public static DMSvr.DMSvcClient SvcConnect(string serverAddress)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 0x7fffffff;
            binding.ReaderQuotas.MaxArrayLength = 0x7fffffff;
            binding.ReaderQuotas.MaxStringContentLength = 0x7fffffff;

            //EndpointAddress addr = new EndpointAddress("http://win-hfvgfmp2gdc:8080/DMSvr/Svc");
            EndpointAddress addr = new EndpointAddress(serverAddress);
            return new DMSvr.DMSvcClient(binding, addr);

        }
        //private string BaseAddress(string targetService)
        //{
        //    StringBuilder sb = new StringBuilder();f
        //    sb.Append("http://win-hfvgfmp2gdc:8080/DMSvr/Svc");

        //    if (!sb.ToString().EndsWith("/"))
        //    {
        //        sb.Append("/");
        //    }

        //    sb.Append(targetService);

        //    return sb.ToString();
        //}
    }
}