using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BesterAufwandNutzen {
    public class Fortbewegung {
        Jahreszeit season;
        double packageWeight;
        double speed;
        double availableTime;

        // calculated
        decimal foodCosts = 5.50m; // soundso viele Kosten pro Stunde im Durchschnitt
        decimal lodgingCosts = 100; // soundso viele Kosten pro Tag


        public double Distance;
        public double PureJourneyDuration { get; set; }
        // Output:
        public double FootPrint { get; set; }
        public double Duration { get; set; } // in hours
        public decimal TotalCosts { get; set; }

        public Fortbewegung(Jahreszeit season,
            double packageWeight, double speed, double distance, double availableTime) {
            this.season = season;
            this.packageWeight = packageWeight;
            this.speed = speed;
            Distance = distance;
            this.availableTime = availableTime;
        }

        public virtual void CalculateBestWay(bool costAspect, bool footPrintAspect, bool timeAspect) {
            if (costAspect) {
                TotalCosts = this.CalculateCostAspect();
                Console.WriteLine("Gesamtkosten: {0} €", decimal.Round(TotalCosts, 2));
            }
            if (footPrintAspect) {
                FootPrint = this.CalculateFootPrintAspect();
                Console.WriteLine("Fußabdruck: {0} kg CO2.", FootPrint);
            }
            if (timeAspect) {
                Duration = this.CalculateTimeAspect();
                Console.WriteLine("Dauer: {0} Stunden.", Math.Round(Duration, 2));
            }    
        }

        protected virtual decimal CalculateCostAspect() {
            PureJourneyDuration = Distance / speed;
            var food = Convert.ToDecimal(PureJourneyDuration) * foodCosts;
            return Duration > 12 ? food + (Convert.ToDecimal(PureJourneyDuration) / 24 * lodgingCosts) : food;
        }

        protected virtual double CalculateFootPrintAspect() {
            return FootPrint;
        }

        protected virtual double CalculateTimeAspect() {
            Duration = Distance / speed;
            return Duration;
        }

    }
}
