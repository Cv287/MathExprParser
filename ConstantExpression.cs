namespace lab4
{
    public class ConstantExpression : IExpression
    {
        private char _value;

        public ConstantExpression(char c)
        {
            _value = c;
        }

        public ConstantExpression(string source)
        {
            _value = char.Parse(source);
        }

        public ConstantExpression(Token t)
        {
            _value = char.Parse(t.ToString());
        }

        public int Calculate()
        {
            throw new System.Exception("Can't calculate a letter!");
        }

        public override System.String ToString()
        {
            return _value.ToString();
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