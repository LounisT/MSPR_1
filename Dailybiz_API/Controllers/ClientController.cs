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
        [Route("api/Client/{id}")]
        public string GetClient(string CodeClient)
        {
            Client client = new Client { };
            API.setSession();
            string reponse = API.idev.LireTable("FB_CLIENTS", "CodeClient='" + CodeClient + "'", "", "0", "0", "0");
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

        [HttpGet]
        [Route("api/ContactDuClient/{CodeClient}")]
        public string GetContact(string CodeClient)
        {
            Contact contact = new Contact { };
            API.setSession();
            string reponse = API.idev.LireTable("FB_Contacts", "CodeClient='" + CodeClient + "'", "", "0", "0", "0");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(reponse);
            XmlNodeList elem = doc.GetElementsByTagName("FICHE");
            List<Contact> ListeDeContacts = new List<Contact>();

            for (int i = 0; i < elem.Count; i++)
            {
                contact = new Contact
                {
                    RefContact = elem[i]["REFCONTACT"].InnerText,
                    CodeClient = elem[i]["CODECLIENT"].InnerText,
                    Nom = elem[i]["NOM"].InnerText,
                    Prenom = elem[i]["PRENOM"].InnerText,
                    Tel = elem[i]["TEL"].InnerText,
                    Fonction = elem[i]["FONCTION"].InnerText,
                    Email = elem[i]["EMAIL"].InnerText,
                    Adresse1 = elem[i]["ADRESSE1"].InnerText,
                    Adresse2 = elem[i]["ADRESSE2"].InnerText,
                    Ville = elem[i]["VILLE"].InnerText,
                    CP = elem[i]["CP"].InnerText,
                    Pays = elem[i]["PAYS"].InnerText,
                    Commentaire = elem[i]["COMMENTAIRE"].InnerText
                };

                ListeDeContacts.Add(contact);

            }

            string json = JsonConvert.SerializeObject(ListeDeContacts/*contact*/, Newtonsoft.Json.Formatting.Indented);

            return json;
        }


        // Ajouter un client
        [HttpPost]
        [Route("api/Client/Add/{cXml}")]
        public string AddClient(string cXml)
        {
           string cRetour = API.idev.InsererTable(cXml);
           return cRetour;
        }

        // Supprimer un client
        [HttpDelete]
        [Route("api/Client/Delete/{idClient}")]
        public string DeleteClient(string idClient)
        {
            string cRetour = API.idev.SuppresionTable("FB_Clients", idClient);
            return cRetour;
        }

        // Mettre à jour un client
        [HttpPut]
        [Route("api/Client/Update/{cXml}")]
        public string UpdateClient(string cXml)
        {
            string cRetour = API.idev.MajTable(cXml);
            return cRetour;
        }

        
    }
}
