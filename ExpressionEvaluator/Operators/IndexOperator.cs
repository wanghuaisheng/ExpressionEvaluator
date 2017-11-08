using System;
using System.Linq.Expressions;

namespace ExpressionEvaluator.Operators
{
    /// <summary>
    /// Ë÷Òý²Ù×÷·û
    /// </summary>
    internal class IndexOperator : Operator<Func<Expression, Expression, Expression>>
    {
        public IndexOperator(string value, int precedence, bool leftassoc, Func<Expression, Expression, Expression> func)
            : base(value, precedence, leftassoc, func)
        {
        }
    }
}