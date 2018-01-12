using System;
using System.Collections.Generic;
using System.Text;

namespace 记事本
{
    class FunctionEventArgs : EventArgs
    {
        public readonly int _choose;
        //只能在声明的时候赋值或在构造函数中赋值
        public FunctionEventArgs(int choose)
        {
            this._choose = choose;
        }
    }
}
