using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Documents;
using ÜbungTaschenrechner.Entities;
using ResX = ÜbungTaschenrechner.Resources.Resources;


//  Die Klasse CalculatorWindowViewModel ist eine View-Modell-Klasse, die das Verhalten und die Logik der Taschenrechneranwendung steuert.
//  Sie hat eine öffentliche Eigenschaft namens CurrentValue, die die aktuelle Zahl oder den aktuellen Ausdruck darstellt, der in das Taschenrechnerfenster eingegeben wird.
//  Die Eigenschaft EquationSolver ist eine Instanz der EquationSolver-Klasse, die die zugrunde liegende Rechenlogik enthält.
//  Die Klasse hat drei öffentliche Methoden:NumberPressed wird aufgerufen, wenn eine Zahl auf dem Taschenrechner gedrückt wird.
//  Sie fügt die gedrückte Zahl zur aktuellen CurrentValue hinzu.OperatorPressed wird aufgerufen, wenn ein mathematischer Operator (+, -, *, /) auf dem Taschenrechner gedrückt wird.
//  Sie fügt den aktuellen Wert zu EquationSolver als Operand hinzu und setzt den angegebenen Operator.
//  Wenn der letzte Eintrag im EquationSolver auch ein Operator ist, wird der neue Operator anstelle des alten Operators gesetzt.EqualsPressed wird aufgerufen, wenn die "Gleich" Taste auf dem Taschenrechner gedrückt wird.
//  Sie fügt den aktuellen Wert zu EquationSolver als Operand hinzu und löst die Gleichung mit EquationSolver.Solve().
//  Das Ergebnis wird als neuer aktueller Wert in CurrentValue gesetzt.Die Klasse erbt von BaseViewModel und implementiert daher das INotifyPropertyChanged-Interface.
//  Dies ermöglicht es, dass bei Änderungen an den öffentlichen Eigenschaften von CalculatorWindowViewModel die Änderungen an die Ansicht (die UI) automatisch weitergegeben werden.

namespace ÜbungTaschenrechner.ViewModels
{
    public class CalculatorWindowViewModel : BaseViewModel   // Die Klasse CalculatorWindowViewModel ist eine Unterklasse der Klasse BaseViewModel, was bedeutet, dass sie alle Eigenschaften und Methoden von BaseViewModel erbt und erweitern oder überschreiben kann.
    {
        #region Private Variables

        #endregion

        #region Constructor
        public CalculatorWindowViewModel()    // Das ist der Konstruktor der Klasse CalculatorWindowViewModel, der beim Erstellen eines neuen Objekts dieser Klasse aufgerufen wird. In diesem Fall ist der Konstruktor leer, d.h. es wird nichts ausgeführt, wenn ein neues Objekt erstellt wird.
        {

        }

        #endregion

        #region Public Properties

        public string CurrentValue { get; set; } = string.Empty;  // CurrentValue - Eine Zeichenfolge, die den aktuellen Wert des Taschenrechners speichert. Es wird aktualisiert, wenn der Benutzer eine Zahl oder einen Operator eingibt.
                       // Die Eigenschaft CurrentValue ist ein öffentliches Feld der Klasse CalculatorWindowViewModel, das einen string als Wert enthält und das aktuelle Wertfeld des Taschenrechners repräsentiert.
                      // Standardmäßig wird es mit einem leeren String initialisiert, damit es beim Start des Taschenrechners leer ist.Diese Eigenschaft wird verwendet, um die aktuelle Benutzereingabe zu speichern, während der Benutzer Zahlen und Operatoren eingibt, um eine Gleichung zu erstellen, die später ausgewertet wird.

        public EquationSolver EquationSolver { get; private set; } = new EquationSolver();   // Die Eigenschaft EquationSolver ist vom Typ EquationSolver und stellt einen Solver zur Verfügung, der verwendet wird, um mathematische Gleichungen zu lösen.
                                                                                             // In diesem Fall wird EquationSolver beim Erstellen eines CalculatorWindowViewModel-Objekts automatisch initialisiert und es wird eine neue Instanz von EquationSolver zugewiesen. Die EquationSolver-Instanz wird dann verwendet, um die eingegebenen Gleichungen zu lösen. Da die Eigenschaft EquationSolver einen privaten Setter hat, kann sie nur innerhalb der CalculatorWindowViewModel-Klasse gesetzt werden.

