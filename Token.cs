using System;

namespace lab4
{
    static class Char
    {
        public static Boolean IsOperation(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/')
            {
                return true;
            }
            return false;
        }

        public static Boolean IsParen(char c)
        {
            return (c == '(' || c == ')');
        }
    }

    public enum TokenType
    {
        Number,
        Constant,
        OperationPlus,
        OperationMinus,
        OperationMultiply,
        OperationDivide,
        LeftParen,
        RightParen,
        EOF
    }

    public class Token
    { 
        private String _body;
        public TokenType type;
        
        public Token()
        {
            this._body = "";
        }

        public Token(string source, TokenType type)
        {
            this._body = source;
            this.type = type;
        }

        public int ToInt()
        {
            if (type == TokenType.Number)
            {
                return int.Parse(_body);
            }
            throw new Exception($"Tried ToInt() on Token but its type: {type}");
        }

        public override String ToString()
        {
            return this._body;
        }
    }
}