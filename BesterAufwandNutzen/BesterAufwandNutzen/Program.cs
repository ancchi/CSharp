using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;

namespace BesterAufwandNutzen {
    class Program {
        static void Main(string[] args) {

            Dictionary<string, double> durations = new Dictionary<string, double>();
            Dictionary<string, decimal> costs = new Dictionary<string, decimal>();
            Dictionary<string, double> footPrints = new Dictionary<string, double>();

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
            durations.Add("Auto", auto.Duration);
            costs.Add("Auto", auto.TotalCosts);
            footPrints.Add("Auto", auto.FootPrint);
            Console.WriteLine("__________________________________________________________");

            ZuFuss zuFuss = new ZuFuss(Jahreszeit.Spring, packageWeight, 10, distance, -1);
            zuFuss.CalculateBestWay(true, true, true);
            durations.Add("ZuFuss", zuFuss.Duration);
            costs.Add("ZuFuss", zuFuss.TotalCosts);
            footPrints.Add("ZuFuss", zuFuss.FootPrint);
            Console.WriteLine("__________________________________________________________");

            Zug zug = new Zug((Jahreszeit)1, packageWeight, 200, distance, -1, isBahncardPresent, 130);
            zug.CalculateBestWay(true, true, true);
            durations.Add("Zug", zug.Duration);
            costs.Add("Zug", zug.TotalCosts);
            footPrints.Add("Zug", zug.FootPrint);
            Console.WriteLine("__________________________________________________________");

            Flugzeug flugzeug = new Flugzeug((Jahreszeit)1, packageWeight, 800, distance, -1, areFlightMilesPresent, 60);
            flugzeug.CalculateBestWay(true, true, true);
            durations.Add("Flugzeug", flugzeug.Duration);
            costs.Add("Flugzeug", flugzeug.TotalCosts);
            footPrints.Add("Flugzeug", flugzeug.FootPrint);
            Console.WriteLine("===========================================================");

            string fastestWay = durations.Where(d => d.Value == durations.Min(d => d.Value)).Select(d => d.Key).First().ToString();
            var cheapestWay = costs.Where(c => c.Value == costs.Min(c => c.Value)).Select(c => c.Key).First().ToString();
            var healthiestWay = footPrints.Where(f => f.Value == footPrints.Min(f => f.Value)).Select(f => f.Key).First().ToString();

            Console.WriteLine("Am schnellsten: " + fastestWay);
            Console.WriteLine("Am günstigten: " + cheapestWay);
            Console.WriteLine("Am besten für die Umwelt: " + healthiestWay);
            if (packageWeight > 20)
                Console.WriteLine("Aufgrund der Schwere des Gepäcks empfehlen wir Ihnen, nicht zu Fuß zu gehen.");
        }

        
    }
}
