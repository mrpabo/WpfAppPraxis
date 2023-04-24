using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÜbungTaschenrechner.Entities      // Dieser Code definiert eine Aufzählung (enum) von Mathematischen Operatoren, die in einem Taschenrechner verwendet werden können.
                                            // Die Aufzählung enthält fünf Operatoren: None (kein Operator), Plus (+), Minus (-), Multiply (*) und Divide (/). Jeder Operator hat einen numerischen Wert, wobei None den Wert 0 hat und Plus, Minus, Multiply und Divide die Werte 1, 2, 3 und 4 haben.
                                            // Diese Aufzählung kann verwendet werden, um die ausgewählten Operatoren im Taschenrechner-Code darzustellen und zu verarbeiten.
{
    public enum MathOperators            // Die Aufzählung (enum) "MathOperators" definiert eine Menge von möglichen mathematischen Operatoren, die in einem Taschenrechner verwendet werden können.
    {
        None,
        Plus,
        Minus,
        Multiply,
        Divide
    }
}
