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



            Console.ReadKey();
        }
    }
}
