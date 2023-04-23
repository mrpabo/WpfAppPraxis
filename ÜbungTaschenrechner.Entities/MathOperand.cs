using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;   // Die System.Text Namespace enthält Klassen zum Codieren, Dekodieren und Darstellen von Zeichen und Byte-Sequenzen in verschiedenen Text-Encodings. Zum Beispiel enthält dieser Namespace die Encoding Klasse, die Methoden zum Konvertieren von Zeichen und Byte-Sequenzen in verschiedene Text-Encodings und umgekehrt bereitstellt. Andere Klassen in diesem Namespace enthalten auch Methoden zum Arbeiten mit Strings und Textformatierung.
using System.Threading.Tasks;  // Die "Task Parallel Library" (TPL) ist eine Komponente des .NET-Frameworks, die es erleichtert, asynchrone, parallele und datenflussorientierte Programme zu schreiben. Sie bietet eine Vielzahl von Klassen und Methoden, um komplexe Aufgaben parallel und asynchron auszuführen. Die TPL ist seit .NET Framework 4.0 verfügbar und wird von .NET Core und .NET 5+ unterstützt.

// In diesem Beispiel wird eine Klasse "MathOperand" erstellt, die ein numerischer Operand in einer mathematischen Gleichung repräsentiert.
// Es enthält nur eine Eigenschaft "Value", die den numerischen Wert des Operanden enthält.
// Die Klasse implementiert auch die Schnittstelle "IMathOperand", die in diesem Beispiel nicht explizit definiert ist, aber die in Zukunft möglicherweise nützlich sein könnte.
// Die "ToString" Methode wird überschrieben, um eine lesbare Darstellung des Operanden zu ermöglichen.
// Die Klasse ist auch von "ModelBase" abgeleitet, was darauf hindeutet, dass es Teil eines größeren Models ist.

namespace ÜbungTaschenrechner.Entities
{
    public class MathOperand : ModelBase, IMathOperand         //Die Klasse MathOperand erbt von der Klasse ModelBase und implementiert das Interface IMathOperand.
                                                               //Sie repräsentiert eine Zahl, die als Operand in mathematischen Operationen verwendet wird.
                                                               //Die Klasse hat eine öffentliche Eigenschaft Value, die den Wert des Operanden als Double darstellt.
                                                               //Die Eigenschaft ValueString gibt den Wert des Operanden als String zurück.
                                                               //Die Klasse hat auch eine ToString()-Methode, die den Wert des Operanden als String zurückgibt.
    {
        #region Constructor

        public MathOperand(double value)      //Dies ist der Konstruktor der MathOperand-Klasse.
                                              //Er akzeptiert einen double-Wert value als Parameter und weist ihn der Value-Eigenschaft zu, die in der Klasse definiert ist.
        {
            Value = value;              //setzt den Wert der Eigenschaft Value auf den übergebenen Wert. Die Eigenschaft Value ist vom Typ double und enthält den numerischen Wert des Operanden.
        }

        #endregion

        #region Public Properties

        public double Value { get; set; }        // Die Eigenschaft "Value" des "MathOperand" ist vom Typ "double" und hat sowohl eine Getter- als auch eine Setter-Methode.
                                                 // Sie ermöglicht den Zugriff auf den numerischen Wert des Operanden.

        public string ValueString => Value.ToString();      /*Dies ist eine Abkürzung für eine Eigenschaft mit einer get-Methode, die das Ergebnis von Value.ToString() zurückgibt. 
                                                             * Es ist äquivalent zu:
                                                             * public string ValueString
                                                                         }
                                                                            get { return Value.ToString();
                                                                        
                                                                        }
                                                             */

        #endregion

        #region Public Methods

        public override string ToString()        // Die Methode "ToString" ist eine Überschreibung der gleichnamigen Methode aus der Klasse "Object" und ermöglicht es,
                                                 // eine benutzerdefinierte Repräsentation des Objekts in Form eines Strings zurückzugeben. In diesem Fall gibt die Methode den Wert der Eigenschaft "Value" als String zurück.
        {
            return Value.ToString();
        }

        #endregion
    }
}
