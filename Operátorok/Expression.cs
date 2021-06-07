using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
            Operator = (Operators)GetEnumFromDescription(s[1], typeof(Operators));
            OperandB = int.Parse(s[2]);
        }

        //Enum kezelő metódusok, külön osztályban lenne a helyük...
        public static string GetDescriptionFromEnumValue(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute =
                Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
        public static int GetEnumFromDescription(string description, Type enumType)
        {
            foreach (var field in enumType.GetFields())
            {
                DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute == null)
                    continue;
                if (attribute.Description == description)
                {
                    return (int)field.GetValue(null);
                }
            }
            return 0;
        }

    }
}
