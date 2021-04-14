using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
    /// <summary>
    /// Stack: Last In First Out(LIFO)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SequenceStack<T>
    {
        public static void InitStack(SqStack<T> sqStack)
        {
            sqStack.top = -1;
        }
        public static T GetTop(SqStack<T> sqStack)
        {
            if (sqStack.top == -1)
                return default;
            return sqStack.data[sqStack.top];
        }
        public static bool Push(SqStack<T> sqStack, T elem)
        {
            if (sqStack.top == sqStack.data.Length - 1)
                return false;
            sqStack.data[++sqStack.top] = elem;
            return true;
        }
        public static T Pop(SqStack<T> sqStack)
        {
            if (sqStack.top == -1)
                return default;
            return sqStack.data[sqStack.top--];
        }
        public static bool StackEmpty(SqStack<T> sqStack)
        {
            return sqStack.top == -1;
        }
        #region Others
        /// <summary>
        /// 十进制数num转换为d进制数
        /// </summary>
        /// <param name="num"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int Conversion(int num, int d)
        {
            string result = "";
            SqStack<int> sqStack = new SqStack<int>();
            SequenceStack<int>.InitStack(sqStack);
            while (num > 0)
            {
                SequenceStack<int>.Push(sqStack, num % d);
                num /= d;
            }
            while (!SequenceStack<int>.StackEmpty(sqStack))
            {
                result += SequenceStack<int>.Pop(sqStack);
            }
            return Convert.ToInt32(result);
        }
        #endregion
    }
}
