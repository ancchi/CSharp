using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BesterAufwandNutzen {
    public class ZuFuss : Fortbewegung {

        public ZuFuss(Jahreszeit season,
            double packageWeight, double speed, double distance, double availableTime)
            : base(season,
             packageWeight, speed, distance, availableTime) {
        }

        public override void CalculateBestWay(bool costAspect, bool footPrintAspect, bool timeAspect) {
            Console.WriteLine("____________________________________");
            Console.WriteLine("###### Kosten für einen Gang zu Fuß: ######");
            base.CalculateBestWay(costAspect, footPrintAspect, timeAspect);
        }

        protected override double CalculateFootPrintAspect() {
            return 0;
        }

        protected override double CalculateTimeAspect() {
            var duration = base.CalculateTimeAspect();
            // alle 3 Stunden 15 Minuten Pause
            duration += (PureJourneyDuration / 3) * 0.15;
            if (PureJourneyDuration > 5)
                duration += 0.75; // Mittagspause
            return duration;
        }
    }
}
