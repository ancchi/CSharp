using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BesterAufwandNutzen {
    public class Auto : Fortbewegung {

        bool isCarPresent;
        decimal carLendingPrize; // per hour
        decimal fuelOrReloadCosts; // per 100 km

        public Auto(Jahreszeit season,
            double packageWeight, double speed, double distance, double availableTime,
            bool isCarPresent, decimal carLendingPrize, decimal fuelOrReloadCosts) 
            : base(season, packageWeight, speed, distance, availableTime) {
            this.isCarPresent = isCarPresent;
            this.carLendingPrize = carLendingPrize;
            this.fuelOrReloadCosts = fuelOrReloadCosts;
        }

        public override void CalculateBestWay(bool costAspect, bool footPrintAspect, bool timeAspect) {
            Console.WriteLine("____________________________________");
            Console.WriteLine("###### Kosten für eine Fahrt mit dem Auto: ######");
            base.CalculateBestWay(costAspect, footPrintAspect, timeAspect);
        }

        protected override decimal CalculateCostAspect() {
            decimal totalCosts;
            totalCosts = base.CalculateCostAspect();
            Console.Write("Gesamtkosten");
            if (!isCarPresent) {
                totalCosts += (Convert.ToDecimal(PureJourneyDuration) * carLendingPrize) +
                    (Convert.ToDecimal(Distance / 100) * fuelOrReloadCosts);
                Console.WriteLine(" mit Leihkosten.");
            } else {
                totalCosts += Convert.ToDecimal(Distance / 100) * fuelOrReloadCosts;
                Console.WriteLine(" ohne Leihkosten.");
            }
            return totalCosts;
        }

        protected override double CalculateFootPrintAspect() {
            FootPrint = Math.Round(Distance * 0.23, 2);
            return FootPrint;
        }

        protected override double CalculateTimeAspect() {
            var duration = base.CalculateTimeAspect();
            duration += (PureJourneyDuration / 2) * 0.10; // Alle 2 Stunden 10 Minuten Pause
            if (PureJourneyDuration > 5)
                duration += 0.75; // Mittagspause
            return duration;
        }
    }
}
