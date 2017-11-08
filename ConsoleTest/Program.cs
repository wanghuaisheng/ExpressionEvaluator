using ExpressionEvaluator;
using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static Dictionary<string, Func<Para, int, decimal>> exprDic = new Dictionary<string, Func<Para, int, decimal>>();
        static void Main(string[] args)
        {
            Test2();

            Console.ReadLine();
        }

        static Dictionary<string, Func<decimal, decimal, decimal>> exprDic1 = new Dictionary<string, Func<decimal, decimal, decimal>>();
        private static void Test2()
        {
            string key = "10M";
            if (!exprDic.ContainsKey(key))
            {
                CompiledExpression exp = new CompiledExpression(key);
                exp.RegisterDefaultTypes();
                exp.RegisterParameter("Y", typeof(decimal));
                exp.RegisterParameter("X", typeof(decimal));
                //exp.BuildTree();
                var expr = exp.Compile<Func<decimal, decimal, decimal>>();
                exprDic1[key] = expr;
            }
            Console.WriteLine(exprDic1[key](1, 2));
            Console.WriteLine(exprDic1[key](1, 3));
        }

        private static void Test1()
        {
            string key = "3M +Para.Val('单价')*X";
            if (!exprDic.ContainsKey(key))
            {
                CompiledExpression exp = new CompiledExpression(key);
                exp.RegisterDefaultTypes();
                exp.RegisterParameter("Para", typeof(Para));
                exp.RegisterParameter("X", typeof(int));
                //exp.BuildTree();
                var expr = exp.Compile<Func<Para, int, decimal>>();
                exprDic[key] = expr;
            }
            Console.WriteLine(exprDic[key](new Para { Price = 10 }, 5));
            Console.WriteLine(exprDic[key](new Para { Price = 20 }, 8));
        }
    }
}
