using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// 操作运算基类
    /// </summary>
    public class Operation
    {
        //两个操作数
        private double _numberA = 0;
        private double _numberB = 0;

        //定义操作数A
        public double NumberA
        {
            get { return _numberA; }
            set { _numberA = value; }
        }

        //定义操作数B
        public double NumnberB
        {
            get { return _numberB; }
            set { _numberB = value; }
        }

        public virtual double GetResult()
        {
            double result = 0d;
            return result;
        }
    }
}
