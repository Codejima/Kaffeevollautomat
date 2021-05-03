using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kaffeevollautomat
{
    class UI
    {
        const char _block = '■';
        const string _back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
        const string _twirl = "-\\|/";
        public static void WriteProgressBar(int percent, bool update = false)
        {
            if (update)
                Console.Write(_back);
            Console.Write("[");
            var p = (int)((percent / 10f) + .5f);
            for (var i = 0; i < 10; ++i)
            {
                if (i >= p)
                    Console.Write(' ');
                else
                    Console.Write(_block);
            }
            Console.Write("] {0,3:##0}%", percent);
        }
        public static void WriteProgress(int progress, bool update = false)
        {
            if (update)
                Console.Write("\b");
            Console.Write(_twirl[progress % _twirl.Length]);
        }
        public void ProgressBar()
        {
            WriteProgressBar(0);
            for (var i = 0; i <= 100; ++i)
            {
                WriteProgressBar(i, true);
                Thread.Sleep(50);
            }
            Console.WriteLine();
            WriteProgress(0);
            for (var i = 0; i <= 100; ++i)
            {
                WriteProgress(i, true);
                Thread.Sleep(5);
            }
        }
        public void Logo()
        {
            Console.WriteLine(@"   ___          _       _ _                     ___       __  __           ");
            Console.WriteLine(@"  / __\___   __| | ___ (_|_)_ __ ___   __ _    / __\___  / _|/ _| ___  ___ ");
            Console.WriteLine(@" / /  / _ \ / _` |/ _ \| | | '_ ` _ \ / _` |  / /  / _ \| |_| |_ / _ \/ _ \");
            Console.WriteLine(@"/ /__| (_) | (_| |  __/| | | | | | | | (_| | / /__| (_) |  _|  _|  __/  __/");
            Console.WriteLine(@"\____/\___/ \__,_|\___|/ |_|_| |_| |_|\__,_| \____/\___/|_| |_|  \___|\___|");
            Console.WriteLine(@"                     |__/                                                  ");
            //Console.WindowWidth;
        }
    }
}
