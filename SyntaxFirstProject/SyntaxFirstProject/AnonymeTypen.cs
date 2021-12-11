using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Anonyme Typen:
 * - werden mit "var" deklariert und mit "new { ... } initialisiert
 * - können nur Properties (keine Felder oder Methoden enthalten)
 * - die Eigenschaften (Properties) eines anonymen Typs sind schreibgeschützt - sobald das Objekt
 *   initialisiert wurde, können die Eigenschaften nicht mehr geändert oder erweitert werden
 *   Verwendung:
 *   - zur Vereinfachung bereits bestehender Objekte, wenn das Ergebnis nicht alle Eigenschaften des
 *   Ursprungsobjektes enthalten muss oder soll
 */
namespace SyntaxFirstProject {
    class AnonymeTypen {

        private List<MyGame> myGames = new();
        
        public AnonymeTypen() {
            myGames.Add(new MyGame { NameOfGame = "Skyrim", DownloadSize = 60.7, GameCategory = "RPG", Installed = true});
            myGames.Add(new MyGame { NameOfGame = "Da Vinci Code", DownloadSize = 4.6, GameCategory = "Puzzle", Installed = true });
            myGames.Add(new MyGame { NameOfGame = "Portals", DownloadSize = 47.8, GameCategory = "Puzzle, Adventure", Installed = false });
            myGames.Add(new MyGame { NameOfGame = "Flatout3", DownloadSize = 7.1, GameCategory = "Race", Installed = true });

        }

        public void Run() {

            // anonymer Typ:

            var myAnonymousType = new { First = 1, Second = 2 };
            Console.WriteLine("First: " + myAnonymousType.First);


            Console.WriteLine("___________________________________");

            // Anwendung in Select

            var gamesData1 = myGames.Where(g => g.Installed == true)
                .Select(g => new { g.NameOfGame, g.GameCategory });

            /*Console.WriteLine("Installierte Spiele:\n");
            foreach (var game in games) {
                Console.WriteLine("{0}\nKategorie: {1}\n", game.NameOfGame, game.GameCategory);
            }*/

            // anonyme Typen an eine Methode übergeben - sie wird als Dynamic weiterverarbeitet

            ShowInstalledGames1(gamesData1);


            // Anwendung in Select mit Namen:
            var gamesData2 = myGames.Where(g => g.Installed == true)
                .Select(g => new { Name = g.NameOfGame, Category = g.GameCategory });

            ShowInstalledGames2(gamesData2);
        }

        /*
         * zu beachten:
         * 1. Liste muss als "IEnumerable" mit Generic-Typ "dynamic" deklariert werden
         * 2. Die Elemente der Liste (also des IEnumerable) müssen in der foreach-Schleife als dynamic
         *    deklariert werden
         */

        // hier werden die Eigenschaften-Namen des ursprünglichen Objektes verwendet, weil das anonyme
        // Objekt keine eigenen Namen hat
        private void ShowInstalledGames1(IEnumerable<dynamic> gamesData) {

            Console.WriteLine("Installierte Spiele:\n");
            foreach (dynamic game in gamesData) {
                Console.WriteLine("{0}\nKategorie: {1}\n", game.NameOfGame, game.GameCategory);
            }

        }

        // hier werden die neuen Eigenschaften-Namen verwendet, die bei der Initialisierung des
        // anonymen Objektes vergeben wurden
        private void ShowInstalledGames2(IEnumerable<dynamic> gamesData) {

            Console.WriteLine("Installierte Spiele:\n");
            foreach (dynamic game in gamesData) {
                Console.WriteLine("{0}\nKategorie: {1}\n", game.Name, game.Category);
            }

        }

    }





    class MyGame { 

        public string NameOfGame { get; set; }
        public double DownloadSize { get; set; }
        public string GameCategory { get; set; }
        public bool Installed { get; set; }


    }
}
