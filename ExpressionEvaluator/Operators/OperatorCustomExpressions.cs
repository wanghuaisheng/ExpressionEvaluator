using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace ExpressionEvaluator.Operators
{
    internal class OperatorCustomExpressions
    {
        /// <summary>
        /// 返回访问成员表达式的表达式
        /// </summary>
        /// <param name="le">拥有成员的表达式</param>
        /// <param name="membername">成员名称</param>
        /// <param name="args">成员为方法时，传递的参数表达式列表</param>
        /// <returns>成员访问表达式</returns>
        public static Expression MemberAccess(Expression le, string membername, List<Expression> args)
        {
            List<Type> argTypes = new List<Type>();
            args.ForEach(x => argTypes.Add(x.Type));

            Expression instance = null;
            Type type = null;
            if (le.Type.Name == "RuntimeType")
            {
                type = ((Type)((ConstantExpression)le).Value);
            }
            else
            {
                type = le.Type;
                instance = le;
            }

            MethodInfo mi = type.GetMethod(membername, argTypes.ToArray());
            if (mi != null)
            {
                ParameterInfo[] pi = mi.GetParameters();
                for (int i = 0; i < pi.Length; i++)
                {
                    args[i] = TypeConversion.Convert(args[i], pi[i].ParameterType);
                }
                return Expression.Call(instance, mi, args);
            }
            else
            {
                Expression exp = null;

                PropertyInfo pi = type.GetProperty(membername);
                if (pi != null)
                {
                    exp = Expression.Property(instance, pi);
                }
                else
                {
                    FieldInfo fi = type.GetField(membername);
                    if (fi != null)
                    {
                        exp = Expression.Field(instance, fi);
                    }
                }

                if (exp != null)
                {
                    if (args.Count > 0)
                    {
                        return Expression.ArrayAccess(exp, args);
                    }
                    else
                    {
                        return exp;
                    }
                }
                else
                {
                    throw new Exception(string.Format("未找到成员: {0}.{1}", le.Type.Name, membername));
                }
            }
        }

        /// <summary>
        /// 让字符串支持+操作符 而扩展的Expression.Add
        /// </summary>
        /// <param name="le">左表达式</param>
        /// <param name="re">右表达式</param>
        /// <returns>添加表达式</returns>
        public static Expression Add(Expression le, Expression re)
        {
            if (le.Type == typeof(string) && re.Type == typeof(string))
            {
                return Expression.Add(le, re, typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }));
            }
            else
            {
                return Expression.Add(le, re);
            }
        }

        /// <summary>
        /// 获取 一维数组索引访问表达式,扩展支持字符串索引访问
        /// </summary>
        /// <param name="le">左表达式</param>
        /// <param name="re">右表达式</param>
        /// <returns>一维数组索引访问表达式</returns>
        public static Expression ArrayAccess(Expression le, Expression re)
        {
            if (le.Type == typeof(string))
            {
                MethodInfo mi = typeof(string).GetMethod("ToCharArray", new Type[] { });
                le = Expression.Call(le, mi);
            }
            return Expression.ArrayAccess(le, re);
        }

    }
}