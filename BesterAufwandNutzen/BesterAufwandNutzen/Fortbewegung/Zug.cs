using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BesterAufwandNutzen {
    public class Zug : Fortbewegung {

        bool isTrainCardPresent;
        decimal trainTicketPrize;

        public Zug(Jahreszeit season,
            double packageWeight, double speed, double distance, double availableTime,
            bool isTrainCardPresent, decimal trainTicketPrize)
            : base(season, packageWeight, speed, distance, availableTime) {
            this.trainTicketPrize = trainTicketPrize;
            this.isTrainCardPresent = isTrainCardPresent;
        }

        public override void CalculateBestWay(bool costAspect, bool footPrintAspect, bool timeAspect) {
            Console.WriteLine("____________________________________");
            Console.WriteLine("###### Kosten für eine Zugfahrt: ######");
            base.CalculateBestWay(costAspect, footPrintAspect, timeAspect);
        }

        protected override decimal CalculateCostAspect() {
            decimal totalCosts;
            totalCosts = base.CalculateCostAspect();
            Console.Write("Gesamtkosten mit Bahn");
            if (!isTrainCardPresent) {
                totalCosts += trainTicketPrize;
                Console.WriteLine(" ohne Hunderter-Bahncard.");
            } else {
                Console.WriteLine(" mit Hunderter-Bahncard.");
            }
            return totalCosts;
        }

        protected override double CalculateFootPrintAspect() {
            FootPrint = Math.Round(Distance * 0.03 , 2);
            return FootPrint;
        }

        protected override double CalculateTimeAspect() {
            var duration = base.CalculateTimeAspect();
            return duration;
        }
    }
}
