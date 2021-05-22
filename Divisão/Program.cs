using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisão
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o valor que deseja dividir: ");
            var num1 = Console.ReadLine();


            Console.WriteLine("Informe o valor divisor: ");
            var num2 = Console.ReadLine();

            decimal resultado = Convert.ToDecimal(num1) / Convert.ToDecimal(num2);


            Console.WriteLine($"A divisão de {num1} por {num2} é = {resultado} ");

            Console.ReadLine();
        }
    }
}
