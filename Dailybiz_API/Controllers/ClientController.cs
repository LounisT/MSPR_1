using Dailybiz_API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Providers.Entities;
using System.Xml;
using Dailybiz_API.com.dailybiz.exe;
using System.Web;

namespace Dailybiz_API.Controllers
{
    public class ClientController : ApiController
    {
        [HttpGet]
        [Route("api/Client/{CodeClient}")]
        public string GetClient(string CodeClient)
        {
            Client client = new Client();
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            try
            {
                API.setSession();
            }
            catch
            {
                return "Session Invalide";
            }
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


        // Ajouter un client
        [HttpGet]
        [Route("api/Client/Add/RefClient={RefClient}/CodeClient={CodeClient}/Nom={Nom}/Adresse1={Adresse1}/Adresse2={Adresse2}/Ville={Ville}/CP={CP}/Pays={Pays}/Web={Web}/Tel={Tel}/Email={Email}/CompteComptable={CompteComptable}")]
        public string AddClient(string RefClient, string CodeClient, string Nom, string Adresse1, string Adresse2, string Ville, string CP, string Pays, string Web,string tel, string Email, string CompteComptable)
        {



            string ClientXML = @"<?xml version=""1.0"" encoding=""utf-8""?>
            <FB_CLIENTS>
            <FICHE>
            <ADMIN>madydmk@gmail.com</ADMIN>
            <ADRESSE1>[ADRESSE1]</ADRESSE1>
            <ADRESSE2>[ADRESSE2]</ADRESSE2>
            <ADRESSE3/>
            <CAPITAL/>
            <CLEHACHAGEEDI/>
            <CLERIB>72</CLERIB>
            <CLIENTBLOQUE/>
            <CLIENTGARANTIFACTOR/>
            <CODE/>
            <CODEAPE/>
            <CODEBANQUE>03469</CODEBANQUE>
            <CODEBICSWIFT/>
            <CODECATALOGUE>CATAL01</CODECATALOGUE>
            <CODECLIENT>[CODECLIENT]</CODECLIENT>
            <CODECLIENT_PAYEUR/>
            <CODECLIENTBOUTIQUE/>
            <CODEDEVISE/>
            <CODEFAMILLECLIENT>FAM_CLI03</CODEFAMILLECLIENT>
            <CODEGUICHET>12185</CODEGUICHET>
            <CODEMODELEREGLEMENT/>
            <CODEORIGINE/>
            <CODEVENDEUR>VENDEUR02</CODEVENDEUR>
            <COMP_COMPTABLE>[COMPTECOMPTABLE]</COMP_COMPTABLE>
            <COMPTEENCAISSEMENT/>
            <COMPTEPCA/>
            <CP>[CP]</CP>
            <CRITERE1/>
            <CRITERE2/>
            <CRITERE3/>
            <CRITERE4/>
            <CRITERE5/>
            <CRITERE6/>
            <CRITERE7/>
            <CRITERE8/>
            <CRITERE9/>
            <DATEAPPROBATION/>
            <DATEARCHIVAGE/>
            <DATECREATION>18/03/2008 00:00:00</DATECREATION>
            <DATEDERNIEREFACTURE/>
            <DATEMAJ/>
            <DOMICILIATION/>
            <EMAIL>[EMAIL]</EMAIL>
            <ENCOURS/>
            <EXM/>
            <FAX>0133120001</FAX>
            <FICHIER_LOGO/>
            <FICHIER_LOGOHAUTER/>
            <FORMEJURIDIQUE/>
            <FTPDOSSIERAPARSEREDI/>
            <FTPMOTDEPASSEEDI/>
            <FTPPORTEDI/>
            <FTPURIEDI/>
            <FTPUTILISATEUREDI/>
            <GARANTI/>
            <GLN/>
            <IBAN>FR7603469121851568794001572</IBAN>
            <ID_SF/>
            <IDE_AUTORISEPKI/>
            <IDE_CODEDOSSIERPARENT/>
            <IDE_DOSSIERPAYANT/>
            <IDE_REFABONNE/>
            <INDUSTRIE/>
            <MANDATAIREEDI/>
            <MODETRANSPORT/>
            <MONTANTGARANTI/>
            <MOTIF/>
            <NOM>[NOM]</NOM>
            <NOMBREEMPLOYES/>
            <NONSOUMISTVA>False</NONSOUMISTVA>
            <NUMEROCOMPTE>15687940015</NUMEROCOMPTE>
            <NUMEROFACTOR/>
            <NUMEROSIRET/>
            <NUMEROURSSAF/>
            <OXATIS_CUSTOMERID/>
            <PAYS>[PAYS]</PAYS>
            <REFCLIENT>[REFCLIENT]</REFCLIENT>
            <REGLEMENT>30joursfindemois</REGLEMENT>
            <RELANCEFACTURE/>
            <RELCO_TYPECOMMANDE/>
            <SECTEUR/>
            <SIREN/>
            <SOUMISTVADOM>False</SOUMISTVADOM>
            <SOUMISTVAUE/>
            <STATUT/>
            <TARIFPARQTE>False</TARIFPARQTE>
            <TAUXREMISE>0,0000</TAUXREMISE>
            <TEL>[TEL]</TEL>   
            <TITULAIRECOMPTE/>
            <TVA_INTRA>FR78523000000</TVA_INTRA>
            <TYPE_NONSOUMISTVA/>
            <TYPEPAIEMENT>Chèque</TYPEPAIEMENT>
            <TYPESOCIETE/>
            <VILLE>[VILLE]</VILLE>
            <VILLERCS/>
            <VILLEURSSAF/>
            <WEB>[WEB]</WEB>
            <XPE_AUTORISEPKI/>
            <XPE_CODEABONNE_SUPPL/>
            <XPE_CODEDOSSIERPARENT/>
            <XPE_DOSSIERPAYANT/>
            <XPE_PRODUCTIONPARTAGEE/>
            <XPE_REFABONNE/>
            <EXP_CIVILITEVENDEUR/>
            <EXP_CLIENTARCHIVE>NON</EXP_CLIENTARCHIVE>
            <EXP_CODECLIENT_IFRHA>[CODECLIENT]</EXP_CODECLIENT_IFRHA>
            <EXP_COMPTEUR>1</EXP_COMPTEUR>
            <EXP_CPVILLE/>
            <EXP_CRÉÉPAR>DiakiteMademba</EXP_CRÉÉPAR>
            <EXP_DATEDERNIERAVOIR>20/02/202200:00:00</EXP_DATEDERNIERAVOIR>
            <EXP_DATEDERNIERBL/>
            <EXP_DATEDERNIERDEVIS>10/02/202200:00:00</EXP_DATEDERNIERDEVIS>
            <EXP_DATEDERNIERECOMMANDE/>
            <EXP_DATEDERNIEREFACTURE>31/03/202200:00:00</EXP_DATEDERNIEREFACTURE>
            <EXP_EMAILVENDEUR>madydmk@gmail.com</EXP_EMAILVENDEUR>
            <EXP_IBAN_FORMAT>FR7603469121851568794001572</EXP_IBAN_FORMAT>
            <EXP_IDYLISCOMPTEURLIGNE>1</EXP_IDYLISCOMPTEURLIGNE>
            <EXP_MONTANTDUCLIENT>33297,5000</EXP_MONTANTDUCLIENT>
            <EXP_MONTANTRESTANTDU1MOIS>0,0000</EXP_MONTANTRESTANTDU1MOIS>
            <EXP_MONTANTRESTANTDU2MOIS>0,0000</EXP_MONTANTRESTANTDU2MOIS>
            <EXP_MONTANTRESTANTDU3MOIS>0,0000</EXP_MONTANTRESTANTDU3MOIS>
            <EXP_MONTANTRESTANTDU4MOIS>0,0000</EXP_MONTANTRESTANTDU4MOIS>
            <EXP_MONTANTRESTANTDU5MOIS>0,0000</EXP_MONTANTRESTANTDU5MOIS>
            <EXP_MONTANTRESTANTDUPLUS5MOIS>33297,5000</EXP_MONTANTRESTANTDUPLUS5MOIS>
            <EXP_MONTANTRESTANTDUTOTALMOIS>33297,5000</EXP_MONTANTRESTANTDUTOTALMOIS>
            <EXP_MONTANTRESTANTDUTOTALSANSAVOIRSMOIS>33297,5000</EXP_MONTANTRESTANTDUTOTALSANSAVOIRSMOIS>
            <EXP_NOMPRENOMVENDEUR>VaubonAdèle</EXP_NOMPRENOMVENDEUR>
            <EXP_NOMVENDEUR>Vaubon</EXP_NOMVENDEUR>
            <EXP_PRENOMVENDEUR>Adèle</EXP_PRENOMVENDEUR>
            <EXP_SITE/>
            <EXP_STATUT><CENTER><I CLASS = ""FA FA-CHECK FA - LG FA - FW"" ARIA-HIDDEN= ""TRUE_"" STYLE= ""COLOR:#008000""></I><FONT SIZE=""8PX"" FACE=""ARIAL"" STYLE= ""DISPLAY:NONE"">RIEN À SIGNALER</FONT></CENTER></EXP_STATUT>
            <EXP_STATUTCRM>RIEN À SIGNALER</EXP_STATUTCRM>
            <EXP_TOTALMONTANTRESTANT>33297,5000</EXP_TOTALMONTANTRESTANT>
            <EXP_TOTALMONTANTRESTANTRELANCE>33297,5000</EXP_TOTALMONTANTRESTANTRELANCE>
            <EXP_TYPE_NONSOUMISTVA>SOUMIS À TVA EN FRANCE MÉTROPOLITAINE</EXP_TYPE_NONSOUMISTVA>
            <COMP_ANCIENNETÉ>6 ans ou +</COMP_ANCIENNETÉ>
            <COMP_NOMBREDEMPLOYÉS>10</COMP_NOMBREDEMPLOYÉS>
            </FICHE>
            </FB_CLIENTS>";

            if (RefClient != null && RefClient != "")
            {
                ClientXML = ClientXML.Replace("[REFCLIENT]", RefClient);
            }
            if (CodeClient != null && CodeClient != "")
            {
                ClientXML = ClientXML.Replace("[CODECLIENT]", CodeClient);
            }
            if (Nom != null && Nom != "")
            {            
                ClientXML = ClientXML.Replace("[NOM]", Nom);
            }
            if (Adresse1 != null && Adresse1 != "")
            {
                ClientXML = ClientXML.Replace("[ADRESSE1]", Adresse1);
            }
            if (Adresse2 != null && Adresse2 != "")
            {
                ClientXML = ClientXML.Replace("[ADRESSE2]", Adresse2);   
            }
            if (Ville != null && Ville != "")
            {   
                ClientXML = ClientXML.Replace("[VILLE]", Ville);
            }
            if (CP != null && CP != "")
            {   
                ClientXML = ClientXML.Replace("[CP]", CP);
            }
            if (Pays != null && Pays != "")
            {
                ClientXML = ClientXML.Replace("[PAYS]", Pays);
            }
            if (tel != null && tel != "")
            {
                ClientXML = ClientXML.Replace("[TEL]", tel);
            }
            if (Web != null && Web != "")
            {
                ClientXML = ClientXML.Replace("[WEB]", Web);
            }
            if (Email != null && Email != "")
            {
                ClientXML = ClientXML.Replace("[EMAIL]", Web);
            }
            if (CompteComptable != null && CompteComptable != "")
            {
                ClientXML = ClientXML.Replace("[COMPTECOMPTABLE]", Web);
            }
                

            API.setSession();
           
            string cRetour = API.idev.InsererTable(ClientXML);
            return cRetour;
        }

        // Supprimer un client
        [HttpPut]
        [Route("api/Client/Delete")]
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


        [HttpGet]
        [Route("api/ContactDuClient/{CodeClient}")]
        public string GetContact(string CodeClient)
        {
            Contact contact = new Contact { };
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            try
            {
                API.setSession();
            }
            catch
            {
                return "Session Invalide";
            }
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


 
    }
}
