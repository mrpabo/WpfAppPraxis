using System;                   //Dieser Codeimportiert die Namespace-Referenz System. Ein Namespace ist eine logische Gruppierung von Klassen und anderen Typen in einer Anwendung.
                                //Das Importieren einer Namespace-Referenz ermöglicht dem Code Zugriff auf alle Typen in diesem Namespace ohne vollqualifizierte Typnamen verwenden zu müssen.
                                //System ist ein wichtiger Namespace in C#, der viele grundlegende Typen und Klassen enthält, z.B. die Klasse Console, die oft zum Lesen von Eingaben und zum Schreiben von Ausgaben in die Konsole verwendet wird.

using System.Collections.ObjectModel;  // Die System.Collections.ObjectModel Namespace enthält Klassen, die erweiterte Collection-Funktionen bereitstellen, die in der Standard-System.Collections.
                                       // Generic Namespace nicht verfügbar sind. Ein wichtiges Beispiel ist die ObservableCollection<T> Klasse, die eine spezielle Art von Liste darstellt, die in der Lage ist,
                                       // Benachrichtigungen auszulösen, wenn ihre Elemente hinzugefügt, entfernt oder aktualisiert werden. Diese Funktion ist besonders nützlich in Anwendungen,
                                       // die eine Datenbindung verwenden, um Benutzeroberflächen zu aktualisieren, sobald die zugrunde liegenden Daten geändert werden.

using System.Linq;      // using System.Linq; wird verwendet, um eine Abfrage zu definieren, die in einer Auflistung von Objekten ausgeführt wird. Die Abfrage ist eine Folge von Methodenaufrufen,
                        // die es ermöglichen, die Elemente in der Auflistung zu filtern, zu sortieren oder zu transformieren. Mit Linq können Daten auf eine intuitive und kompakte Weise bearbeitet werden.

using System.Net;      // Die System.Net-Namespace enthält Typen, die Netzwerkkommunikation ermöglichen und Dienste wie HTTP, FTP und SMTP unterstützen.
                       // Mit den Typen des System.Net-Namespaces können Sie Netzwerkverbindungen herstellen, Daten an Server senden und von Servern empfangen,
                       // HTTP-Anforderungen senden und empfangen und vieles mehr. Der Namespace enthält auch Klassen, die die Sicherheit von Netzwerkverbindungen erhöhen,
                       // z. B. System.Net.Security.SslStream, die es ermöglicht, Daten mit SSL-/TLS-Verschlüsselung zu senden und zu empfangen.

using System.Reflection;     // Die "System.Reflection" Namespace enthält Klassen, die verwendet werden, um Informationen über die geladene Assembly, Typen, Methoden und andere Objekte zur Laufzeit zu ermitteln.
                             // Dies kann hilfreich sein, wenn Sie z.B. eine dynamische Typen-Instanziierung oder -Manipulation durchführen möchten oder wenn Sie zur Laufzeit auf Informationen einer geladenen Assembly zugreifen möchten.
using System.Security.Cryptography;   // Das System.Security.Cryptography Namespace enthält Klassen zur Implementierung kryptographischer Algorithmen und Sicherheitsdienste zum Schutz von Daten.
                                      // Dieser Namespace bietet Unterstützung für die Erstellung und Verwaltung von Schlüsseln, die Hashing von Daten sowie die Verschlüsselung und Entschlüsselung von Daten.
                                      // Hier sind einige Beispiele für Klassen, die in diesem Namespace enthalten sind:
                                      // Aes: Implementiert den Advanced Encryption Standard (AES) Algorithmus zur Verschlüsselung von Daten.
                                      // HMACSHA256: Implementiert einen Hash-basierten Message Authentication Code (HMAC) mit dem SHA256-Algorithmus zur Authentifizierung von Nachrichten.
                                      // RSA: Implementiert den RSA-Algorithmus zur Erstellung und Verwaltung von öffentlichen und privaten Schlüsseln.
                                      // SHA256: Implementiert den SHA256-Algorithmus zur Berechnung des Hashwerts von Daten. Dies sind nur einige Beispiele, es gibt noch viele weitere Klassen und Funktionen in diesem Namespace.

