using Dailybiz_API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using System.Xml;

namespace Dailybiz_API.Controllers
{
    public class ClientController : ApiController
    {
        [HttpGet]
        [Route("api/client/{id}")]
        public string GetClient(string CodeClient)
        {
            Client client = new Client { };
            API.setSession();
            string reponse = API.idev.LireTable("FB_CLIENTS", "CodeClient=" + CodeClient + "", "", "0", "0", "0");
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

            //client.Contacts = ListeContacts(client);
            string json = JsonConvert.SerializeObject(ListeDeClients, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        // PUT v1/client

        // Ajouter un client
        [HttpPost]
        [Route("api/client/add")]
        public string AddClient(string cXml)
        {
           string cRetour = API.idev.InsererTable(cXml);
           return cRetour;
        }

        // Supprimer un client
        [HttpDelete]
        [Route("api/client/delete/{id}")]
        public string DeleteClient(string idClient)
        {
            string cRetour = API.idev.SuppresionTable("FB_Clients", idClient);
            return cRetour;
        }

        // Mettre à jour un client
        [HttpPut]
        [Route("api/client/update/{id}")]
        public string UpdateClient(string cXml)
        {
            string cRetour = API.idev.MajTable(cXml);
            return cRetour;
        }

        
    }
}
