using System.Security.Cryptography;
using System;
using System.Runtime.ConstrainedExecution;
using System.Net;

namespace ÜbungTaschenrechner.Entities           // Dieser Code definiert die Klasse MathOperator, die von der Basisklasse ModelBase erbt und das IMathOperator-Interface implementiert. Sie hat eine Konstruktorfunktion, die einen Wert des Enums MathOperators als Parameter erwartet, sowie zwei öffentliche Eigenschaften.
                                                 // Die Eigenschaft Value ist vom Typ MathOperators und hat sowohl eine Getter- als auch eine Setter-Methode. Die Eigenschaft ValueString ist vom Typ string und gibt einen String zurück, der auf den Enum-Wert Value abgebildet ist. Außerdem gibt es eine öffentliche Methode ToString(), die ebenfalls einen String zurückgibt, der auf den Enum-Wert Value abgebildet ist.
{
    public class MathOperator : ModelBase, IMathOperator         // Die Klasse MathOperator erbt von der Klasse ModelBase und implementiert das Interface IMathOperator. Sie definiert einen enum MathOperators, der die möglichen mathematischen Operatoren Plus, Minus, Multiply und Divide sowie einen None-Wert enthält.
                                                                 // Der Konstruktor der Klasse nimmt einen MathOperators-Parameter value entgegen und setzt die Value-Eigenschaft des Objekts auf diesen Wert.Die Value-Eigenschaft des Objekts gibt den Wert des MathOperators zurück, während die ValueString-Eigenschaft den entsprechenden Operator als String zurückgibt.Die ToString()-Methode gibt ebenfalls den entsprechenden Operator als String zurück.
    {
        #region Constructor

        public MathOperator(MathOperators value)     // Dies ist der Konstruktor der MathOperator-Klasse. Er nimmt einen Parameter vom Typ MathOperators entgegen und setzt die Value-Eigenschaft des Objekts auf diesen Wert.
        {
            Value = value;           // weist dem Value-Attribut des MathOperator-Objekts den übergebenen Wert zu.
        }

        #endregion

        #region Public Properties

        public MathOperators Value { get; set; } = MathOperators.Plus;      // Die Value Eigenschaft des MathOperator Objekts gibt den zugewiesenen MathOperators Wert zurück oder legt ihn fest, wenn der Aufrufer eine Zuweisung durchführt. Der Standardwert für die Value Eigenschaft ist MathOperators.Plus.
                                                                            // Die MathOperators Enumeration stellt verschiedene mathematische Operatoren dar, die in einem Taschenrechner verwendet werden können.Der MathOperator wird verwendet, um eine Instanz eines Operators darzustellen, der in der Anwendung verwendet wird.
        public string ValueString             //   Die ValueString Eigenschaft gibt einen String zurück, der das aktuelle MathOperators-Objekt darstellt, das diesem MathOperator-Objekt zugeordnet ist. Der Wert des Value-Enum wird in ein passendes Symbol (z.B. "+" für "Plus") konvertiert und zurückgegeben.
                                              //   Wenn der Value ungültig ist, wird "?" zurückgegeben.Die Implementierung dieser Eigenschaft erfolgt über einen switch-Block, der die möglichen Werte des Value-Enums durchläuft und das entsprechende Symbol zurückgibt.
        {
            get
            {
                switch (Value)       // Klasse enthält eine Eigenschaft mit dem Namen "Value", die den zugrunde liegenden Operator speichert (z. B. Plus, Minus, Multiplikation oder Division).
                {
                    case MathOperators.Plus:
                        return "+";
                    case MathOperators.Minus:       // Diese Eigenschaft gibt den Operator als String zurück, z.B. "+" für MathOperators.Plus, "-" für MathOperators.Minus usw.
                        return "-";
                    case MathOperators.Multiply:
                        return "*";
                    case MathOperators.Divide:
                        return "/";
                    case MathOperators.None:
                    default:
                        return "?";                   //  Wenn die Eigenschaft None ist, gibt sie ein Fragezeichen zurück.
                }
            }
        }

        #endregion

        #region Public Methods

        public override string ToString()        //  Methode "ToString" gibt ebenfalls eine Zeichenfolge zurück, die den Operator darstellt, der in der "Value"-Eigenschaft gespeichert ist.
        {
            switch (Value)
            {
                case MathOperators.Plus:
                    return "+";
                case MathOperators.Minus:
                    return "-";
                case MathOperators.Multiply:
                    return "*";
                case MathOperators.Divide:
                    return "/";

                case MathOperators.None:
                default:
                    return "?";
            }
        }

        #endregion
    }
}
