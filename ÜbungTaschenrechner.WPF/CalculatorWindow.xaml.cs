using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ÜbungTaschenrechner.Entities;
using ÜbungTaschenrechner.ViewModels;
using ResX = ÜbungTaschenrechner.Resources.Resources;

namespace ÜbungTaschenrechner.WPF
{
    public partial class CalculatorWindow : MetroWindow
    {
        #region Private Variables

        private CalculatorWindowViewModel viewModel;

        #endregion

        #region Constructor

        public CalculatorWindow()
        {
            viewModel = new CalculatorWindowViewModel();

            InitializeComponent();

            DataContext = viewModel;
        }

        #endregion

        #region CommandBindings

        private void Cmd_InputNumber_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string number = (string)e.Parameter;

            viewModel.NumberPressed(number);
        }
        private void Cmd_InputNumber_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            string parameter = (string)e.Parameter;

            if(parameter == ResX.DecimalPoint)
            {
                if(viewModel.CurrentValue.Contains(ResX.DecimalPoint) == false)
                {
                    e.CanExecute = true;
                }
            }
            else
            {
                e.CanExecute = true;
            }
        }

        private void Cmd_InputOperator_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string parameter = (string)e.Parameter;

            MathOperators op = MathOperators.None;

            switch(parameter)
            {
                case "Plus":
                    op = MathOperators.Plus;
                    break;
                case "Minus":
                    op = MathOperators.Minus;
                    break;
                case "Multiply":
                    op = MathOperators.Multiply;
                    break;
                case "Divide":
                    op = MathOperators.Divide;
                    break;
            }

            viewModel.OperatorPressed(op);
        }
        private void Cmd_InputOperator_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //if (String.IsNullOrWhiteSpace(viewModel.CurrentValue) == false)
            {
                e.CanExecute = true;
            }
        }

        private void Cmd_Equals_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            viewModel.EqualsPressed();
        }

        private void Cmd_ClearCurrentValue_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            viewModel.CurrentValue = String.Empty;
        }
        private void Cmd_ClearCurrentValue_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(viewModel.CurrentValue) == false)
            {
                e.CanExecute = true;
            }
        }

        private void Cmd_ClearEquation_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            viewModel.EquationSolver.Equation.Clear();
            viewModel.CurrentValue = String.Empty;
        }
        private void Cmd_ClearEquation_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(viewModel.EquationSolver.Equation.Count > 0)
            {
                e.CanExecute^= true;
            }
        }

        private void Cmd_Back_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            viewModel.CurrentValue = viewModel.CurrentValue.Remove(viewModel.CurrentValue.Length - 1);
        }
        private void Cmd_Back_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(viewModel.CurrentValue) == false)
            {
                e.CanExecute = true;
            }
        }

        #endregion

        private void Cmd_Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
