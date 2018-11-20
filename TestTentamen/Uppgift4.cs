namespace TestTentamen
{
    class Uppgift4
    {

        // Interface to adapt to
        public interface ITranslator
        {
            string Greet();
        }

        //Adaptee
        public class SwedishSpeaker
        {
            public string Hälsa()
            {
                return "Hej!";
            }
        }

        //Adapter
        public class SwedishTranslator : ITranslator
        {
            //Adaptee
            private readonly SwedishSpeaker _speaker = new SwedishSpeaker();
            public string Greet()
            {
                return _speaker.Hälsa();
            }
        }


        // Client (user of the adapter)
        public class ArabicSpeaker
        {
            private ITranslator _translator;

            public ArabicSpeaker(ITranslator translator)
            {
                _translator = translator;
            }

            public string ArabicHello()
            {
                return _translator.Greet();
            }
        }
    }
}
