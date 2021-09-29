using MVCeDOCSwebServiceClient.DataAccess;
using MVCeDOCSwebServiceClient.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MVCeDOCSwebServiceClient.Controllers
{
    public class DocsFusionController : Controller
    {
        // GET: DocsFusion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListLibraries()
        {
            DocsFusionModel docsFusion = new DocsFusionModel();

            try
            {
                if(String.IsNullOrEmpty(ViewBag.serverAddress))
                {
                    ClientSection clientSection = (ClientSection)WebConfigurationManager.GetSection("system.serviceModel/client");
                    ChannelEndpointElement endpoint = clientSection.Endpoints[0];
                    ViewBag.serverAddress = endpoint.Address.ToString();
                }
                
                DMSvr.GetLoginLibrariesCall call = new DMSvr.GetLoginLibrariesCall();
                call.dstIn = string.Empty;
                DMSvr.DMSvcClient client = Connection.SvcConnect(ViewBag.serverAddress);
                DMSvr.GetLoginLibrariesReply reply = client.GetLoginLibraries(call);
                client.Close();
                docsFusion.LoginLibsCount = reply.libraries.Length;
                docsFusion.LoginLibs = reply.libraries;

            }
            catch (Exception ex)
            {

                throw ex;
            }


            return View(docsFusion);

        }

        
    }
}