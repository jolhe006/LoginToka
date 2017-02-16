using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LoginToka.Models
{
    public class User
    {
        [Required]
        public string id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El Usuario es requerido.")]
        [DataType(DataType.Text)]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La contraseña es requerida.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Display(Name = "Ciudad")]
        public string ciudad { get; set; }

        [Display(Name = "Puesto")]
        public string puesto { get; set; }

        [Display(Name = "Privilegio")]
        public string privilegio { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool rememberMe { get; set; }

        public bool IsValidate()
        {
            LoginToka.mx.com.toka.aplicaciones.Service serv = new mx.com.toka.aplicaciones.Service();
            XmlNode response = serv.getUser(usuario, password);

            string strResponse = response.OuterXml.ToString();
            StringReader readerResponse = new StringReader(strResponse);

                        
            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(readerResponse);
            DataTable dt = theDataSet.Tables[0];
            DataRow dr = dt.Rows[0];

            //User person = new User();

            foreach (DataColumn c in dr.Table.Columns)
            {
                PropertyInfo p = this.GetType().GetProperty(c.ColumnName);                
                if (p != null && dr[c] != DBNull.Value)
                { p.SetValue(this, dr[c], null); }
            }

            return (this.id != null);
        }        
    }
}