using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Xml.Schema;
using static System.Net.WebRequestMethods;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Alle Varianten. Zum Spielen einer Variante das "//" vor der Variante entfernen!

            //Variante1(200); // Geheimzahl ist in der Klammer zu definieren
            //Variante2(200);
            //Variante3(200);
            //Variante4(200);
            //Variante5(); // Ab hier kann man die Geheimzahl nicht mehr definieren, weil jetzt die Zahl per Zufall generiert wird
            //Variante6();
            //Variante7();
            //Variante8();
            //Variante9();

            Zusatzaufgabe1();
            //Zusatzaufgabe2();

            // Damit das Konsolenfenster nach dem Spiel noch offen bleibt.
            Console.WriteLine("\n\n\nZum Beenden des Programms eine beliebige Taste drücken");
            Console.ReadKey();
        }

        // Funktion, um Zahlen vom Benutzer zu bekommen
        static int GetNumber(string text)
        {
            // Für die Funktion Wichtige Variabeln
            int NutzerZahl; // Variabel, die die Eingabe des nutzers Speichert
            bool nummerTest; // Variabel um zu testen, ob die Eingabe eine Zahl ist

            // Frage ab nach Zahlen
            Console.WriteLine(text);

            // Überprüft, ob die Eingabe wirklich Zahl im Int32 Bereich ist. 
            // Wichtig, damit der Nutzer nicht das Programm durch fettfingern crasht
            // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/how-to-determine-whether-a-string-represents-a-numeric-value


            nummerTest = int.TryParse(Console.ReadLine(), out NutzerZahl); // ist die Eingabe eine Zahl?
            while (nummerTest == false) // Solange die Eingabe keine Zahl ist, soll der Nutzer erneut aufgefordert werden, 
                                        // eine Zahl einzugeben
            {
                Console.WriteLine("Deine Eingabe muss eine Zahl im Int32 Bereich sein.");
                Console.WriteLine(text);
                nummerTest = int.TryParse(Console.ReadLine(), out NutzerZahl);
            }
            // Wurde dann endlich eine Zahl eingegeben, Spuckt die Funktion diese aus.
            return NutzerZahl;
        }
        
        static void Variante1(int Geheimzahl) // Somit kann man von oben direkt in der Funktion die Geheimzahl definieren     
        {
            // Variante 1:
            // Für die erste Variante müssen Sie sich eine Geheimzahl ausdenken.
            // Der Benutzer soll nun eine Zahl eingeben und 
            // bekommt von ihrem Programm gesagt „Die Zahl ist richtig“ oder die Zahl ist falsch

            // Definiere Variabeln
            int GeheimzahlInput;

            GeheimzahlInput = GetNumber("Bitte die Geheimzahl eingeben.");
            if (GeheimzahlInput == Geheimzahl)
            {
                Console.WriteLine("Die Zahl ist richtig.");
            }
            else
            {
                Console.WriteLine("Die Zahl ist falsch. \n" +
                    "Die richtige Zahl wäre " + Geheimzahl + " gewesen.");
            }
        }

        static void Variante2(int Geheimzahl)
        {
            // Variante 2:
            // Nun erweitern Sie ihre Ausgabe um die Bemerkung
            // „Die eingegebene Zahl ist zu groß“ oder „Die eingegebene Zahl ist
            // zu klein“ oder „Die eingegebene Zahl ist richtig“

            int GeheimzahlInput;

            GeheimzahlInput = GetNumber("Bitte die Geheimzahl eingeben.");

            // als Erstes wird überprüft, ob die Zahl der Geheimzahl entspricht
            if (GeheimzahlInput == Geheimzahl)
            {
                Console.WriteLine("Die Zahl ist richtig.");
            }

            // dann, ob sie zu Klein ist
            else if (GeheimzahlInput < Geheimzahl) 
            {
                Console.WriteLine("Die Zahl ist zu klein. \n" +
                    "Die richtige Zahl wäre " + Geheimzahl + " gewesen.");
            }

            // und wenn sie weder zu Klein, noch gleich ist, kann sie nur noch zu groß sein.
            // Deswegen reicht hier ein else Statement
            else
            {
                Console.WriteLine("Die Zahl ist zu groß. \n" +
                    "Die richtige Zahl wäre " + Geheimzahl + " gewesen.");
            }

        }

        static void Variante3(int Geheimzahl)
        {
            // Variante 3:
            // Für die nächste Variante erweitern Sie das Programm um eine Schleife,
            // und geben so lange neue Zahlenversuche ein, bis die Zahl gefunden wurde.

            int GeheimzahlInput;

            while (true) // Der while loop ist dafür da, dass der Nutzer die Zahl so lange eingibt,
                         // bis die richtige erraten wurde
            {
                GeheimzahlInput = GetNumber("Bitte die Geheimzahl eingeben.");

                // als Erstes wird überprüft, ob die Zahl der Geheimzahl entspricht
                if (GeheimzahlInput == Geheimzahl)
                {
                    Console.WriteLine("Die Zahl ist richtig.");
                    break; // wenn die Geheimzahl richtig ist, wird nicht mehr aufgefordert, die Geheimzahl einzugeben.
                }

                // dann, ob sie zu Klein ist
                else if (GeheimzahlInput < Geheimzahl)
                {
                    Console.WriteLine("Die Zahl ist zu klein. \n");
                }

                // und wenn sie weder zu Klein, noch gleich ist, kann sie nur noch zu groß sein.
                // Deswegen reicht hier ein else Statement
                else
                {
                    Console.WriteLine("Die Zahl ist zu groß. \n");
                }
            }

        }

        static void Variante4(int Geheimzahl)
        {
            // Variante 4: 
            //Für die nächste Variante erweitern Sie das Programm so,
            //dass Sie nachher dem Benutzer angeben können, wie viele Versuche er gebraucht hat. 

            int GeheimzahlInput, AnzahlVersuche;

            AnzahlVersuche = 0; // Anzahl der Versuche, die der Nutzer gebraucht hat.
            while (true) // Der while loop ist dafür da, dass der Nutzer die Zahl so lange eingibt,
                         // bis die richtige erraten wurde
            {
                AnzahlVersuche++; // Erhöht die Anzahl der Versuche um 1
                GeheimzahlInput = GetNumber("Bitte die Geheimzahl eingeben.");

                // als Erstes wird überprüft, ob die Zahl der Geheimzahl entspricht
                if (GeheimzahlInput == Geheimzahl)
                {
                    Console.WriteLine("Die Zahl ist richtig. \n" +
                        "Du hast " + AnzahlVersuche + " Versuch(e) gebraucht.");
                    break; // wenn die Geheimzahl richtig ist, wird nicht mehr aufgefordert, die Geheimzahl einzugeben.
                }

                // dann, ob sie zu Klein ist
                else if (GeheimzahlInput < Geheimzahl)
                {
                    Console.WriteLine("Die Zahl ist zu klein. \n");
                }

                // und wenn sie weder zu Klein, noch gleich ist, kann sie nur noch zu groß sein.
                // Deswegen reicht hier ein else Statement
                else
                {
                    Console.WriteLine("Die Zahl ist zu groß. \n");
                }
            }
        }

        static void Variante5()
        {
            // Variante 5:
            // Nun kommt der Zufall ins Spiel. Dies ist ein sehr großer Schritt, gerade jetzt, zu Beginn ihrer Programmierer-Laufbahn.
            // Aber es erhöht deutlich den Reiz dieses Programms wenn man eben selber auch nicht weiß welche Zahl geraten werden
            // muss.Zunächst benötigt man ein neues Element, welches eine solche Zufallszahl erzeugt. Wie eine solche Funktion in 
            // C# heißt und wie sie benutzt wird, kann man leicht auf 
            // https://docs.microsoft.com/de-de/dotnet/api/system.random.next?view=netframework-4.8 finden. Bauen Sie diesen 
            // Programmcode ein, und versuchen Sie die die zufällige Zahl herauszufinden.Aus welchen Zahlenbereich kommt die
            // Zufallszahl, wenn sie keine weiteren Angaben machen ? (Sie üben dabei zusätzlich zur Variante 4 den Einsatz eines
            // Zufallszahlengenerators)

            int Geheimzahl, GeheimzahlInput, AnzahlVersuche;

            // Funktion, um eine Zufallszahl zu generieren
            Random rnd = new Random();
            Geheimzahl = rnd.Next();
            Console.WriteLine(Geheimzahl);


            AnzahlVersuche = 0;
            while (true) // Der while loop ist dafür da, dass der Nutzer die Zahl so lange eingibt,
                         // bis die richtige erraten wurde
            {
                AnzahlVersuche++; // Erhöht die Anzahl der Versuche um 1
                GeheimzahlInput = GetNumber("Bitte die Geheimzahl eingeben.");

                // als Erstes wird überprüft, ob die Zahl der Geheimzahl entspricht
                if (GeheimzahlInput == Geheimzahl)
                {
                    Console.WriteLine("Die Zahl ist richtig. \n" +
                        "Du hast " + AnzahlVersuche + " Versuch(e) gebraucht.");
                    break; // wenn die Geheimzahl richtig ist, wird nicht mehr aufgefordert, die Geheimzahl einzugeben.
                }

                // dann, ob sie zu Klein ist
                else if (GeheimzahlInput < Geheimzahl)
                {
                    Console.WriteLine("Die Zahl ist zu klein. \n");
                }

                // und wenn sie weder zu Klein, noch gleich ist, kann sie nur noch zu groß sein.
                // Deswegen reicht hier ein else Statement
                else
                {
                    Console.WriteLine("Die Zahl ist zu groß. \n");
                }
            }
        }

        static void Variante6()
        {
            // Variante 6:
            // Was für eine Zufallszahl kann dort überhaupt bei herauskommen? Auf der obigen Internetseite steht etwas von 0 bis 
            // MaxValue – klickt man auf MaxValue erfährt man, dass dies 2147483647 sein kann. Wie kann man so eine Zahl aber
            // verändern, sodass man Zufallszahlen zwischen 1 und 100 herausbekommt, oder zwischen 1000 und 10000 ?
            // Dazu gibt es einen sogenannten Modulo Operator, das % -Zeichen.
            // Dieses % ist eine so genannte Modulo Rechnung, die Sie aus der Grundschule kennen: 
            // 7:3 = 2 Rest 1 schreibt ein Grundschüler bei einer Division hin, die nicht komplett aufgeht. Das was dort als Rest
            // herauskommt, ist genau das, was bei einer Modulo - Rechnung als Ergebnis angezeigt wird. Damit kann man die
            // Zufallszahlen von 0 bis 2147483647 auf einen beliebigen kleineren Zahlenraum abbilden. Tun Sie das und verändern
            // Ihr Programm so, dass Sie Zahlen zwischen 1 und 1000 eingeben können. Überlegen Sie dann wie sie dann auch  
            // Zahlen zwischen 100 und 200 herauskriegen können.


            int Geheimzahl, GeheimzahlInput, AnzahlVersuche, von, bis;

            von = 100;
            bis = 200;

            Random rnd = new Random();            // Funktion, um eine Zufallszahl zu generieren mit Range Modulo // Lösung: https://www.sololearn.com/Discuss/1496126/use-the-modulo-operator-to-generate-random-numbers-within-a-specific-range

            Geheimzahl = von + (rnd.Next() % (bis - von + 1)); 

            AnzahlVersuche = 0;
            while (true) // Der while loop ist dafür da, dass der Nutzer die Zahl so lange eingibt,
                         // bis die richtige erraten wurde
            {
                AnzahlVersuche++; // Erhöht die Anzahl der Versuche um 1
                GeheimzahlInput = GetNumber("Bitte die Geheimzahl eingeben.");

                // als Erstes wird überprüft, ob die Zahl der Geheimzahl entspricht
                if (GeheimzahlInput == Geheimzahl)
                {
                    Console.WriteLine("Die Zahl ist richtig. \n" +
                        "Du hast " + AnzahlVersuche + " Versuch(e) gebraucht.");
                    break; // wenn die Geheimzahl richtig ist, wird nicht mehr aufgefordert, die Geheimzahl einzugeben.
                }

                // dann, ob sie zu Klein ist
                else if (GeheimzahlInput < Geheimzahl)
                {
                    Console.WriteLine("Die Zahl ist zu klein. \n");
                }

                // und wenn sie weder zu Klein, noch gleich ist, kann sie nur noch zu groß sein.
                // Deswegen reicht hier ein else Statement
                else
                {
                    Console.WriteLine("Die Zahl ist zu groß. \n");
                }
            }
        }

        static void Variante7()
        {
            // Variante 7:
            // Natürlich ist das „old-School“ heutzutage liefert natürlich der Zufallsgenerator zielgenau die Werte die man braucht, 
            // indem man entsprechende Parameter in den Funktionsaufruf eingibt.Nutzen Sie dies um ihr Programm für die nächste
            // Aufgabe fit zu machen: Der Benutzer gibt nun den Zahlenraum selber ein, indem er die Grenzen selber festlegt, 
            // zwischen denen die Zufallszahlen gewählt werden sollen.

            int Geheimzahl, GeheimzahlInput, AnzahlVersuche, von, bis;

            // Funktion, um eine Zufallszahl zu generieren mit Range // Lösung: https://www.sololearn.com/Discuss/1496126/use-the-modulo-operator-to-generate-random-numbers-within-a-specific-range
            Console.WriteLine("In welchem Zahlenbereich soll die Zufallszahl generiert werden?");
            von = GetNumber("Von: ");
            bis = GetNumber("Bis: ");
            while (bis < von)
            {
                Console.WriteLine("\"Bis:\" muss größer sein als \"Von:\"");
                bis = GetNumber("Bis: ");
            }

            Random rnd = new Random();
            Geheimzahl = rnd.Next(von, bis);

            AnzahlVersuche = 0;
            while (true) // Der while loop ist dafür da, dass der Nutzer die Zahl so lange eingibt,
                         // bis die richtige erraten wurde
            {
                AnzahlVersuche++; // Erhöht die Anzahl der Versuche um 1
                GeheimzahlInput = GetNumber("Bitte die Geheimzahl eingeben.");

                // als Erstes wird überprüft, ob die Zahl der Geheimzahl entspricht
                if (GeheimzahlInput == Geheimzahl)
                {
                    Console.WriteLine("Die Zahl ist richtig. \n" +
                        "Du hast " + AnzahlVersuche + " Versuch(e) gebraucht.");
                    break; // wenn die Geheimzahl richtig ist, wird nicht mehr aufgefordert, die Geheimzahl einzugeben.
                }

                // dann, ob sie zu Klein ist
                else if (GeheimzahlInput < Geheimzahl)
                {
                    Console.WriteLine("Die Zahl ist zu klein. \n");
                }

                // und wenn sie weder zu Klein, noch gleich ist, kann sie nur noch zu groß sein.
                // Deswegen reicht hier ein else Statement
                else
                {
                    Console.WriteLine("Die Zahl ist zu groß. \n");
                }
            }
        }

        static void Variante8()
        {
            // Variante 8:
            // Mit der richtigen Strategie kann man eine solche Zufallszahl erstaunlich schnell herausbekommen – wie viele Schritte
            // benötigt man für das obige Beispiel(1000 bis 10000) Antwort: 14 Versuche, wenn man die richtige Strategie benutzt. Geben Sie nun dem
            // Benutzer eine qualifizierte Rückmeldung zu der Anzahl von Versuchen: Hatte er Glück und brauche weniger Versuche
            // als eigentlich nötig? Dann gratulieren Sie ihm, liegt er im Durchschnitt, hat er das Prinzip verstanden, braucht er mehr
            // Versuche animieren Sie ihn es neu zu versuchen.

            int Geheimzahl, GeheimzahlInput, AnzahlVersuche, von, bis, AnzahlVersucheSollMax;

            // Funktion, um eine Zufallszahl zu generieren mit Range // Lösung: https://www.sololearn.com/Discuss/1496126/use-the-modulo-operator-to-generate-random-numbers-within-a-specific-range
            von = 1000;
            bis = 10000;

            Random rnd = new Random();
            Geheimzahl = rnd.Next(von, bis);
            //Geheimzahl = 20;
            //Console.WriteLine("Zahl ist " + Geheimzahl);

            AnzahlVersucheSollMax = 14; // Hier der Counter, Wie viel der Nutzer maximal brauchen sollte. Fängt mit 1 an. Bsp Bereich von 20 - 30 und Geheimzahl ist 29, oder 30
            AnzahlVersuche = 0;
            while (true) // Der while loop ist dafür da, dass der Nutzer die Zahl so lange eingibt,
                         // bis die richtige erraten wurde
            {
                AnzahlVersuche++; // Erhöht die Anzahl der Versuche um 1
                GeheimzahlInput = GetNumber("Bitte die Geheimzahl eingeben.");

                // als Erstes wird überprüft, ob die Zahl der Geheimzahl entspricht
                if (GeheimzahlInput == Geheimzahl)
                {
                    if (AnzahlVersuche < AnzahlVersucheSollMax)
                    {
                        Console.WriteLine("Die Zahl ist richtig. \n" +
                        "Du hast " + AnzahlVersuche + " Versuch(e) gebraucht und warst Schneller als erwartet!");
                    }
                    else if (AnzahlVersuche == AnzahlVersucheSollMax)
                    {
                        Console.WriteLine("Die Zahl ist richtig. \n" +
                       "Du hast " + AnzahlVersuche + " Versuch(e) gebraucht und das Prinzip verstanden.");
                    }
                    else
                    {
                        Console.WriteLine("Die Zahl ist richtig. \n" +
                       "Du hast " + AnzahlVersuche + " Versuch(e) gebraucht und das Prinzip nicht verstanden. \n" +
                       "Versuche es erneut!");
                    }
                    break; // wenn die Geheimzahl richtig ist, wird nicht mehr aufgefordert, die Geheimzahl einzugeben.
                }

                // dann, ob sie zu Klein ist
                else if (GeheimzahlInput < Geheimzahl)
                {
                    Console.WriteLine("Die Zahl ist zu klein. \n");
                }

                // und wenn sie weder zu Klein, noch gleich ist, kann sie nur noch zu groß sein.
                // Deswegen reicht hier ein else Statement
                else
                {
                    Console.WriteLine("Die Zahl ist zu groß. \n");
                }
            }

        }

        static void Variante9()
        {
            // VAriante 9:
            // Überlegen Sie sich nun, wie Sie herausfinden, welche Anzahl von Versuchen „gut“ und welche Anzahl tatsächlich eine 
            // schlechte Anzahl von Versuchen darstellt.Bauen Sie diese korrekte Bewertung in Ihr Programm ein.
            // Überlegen Sie nun: Haben Sie das Problem programmtechnisch gelöst oder mathematisch?
            // Rufen Sie nun den Lehrer und erläutern Sie ihm in einem kurzen Fachgespräch ihre Lösung

            // Geholfen hat https://info-bw.de/faecher:informatik:oberstufe:algorithmen:binaere_suche:start

            int Geheimzahl, GeheimzahlInput, AnzahlVersuche, von, bis, GeheimzahlBereich, AnzahlVersucheSollMax;

            // Funktion, um eine Zufallszahl zu generieren mit Range // Lösung: https://www.sololearn.com/Discuss/1496126/use-the-modulo-operator-to-generate-random-numbers-within-a-specific-range
            Console.WriteLine("In welchem Zahlenbereich soll die Zufallszahl generiert werden?");
            von = GetNumber("Von: ");
            bis = GetNumber("Bis: ");
            while (bis < von)
            {
                Console.WriteLine("\"Bis:\" muss größer sein als \"Von:\"");
                bis = GetNumber("Bis: ");
            }

            Random rnd = new Random();
            Geheimzahl = rnd.Next(von, bis);
            //Geheimzahl = 30;
            //Console.WriteLine("Zahl ist " + Geheimzahl);

            // Hier finden wir heraus, wie viele Versuche man maximal benötigen sollte, anhand einer simplen Strategie
            GeheimzahlBereich = bis - von; // Erst finden wir heraus, wie groß der Zahlenbereich ist, in dem gespielt wird
            if (GeheimzahlBereich == 0)
            {
                GeheimzahlBereich = Geheimzahl;
            }
            AnzahlVersucheSollMax = 0; // Hier der Counter, Wie viel der Nutzer maximal brauchen sollte.

            // Die Geheimzahl wird nun so oft durch 2 halbiert, bis sie Eins ergibt.
            // Die Anzahl, wie oft diese Rechnung gemacht werden musste ist dann die Anzahl der maximal zu brauchenden Versuche
            // Für die effizientere Lösung nutzt man den logarythmus
            while (GeheimzahlBereich != 0)
            {
                AnzahlVersucheSollMax++;
                GeheimzahlBereich = GeheimzahlBereich / 2;
            }
            Console.WriteLine(AnzahlVersucheSollMax);

            AnzahlVersuche = 0;
            while (true) // Der while loop ist dafür da, dass der Nutzer die Zahl so lange eingibt,
                         // bis die richtige erraten wurde
            {
                AnzahlVersuche++; // Erhöht die Anzahl der Versuche um 1
                GeheimzahlInput = GetNumber("Bitte die Geheimzahl eingeben.");

                // als Erstes wird überprüft, ob die Zahl der Geheimzahl entspricht
                if (GeheimzahlInput == Geheimzahl)
                {
                    if (AnzahlVersuche < AnzahlVersucheSollMax)
                    {
                        Console.WriteLine("Die Zahl ist richtig. \n" +
                        "Du hast " + AnzahlVersuche + " Versuch(e) gebraucht und warst Schneller als erwartet!");
                    }
                    else if (AnzahlVersuche == AnzahlVersucheSollMax)
                    {
                        Console.WriteLine("Die Zahl ist richtig. \n" +
                       "Du hast " + AnzahlVersuche + " Versuch(e) gebraucht und das Prinzip verstanden.");
                    }
                    else
                    {
                        Console.WriteLine("Die Zahl ist richtig. \n" +
                       "Du hast " + AnzahlVersuche + " Versuch(e) gebraucht und das Prinzip nicht verstanden. \n" +
                       "Versuche es erneut!");
                    }
                    break; // wenn die Geheimzahl richtig ist, wird nicht mehr aufgefordert, die Geheimzahl einzugeben.
                }

                // dann, ob sie zu Klein ist
                else if (GeheimzahlInput < Geheimzahl)
                {
                    Console.WriteLine("Die Zahl ist zu klein. \n");
                }

                // und wenn sie weder zu Klein, noch gleich ist, kann sie nur noch zu groß sein.
                // Deswegen reicht hier ein else Statement
                else
                {
                    Console.WriteLine("Die Zahl ist zu groß. \n");
                }
            }
        }

        static void Zusatzaufgabe1()
        {
            // Zusatzaufgabe 1:
            // Nachdem nun in allen Varianten des Codeknackers der Computer die Zahl vorgegeben hat, dürfen jetzt Sie sich die 
            // Geheimzahl selber ausdenken – der Computer soll im letzten Programm nun Ihre Zahl raten. Sie geben genauso wie
            // der Computer in den letzten Varianten an, ob die geratene Zahl zu groß, zu klein oder richtig ist.Natürlich sollten Sie
            // ebenfalls die Grenzen des Bereichs angeben in dem der Computer suchen darf

            int von, bis, GeheimzahlBereich, AnzahlVersuche, AnzahlVersucheSollMax, Guess, GrossKleinRichtig;

            Console.WriteLine("Jetzt errät der Computer deine Zahl!");
            Console.WriteLine("In welchem Zahlenbereich ist deine Zufallszahl?");
            von = GetNumber("Von: ");
            bis = GetNumber("Bis: ");
            // Check, dass von nicht größer als bis ist
            while (bis < von)
            {
                Console.WriteLine("\"Bis:\" muss größer sein als \"Von:\"");
                bis = GetNumber("Bis: ");
            }

            // Check, wie viele Versuche der PC maximal brauchen sollte
            GeheimzahlBereich = bis - von;
            AnzahlVersucheSollMax = 0;
            while (GeheimzahlBereich != 0)
            {
                AnzahlVersucheSollMax++;
                GeheimzahlBereich = GeheimzahlBereich / 2;
            }
            Console.WriteLine("Der Computer muss in Maximal " + AnzahlVersucheSollMax + " Versuchen die Geheimzahl finden.");

            // Hier fängt der PC an zu rechnen
            AnzahlVersuche = 0;
            while (true)
            {
                AnzahlVersuche++;
                Guess = (bis - von) / 2 + von;
                Console.WriteLine("\nIst die Geheimzahl " + Guess + "?");

                // Holt Antwort vom Nutzer
                while (true)
                {
                    GrossKleinRichtig = GetNumber("Mögliche Antworten sind:\n" +
                        "1 = Ja\n" +
                    "2 = Die Zahl ist zu klein\n" +
                    "3 = Die Zahl ist zu groß\n");
                    // überprüft, ob die Antwort eine mögliche Antwortoption ist
                    if (GrossKleinRichtig == 1 || GrossKleinRichtig == 2 || GrossKleinRichtig == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Deine Eingabe war keine mögliche Antwortoption.\n" +
                            "Bitte versuch es erneut!\n");
                    }
                }
                // Zahl richtig
                if (GrossKleinRichtig == 1)
                {
                    Console.WriteLine("Der Computer hat richtig geraten und hat " + AnzahlVersuche + " Versuch(e) Gebraucht.");
                    break;
                }
                // Zahl zu klein
                else if (GrossKleinRichtig == 2)
                {
                    von = Guess + 1;
                }
                // Zahl zu groß
                else if (GrossKleinRichtig == 3)
                {
                    bis = Guess - 1;
                }
            }
        }

        static void Zusatzaufgabe2()
        {

        }
    }
}
