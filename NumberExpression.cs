namespace lab4
{
    public class NumberExpression : IExpression
    {
        private int _value;

        public NumberExpression(int value)
        {
            _value = value;
        }

        public NumberExpression(Token token)
        {
            _value = int.Parse(token.ToString());
        }

        public int Calculate()
        {
            return _value;
        }

        public override System.String ToString()
        {
            return $"{_value}";
        }

        public System.String Get1Notation()
        {
            return ToString();
        }

        public System.String Get2Notation()
        {
            return ToString();
        }

        public System.String Get3Notation()
        {
            return ToString();
        }
    }
}