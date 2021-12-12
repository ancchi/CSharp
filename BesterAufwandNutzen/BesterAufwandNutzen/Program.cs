using System;
using System.Data;
using System.IO;
using System.Net;
using System.Text;

namespace BesterAufwandNutzen {
    class Program {
        static void Main(string[] args) {
            double distance;
            bool isCarPresent;
            bool isBahncardPresent;
            bool areFlightMilesPresent;
            double packageWeight;

            Console.OutputEncoding = Encoding.UTF8; // damit das Euro-Zeichen auf der Konsole ausgegeben wird

            Console.WriteLine("Bitte geben sie die Entfernung zu Ihrem Ziel ein:");
            distance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ist ein Auto vorhanden? Ja/Nein");
            isCarPresent = Convert.ToBoolean(Console.ReadLine().ToLower().Equals("ja") ? true : false );
            Console.WriteLine("Ist eine Bahncard 100 vorhanden? Ja/Nein");
            isBahncardPresent = Convert.ToBoolean(Console.ReadLine().ToLower().Equals("ja") ? true : false);
            Console.WriteLine("Sind so viele Flugmeilen vorhanden, dass sie die Kosten decken? Ja/Nein");
            areFlightMilesPresent = Convert.ToBoolean(Console.ReadLine().ToLower().Equals("ja") ? true : false);
            Console.WriteLine("Wie schwer ist voraussichtlich Ihr Gepäck?");
            packageWeight = Convert.ToDouble(Console.ReadLine());


            /* string origin = "Oberoi Mall, Goregaon";
             string destination = "Infinity IT Park, Malad East";
             string duration = string.Empty;
             string distance = string.Empty;
             string url = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin + "&destinations=" + destination + "&key=AIzaSyBE1J5Pe_GZXBR_x9TXOv6TU5vtCSmEPW4";
             WebRequest request = WebRequest.Create(url);
             using (WebResponse response = (HttpWebResponse)request.GetResponse()) {
                 using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) {
                     DataSet dsResult = new DataSet();
                     dsResult.ReadXml(reader);
                     duration = dsResult.Tables["duration"].Rows[0]["text"].ToString();
                     distance = dsResult.Tables["distance"].Rows[0]["text"].ToString();
                 }
             }
             Console.WriteLine("Die Distanz zwischen {0} und {1} beträgt: {2}, die Dauer beträgt {3}.",
                 origin, destination, distance, duration);*/

            // TODO Gepäckgewicht und Zeitrahmen berücksichtigen

            Auto auto = new Auto( Jahreszeit.Spring, packageWeight, 130, distance, -1, isCarPresent, 20.0m, 10.0m);
            auto.CalculateBestWay(true, true, true);
            Console.WriteLine("__________________________________________________________");

            ZuFuss zuFuss = new ZuFuss(Jahreszeit.Spring, 500, 10, 400, -1);
            zuFuss.CalculateBestWay(true, true, true);
            Console.WriteLine("__________________________________________________________");

            Zug bahnCardVorhanden = new Zug((Jahreszeit)1, 500, 200, 400, -1, true, 130);
            bahnCardVorhanden.CalculateBestWay(true, true, true);
            Zug keineBahncard = new Zug((Jahreszeit)1, 500, 200, 400, -1, false, 130);
            keineBahncard.CalculateBestWay(true, true, true);
            Console.WriteLine("__________________________________________________________");

            Flugzeug mitFlugMeilen = new Flugzeug((Jahreszeit)1, 500, 800, 400, -1, true, 60);
            mitFlugMeilen.CalculateBestWay(true, true, true);
            Flugzeug ohneFlugMeilen = new Flugzeug((Jahreszeit)1, 500, 800, 400, -1, false, 60);
            ohneFlugMeilen.CalculateBestWay(true, true, true);
        }
    }
}
