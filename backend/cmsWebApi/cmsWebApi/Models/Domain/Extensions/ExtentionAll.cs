using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsWebApi.models.Domain.Extentions
{
    public static class ExtentionAll
    {
        public static DateTime? ToDate(this string vlr)
        {
            try { return Convert.ToDateTime(vlr); }
            catch (Exception) { return null; }
        }
        public static DateTime ToDate(this string vlr, string parm = "")
        {
            DateTime aux = DateTime.Now;
            try { aux = Convert.ToDateTime(vlr); }
            catch (Exception) { }
            return aux;
        }
        public static DateTime ToDate(this object vlr, string parm = "")
        {
            DateTime aux = DateTime.Now;
            try { aux = Convert.ToDateTime(vlr); }
            catch (Exception) { }
            return aux;
        }
        public static int ToInt(this string vlr)
        {
            try { return Convert.ToInt32(vlr); }
            catch (Exception) { return 0; }
        }
        public static int ToInt(this object vlr)
        {
            try { return Convert.ToInt32(vlr); }
            catch (Exception) { return 0; }
        }
        
    }
}