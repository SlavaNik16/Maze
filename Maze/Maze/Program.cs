
using System.ComponentModel.DataAnnotations;

namespace Maze
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите start или end (чтобы начать игру или завершить соответственно):)");
            var otvet = Console.ReadLine();
            bool run = false;
            if (otvet == "start")
            {
                run = true;
            }
            else if (otvet == "end")
            {
                run = false;
            }
            int i = 0;
            int j = 0;
            int n = 21;
            var wall = '█';
            var player = '☺';
            var end = '⌂';

            string[] str = File.ReadAllLines("maze1.txt");//Читаю файл с лабиринтом и присваиваю одномерному масиву str
            int[,] map = new int[str.Length, str[0].Split(' ').Length];//Создаю двумерный массив с длиной равной n = 21;
            //[0,0][0,1][0,2] и так далее, по столбцам
            for (i = 0; i < str.Length; i++)
            {
                string[] str2 = str[i].Split(' '); //тут же создаем массив по символьно
                for (j = 0; j < str2.Length; j++) 
                    map[i, j] = int.Parse(str2[j]); //Преобразуем из строки в int32 и присваиваем двумерному массиву
            }

            ConsoleKeyInfo key;
            Console.CursorVisible = false;
            int x = 2;
            int y = 0;
            int indexX = -1;
            int indexY = -1;
            int playerX = -1;
            int playerY = -1;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
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
            
         Console.SetCursorPosition(x+=playerX,y+=playerY);

           
        while (run)
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
                    run = false;
                }
                Console.SetCursorPosition(x, y);
            }
            Console.SetCursorPosition(x, y+=2);
            Console.WriteLine();
            Console.WriteLine("Поздравляю! Вы прошли обучение. Желаете перейти на новый уровень(Улитка): ");
        }
    }
}