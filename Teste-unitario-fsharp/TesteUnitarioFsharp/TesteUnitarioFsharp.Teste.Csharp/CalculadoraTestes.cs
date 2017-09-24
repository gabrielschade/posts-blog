using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteUnitarioFsharp.Teste.Csharp
{
    [TestClass]
    public class CalculadoraTestes
    {
        [TestMethod]
        public void TesteSomando2E3()
        {
            int parcela1 = 2, 
                parcela2 = 3, 
                esperado = 5;

            int resultado = Calculadora.Somar(parcela1, parcela2);
            Assert.AreEqual(esperado, resultado);
        }


    }
}
