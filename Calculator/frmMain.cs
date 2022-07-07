using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        double currentValue = 0;   //第1个数 
        double numSum = 0;  //第2个数
        private EnumOperator currentOperator; //当前操作符  


        /// <summary>
        /// 按数字的时候
        /// </summary>
        /// <param name="strNumber"></param>
        private void NumberClick(string strNumber)
        {
            lblMain.Text = lblMain.Text + strNumber;
            currentValue = Convert.ToDouble(lblMain.Text);

            lblFu.Text += strNumber;
        }
        /// <summary>
        /// 定义一个枚举运算符参数的函数
        /// 里面调用DisplayOperator方法
        /// </summary>
        /// <param name="op"></param>
        private void OperatorClick(EnumOperator op)
        {
            if (currentOperator != EnumOperator.None)
            {
                //计算
                Evaluate();
            }
            else
            {
                //numSum = double.Parse(lblResult.Text);
                double.TryParse(lblMain.Text, out numSum);
            }

            DisplayOperator(op);

            lblMain.Text = "";
            currentOperator = op;
        }

        /// <summary>
        /// 根据运算符号来执行四则运算显示的内容
        /// </summary>
        /// <param name="op"></param>
        private void DisplayOperator(EnumOperator op)
        {
            //选择判断
            switch (op)
            {
                case EnumOperator.None:
                    lblFu.Text = lblMain.Text;
                    lblFu.Text += "";
                    break;
                case EnumOperator.Add:
                    if (lblMain.Text != "")
                    {
                        lblFu.Text = lblMain.Text;
                    }
                    lblFu.Text += "+";
                    break;
                case EnumOperator.Minus:
                    if (lblMain.Text != "")
                    {
                        lblFu.Text = lblMain.Text;
                    }
                    lblFu.Text += "-";
                    break;
                case EnumOperator.Multiply:
                    lblFu.Text = lblMain.Text;
                    lblFu.Text += "x";
                    break;
                case EnumOperator.Divide:
                    lblFu.Text = lblMain.Text;
                    lblFu.Text += "➗";
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 根据运算符和两个数字计算结果
        /// 调用简单工厂模式生成的类
        /// </summary>
        private void Evaluate()
        {
            Operation oper;

            //根据不同的对象生成不同的类，多态!
            switch (currentOperator)
            {
                case EnumOperator.None:
                    break;
                    //加
                case EnumOperator.Add:
                    oper = OperationFactory.createOpeate(EnumOperator.Add);
                    oper.NumberA = numSum;
                    oper.NumnberB = currentValue;
                    numSum = oper.GetResult();
                    break;
                    //减
                case EnumOperator.Minus:
                    oper = OperationFactory.createOpeate(EnumOperator.Minus);
                    oper.NumberA = numSum;
                    oper.NumnberB = currentValue;
                    numSum = oper.GetResult();
                    break;
                    //乘
                case EnumOperator.Multiply:
                    oper = OperationFactory.createOpeate(EnumOperator.Multiply);
                    oper.NumberA = numSum;
                    oper.NumnberB = currentValue;
                    numSum = oper.GetResult();
                    break;
                    //除
                case EnumOperator.Divide:
                    //判断结果
                    if (currentValue != 0)
                    {
                        oper = OperationFactory.createOpeate(EnumOperator.Divide);
                        oper.NumberA = numSum;
                        oper.NumnberB = currentValue;
                        numSum = oper.GetResult();
                    }
                    else
                    {
                        MessageBox.Show("除数不能为0");
                    }
                    break;
            }
            currentValue = 0;
            currentOperator = EnumOperator.None;
        }
        #region 数字引用
        
        //数字0
        private void button9_Click(object sender, EventArgs e)
        {
            NumberClick(btn0.Text);
        }
        //数字1
        private void button11_Click(object sender, EventArgs e)
        {
            NumberClick(btn1.Text);
        }
        //数字2
        private void button6_Click(object sender, EventArgs e)
        {
            NumberClick(btn2.Text);
        }
        //数字3
        private void button7_Click(object sender, EventArgs e)
        {
            NumberClick(btn3.Text);
        }
        //数字4
        private void button8_Click(object sender, EventArgs e)
        {
            NumberClick(btn4.Text);
        }
        //数字5
        private void button5_Click(object sender, EventArgs e)
        {
            NumberClick(btn5.Text);
        }
        //数字6
        private void button4_Click(object sender, EventArgs e)
        {
            NumberClick(btn6.Text);
        }
        //数字7
        private void button3_Click(object sender, EventArgs e)
        {
            NumberClick(btn7.Text);
        }
        //数字8
        private void button2_Click(object sender, EventArgs e)
        {
            NumberClick(btn8.Text);
        }
        //数字9
        private void button1_Click(object sender, EventArgs e)
        {
            NumberClick(btn9.Text);
        }

        #endregion
        //加+
        private void button12_Click(object sender, EventArgs e)
        {
            OperatorClick(EnumOperator.Add);
        }

        //减-
        private void button13_Click(object sender, EventArgs e)
        {
            OperatorClick(EnumOperator.Minus);
        }

        //乘x
        private void button14_Click(object sender, EventArgs e)
        {
            OperatorClick(EnumOperator.Multiply);
        }

        //初÷
        private void button15_Click(object sender, EventArgs e)
        {
            OperatorClick(EnumOperator.Divide);
        }

        //等于＝
        private void button10_Click(object sender, EventArgs e)
        {
            Evaluate();
            lblMain.Text = numSum.ToString();

            //防止一直重复按 = 
            if (lblMain.Text.Length > 1 && lblMain.Text.Substring(lblMain.Text.Length - 1) != "=")
            {
                lblMain.Text += "=";
            }
        }
        
        //删一格
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lblMain.Text=="")
            {
                //调用归零
                gui0();
                return;
            }
            this.lblMain.Text = lblMain.Text.Substring(0, this.lblMain.Text.Length - 1);//主显示删一格
            this.lblFu.Text = lblFu.Text.Substring(0, this.lblFu.Text.Length - 1);//副显示与主显示同步
        }

        //归零
        private void button16_Click(object sender, EventArgs e)
        {
            gui0();
        }
        /// <summary>
        /// 归零方法
        /// </summary>
        private void gui0()
        {
            currentOperator = EnumOperator.None;
            lblMain.Text = "";
            lblFu.Text = "";
            numSum = 0;
        }

    }
}
