namespace ExpressionEvaluator.Operators
{
    /// <summary>
    /// �������ӿ�
    /// </summary>
    internal interface IOperator
    {
        /// <summary>
        /// ֵ
        /// </summary>
        string Value { get; set; }
        /// <summary>
        /// ���ȼ�
        /// </summary>
        int Precedence { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        int Arguments { get; set; }
        /// <summary>
        /// �Ƿ���������
        /// </summary>
        bool LeftAssoc { get; set; }
    }
}