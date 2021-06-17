
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
    public class SequentialStack<T>
    {
        /// <summary>
        /// (TQ)初始化栈
        /// </summary>
        /// <param name="sqStack"></param>
        public void InitStack(SqStack<T> sqStack)
        {
            sqStack.top = -1;
        }
        public T GetTop(SqStack<T> sqStack)
        {
            if (sqStack.top == -1)
                return default;
            return sqStack.data[sqStack.top];
        }
        /// <summary>
        /// (TQ)进栈
        /// </summary>
        /// <param name="sqStack"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Push(SqStack<T> sqStack, T data)
        {
            if (sqStack.top == sqStack.data.Length - 1)
                return false;
            sqStack.data[++sqStack.top] = data;
            return true;
        }
        /// <summary>
        /// (TQ)出栈
        /// </summary>
        /// <param name="sqStack"></param>
        /// <returns></returns>
        public T Pop(SqStack<T> sqStack)
        {
            if (sqStack.top == -1)
                return default;
            return sqStack.data[sqStack.top--];
        }
        /// <summary>
        /// (TQ)判断是否为空栈
        /// </summary>
        /// <param name="sqStack"></param>
        /// <returns></returns>
        public bool IsStackEmpty(SqStack<T> sqStack)
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
        public int Conversion(int num, int d)
        {
            string result = "";
            SqStack<int> sqStack = new SqStack<int>();
            SequentialStack<int> function = new SequentialStack<int>();
            function.InitStack(sqStack);
            while (num > 0)
            {
                function.Push(sqStack, num % d);
                num /= d;
            }
            while (!function.IsStackEmpty(sqStack))
            {
                result += function.Pop(sqStack);
            }
            return Convert.ToInt32(result);
        }
        #endregion
    }
}