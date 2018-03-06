using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Channels;

namespace PocztaPolskaTrackerSoapClient.Models
{
    public class TrackerModel
    {
        public PocztaPolskaService.Przesylka track(String number)
        {
            CustomBinding customBinding = new CustomBinding();
            SecurityBindingElement security = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
            security.IncludeTimestamp = false;
            customBinding.Elements.Add(security);
            TextMessageEncodingBindingElement encoding = new TextMessageEncodingBindingElement();
            encoding.MessageVersion = MessageVersion.Soap11;
            customBinding.Elements.Add(encoding);
            HttpsTransportBindingElement httpsTransportBindingElement = new HttpsTransportBindingElement();
            httpsTransportBindingElement.RequireClientCertificate = false;
            httpsTransportBindingElement.UseDefaultWebProxy = false;
            customBinding.Elements.Add(httpsTransportBindingElement);

            System.ServiceModel.EndpointAddress endpointAddress = new System.ServiceModel.EndpointAddress(@"https://tt.poczta-polska.pl/Sledzenie/services/Sledzenie.SledzenieHttpSoap11Endpoint/");

            PocztaPolskaService.SledzeniePortTypeClient client = new PocztaPolskaService.SledzeniePortTypeClient(customBinding, endpointAddress);
            client.ClientCredentials.UserName.UserName = "sledzeniepp";
            client.ClientCredentials.UserName.Password = "PPSA";

            PocztaPolskaService.Przesylka przesylka = client.sprawdzPrzesylke(number);
            return przesylka;
        }
    }
}