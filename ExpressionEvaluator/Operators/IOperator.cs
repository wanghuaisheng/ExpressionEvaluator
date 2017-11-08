namespace ExpressionEvaluator.Operators
{
    /// <summary>
    /// 操作符接口
    /// </summary>
    internal interface IOperator
    {
        /// <summary>
        /// 值
        /// </summary>
        string Value { get; set; }
        /// <summary>
        /// 优先级
        /// </summary>
        int Precedence { get; set; }
        /// <summary>
        /// 参数个数
        /// </summary>
        int Arguments { get; set; }
        /// <summary>
        /// 是否左联操作
        /// </summary>
        bool LeftAssoc { get; set; }
    }
}