using System.Xml.Linq;      // Die System.Xml.Linq Namespace enthält Klassen für die Arbeit mit LINQ to XML. Es ist ein Teil des .
                            // NET-Frameworks und ermöglicht das Lesen, Schreiben, Validieren und Manipulieren von XML-Dokumenten mit der LINQ-Technologie. Hiermit können Entwickler effizient XML-basierte Daten in C#-Code integrieren und verarbeiten.
                            // Einige wichtige Klassen in diesem Namespace sind XDocument, XElement, XAttribute und XNamespace.

namespace ÜbungTaschenrechner.Entities
{
    public class EquationSolver                                // Die Klasse EquationSolver ist eine Klasse in C#, die eine mathematische Gleichung lösen kann.
                                                               // Sie enthält eine Sammlung von mathematischen Operanden und Operatoren, die als ObservableCollection deklariert sind

        //Consruktor erklärung:
        //Konstruktoren haben keinen Rückgabewert, und es ist nicht möglich, sie direkt aufzurufen.
        //Stattdessen werden sie automatisch aufgerufen, wenn ein neues Objekt der Klasse erstellt wird,
        //entweder durch das Schlüsselwort "new" oder durch Aufruf eines anderen Konstruktors in der Klasse durch das Schlüsselwort "this".
        //Konstruktoren können auch überladen werden, um verschiedene Arten von Konstruktoren für dasselbe Objekt bereitzustellen.

