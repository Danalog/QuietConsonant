using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utauPlugin;
using System.Text.RegularExpressions;

namespace QuietConsonant
{
    class Program
    {
        static void Main(string[] args)
        {
            UtauPlugin utauPlugin = new UtauPlugin(args[0]);
            utauPlugin.Input();

            foreach (Note note in utauPlugin.note)
            {
                string noteLyric = note.GetLyric();

                Regex findConsonantTransition = new Regex("([mrln])([ ])(.*)");

                Regex catchNasalTransition = new Regex("ng([ ])(.*)");

                bool isConsonantTransition = findConsonantTransition.IsMatch(noteLyric);

                bool isNasalTransition = catchNasalTransition.IsMatch(noteLyric);

                if (isConsonantTransition == true)
                {
                    string currentFlags = note.GetFlags();

                    string flags = currentFlags + "P0";

                    note.SetFlags(flags);
                }    

                if (isNasalTransition == true)
                {
                    string currentFlags = note.GetFlags();

                    string flags = currentFlags + "P0";

                    note.SetFlags(flags);
                }    
            }    

            utauPlugin.Output();
        }

    }
}
