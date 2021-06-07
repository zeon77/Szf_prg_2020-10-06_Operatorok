using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Operátorok
{
    class Operátorok
    {
        static void Main(string[] args)
        {
            //1.
            List<Expression> expressions = new List<Expression>();
            foreach (var line in File.ReadAllLines("kifejezesek.txt").Skip(1))
                expressions.Add(new Expression(line));

            //Enum Description-ok kezelése
            //string desc = Expression.GetDescriptionFromEnumValue(Expression.Operators.addition);
            //Console.WriteLine(desc);
            //var enumValue = (Expression.Operators)Expression.GetEnumFromDescription("+", typeof(Expression.Operators));
            //Console.WriteLine(enumValue);

            //2.
            //TODO: Miért kevesebb egyel?
            Console.WriteLine($"2. feladat: Kifejezések száma: {expressions.Count}");

            Console.ReadKey();
        }
    }
}