    {
        #region Constructor                                    

        public EquationSolver()             // Dies ist der Standardkonstruktor der Klasse EquationSolver. Der Konstruktor wird automatisch aufgerufen, wenn ein Objekt dieser Klasse erstellt wird.
                                            //In diesem Fall initialisiert der Konstruktor das Equation-Feld als eine neue leere Instanz der Klasse ObservableCollection<IMathItem>.
                                            //Mit anderen Worten, jedes Mal, wenn ein neues EquationSolver-Objekt erstellt wird, wird auch eine neue ObservableCollection<IMathItem> erstellt,
                                            //die als Equation-Feld dieser Instanz zugeordnet wird.
        {
            Equation = new ObservableCollection<IMathItem>()
            {
                
            };
        }



#endregion
#region Public Properties
        public string CurrentText { get; set; }                 //Die Eigenschaft CurrentText ist ein String, der den aktuellen Text der Gleichung enthält

        public ObservableCollection<IMathItem> Equation { get; set; } = new ObservableCollection<IMathItem>();

        // Die Zeile deklariert eine öffentliche Eigenschaft Equation, die ein ObservableCollection von IMathItem-Objekten enthält.
        // ObservableCollection ist eine spezielle Art von Sammlung in C#, die die Möglichkeit bietet, Änderungen an der Sammlung zu verfolgen und Benachrichtigungen zu senden,
        // wenn sich die Sammlung ändert. Die Eigenschaft hat einen öffentlichen Setter und Getter und wird bei der Initialisierung automatisch als leere ObservableCollection initialisiert.



        #endregion
        #region Public Methods
        public void AddItem(string number, MathOperators op)        //Die Methode AddItem fügt ein neues Element (Operand oder Operator) zur Gleichung hinzu.
        {
            double value = Convert.ToDouble(number);              // wandelt eine Zeichenfolge (string), die eine Zahl repräsentiert, in eine Fließkommazahl (double) um.
                                                                  // Dazu wird die statische Methode Convert.ToDouble der Klasse System.Convert verwendet. Wenn die Konvertierung nicht erfolgreich ist, wird eine FormatException ausgelöst.

            Equation.Add(new MathOperand(value));           // Dieser Codeabschnitt fügt der Gleichung(Equation) eine neue Zahl als Operand hinzu.
                                                            // Dazu wird der übergebene String "number" in eine Double-Zahl umgewandelt und dann ein neues Objekt der Klasse "MathOperand" mit diesem Wert erstellt und der Gleichung hinzugefügt.


            if (op != MathOperators.None)                   // Dieser Codeausschnitt prüft, ob der Operator, der hinzugefügt werden soll, nicht der None-Operator ist. Wenn es nicht None ist, wird eine neue Instanz der Klasse MathOperator erstellt und der Equation-Auflistung hinzugefügt.
                                                            // Das bedeutet, dass, wenn eine Zahl ohne nachfolgenden Operator hinzugefügt wird, kein Operator zur Equation-Auflistung hinzugefügt wird.
            {                                       
                Equation.Add(new MathOperator(op));
            }
        }

        public double Solve()                                       //Die Methode Solve löst die Gleichung und gibt das Ergebnis als Double zurück
        {
            if(Equation.Last() is IMathOperator)                //Diese Bedingung überprüft, ob das letzte Element der Gleichung ein IMathOperator-Objekt ist.
                                                                //Wenn dies der Fall ist, wird es aus der Gleichungsliste entfernt, da eine Gleichung nicht mit einem Operator enden kann.
            {
                Equation.RemoveAt(Equation.Count - 1);
            }

            SolveOperation(MathOperators.Multiply);             //Diese Zeilen rufen die SolveOperation Methode auf, um die Rechenoperationen auszuführen. Zuerst wird Multiplikation, dann Division, Addition und Subtraktion in dieser Reihenfolge aufgerufen.
            SolveOperation(MathOperators.Divide);              //Das ist die Reihenfolge der Operationen, die durch die Regel der Mathematik definiert ist, dass Multiplikation und Division vor Addition und Subtraktion ausgeführt werden.
            SolveOperation(MathOperators.Plus);
            SolveOperation(MathOperators.Minus);

            var result = Equation.Cast<MathOperand>().First().Value;  //Die Variable "result" wird mit dem Wert des ersten MathOperand-Elements in der "Equation" ObservableCollection initialisiert.
                                                                      //Dazu wird die Methode "Cast<T>()" aufgerufen, um alle Elemente in der ObservableCollection in ein IEnumerable<MathOperand> zu konvertieren.
                                                                      //Dann wird die Methode "First()" aufgerufen, um das erste Element zurückzugeben, und schließlich wird auf dessen Eigenschaft "Value" zugegriffen, um den Wert zu erhalten.
           
            Equation.Clear();                           // Die Methode "Clear()" löscht alle Elemente aus der ObservableCollection "Equation", so dass sie danach leer ist.

            return result;                  // Diese Anweisung gibt das Ergebnis der Gleichungsberechnung zurück, das als double-Wert berechnet wurde.
        }
        public void SolveOperation(MathOperators mathOperator)    //Die Methode SolveOperation löst eine Operation (Multiplikation, Division, Addition oder Subtraktion) innerhalb der Gleichung.
        {
            while(Equation.Where(x => x is MathOperator).Cast<MathOperator>().Any(x => x.Value == mathOperator))    // Solange es mindestens einen MathOperator in der Equation gibt, bei dem der Wert mit dem mathOperator-Parameter übereinstimmt, führe den folgenden Codeblock aus.
            {
                MathOperator firstOperator = Equation.Where(x => x is MathOperator).Cast<MathOperator>().Where(x => x.Value == mathOperator).First();
                int index = Equation.IndexOf(firstOperator);   // hier wird der erste Operator im Gleichungs-ObservableCollection gesucht, der dem angegebenen Operator (mathOperator) entspricht.
                                                               // Sobald der Operator gefunden ist, wird sein Index in der Gleichungsliste gespeichert.

                int indexLeftOperand = index - 1;
                MathOperand leftOperand = (MathOperand)Equation[indexLeftOperand];    // Diese Zeilen von Code holen den linken Operanden des Operators, der an der Index-Position "index" in der "Equation" (Gleichung) steht. Der Index des linken Operanden ist "index - 1".
                                                                                      // Die Variable "leftOperand" wird erstellt und die Klasse des linken Operanden "MathOperand" wird gecastet und in dieser Variable gespeichert.

                int indexRightOperand = index + 1;
                MathOperand rightOperand = (MathOperand)Equation[indexRightOperand];   // Hier wird der Index des rechten Operanden bestimmt und der Wert des Operanden als MathOperand-Objekt zugewiesen.
                                                                                       // Dazu wird der zuvor gefundene Index des Operators um 1 erhöht, um den Index des rechten Operanden zu erhalten, und dann wird das Element an diesem Index aus der Equation-Liste extrahiert und in ein MathOperand-Objekt gecastet.

                MathOperand solvedOperand = null;       // Dies liegt daran, dass der solvedOperand erst initialisiert werden soll, nachdem der entsprechende mathematische Operator (mathOperator) gefunden wurde und zwei Operanden zur Verfügung stehen, aus denen das Ergebnis berechnet werden kann.
                                                        // Da dies möglicherweise nicht immer der Fall ist, wenn der Code diese Zeile erreicht, wird die Variable als null initialisiert.

                switch (mathOperator)     // Hier wird anhand des übergebenen MathOperators mathOperator entschieden, welche Rechenoperation auf den linken und rechten Operanden durchgeführt wird.
                {
                    case MathOperators.Plus:        //  Bei MathOperators.Plus wird die Summe aus leftOperand und rightOperand gebildet und das Ergebnis in solvedOperand gespeichert.
                        solvedOperand = new MathOperand(leftOperand.Value + rightOperand.Value);
                        break;
                    case MathOperators.Minus:        // Bei MathOperators.Minus wird die Differenz aus leftOperand und rightOperand gebildet und das Ergebnis in solvedOperand gespeichert.
                        solvedOperand = new MathOperand(leftOperand.Value - rightOperand.Value);
                        break;
                    case MathOperators.Multiply:      // Bei MathOperators.Multiply wird das Produkt aus leftOperand und rightOperand gebildet und das Ergebnis in solvedOperand gespeichert.
                        solvedOperand = new MathOperand(leftOperand.Value * rightOperand.Value);
                        break;
                    case MathOperators.Divide:        // Bei MathOperators.Divide wird der Quotient aus leftOperand und rightOperand gebildet und das Ergebnis in solvedOperand gespeichert.
                        solvedOperand = new MathOperand(leftOperand.Value / rightOperand.Value);
                        break;
                    case MathOperators.None:         //Wenn keiner der angegebenen Operatoren zutrifft (MathOperators.None) wird eine Ausnahme (Exception) ausgelöst,
                default:                        //da keine Rechenoperation durchgeführt werden kann.
                        throw new Exception("No Operator available");
                }

               
                // Diese Code-Zeilen entfernt das erste Vorkommen eines MathOperator-Objekts aus der Equation - Liste.Der firstOperator wurde zuvor aus der Liste extrahiert,
                // um den Index seiner Position in der Liste zu finden. Das Entfernen des Operators aus der Liste ist notwendig, um den Operator
                // und die Operanden durch das Ergebnis der Operation zu ersetzen.
                
                Equation.Remove(leftOperand);   //Diese Zeile entfernt das leftOperand aus der Equation-Liste.
                Equation.Remove(firstOperator);  //Diese Code-Zeile entfernt das erste Vorkommen eines MathOperator-Objekts aus der Equation-Liste. Der firstOperator wurde zuvor aus der Liste extrahiert, um den Index seiner Position in der Liste zu finden.
                                                 //Das Entfernen des Operators aus der Liste ist notwendig, um den Operator und die Operanden durch das Ergebnis der Operation zu ersetzen.
                Equation.Remove(rightOperand);   // Dieser Code entfernt das rechte Operandenobjekt aus der Gleichungsliste "Equation".

                Equation.Insert(indexLeftOperand, solvedOperand);   // Diese Zeile fügt das solvedOperand Objekt an der Stelle indexLeftOperand in der Equation-Liste ein, wobei alle anderen Elemente nach rechts verschoben werden.
                                                                    // Dadurch wird das ursprüngliche linke Operandenobjekt durch das neue gelöste Operandenobjekt ersetzt, das das Ergebnis der Berechnung darstellt.
            }
        }

        #endregion
    }
}
