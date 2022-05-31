using Dailybiz_API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using System.Xml;

namespace Dailybiz_API.Controllers
{
    public class ClientController : ApiController
    {
        private string reponse;
        [HttpGet]
        [Route("api/Client/{id}")]
        public string GetClient(string CodeClient)
        {
            Client client = new Client { };
            API.setSession();
            if (CodeClient != null && CodeClient != "") {          
                reponse = API.idev.LireTable("FB_CLIENTS", "CodeClient='" + CodeClient + "'", "", "0", "0", "0");
            } else {      
                reponse = API.idev.LireTable("FB_CLIENTS", "1=1", "", "0", "0", "0");
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(reponse);
            XmlNodeList elem = doc.GetElementsByTagName("FICHE");
            List<Client> ListeDeClients = new List<Client>();
            
            for (int i = 0; i < elem.Count; i++)
            {
                client = new Client
                {
                    RefClient = elem[i]["REFCLIENT"].InnerText,
                    CodeClient = elem[i]["CODECLIENT"].InnerText,
                    Nom = elem[i]["NOM"].InnerText,
                    Adresse1 = elem[i]["ADRESSE1"].InnerText,
                    Adresse2 = elem[i]["ADRESSE2"].InnerText,
                    Ville = elem[i]["VILLE"].InnerText,
                    CP = elem[i]["CP"].InnerText,
                    Pays = elem[i]["PAYS"].InnerText,
                    Email = elem[i]["EMAIL"].InnerText,
                    Tel = elem[i]["TEL"].InnerText,
                    Web = elem[i]["WEB"].InnerText,
                    CompteComptable = elem[i]["COMP_COMPTABLE"].InnerText
                };

                ListeDeClients.Add(client);

            }

            string json = JsonConvert.SerializeObject(ListeDeClients, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        // PUT v1/client

        // Ajouter un client
        [HttpPost]
        [Route("api/Client/Add")]
        public string AddClient(string cXml)
        {
           string cRetour = API.idev.InsererTable(cXml);
           return cRetour;
        }

        // Supprimer un client
        [HttpDelete]
        [Route("api/Client/Delete/{id}")]
        public string DeleteClient(string idClient)
        {
            string cRetour = API.idev.SuppresionTable("FB_Clients", idClient);
            return cRetour;
        }

        // Mettre à jour un client
        [HttpPut]
        [Route("api/Client/Update")]
        public string UpdateClient(string cXml)
        {
            string cRetour = API.idev.MajTable(cXml);
            return cRetour;
        }

        
    }
}
