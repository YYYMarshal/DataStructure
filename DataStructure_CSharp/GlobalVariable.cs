using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure_CSharp
{
    public class GlobalVariable
    {
        private static readonly Lazy<GlobalVariable> lazy = new Lazy<GlobalVariable>(() => new GlobalVariable());
        public static GlobalVariable Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public int MaxSize = 100;
    }
}
