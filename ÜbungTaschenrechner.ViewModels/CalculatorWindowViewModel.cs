using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Documents;
using ÜbungTaschenrechner.Entities;
using ResX = ÜbungTaschenrechner.Resources.Resources;                 //ResX ResourcenManager Tool zum Überstzen

namespace ÜbungTaschenrechner.ViewModels
{
    public class CalculatorWindowViewModel : BaseViewModel
    {
        #region Private Variables

        #endregion

        #region Constructor
        public CalculatorWindowViewModel()
        {

        }

        #endregion

        #region Public Properties

        public string CurrentValue { get; set; } = string.Empty;

        public EquationSolver EquationSolver { get; private set; } = new EquationSolver();

        #endregion

        #region Public Methods

        public void NumberPressed(string number)
        {
            if (number == ResX.DecimalPoint && String.IsNullOrEmpty(CurrentValue))
            {
                CurrentValue += "0";
            }

            this.CurrentValue += number.Replace(".", ResX.DecimalPoint);
        }

        public void OperatorPressed(MathOperators op)
        {
            if(String.IsNullOrEmpty(CurrentValue) && EquationSolver.Equation.Last() is IMathOperator)
            {
                var lastOperator = (IMathOperator)EquationSolver.Equation.Last();
                lastOperator.Value = op;
            }
            else
            {
                EquationSolver.AddItem(CurrentValue, op);
                CurrentValue = String.Empty;
            }
        }

        public void EqualsPressed()
        {
            if (String.IsNullOrEmpty(CurrentValue) == false)
            {
                EquationSolver.AddItem(CurrentValue, MathOperators.None);
                CurrentValue = String.Empty;
            }

            double result = EquationSolver.Solve();

            CurrentValue = result.ToString().Replace(",", ResX.DecimalPoint);
        }

        #endregion
    }
}
