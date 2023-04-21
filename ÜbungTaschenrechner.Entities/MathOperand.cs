using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÜbungTaschenrechner.Entities
{
    public class MathOperand : ModelBase, IMathOperand
    {
        #region Constructor

        public MathOperand(double value)
        {
            Value = value;
        }

        #endregion

        #region Public Properties

        public double Value { get; set; }

        public string ValueString => Value.ToString();

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return Value.ToString();
        }

        #endregion
    }
}
