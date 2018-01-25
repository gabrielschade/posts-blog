using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Extensao.Par(3);         // -> false
            Extensao.MaiorQue(3, 2); // -> true

            int numero = 3;
            numero.Par();       // -> false
            numero.MaiorQue(2); // -> true
        }
    }
}
