using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Expression: ");
            String expr = Console.ReadLine();

            var tokenizer = new Tokenizer(expr);

            var tokens = tokenizer.Tokenize();

            Console.WriteLine($"tokens: {tokenizer.ToString()}");

            // var rpnCalculator = new RPNCalculator(tokens);

            // var res1 = rpnCalculator.Calculate();

            // Console.WriteLine($"res: {res1}");
   

            var parser = new Parser(tokens);

            var res = parser.Parse();

            Console.WriteLine($"Postfix form: {res.Get1Notation()}");
            Console.WriteLine($"Prefix form: {res.Get2Notation()}");
            Console.WriteLine($"Infix form: {res.Get3Notation()}");

            Console.WriteLine($"res of expr: {res.Calculate()}");
        }
    }
}
