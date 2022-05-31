using Dailybiz_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Dailybiz_API.Controllers
{
    public class HomeController : Controller
    {
        // GET v1/factures/{codeclient}
        [HttpGet]
        [Route("v1/factures/{codeclient}")]
        public string GetFacture(string CodeClient)
        {
            Facture facture = new Facture { };
            API.setSession();
            string reponse = API.idev.LireTable("FA_FACTURES", "CodeFournisseur='" + CodeClient + "'", "", "0", "0", "0");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(reponse);
            XmlNodeList elem = doc.GetElementsByTagName("FICHE");
            List<Facture> ListeDeFacture = new List<Facture>();
            for (int i = 0; i < elem.Count; i++)
            {
                facture = new Facture
                {
                    RefFacture = elem[i]["REFFACTURE"].InnerText,
                    DateCrea = elem[i]["DATECREA"].InnerText,
                    RefUtilisateur = elem[i]["EXP_REFUTILISATEUR"].InnerText,
                    ObjetFacture = elem[i]["OBJETFACTURE"].InnerText,
                    CodeFacture = elem[i]["CODEFACTURE"].InnerText,
                    CodeClient = elem[i]["CODECLIENT"].InnerText,
                    CodeDossier = elem[i]["CODEDOSSIER"].InnerText,
                    NomContact = elem[i]["NOMCONTACT"].InnerText,
                    PrenomContact = elem[i]["PRENOMCONTACT"].InnerText,
                    RaisonSociale = elem[i]["EXP_RAISONSOCIALE"].InnerText,
                    Adresse1 = elem[i]["ADRESSE1"].InnerText,
                    Adresse2 = elem[i]["ADRESSE2"].InnerText,
                    CP = elem[i]["CP"].InnerText,
                    Ville = elem[i]["VILLE"].InnerText,
                    Pays = elem[i]["PAYS"].InnerText,
                    Reglement = elem[i]["REGLEMENT"].InnerText,
                    CiviliteContact = elem[i]["CIVILITECONTACT"].InnerText,
                    CodeTva = elem[i]["CODETVA"].InnerText,
                    TotHT = elem[i]["TOTHT"].InnerText,
                    TotTTC = elem[i]["TOTTTC"].InnerText,
                    DateEcheance = elem[i]["DATEECHEANCE"].InnerText,

                };
                ListeDeFacture.Add(facture);
            }

            string json = JsonConvert.SerializeObject(ListeDeFacture, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        // PUT v1/Facture

        // Ajouter un Facture
        [HttpPut]
        [Route("v1/Facture")]
        public string AddFacture(string cXml)
        {
            string cRetour = API.idev.InsererTable(cXml);
            return cRetour;
        }

        // Supprimer un Facture
        [HttpDelete]
        [Route("v1/Facture/{id}")]
        public string DeleteFacture(string idFacture)
        {
            string cRetour = API.idev.SuppresionTable("FB_Factures", idFacture);
            return cRetour;
        }

        // Mettre à jour un Facture
        [HttpGet]
        [Route("v1/Facture/{id}")]
        public string UpdateFacture(string cXml)
        {
            string cRetour = API.idev.MajTable(cXml);
            return cRetour;
        }
        public ActionResult Index()
        {
            GetFacture("");
            return View();
        }
    }

}
