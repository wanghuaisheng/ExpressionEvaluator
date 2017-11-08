using System;
namespace ExpressionEvaluator.Operators
{
    /// <summary>
    /// 操作符基类
    /// </summary>
    /// <typeparam name="T">委托类型</typeparam>
    internal abstract class Operator<T> : IOperator
    {
        /// <summary>
        /// 执行调用委托
        /// </summary>
        public T Func;
        /// <summary>
        /// 值，eg“+”号
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        public int Precedence { get; set; }
        /// <summary>
        /// 参数个数
        /// </summary>
        public int Arguments { get; set; }
        /// <summary>
        /// 是否左联操作符
        /// </summary>
        public bool LeftAssoc { get; set; }
        /// <summary>
        /// 操作符泛型基类
        /// </summary>
        /// <param name="value">值，eg“+”号</param>
        /// <param name="precedence">优先级</param>
        /// <param name="leftassoc">是否左联操作符</param>
        /// <param name="func">执行调用委托</param>
        protected Operator(string value, int precedence, bool leftassoc, T func)
        {
            this.Value = value;
            this.Precedence = precedence;
            this.LeftAssoc = leftassoc;
            this.Func = func;
        }

    }
}