        #endregion

        #region Public Methods

        public void NumberPressed(string number)       // NumberPressed - Diese Methode wird aufgerufen, wenn der Benutzer eine Zahl eingibt. Die Methode fügt die Zahl zur CurrentValue hinzu.
        {
            if (number == ResX.DecimalPoint && String.IsNullOrEmpty(CurrentValue))      // Dieser Codeausschnitt überprüft, ob die Taste mit dem Dezimaltrennzeichen (Punkt oder Komma, abhängig von der eingestellten Sprache) gedrückt wurde und ob der aktuelle Wert leer ist. Wenn beides zutrifft, wird eine "0" dem aktuellen Wert vorangestellt, um sicherzustellen, dass eine gültige Dezimalzahl eingegeben wird.
            {
                CurrentValue += "0";       // Hier wird dem Wert der Eigenschaft CurrentValue der String "0" angehängt, falls number dem Dezimaltrennzeichen entspricht und CurrentValue leer ist. Dies ist nützlich, um sicherzustellen, dass der Wert in CurrentValue eine gültige Dezimalzahl ist, wenn nur das Dezimaltrennzeichen eingegeben wurde.
            }

            this.CurrentValue += number.Replace(".", ResX.DecimalPoint);  // Die Methode NumberPressed fügt der CurrentValue des CalculatorWindowViewModel eine neue Zeichenkette hinzu. Wenn das gedrückte Zeichen "." (Dezimaltrennzeichen) ist und CurrentValue leer ist, fügt es "0" hinzu.
                                                                          // Andernfalls wird das gedrückte Zeichen (falls vorhanden) als neues Zeichen an die CurrentValue angehängt und das Dezimaltrennzeichen durch das in der ResX.DecimalPoint festgelegte Zeichen ersetzt (um konsistent mit der eingestellten Region zu sein).
        }

        public void OperatorPressed(MathOperators op)    // OperatorPressed - Diese Methode wird aufgerufen, wenn der Benutzer einen Operator eingibt. Wenn CurrentValue leer ist und der letzte Eintrag in der Gleichung ein Operator ist, wird der Operator aktualisiert. Andernfalls wird CurrentValue als Operand hinzugefügt und CurrentValue wird zurückgesetzt.
        {
            if(String.IsNullOrEmpty(CurrentValue) && EquationSolver.Equation.Last() is IMathOperator)  // Die Bedingung String.IsNullOrEmpty(CurrentValue) && EquationSolver.Equation.Last() is IMathOperator prüft, ob der aktuelle Wert des Taschenrechners leer ist und das letzte Element in der Rechung des EquationSolver-Objekts ein IMathOperator-Objekt ist. Wenn dies der Fall ist, wird der neue Operator dem vorhandenen IMathOperator-Objekt zugewiesen, indem dessen Value-Eigenschaft aktualisiert wird. Andernfalls wird ein neues IMathOperand-Objekt mit dem aktuellen Wert des Taschenrechners und dem neuen Operator zur EquationSolver-Eigenschaft hinzugefügt, und der aktuelle Wert des Taschenrechners wird zurückgesetzt.
            { 
                var lastOperator = (IMathOperator)EquationSolver.Equation.Last();   //  Die Bedingung String.IsNullOrEmpty(CurrentValue) && EquationSolver.Equation.Last() is IMathOperator prüft, ob der aktuelle Wert des Taschenrechners leer ist und das letzte Element in der Rechung des EquationSolver-Objekts ein IMathOperator-Objekt ist. Wenn dies der Fall ist, wird der neue Operator dem vorhandenen IMathOperator-Objekt zugewiesen, indem dessen Value-Eigenschaft aktualisiert wird. Andernfalls wird ein neues IMathOperand-Objekt mit dem aktuellen Wert des Taschenrechners und dem neuen Operator zur EquationSolver-Eigenschaft hinzugefügt, und der aktuelle Wert des Taschenrechners wird zurückgesetzt.
                lastOperator.Value = op;   // In diesem Codeausschnitt wird der Wert (Operator) des letzten Elements in der Equation-Liste aktualisiert. Wenn das letzte Element ein Operator ist, wird dessen Wert (Value) durch den neuen Operator (op) ersetzt. Wenn das letzte Element kein Operator ist, wird ein neues Element mit dem aktuellen Wert (CurrentValue) und dem Operator (op) der Equation-Liste hinzugefügt.Hier wird der Wert der Value-Eigenschaft des lastOperator-Objekts auf den op-Wert gesetzt, der als Argument an die Methode übergeben wurde. Dies bedeutet, dass der mathematische Operator (z. B. +, -, *, /) des letzten Elements in der Gleichung auf den neuen Operator aktualisiert wird, der gerade gedrückt wurde.
            }
            else
            {
                EquationSolver.AddItem(CurrentValue, op);  // Hier wird die Methode "AddItem" des EquationSolver-Objekts aufgerufen. Dabei wird der aktuelle Wert (CurrentValue) und der Operator (op) als Argumente übergeben. Dadurch wird ein neues IMathItem-Objekt mit dem angegebenen Wert und Operator erstellt und der EquationSolver-Equation-Liste hinzugefügt.
                CurrentValue = String.Empty;  // Hier wird der Wert von CurrentValue auf einen leeren String gesetzt, nachdem ein Operator gedrückt wurde und dieser dem EquationSolver hinzugefügt wurde. Das bedeutet, dass der aktuelle Wert des Taschenrechners nun gelöscht ist und der Benutzer eine neue Zahl eingeben kann.
            } 
        }

