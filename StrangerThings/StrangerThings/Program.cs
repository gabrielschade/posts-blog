using System;

namespace StrangerThings
{
    class Program
    {
        static void Main(string[] args)
        {
            // ##Return
            //int number10 = 10;
            //Func<object, string> toString = obj => obj.ToString();

            //var value10 = UpsideDown<int>.PortalToUpsideDown(number10);
            //var valueToString = UpsideDown<Func<object, string>>.PortalToUpsideDown(toString);

            //var value10ViaExtensions = 10.PortalToUpsideDown();
            //var valueToStringViaExtensions = toString.PortalToUpsideDown();

            // ## Without Apply
            //Func<string, string> messageWithLight = message =>
            //{
            //    Console.WriteLine(message);
            //    return message;
            //};

            //messageWithLight("A");

            //var UpsideDownMessage = messageWithLight.PortalToUpsideDown();
            //UpsideDownMessage("A"); //Compile Error

            //## With Apply
            //Func<string, string> messageWithLight = message =>
            //{
            //    Console.WriteLine(message);
            //    return message;
            //};

            //messageWithLight("A");

            //var UpsideDownMessage = messageWithLight.PortalToUpsideDown();
            //var upsideDownLetter = "A".PortalToUpsideDown();

            //## With Apply Extension Method
            //Func<string, string> messageWithLight = message =>
            //{
            //    Console.WriteLine(message);
            //    return message;
            //};

            //messageWithLight("A");

            //var UpsideDownMessage = messageWithLight.PortalToUpsideDown();
            //var upsideDownLetter = "A".PortalToUpsideDown();

            //var result = upsideDownLetter.Apply(UpsideDownMessage);

            //## Multiples Paramters With Apply 
            //Func<string, string, string> messagesWithLight = (message1, message2) =>
            //{
            //    Console.WriteLine(message1);
            //    Console.WriteLine(message2);
            //    return string.Concat(message1, " ", message2);
            //};

            //messagesWithLight("H","I");

            //var UpsideDownMessages = messagesWithLight.PortalToUpsideDown();
            //var upsideDownLetter = "H".PortalToUpsideDown();
            //var upsideDownLetter2 = "I".PortalToUpsideDown();

            //var result = UpsideDown<string>.Apply(upsideDownLetter, UpsideDownMessages); //CompileError

            //## Map

            UpsideDown<int> elevenPower = 100.PortalToUpsideDown();
            UpsideDown<int> elevenIncreasedPower = 
                UpsideDown<int>.Map(
                    elevenPower, 
                    power => power * 10);

            UpsideDown<int> elevenIncreasedPower2 = 
                elevenPower.Map(power => power * 10);

        }
    }
}
