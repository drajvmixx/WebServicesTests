
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using System;
using System.Collections.Generic;

namespace API_Tests_by_IrynaShelevii
{
    public class SoapWeb
    {
        public HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso");
            request.ContentType = "text/xml; charset=utf-8";
            request.Method = "POST";
            return request;
        }

        public List<string> InvokeSoapService()
        {
            var request = CreateWebRequest();
            XmlDocument body = new XmlDocument();

            var bodyXml = @"<?xml version = ""1.0"" encoding = ""utf-8"" ?>"+
            @"<soap:Envelope xmlns:soap = ""http://schemas.xmlsoap.org/soap/envelope/"" >"+
            @"<soap:Body>" +
            @" <ListOfLanguagesByName xmlns = ""http://www.oorsprong.org/websamples.countryinfo"" >"+
            @"</ListOfLanguagesByName>"+
            @" </soap:Body>"+
            @"</soap:Envelope>";
            body.LoadXml(bodyXml);
            using (Stream stream = request.GetRequestStream())
            {
                body.Save(stream);
            }
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    var serviceResult = rd.ReadToEnd();
                    var doc = System.Xml.Linq.XDocument.Parse(serviceResult);
                    XNamespace ns = "http://www.oorsprong.org/websamples.countryinfo";
                    var result = doc.Root.Descendants(ns + "ListOfLanguagesByNameResponse")
                        .Descendants(ns + "ListOfLanguagesByNameResult")
                        .Elements(ns + "tLanguage")
                        .Select(lang => lang.Element(ns + "sName").Value)
                        .ToList();
                    return result;
                }
            }
        }
    }
}
