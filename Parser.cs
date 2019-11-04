using System;
using System.Collections.Generic;

namespace lab4
{
    public class Parser
    {
        private LinkedList<Token> _tokens;
        private LinkedListNode<Token> _curr;
        public Parser(LinkedList<Token> tokens)
        {
            _tokens = tokens;
            _curr = _tokens.First;
        }

        private Token Peek()
        {
            return _curr.Value;
        }

        private void Next()
        {
            _curr = _curr.Next;
        }

        private Token PeekNext()
        {
            _curr = _curr.Next;
            return _curr.Value;
        }

        public IExpression Parse()
        {
            return ParseAddSubExpression();
        }

        public IExpression ParseAddSubExpression()
        {
            var token = Peek();
            IExpression res = ParseMulDivExpression();

            while (true)
            {
                switch (Peek())
                {
                    case Token tok when tok.type == TokenType.OperationPlus:
                        PeekNext();
                        res = new BinaryExpression(res, ParseMulDivExpression(), OperationType.Plus);
                        break;

                    case Token tok when tok.type == TokenType.OperationMinus:
                        PeekNext();
                        res = new BinaryExpression(res, ParseMulDivExpression(), OperationType.Minus);
                        break;

                    default:
                        return res;
                }
            }
        }
        public IExpression ParseMulDivExpression()
        {
            // var token = Peek();
            IExpression res = ParsePrimaryExpression();

            while (true)
            {
                switch (Peek())
                {
                    case Token tok when tok.type == TokenType.OperationMultiply:
                        PeekNext();
                        res = new BinaryExpression(res, ParsePrimaryExpression(), OperationType.Multiply);
                        break;

                    case Token tok when tok.type == TokenType.OperationDivide:
                        PeekNext();
                        res = new BinaryExpression(res, ParsePrimaryExpression(), OperationType.Divide);
                        break;

                    default:
                        return res;
                }
            }
        }

        public IExpression ParsePrimaryExpression()
        {
            var token = Peek();

            switch (token.type)
            {
                case TokenType.Number:
                    return ParseNumberExpression(token);

                case TokenType.Constant:
                    return ParseConstantExpression();

                case TokenType.LeftParen:
                case TokenType.RightParen:
                    return ParseParenthesesExpression();

                default:
                    throw new Exception($"ParsePrimaryExpression error. Found {token}");
            }
        }

        private IExpression ParseParenthesesExpression()
        {
            var token = Peek();

            switch (token.type)
            {
                case TokenType.LeftParen:
                    Next();
                    var res = ParseAddSubExpression();

                    if (Peek().type != TokenType.RightParen)
                    {
                        throw new Exception($"ParseParanthesesExpr error. Expected ')', found {token}");
                    }

                    Next();
                    return res;

                default:
                    throw new Exception($"ParseParenthesesExpr error. Expected '(', found {token}");
            }
        }

        public IExpression ParseNumberExpression(Token token)
        {
            if (token.type == TokenType.Number)
            {
                Next();
                return new NumberExpression(token);
            }
            else
            {
                throw new Exception($"Tried to parse not a number in ParseNumberExpression, but {token}");
            }
        }

        private IExpression ParseConstantExpression()
        {
            if (Peek().type == TokenType.Constant)
            {
                String token_body = Peek().ToString();
                Next();
                return new ConstantExpression(token_body);
            }
            else
            {
                throw new Exception($"Expected constant, found {Peek()}");
            }
        }    
    }
}