        public void EqualsPressed()            // EqualsPressed - Diese Methode wird aufgerufen, wenn der Benutzer die Taste "Gleich" drückt. Wenn CurrentValue nicht leer ist, wird es als Operand zur Gleichung hinzugefügt. Die Methode löst die Gleichung und aktualisiert CurrentValue mit dem Ergebnis.   
        {
            if (String.IsNullOrEmpty(CurrentValue) == false)   // Diese Zeile überprüft, ob der aktuelle Wert (CurrentValue) nicht leer oder null ist. Wenn dies der Fall ist, wird dem Gleichungs-Resolver (EquationSolver) das aktuelle Element hinzugefügt, das den aktuellen Wert als Operanden und den MathOperators.None als Operator enthält. Anschließend wird der aktuelle Wert geleert, um eine neue Operandeneingabe zu ermöglichen.
            {
                EquationSolver.AddItem(CurrentValue, MathOperators.None);  // Hier wird der aktuelle Wert (CurrentValue) als Operand zum Gleichungs-Solver (EquationSolver) hinzugefügt, zusammen mit dem Operator "None", um anzuzeigen, dass es keine weiteren Operationen gibt. Der aktuelle Wert wird dann auf eine leere Zeichenfolge zurückgesetzt, um den Benutzer für eine neue Eingabe bereit zu machen.
                CurrentValue = String.Empty;  // Hier wird der aktuelle Wert (CurrentValue) zurückgesetzt, indem ihm ein leerer String zugewiesen wird. Das bedeutet, dass der Inhalt des Textfeldes des Taschenrechners gelöscht wird, nachdem der Benutzer auf die Taste "Gleich" gedrückt hat und das Ergebnis angezeigt wurde.
            }

            double result = EquationSolver.Solve();    // Hier wird die Solve()-Methode des EquationSolver-Objekts aufgerufen, um die Gleichung zu lösen. Das Ergebnis wird in einer double-Variablen result gespeichert.

            CurrentValue = result.ToString().Replace(",", ResX.DecimalPoint);   //  Hier wird die Solve()-Methode des EquationSolver-Objekts aufgerufen, um die Gleichung zu lösen. Das Ergebnis wird in einer double-Variablen result gespeichert.
        }

        #endregion
    }
}
