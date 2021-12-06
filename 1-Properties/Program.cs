using LaMiaLibreria;

namespace Properties
{
    using System;
    using System.Linq;

    /// <summary>
    /// The seeds of italian cards.
    /// </summary>
    public enum ItalianSeeds
    {
        DENARI,
        COPPE,
        SPADE,
        BASTONI,
    }

    /// <summary>
    /// The names of italian cards.
    /// </summary>
    public enum ItalianNames
    {
        ASSO,
        DUE,
        TRE,
        QUATTRO,
        CINQUE,
        SEI,
        SETTE,
        FANTE,
        CAVALLO,
        RE,
    }

    /// <summary>
    /// The runnable entrypoint of the exercise.
    /// </summary>
    public class Program
    {
        /// <inheritdoc cref="Program" />
        public static void Main()
        {
            DeckFactory df = new DeckFactory();
            
            df.Names = (Enum.GetNames(typeof(ItalianNames)).ToList());
            df.Seeds = (Enum.GetNames(typeof(ItalianSeeds)).ToList());
            
            Console.WriteLine("$The {df.DeckSize} deck has italian cards: ");

            foreach (Card c in df.Deck)
            {
                Console.WriteLine(c);
            }

            //Class1 x = new Class1();
        }
    }
}
