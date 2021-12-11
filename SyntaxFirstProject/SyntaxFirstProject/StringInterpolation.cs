using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxFirstProject {
    class StringInterpolation {
        public void Run() {

            /*
             * String-Interpolation Entwicklung 
             */

            int id = 123;
            DateTime datum = DateTime.Now;
            Console.WriteLine("Kunde #" + String.Format("{0:0000}", id) + // Stellenanzahl -> 0123
                ":\nDatum: " + String.Format("{0:d}", datum)); // Datum -> dd.MM.yyyyy
            Console.WriteLine();
            // einfacher/kompakter:
            Console.WriteLine(String.Format("Kunde #{0:0000}:\nDatum: {1:d}", id, datum));
            Console.WriteLine();
            // einfacher/kompatker:
            Console.WriteLine("Kunde #{0:0000}:\nDatum: {1:d}", id, datum);
            Console.WriteLine();
            // am einfachsten:
            Console.WriteLine($"Kunde #{id:0000}:\nDatum: {datum:d}");

            // Kombination mit dem verbatim String ("wortgetreuer String")
            Console.WriteLine($@"{id:0000}: {datum:d}: \\server\User{id}"); // -> 0123: 24.05.2021: \\server\User123
        }
    }
}
