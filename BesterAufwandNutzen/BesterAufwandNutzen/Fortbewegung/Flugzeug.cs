using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BesterAufwandNutzen {
    public class Flugzeug : Fortbewegung {

        bool flightMiles;
        decimal flightTicketPrice;

        public Flugzeug(Jahreszeit season,
            double packageWeight, double speed, double distance, double availableTime,
            bool flightMiles, decimal flightTicketPrice)
            : base(season,
             packageWeight, speed, distance, availableTime) {
            this.flightMiles = flightMiles;
            this.flightTicketPrice = flightTicketPrice;
        }

        public override void CalculateBestWay(bool costAspect, bool footPrintAspect, bool timeAspect) {
            Console.WriteLine("____________________________________");
            Console.WriteLine("###### Kosten für einen Flug: ######");
            base.CalculateBestWay(costAspect, footPrintAspect, timeAspect);
            
        }

        protected override decimal CalculateCostAspect() {
            decimal totalCosts;
            totalCosts = base.CalculateCostAspect();
            Console.Write("Gesamtkosten");
            if (!flightMiles) {
                totalCosts += flightTicketPrice;
                Console.WriteLine(" ohne Flugmeilen: ");
            } else {
                Console.WriteLine(" mit Flugmeilen: ");
            }
            return totalCosts;
        }

        protected override double CalculateFootPrintAspect() {
            FootPrint = Math.Round(Distance / 2.7, 2);
            return FootPrint;
        }

    }
}
