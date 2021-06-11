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
            foreach (var line in File.ReadAllLines("kifejezesek.txt"))
                expressions.Add(new Expression(line));

            //2.
            Console.WriteLine($"2. feladat: Kifejezések száma: {expressions.Count}");

            //3.
            var mod = expressions.Where(x => x.Operator == "mod").Count();
            Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {mod}");

            //4.
            Console.WriteLine($"4. feladat: {(expressions.Any(x => x.OperandA % 10 == 0 && x.OperandB % 10 == 0) ? "Van" : "Nincs")} ilyen kifejezés.");

            //5.
            Console.WriteLine($"5. feladat: Statisztika");
            expressions
                .Where(x => x.isValidOperator)
                .GroupBy(x => x.Operator)
                .Select(gr => new { Operator = gr.Key, Count = gr.Count() }).ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Operator,3} -> {x.Count} db"));

            //7.
            Console.Write($"7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
            string ex = Console.ReadLine();
            while (ex != "vége")
            {
                Expression e = new Expression(ex);
                Console.WriteLine($"\t{e.ToString()} = {e.Evaluate()}");
                Console.Write($"7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                ex = Console.ReadLine();
            }

            //8.
            Console.WriteLine($"8. feladat: eredemenyek.txt");
            List<string> lines = new List<string>();
            expressions.ForEach(x => lines.Add($"{x.ToString()} = {x.Evaluate()}"));
            File.WriteAllLines("eredmenyek.txt", lines);

            Console.ReadKey();
        }
    }
}
