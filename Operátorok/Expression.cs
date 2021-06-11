using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Operátorok
{
    class Expression
    {
        //Static
        private static List<string> ValidOperators = new List<string>
        {
            "+", "-", "/", "mod", "div"
        };

        //Properties
        public bool isValidOperator { get => ValidOperators.Contains(Operator); }

        public int OperandA { get; set; }
        public int OperandB { get; set; }
        public string Operator { get; set; }

        //Constructors
        public Expression(string line)
        {
            string[] s = line.Split(' ');
            OperandA = int.Parse(s[0]);
            Operator = s[1];
            OperandB = int.Parse(s[2]);
        }
       
        //Methods
        //6.
        public string Evaluate()
        {
            try
            {
                double result;
                switch (Operator)
                {
                    case "+": result = OperandA + OperandB; break;
                    case "-": result = OperandA - OperandB; break;
                    case "*": result = OperandA * OperandB; break;
                    case "/": result = (double)OperandA / OperandB; break;
                    case "div": result = OperandA / OperandB; break;
                    case "mod": result = OperandA % OperandB; break;
                    default: return "Hibás operátor!";
                }
                return result.ToString("0.###");
            }
            catch (Exception)
            {
                return "Egyéb hiba";
            }
        }

        public override string ToString()
        {
            return OperandA + " " + Operator + " " + OperandB;
        }
    }
}
