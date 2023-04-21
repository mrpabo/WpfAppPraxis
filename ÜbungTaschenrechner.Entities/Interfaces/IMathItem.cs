using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ÜbungTaschenrechner.Entities;

namespace ÜbungTaschenrechner.Entities
{
    public interface IMathItem 
    {
        string ValueString { get; }
    }

    public interface IMathOperator : IMathItem
    {
        MathOperators Value { get; set; }
    }

    public interface IMathOperand : IMathItem
    {
        double Value { get; set; }
    }
    
}
