using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ÜbungTaschenrechner.Entities
{
    public class EquationSolver
    {
        #region Constructor

        public EquationSolver()
        {
            Equation = new ObservableCollection<IMathItem>()
            {
                
            };
        }

        #endregion

        #region Public Properties

        public string CurrentText { get; set; }

        public ObservableCollection<IMathItem> Equation { get; set; } = new ObservableCollection<IMathItem>();

        #endregion

        #region Public Methods

        public void AddItem(string number, MathOperators op)
        {
            double value = Convert.ToDouble(number);

            Equation.Add(new MathOperand(value));
             
            if (op != MathOperators.None)
            {
                Equation.Add(new MathOperator(op));
            }
        }

        public double Solve()
        {
            if(Equation.Last() is IMathOperator)
            {
                Equation.RemoveAt(Equation.Count - 1);
            }

            SolveOperation(MathOperators.Multiply);
            SolveOperation(MathOperators.Divide);
            SolveOperation(MathOperators.Plus);
            SolveOperation(MathOperators.Minus);

            var result = Equation.Cast<MathOperand>().First().Value;

            Equation.Clear();

            return result;
        }
        public void SolveOperation(MathOperators mathOperator)
        {
            while(Equation.Where(x => x is MathOperator).Cast<MathOperator>().Any(x => x.Value == mathOperator))
            {
                MathOperator firstOperator = Equation.Where(x => x is MathOperator).Cast<MathOperator>().Where(x => x.Value == mathOperator).First();
                int index = Equation.IndexOf(firstOperator);

                int indexLeftOperand = index - 1;
                MathOperand leftOperand = (MathOperand)Equation[indexLeftOperand];

                int indexRightOperand = index + 1;
                MathOperand rightOperand = (MathOperand)Equation[indexRightOperand];

                MathOperand solvedOperand = null;

                switch (mathOperator)
                {
                    case MathOperators.Plus:
                        solvedOperand = new MathOperand(leftOperand.Value + rightOperand.Value);
                        break;
                    case MathOperators.Minus:
                        solvedOperand = new MathOperand(leftOperand.Value - rightOperand.Value);
                        break;
                    case MathOperators.Multiply:
                        solvedOperand = new MathOperand(leftOperand.Value * rightOperand.Value);
                        break;
                    case MathOperators.Divide:
                        solvedOperand = new MathOperand(leftOperand.Value / rightOperand.Value);
                        break;
                    case MathOperators.None:
                    default:
                        throw new Exception("No Operator available");
                }

                Equation.Remove(leftOperand);
                Equation.Remove(firstOperator);
                Equation.Remove(rightOperand);

                Equation.Insert(indexLeftOperand, solvedOperand);
            }
        }

        #endregion
    }
}
