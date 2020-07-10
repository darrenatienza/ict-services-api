using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Jwt.Models.SG
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportModel
    {
        public ReportModel()
        {
            
        }
        public int ReportID { get; set; }
        public DateTime Date { get; set; }
        public string Desc { get; set; }
        public string Acts { get; set; }
        public string Personnel { get; set; }
        public string Rmks { get; set; }
    }
}