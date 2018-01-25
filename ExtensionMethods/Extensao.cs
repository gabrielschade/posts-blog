using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public static class Extensao
    {
        public static bool Par(this int numero)
        {
            return numero % 2 == 0;
        }

        public static bool MaiorQue(this int numero, int segundoNumero)
        {
            return numero > segundoNumero;
        }
    }
}
