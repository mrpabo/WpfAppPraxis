namespace ÜbungTaschenrechner.Entities
{
    public class MathOperator : ModelBase, IMathOperator
    {
        #region Constructor

        public MathOperator(MathOperators value)
        {
            Value = value;
        }

        #endregion

        #region Public Properties

        public MathOperators Value { get; set; } = MathOperators.Plus;

        public string ValueString
        {
            get
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
        }

        #endregion

        #region Public Methods

        public override string ToString()
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
