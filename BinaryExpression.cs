using System;

namespace lab4
{
    public enum OperationType
    {
        Plus,
        Minus,
        Multiply,
        Divide,
    }

    static class OpType
    {
        public static String ToString(OperationType type)
        {
            switch (type)
            {
                case OperationType.Plus:
                    return "+";
                case OperationType.Minus:
                    return "-";
                case OperationType.Multiply:
                    return "*";
                case OperationType.Divide:
                    return "/";
            }
            return "";
        }
    }

    public class BinaryExpression : IExpression
    {
        private IExpression _n1;
        private IExpression _n2;
        private OperationType _opType;

        public BinaryExpression(IExpression ne1, IExpression ne2, OperationType type)
        {
            _n1 = ne1;
            _n2 = ne2;
            _opType = type;
        }

        public int Calculate()
        {
            int x1 = _n1.Calculate();
            int x2 = _n2.Calculate();

            switch (_opType)
            {
                case OperationType.Plus:
                    return x1 + x2;

                case OperationType.Minus:
                    return x1 - x2;

                case OperationType.Multiply:
                    return x1 * x2;

                case OperationType.Divide:
                    return x1 / x2;

                default:
                    throw new Exception("Unknown operation in binary expression");
            }
        }

        public override String ToString()
        {
            return $"{_n1} {OpType.ToString(_opType)} {_n2}";
        }

        public String Get1Notation()
        {   
            return $"{_n1.Get1Notation()} {_n2.Get1Notation()} {OpType.ToString(_opType)}";
        }

        public String Get2Notation()
        {
            return $"{OpType.ToString(_opType)} {_n1.Get2Notation()} {_n2.Get2Notation()}";
        }

        public String Get3Notation()
        {
            return $"({_n1.Get3Notation()} {OpType.ToString(_opType)} {_n2.Get3Notation()})";
        }
    }
}