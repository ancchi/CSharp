using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 Lokake Typableitung/Typinferenz / Local Type Inference
 Inferenz = Schlussfolgerung

 */

namespace SyntaxFirstProject {
    class LokaleTypableitung {

        /* - Variablen erhalten mit der Typableitung einen festen Datentyp, der im Nachhinein nicht mehr
             gerändert werden kann 
            - der Typ wird automatisch ermittelt, aber die implizit typisierten Variablen müssen immer
                sofort initialisiert werden -> dadurch wird Typsicherheit garantiert
            - die Typableitung heisst "lokal", weil sie nur lokal innerhalb von Methoden möglich ist
            - ein Einsatz als Klassenattribut, Parameter oder Rückgabewert ist nicht möglich
        --> siehe Dynamics

        Notwendigkeit von Typableitungen:
        - bei LINQ-Projektionen und anonymen Typen -> in beiden Fällen entstehen Klassen, deren Namen ein 
          Entwickler nicht kennen kann -> Dynamics
        - es besteht ein Unterschied zur Deklaration eines Typs mit System.Object, da sich der Typ von einem
          mit System.Object deklarierten Objekts tatsächlich während der Laufzeit ändern kann, während der Typ
          durch die Typableitung im weiteren Pogrammverlauf feststeht
        - kürzere Schreibweise (z.B. var mitglied = new VorstandsMitglied(), anstatt VorstandsMitglied mitglied = new VorstandsMitglied()
          -> die neue Schreibweise hat keinerlei Nachteile
        */

        
        // var k = "test"; kompiliert nicht
        
        public void Run() {

            int a;
            var b = 4; // direkte Initialisierung notwendig, Typermittlung wird festgelegt -> Typsicherheit gegeben
            a = 2;
            var c = b + a; // c erhält implizit den Datentyp int
            //c = "Haus"; // -> Typänderung nicht möglich
            var d = "Hausnummer";
            //var e = null; // nicht erlaubt
            //var f = default; // nicht erlaubt
            

            Console.WriteLine("c: " + c.GetType().FullName);
            Console.WriteLine("d: " + d.GetType().FullName);

            for (var i = 0; i < 5; i++) { // var ist bei Laufvariablen erlaubt
                Console.WriteLine(i);
            }

        }
    }
}
