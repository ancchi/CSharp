using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxFirstProject {
    class ZahlenUndDatumsLiterale {

        public void Run() {

            // binär:
            int antwortAufDieFrageAllerFragen = 0b_0010_1010; // Unterstriche als Trennzeichen seit C#7.0 -> 42
            Console.WriteLine(antwortAufDieFrageAllerFragen);

            // Datumsliterale:
            DateTime d1 = new DateTime(1980, 02, 23); // -> 23.02.1980 00:00:00
            Console.WriteLine(d1);

            DateTime d2 = new DateTime(1979, 01, 03, 07, 30, 12); // 03.01.1979 07:30:12
            Console.WriteLine(d2);
        }
    }
}
