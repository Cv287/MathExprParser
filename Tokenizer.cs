using System;
using System.Text;
using System.Collections.Generic;

namespace lab4
{
    public class Tokenizer
    {
        String _body;
        private int _position;
        private LinkedList<Token> tokens;
        
        public Tokenizer(String source)
        {
            this._body = source;
            this._position = 0;
        }

        private int GetPosition()
        {
            return _position;
        }

        private void Next()
        {
            ++_position;
        }

        private char Peek()
        {
            return (_position >= _body.Length) ? '\0' : _body[_position];
        }

        private char PeekNext()
        {
            return ((_position + 1) >= _body.Length) ? '\0' : _body[_position];
        }

        private bool IsEOF()
        {
            return _position >= _body.Length;
        }

        public LinkedList<Token> Tokenize()
        {
            this.tokens = new LinkedList<Token>();

            while (!IsEOF())
            {
                char value = Peek();

                switch(value)
                {
                    case var c when char.IsWhiteSpace(c):
                        Next();
                        break;

                    case var c when char.IsDigit(c):
                        tokens.AddLast(TokenizeNumber());
                        break;

                    case var c when char.IsLetter(c):
                        tokens.AddLast(TokenizeConstant());
                        break;

                    case var c when Char.IsOperation(c):
                        tokens.AddLast(TokenizeOperation());
                        break;

                    case var c when Char.IsParen(c):
                        tokens.AddLast(TokenizeParen());
                        break;

                    default:
                        throw new Exception($"Unknown character {Peek()} at position {GetPosition()}");
                    }
                }

                tokens.AddLast(new Token("\0", TokenType.EOF));
                return tokens;
        }

        private Token TokenizeNumber()
        {
            var token_body = new StringBuilder();

            while (char.IsDigit(Peek()))
            {
                token_body.Append(Peek());
                Next();
            }
            
            return new Token(token_body.ToString(), TokenType.Number);
        }

        private Token TokenizeConstant()
        {
            var token_body = Peek().ToString();
            Next();
            return new Token(token_body, TokenType.Constant);
        }

        private Token TokenizeOperation()
        {
            char operation = Peek();
            TokenType type = new TokenType();

            switch (operation)
            {
                case '+': 
                    type = TokenType.OperationPlus;
                    break;
                
                case '-':
                    type = TokenType.OperationMinus;
                    break;

                case '*':
                    type = TokenType.OperationMultiply;
                    break;

                case '/':
                    type = TokenType.OperationDivide;
                    break;

                default:
                    throw new Exception($"Undefined operation {operation} at position {GetPosition()}");
            }
            
            Next();
            return new Token(operation.ToString(), type);
        }

        private Token TokenizeParen()
        {
            char paren = Peek();
            var type = new TokenType();
            type = (paren == '(') ? TokenType.LeftParen : TokenType.RightParen;
            Next();
            return new Token(paren.ToString(), type);
        }

        public override String ToString()
        {
            String res = "";

            foreach (var token in tokens)
            {
                res += token.ToString() + " ";
            }

            return res;
        }
    }
}