using System;
using System.Collections.Generic;

namespace lab4
{
    public class RPNCalculator
    {
        private LinkedList<Token> _tokens;
        private LinkedListNode<Token> _curr;
        public RPNCalculator(LinkedList<Token> tokens)
        {
            _tokens = tokens;
            _curr = tokens.First;
        }

        private Token Peek()
        {
            return _curr.Value;
        }

        private void Next()
        {
            _curr = _curr.Next;
        }

        private void Prev()
        {
            _curr = _curr.Previous;
        }

        private Token PeekNext()
        {
            _curr = _curr.Next;
            return _curr.Previous.Value;
        }

        private void Reset()
        {
            _curr = _tokens.First;
        }

        private void SetLast()
        {
            _curr = _tokens.Last;
        }

        // public IExpression Parse()
        // {
            
        // }

        public int Calculate()
        {
            var stack = new Stack<int>();

            Reset();
            while (Peek().type != TokenType.EOF)
            {
                var token = Peek();

                switch (token.type)
                {

                    case TokenType.OperationPlus:
                        var right = stack.Pop();
                        var left = stack.Pop();
                        stack.Push(left + right);
                        break;

                    case TokenType.OperationMinus:
                        right = stack.Pop();
                        left = stack.Pop();
                        stack.Push(left - right);
                        break;

                    case TokenType.OperationMultiply:
                        right = stack.Pop();
                        left = stack.Pop();
                        stack.Push(left * right);
                        break;

                    case TokenType.OperationDivide:
                        right = stack.Pop();
                        left = stack.Pop();
                        stack.Push(left / right);
                        break;

                    case TokenType.Number:
                        stack.Push(Peek().ToInt());
                        break;

                    default:
                        throw new Exception($"Expected number or operation, found {token.type}");
                }

                Next();
            }

            return stack.Pop();
        }
    }
}