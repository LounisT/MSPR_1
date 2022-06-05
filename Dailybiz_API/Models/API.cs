using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using Dailybiz_API.com.dailybiz.exe;

namespace Dailybiz_API.Models
{
    public static class API
    {
        public static Idylisapi idev = new Idylisapi();
        public static string test;
        public static string cSessionID;



        public static void setSession(/*string CodeAbonne = "mathiasapi", string Identifiant = "mathias.hue@hotmail.com", string MotDePasse = "Lenny27"*/)
        {
            String session = "";
            session = API.idev.authentification1(/*CodeAbonne*/ "mathiasapi", /*Identifiant*/ "mathias.hue@hotmail.com", /*MotDePasse*/"Lenny27");
            API.idev.SessionIDHeaderValue = new SessionIDHeader();
            API.idev.SessionIDHeaderValue.SessionID = session;

            HttpContext context = HttpContext.Current;




        }

     
       
    }
}
