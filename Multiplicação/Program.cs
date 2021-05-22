using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiplicação
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o primeiro número multiplicador: ");
            var num1 = Console.ReadLine();


            Console.WriteLine("Informe o segundo número que deseja multiplicar: ");
            var num2 = Console.ReadLine();

            decimal resultado = Convert.ToDecimal(num1) * Convert.ToDecimal(num2);


            Console.WriteLine($"A multiplicação de {num1} vezes {num2} é = {resultado} ");

            Console.ReadLine();
        }
    }
}
