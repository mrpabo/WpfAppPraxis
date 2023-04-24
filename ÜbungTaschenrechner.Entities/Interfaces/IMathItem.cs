using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;          // Die Anweisung using System.Windows.Input; importiert das System.Windows.Input-Namespace in die aktuelle Datei und ermöglicht den Zugriff auf darin enthaltene Klassen und Funktionen, die für die Behandlung von Benutzereingaben in einer Windows Presentation Foundation (WPF)-Anwendung nützlich sein können.
using System.Xml.Linq;
using ÜbungTaschenrechner.Entities;

namespace ÜbungTaschenrechner.Entities      // drei Schnittstellen (Interfaces): IMathItem, IMathOperator und IMathOperand.
{
    public interface IMathItem          // IMathItem enthält nur eine Eigenschaft: ValueString, die eine Zeichenfolge enthält, die den Wert des mathematischen Elements repräsentiert.
    {
        string ValueString { get; }      // Diese Zeile definiert eine Eigenschaft ValueString, die von Objekten implementiert werden kann, die das IMathItem-Interface implementieren. Die Eigenschaft hat einen Getter, der einen String zurückgibt. Der String kann verwendet werden, um den Wert des IMathItem-Objekts als lesbarer Text darzustellen, z.B. als String "5" für eine Zahl oder als String "+" für einen Operator.
    }
    public interface IMathOperator : IMathItem      // IMathOperator ist eine Schnittstelle für mathematische Operatoren wie Addition, Subtraktion, Multiplikation und Division. Es hat eine Eigenschaft Value, die den Operator repräsentiert, und eine Eigenschaft ValueString, die eine Zeichenfolge zurückgibt, die den Operator darstellt.
    {
        MathOperators Value { get; set; }         // Diese Zeile definiert die Eigenschaft "Value" des "IMathOperator"-Interfaces als Lese-/Schreibzugriff auf eine Enumerationsvariable vom Typ "MathOperators". Das bedeutet, dass eine Klasse, die das "IMathOperator"-Interface implementiert, eine Eigenschaft "Value" haben muss, die den Wert des Operators speichert, der als "MathOperators"-Enumeration definiert ist.
    }
    public interface IMathOperand : IMathItem     // IMathOperand ist eine Schnittstelle für Operanden wie Zahlen. Es hat eine Eigenschaft Value, die den Wert des Operanden enthält, und eine Eigenschaft ValueString, die eine Zeichenfolge zurückgibt, die den Wert des Operanden darstellt.
    {
        double Value { get; set; }                     // Die Schnittstelle IMathOperand definiert ein Vertragsmuster für eine mathematische Operandenklasse und erbt von der Schnittstelle IMathItem, die die Eigenschaft ValueString erfordert.
                                                       // Die Schnittstelle IMathOperand fordert eine Eigenschaft namens Value, die einen double-Wert enthält und getrennt von einer Implementierung von IMathItem verwendet werden kann.Mit anderen Worten, wenn eine Klasse die Schnittstelle IMathOperand implementiert, muss sie die Eigenschaft Value implementieren,
                                                       // die eine Zahl enthält, während die Eigenschaft ValueString über die vererbte IMathItem-Schnittstelle verfügbar ist und einen String-Wert enthält, der den Wert des Operanden darstellt.
    }
    
}
