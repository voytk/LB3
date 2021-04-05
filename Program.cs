using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp37
{
    class MyClass
    {

        private object locker = new object();


        public bool[] kaplia = new bool[10]; //Console.WindowWidth
        public int[] dlinaKapli = new int[10];
        public int[] ostalos = new int[10];
        public char[] simBol = new char[] {'Q','W','E','R','T','Y','U','I','O','P','A','S','D','F','G',
                                           'H','J','K','L','Z','X','C','V','B','N','M','1','2','3','4',
                                           '5','6','7','8','9','0','Й','Ц','У','К','Е','Н','Г','Ш','Щ',
                                           'З','Х','Ъ','Ф','Ы','В','А','П','Р','О','Л','Д','Ж','Э','Я',
                                           'Ч','С','М','И','Т','Ь','Б','Ю','№','@','#','%','$','&','?'};

        private void NextLine()
        {
            if (Console.CursorLeft == 10)
            {
                Console.WriteLine("");
                //Thread.Sleep(500);

            }
        }




        public void Potok(object x)
        {

            Random kap = new Random();
            Random dlina = new Random();
            Random c = new Random();

            while (true)
            {

                lock (locker)
                {
                    if (this.kaplia[(int)x] == false)
                    {

                        if (kap.Next(0, 100) < 10)


                        {
                            this.kaplia[(int)x] = true;
                            this.dlinaKapli[(int)x] = dlina.Next(3, 10);
                            this.ostalos[(int)x] = dlinaKapli[(int)x];
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write((int)x);//simBol[c.Next(0, 59)]+
                            Console.ForegroundColor = ConsoleColor.Red;
                            this.ostalos[(int)x] = this.ostalos[(int)x] - 1;
                            NextLine();
                        }
                        else
                        {
                            Console.Write(" ");
                            NextLine();
                        }

                    }
                    else
                    {

                        if (this.dlinaKapli[(int)x] - this.ostalos[(int)x] == 1)  //(true) 
                        {

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write((int)x);
                            Console.ForegroundColor = ConsoleColor.Red;
                            this.ostalos[(int)x] = this.ostalos[(int)x] - 1;

                            NextLine();
                        }
                        else
                        {

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write((int)x);
                            Console.ForegroundColor = ConsoleColor.Red;
                            this.ostalos[(int)x] = this.ostalos[(int)x] - 1;

                            this.kaplia[(int)x] = (this.ostalos[(int)x] == 0) ? false : true;
                            NextLine();
                        }

                    }



                }

            }
        }
    }



    class Program
    {
        static void Main()
        {
            MyClass instance = new MyClass();

            Thread thread;


            for (int i = 0; i < 10 - 1; i++)
            {
                thread = new Thread(new ParameterizedThreadStart(instance.Potok));
                thread.Start(i);
            }


            Console.ReadKey();

        }
    }
}

