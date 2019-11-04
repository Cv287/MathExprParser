using System;

namespace lab4
{
    public interface IExpression
    {
        public int Calculate();
        public String Get1Notation();
        public String Get2Notation();
        public String Get3Notation();
    }
}