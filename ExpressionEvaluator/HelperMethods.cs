using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpressionEvaluator
{
    public class HelperMethods
    {

        /// <summary>
        /// Returns a boolean specifying if the character at the current pointer is a valid number
        /// i.e. it starts with a number or a minus sign immediately followed by a number
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static bool IsANumber(string str, int ptr)
        {
            return
                (ptr == 0 || IsCalcOperator(str, ptr - 1)) && (str[ptr] == '-') && IsNumeric(str, ptr + 1) ||
                IsNumeric(str, ptr);
        }

        /// <summary>
        /// 不是计算操作符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ptr"></param>
        /// <returns></returns>
        private static bool IsCalcOperator(string str, int ptr)
        {
            return ptr >= 0 && ptr < str.Length && ".*/%+-<>=&^|".IndexOf(str[ptr]) > 0;
        }

        /// <summary>
        /// Returns a boolean specifying if the character at the current point is of the range '0'..'9'
        /// </summary>
        /// <param name="str"></param>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static bool IsNumeric(string str, int ptr)
        {
            if ((ptr >= 0) & (ptr < str.Length))
                return (str[ptr] >= '0' & str[ptr] <= '9');
            return false;
        }

        public static bool IsHexStart(string str, int ptr)
        {
            if ((ptr >= 0) & (ptr + 2 < str.Length))
                return (str[ptr] == '-' & str[ptr + 1] == '0' & str[ptr + 2] == 'x');
            if ((ptr >= 0) & (ptr + 1 < str.Length))
                return (str[ptr] == '0' & str[ptr + 1] == 'x');
            return false;
        }

        public static bool IsHex(string str, int ptr)
        {
            if ((ptr >= 0) & (ptr < str.Length))
                return (str[ptr] >= '0' & str[ptr] <= '9') | (str[ptr] >= 'A' & str[ptr] <= 'F') | (str[ptr] >= 'a' & str[ptr] <= 'f');
            return true;
        }

        public static bool IsAlpha(char chr)
        {
            return (chr >= 'A' & chr <= 'Z') || (chr >= 'a' & chr <= 'z');
        }

        public static bool IsChineseChar(char chr)
        {
            return chr > '\u4e00' && chr < '\u9fbb';
        }
    }
}
