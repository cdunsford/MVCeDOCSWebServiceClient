using MVCeDOCSwebServiceClient.DataAccess;
using MVCeDOCSwebServiceClient.Models;
using MVCeDOCSwebServiceClient.Services.Utility;
using NLog;
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

        //private static Logger logger = LogManager.GetLogger("myAppLoggerRules");

        // GET: DocsFusion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListLibraries()
        {

            AppLogger.GetInstance().Info("STARTING " + System.Reflection.MethodBase.GetCurrentMethod().Name);

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
                AppLogger.GetInstance().Error("Exception:  " + ex.Message);
                throw ex;
            }

            AppLogger.GetInstance().Info("COMPLETING " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            return View(docsFusion);

        }

        
    }
}