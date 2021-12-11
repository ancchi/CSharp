using System;

namespace SyntaxFirstProject {
    class Program {

        // unter C:\Users\Genius\GithubRepos\CSharp\SyntaxFirstProject\SyntaxFirstProject\bin\Debug\net5.0
        // ausführen und optional einen Parameter mitgeben
        static void Main(string[] args) {

            // Initialisierung mit default anstatt eines Wertes:
            /*int myInt = default; // Initialisierung mit 'default', das ist '0' für alle Zahlen
            Console.WriteLine(myInt); // -> 0*/

            /*StringInterpolation stringInterpolation = new StringInterpolation();
                stringInterpolation.Run();*/

            /*ZahlenUndDatumsLiterale zahlenUndDatumsLiterale = new ZahlenUndDatumsLiterale();
            zahlenUndDatumsLiterale.Run();*/

            /*LokaleTypableitung typableitung = new LokaleTypableitung();
            typableitung.Run();*/

            AnonymeTypen anonymeTypen = new AnonymeTypen();
            anonymeTypen.Run();


        }
    }
}
