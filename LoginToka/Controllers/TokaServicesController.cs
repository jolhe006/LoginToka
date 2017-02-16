using LoginToka.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace LoginToka.Controllers
{
    public class TokaServicesController : Controller
    {
        // GET: TokaServices
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            DataTable Users = GetDtUsers();
            List<User> lstUsers = new List<User>();
            lstUsers = Users.AsEnumerable().Select(u => new User{
                id = u.Field<string>("id"),
                usuario = u.Field<string>("usuario"),
                ciudad = u.Field<string>("ciudad"),
                puesto = u.Field<string>("puesto"),
                privilegio = u.Field<string>("privilegio")
            }).ToList();
                        
            var jsonData = new
            {
                draw = 1,
                recordsTotal = lstUsers.Count,
                data = lstUsers
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);

            /*
            var jsonUsers = JsonConvert.SerializeObject(Users); //serializer.Serialize(Users.Rows);
            var x = jsonUsers.ToString();
            return Json(x, , JsonRequestBehavior.AllowGet);
            */
        }

        public static DataTable GetDtUsers()
        {
            LoginToka.mx.com.toka.aplicaciones.Service serv = new mx.com.toka.aplicaciones.Service();
            XmlNode response = serv.getUsuarios();

            string strResponse = response.OuterXml.ToString();
            StringReader readerResponse = new StringReader(strResponse);


            DataSet ds = new DataSet();
            ds.ReadXml(readerResponse);

            return ds.Tables[0];
        }
    }
}
