
using System.ComponentModel.DataAnnotations;

namespace Maze
{
    class Program
    {
        static void Main()
        {
            //maze1 = 20 * 20
            //maze2 = 60 * 60
            Console.WriteLine("Псевдо игра: Лабиринт\nЦель игры: Дойти до конца! \nЛабиринт:\n1. 20 * 20  - Нуб даже пройдет\n2. 60 * 60 - Придется не легко\n3. 100 * 100 - Даже Уик не справится\n4. 160 * 60\nВыберите уровень сложности: ");
            var otvet = Console.ReadLine();

            int i = 0;
            int j = 0;

            var wall = '█';
            var player = '☺';
            var end = '⌂';

            try
            {
              string[] nenushno = File.ReadAllLines($"maze{otvet}.txt");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Пожалуйста введите число по уровню!!!");
                Environment.Exit(0);    
            }

            string[] str = File.ReadAllLines($"maze{otvet}.txt");//Читаю файл с лабиринтом и присваиваю одномерному масиву str
            string[] str2;
            int[,] map = new int[str.Length, str[0].Split(' ').Length];//Создаю двумерный массив
            //[0,0][0,1][0,2] и так далее, по столбцам
            for (i = 0; i < str.Length; i++)
            {
                str2 = str[i].Split(' '); //тут же создаем массив по символьно
                for (j = 0; j < str2.Length; j++) 
                    map[i, j] = Int32.Parse(str2[j]); //Преобразуем из строки в int32 и присваиваем двумерному массиву
            }

            ConsoleKeyInfo key;
            Console.CursorVisible = false;
            int x = 0;
            int y = 0;
            int indexX = -1;
            int indexY = -1;
            int playerX = -1;
            int playerY = -1;
            for (i = 0; i < str.Length; i++)
            {
                for (j = 0; j < str.Length; j++)
                {
                    if (map[i, j] == 3)
                    {
                        Console.Write(end);
                        indexX = i;
                        indexY = j;
                    }
                    else if (map[i, j] == 2)
                    {
                        Console.Write(player);
                        playerX = i;
                        playerY = j;
                    }
                    else if (map[i, j] == 1)
                    {
                        Console.Write(wall);
                    }
                    else if (map[i, j] == 0)
                    {
                        Console.Write(' ');
                    }

                }
                Console.WriteLine();
            }
            
         //Console.SetCursorPosition(x+=2+playerX,y+=playerY);
         Console.SetCursorPosition(x+=1+playerX,y+=8+playerY);
           
        while (true)
            {      
                key = Console.ReadKey(true);
                if (key.KeyChar == 119 || key.KeyChar == 87)
                {
                    if (map[playerX-1, playerY] != 1)
                    {
                        Console.Write(' ');
                        Console.SetCursorPosition(x, --y);
                        Console.Write(player);
                        playerX--;

                    }
                }
                else if (key.KeyChar == 115 || key.KeyChar == 83)
                {
                    if (map[playerX+1,playerY] != 1)
                    {
                        Console.Write(' ');
                        Console.SetCursorPosition(x, ++y);
                        Console.Write(player);
                        playerX++;
                        
                    }
                    
                }
                else if (key.KeyChar == 97 || key.KeyChar == 65)
                {
                    if (map[playerX, playerY-1] != 1) 
                    {
                        Console.Write(' ');
                        Console.SetCursorPosition(--x,y);
                        Console.Write(player);
                        playerY--;

                    }
                    
                }
                else if (key.KeyChar == 100 || key.KeyChar == 68)
                {
                    if (map[playerX, playerY+1] != 1) 
                    {
                        Console.Write(' ');
                        Console.SetCursorPosition(++x, y);
                        Console.Write(player);
                        playerY++;

                    }
                }
                
                  
                if ((indexX == playerX)&&(indexY == playerY))
                {
                    break;
                }
                Console.SetCursorPosition(x, y);
            }
            Console.SetCursorPosition(x, y+=2);
            Console.WriteLine();
            if (otvet == "1")
            {
                Console.WriteLine("Поздравляю! Вы прошли обучение!");
            }
            else if(otvet == "2")
            {
                Console.WriteLine("Поздравляю! Вы прошли средний уровень!");
            }
            else if (otvet == "3")
            {
                Console.WriteLine("Поздравляю! Вы прошли HARD уровень! Вы сейчас потратили кучу времени на эту игру!");
            }
            else if (otvet == "4")
            {
                Console.WriteLine("Поздравляю! Вы прошли HARD-Dop уровень! Вы сейчас потратили кучу времени на эту игру!");
            }
        }
    }
}