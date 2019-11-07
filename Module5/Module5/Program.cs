using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mines = GenerateMines();
            (int rowPosition, int columnPosition, int healthPoint, bool iconPlayer) player = StartPosition();
            while (true)
            {
                if (player.healthPoint < 0)
                {
                    Death();
                    Thread.Sleep(1000);
                    Field(ref player, mines, true);
                    Thread.Sleep(2500);
                    Death();
                    Console.WriteLine("\nIf you want to repeat the game press ENTER, else ESC...");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Escape: return;
                        case ConsoleKey.Enter: { player = StartPosition(); break; }
                        default: break;
                    }
                }
                else if (player.rowPosition == 10 && player.columnPosition == 10)
                {
                    Win();
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Escape: return;
                        case ConsoleKey.Enter: { player = StartPosition(); break; }
                        default: break;
                    }
                }
                else
                {
                    Field(ref player, mines);
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Escape: return;
                        case ConsoleKey.F1: { Help(); break; }
                        case ConsoleKey.DownArrow: { StepDown(ref player); Damage(mines, ref player); break; }
                        case ConsoleKey.LeftArrow: { StepLeft(ref player); Damage(mines, ref player); break; }
                        case ConsoleKey.RightArrow: { StepRight(ref player); Damage(mines, ref player); break; }
                        case ConsoleKey.UpArrow: { StepUp(ref player); Damage(mines, ref player); break; }
                        case ConsoleKey.NumPad2: goto case ConsoleKey.DownArrow;
                        case ConsoleKey.NumPad4: goto case ConsoleKey.LeftArrow;
                        case ConsoleKey.NumPad6: goto case ConsoleKey.RightArrow;
                        case ConsoleKey.NumPad8: goto case ConsoleKey.UpArrow;
                        case ConsoleKey.S: goto case ConsoleKey.DownArrow;
                        case ConsoleKey.A: goto case ConsoleKey.LeftArrow;
                        case ConsoleKey.D: goto case ConsoleKey.RightArrow;
                        case ConsoleKey.W: goto case ConsoleKey.UpArrow;
                    }
                }
            }
        }

        private static void Field(ref (int rowPosition, int columnPosition, int healthPoint, bool iconPlayer) player, int[,] mines, bool visible = false)
        {
            char[,] field = new char[12, 12];
            field[0, 0] = (char)9484;
            field[0, 11] = (char)9488;
            field[11, 0] = (char)9492;
            field[11, 11] = (char)9496;
            field[10, 10] = (char)36;
            if (player.iconPlayer)
                field[player.rowPosition, player.columnPosition] = (char)1;
            else field[player.rowPosition, player.columnPosition] = (char)15;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if ((i == 0 || i == 11) && (j > 0 && j < 11))
                        field[i, j] = (char)9472;
                    if ((j == 0 || j == 11) && (i > 0 && i < 11))
                        field[i, j] = (char)9474;
                }
            }
            if (visible == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    field[mines[0, i], mines[1, i]] = (char)15;
                }
            }
            Console.Clear();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    Console.Write("{0} ", field[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\x3 = {0}", player.healthPoint);
            player.iconPlayer = true;
            Thread.Sleep(350);
        }

        private static int[,] GenerateMines()
        {
            int[,] mines = new int[3, 10];
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mines[j, i] = Convert.ToInt16(random.Next(1, 10));
                }
            }
            return mines;
        }

        private static void Damage(int[,] mines, ref (int rowPosition, int columnPosition, int healthPoint, bool iconPlayer) player)
        {
            for (int i = 0; i < 10; i++)
            {
                if (mines[0, i] == player.rowPosition && mines[1, i] == player.columnPosition && mines[2, i] != 0)
                {
                    player.healthPoint -= mines[2, i];
                    mines[2, i] = 0;
                    player.iconPlayer = false;
                    Field(ref player, mines);
                }
            }
        }

        private static void StepDown(ref (int rowPosition, int columnPosition, int healthPoint, bool iconPlayer) player)
        {
            if (player.rowPosition < 10)
                player.rowPosition++;
        }

        private static void StepLeft(ref (int rowPosition, int columnPosition, int healthPoint, bool iconPlayer) player)
        {
            if (player.columnPosition > 1)
                player.columnPosition--;
        }

        private static void StepRight(ref (int rowPosition, int columnPosition, int healthPoint, bool iconPlayer) player)
        {
            if (player.columnPosition < 10)
                player.columnPosition++;
        }

        private static void StepUp(ref (int rowPosition, int columnPosition, int healthPoint, bool iconPlayer) player)
        {
            if (player.rowPosition > 1)
                player.rowPosition--;
        }

        private static void Help()
        {
            Console.Clear();
            Console.WriteLine("{0} - Your place", (char)1);
            Console.WriteLine("{0} - Your target", (char)36);
            Console.WriteLine("{0} - Your health point", (char)3);
            Console.WriteLine("{0} - Mine (damage 1-10 health point)", (char)15);
            Console.WriteLine("{0}, Num8, W - Step up", (char)24);
            Console.WriteLine("{0}, Num2, S - Step down", (char)25);
            Console.WriteLine("{0}, Num6, D - Step right", (char)26);
            Console.WriteLine("{0}, Num4, A - Step left", (char)27);
            Console.WriteLine("Esc - Quit");
            Console.WriteLine("F1 - Help");
            if (Console.ReadKey().Key == ConsoleKey.F1)
            {
                Help();
            }
        }

        private static (int rowPosition, int columnPosition, int healthPoint, bool iconPlayer) StartPosition()
        {
            return (1, 1, 10, true);
        }

        private static void Win()
        {
            Console.Clear();
            Console.WriteLine(" {0}   {0}  {0}{0}{0}  {0}   {0}    {0}{0}{0}{0} {0}{0}{0}   {0}{0}{0}{0}   {0}  {0}  {0} {0} {0}   {0}", (char)3);
            Console.WriteLine(" {0}   {0} {0}   {0} {0}   {0}   {0}   {0} {0}  {0}  {0}      {0}  {0}  {0} {0} {0}{0}  {0}", (char)3);
            Console.WriteLine("  {0}{0}{0}  {0}   {0} {0}   {0}   {0}{0}{0}{0}{0} {0}{0}{0}   {0}{0}{0}{0}   {0} {0}  {0}  {0} {0} {0} {0}", (char)3);
            Console.WriteLine("   {0}   {0}   {0} {0}   {0}   {0}   {0} {0}  {0}  {0}      {0}{0} {0}{0}   {0} {0}  {0}{0}", (char)3);
            Console.WriteLine("   {0}    {0}{0}{0}   {0}{0}{0}    {0}   {0} {0}   {0} {0}{0}{0}{0}   {0}  {0}    {0} {0}   {0}", (char)3);
            Console.WriteLine("\nIf you want to repeat the game press ENTER, else ESC...");
        }

        private static void Death()
        {
            Console.Clear();
            Console.WriteLine(" #   #  ###  #   #    #### ###   ####   ####  # #### #### ");
            Console.WriteLine(" #   # #   # #   #   #   # #  #  #      #   # # #    #   #");
            Console.WriteLine("  ###  #   # #   #   ##### ####  ####   #   # # #### #   #");
            Console.WriteLine("   #   #   # #   #   #   # #  #  #      #   # # #    #   #");
            Console.WriteLine("   #    ###   ###    #   # #   # ####   ####  # #### #### ");
        }
    }
}
