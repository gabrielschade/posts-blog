using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public static class Extensao
    {
        public static bool Par(this int numero)
            => numero % 2 == 0;
        

        public static bool MaiorQue(this int numero, int segundoNumero)
            => numero > segundoNumero;
        
    }
}
