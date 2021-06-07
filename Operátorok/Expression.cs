using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operátorok
{
    class Expression
    {
        public enum Operators
        {
            [Description("+")] addition,
            [Description("-")] subtraction,
            [Description("*")] multiplication,
            [Description("/")] division,
            [Description("mod")] mod,
            [Description("div")] div
        }
        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public Operators Operator { get; set; }

        public Expression(string line)
        {
            string[] s = line.Split(' ');
            OperandA = int.Parse(s[0]);
            OperandB = int.Parse(s[2]);

            var type = Operator.GetType();
            var memInfo = type.GetMember(Operators.addition.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attributes[0]).Description;

            Operator = (Operators) Enum.Parse(typeof(Operators), description, true);
        }
    }
}
