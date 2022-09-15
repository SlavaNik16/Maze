
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Maze
{
    class Program
    {
       
        static void Main()
        {
            //maze1 = 20 * 20
            //maze2 = 60 * 60
            //maze3 = 160 * 60
            //maze4 = 100 * 100
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.WriteLine("Псевдо игра: Лабиринт\nЦель игры: Дойти до конца! \nЛабиринт:\n1. 20 * 20  - Даже нуб пройдет\n2. 60 * 60 - Придется не легко\n3. 160 * 60 - Даже \"он\" не справится\n4. 100 * 100 - Суицид не выход\nВыберите уровень сложности: ");
            var otvet = Console.ReadLine();

            int i = 0;
            int j = 0;
            int n = 0;
            int n1 = 0;
            int n2 = 0;
            var wall = '█';
            var player = '☺';
            var end = '⌂';
            var start = '☼';        
            var poskaska = false;
            int count = 0;


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
            int[,] map = new int[str.Length, str[0].Split(' ').Length];//Создаю двумерный массив
            //[0,0][0,1][0,2] и так далее, по столбцам
            for (i = 0; i < str.Length; i++)
            {
               string[] str2 = str[i].Split(' '); //тут же создаем массив по символьно
                for (j = 0; j < str2.Length; j++) 
                    map[i, j] = Int32.Parse(str2[j]); //Преобразуем из строки в int32 и присваиваем двумерному массиву
                n = str2.Length;
            }

            string[] pos = File.ReadAllLines($"maze{otvet}.Pos.txt");//Читаю файл с лабиринтом и присваиваю одномерному масиву str
            int[,] map_pos = new int[pos.Length, pos[0].Split(' ').Length];//Создаю двумерный массив
            //[0,0][0,1][0,2] и так далее, по столбцам
            for (i = 0; i < pos.Length; i++)
            {
                string[] pos2 = pos[i].Split(' '); //тут же создаем массив по символьно
                for (j = 0; j < pos2.Length; j++)
                    map_pos[i, j] = Int32.Parse(pos2[j]); //Преобразуем из строки в int32 и присваиваем двумерному массиву
                n1 = pos2.Length;
            }

            string[] tum = File.ReadAllLines($"maze{otvet}.tum.txt");//Читаю файл с лабиринтом и присваиваю одномерному масиву str
            int[,] map_tum = new int[tum.Length, tum[0].Split(' ').Length];//Создаю двумерный массив
            //[0,0][0,1][0,2] и так далее, по столбцам
            for (i = 0; i < tum.Length; i++)
            {
                string[] tum2 = tum[i].Split(' '); //тут же создаем массив по символьно
                for (j = 0; j < tum2.Length; j++)
                    map_tum[i, j] = Int32.Parse(tum2[j]); //Преобразуем из строки в int32 и присваиваем двумерному массиву
                n2 = tum2.Length;
            }
            Console.Clear();
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
                        if (map_tum[i, j] == 1)
                        {
                            Console.Write(' ');
                        }
                        else
                        {
                            Console.Write(player);
                            playerX = i;
                            playerY = j;
                        }
                    }
                    else if (map[i, j] == 1)
                    {
                        if (map_tum[i, j] == 1)
                        {
                            Console.Write(' ');
                        }
                        else
                        {
                            Console.Write(wall);
                        }
                        
                    }
                    else if (map[i, j] == 0)
                    {
                        if (map_tum[i, j] == 1)
                        {
                            Console.Write(' ');
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                        
                    }
                }
                Console.WriteLine();
            }

            
         Console.SetCursorPosition(x+=playerY,y+=playerX);
           
        while (true)
            {

                
                key = Console.ReadKey(true);
                if (key.KeyChar == 119 || key.KeyChar == 87)
                {
                    if ((map[playerX-1, playerY] != 1 && !poskaska) ||(poskaska && map_pos[playerX - 1, playerY] !=1))
                    {
                        
                        Console.Write(' ');
                        Console.SetCursorPosition(x, --y);
                        Console.Write(player);
                        count++;

                        if (!poskaska)
                        {
                            if (map_pos[playerX - 1, playerY] == 0)
                            {
                                map_pos[playerX, playerY] = 1;
                            }
                            else
                            {
                                map_pos[playerX, playerY] = 0;
                            }
                        }
                        playerX--;
                        

                    }
                }
                else if (key.KeyChar == 115 || key.KeyChar == 83)
                {
                    
                    if ((map[playerX+1,playerY] != 1 && !poskaska) || (poskaska && map_pos[playerX + 1, playerY] != 1))
                    {

                        Console.Write(' ');
                        Console.SetCursorPosition(x, ++y);
                        Console.Write(player);
                        count++;
                        if (!poskaska)
                        {
                            if (map_pos[playerX + 1, playerY] == 0)
                            {
                                map_pos[playerX, playerY] = 1;
                            }
                            else
                            {
                                map_pos[playerX, playerY] = 0;
                            }
                        }
                        playerX++;
                        
                    }
                    
                }
                else if (key.KeyChar == 97 || key.KeyChar == 65)
                {
                   
                    if ((map[playerX, playerY-1] != 1 && !poskaska) || (poskaska && map_pos[playerX, playerY - 1] != 1))
                    {
                        Console.Write(' ');
                        Console.SetCursorPosition(--x,y);
                        Console.Write(player);
                        count++;
                        if (!poskaska)
                        {
                            if (map_pos[playerX, playerY-1] == 0)
                            {
                                map_pos[playerX, playerY] = 1;
                            }
                            else
                            {
                                map_pos[playerX, playerY] = 0;
                            }
                        }
                        playerY--;

                    }
                    
                }
                else if (key.KeyChar == 100 || key.KeyChar == 68)
                {
                   
                    if ((map[playerX, playerY+1] != 1 && !poskaska) || (poskaska && map_pos[playerX, playerY + 1] != 1))
                    {
                        Console.Write(' ');
                        Console.SetCursorPosition(++x, y);
                        Console.Write(player);
                        count++;
                        if (!poskaska)
                        {
                            if (map_pos[playerX, playerY + 1] == 0)
                            {
                                map_pos[playerX, playerY] = 1;
                            }
                            else
                            {
                                map_pos[playerX, playerY] = 0;
                            }
                        }
                        playerY++;

                    }
                }
                else if ((key.KeyChar == 112 || key.KeyChar == 80) && !poskaska)
                {
                    poskaska = true;
                    Console.SetCursorPosition(0, 0);
                    for (i = 0; i < pos.Length; i++)
                    {
                        for (j = 0; j < n1; j++)
                        {
                            if (map_pos[i, j] == 3)
                            {
                                Console.Write(end);
                            }
                            else if (map_pos[i, j] == 2)
                            {
                                Console.Write(player);
                            }
                            else if (map_pos[i, j] == 1)
                            {
                                Console.Write(wall);
                            }
                            else if (map_pos[i, j] == 0)
                            {
                                Console.Write('*');
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.SetCursorPosition(x, y);
                }


                

                map_tum[playerX - 1, playerY] = 0;
                map_tum[playerX - 1, playerY - 1] = 0;
                map_tum[playerX - 1, playerY + 1] = 0;

                map_tum[playerX + 1, playerY] = 0;
                map_tum[playerX + 1, playerY - 1] = 0;
                map_tum[playerX + 1, playerY + 1] = 0;

                map_tum[playerX, playerY + 1] = 0;
                map_tum[playerX + 1, playerY + 1] = 0;
                map_tum[playerX - 1, playerY + 1] = 0;

                map_tum[playerX, playerY - 1] = 0;
                map_tum[playerX + 1, playerY - 1] = 0;
                map_tum[playerX - 1, playerY - 1] = 0;

                if (!poskaska)
                {
                    Console.SetCursorPosition(0, 0);
                    for (i = 0; i < str.Length; i++)
                    {

                        for (j = 0; j < n; j++)
                        {
                            if (map[i, j] == 3)
                            {
                                if (map_tum[i, j] == 1)
                                {
                                    Console.Write(' ');
                                }
                                else
                                {
                                    Console.Write(end);
                                    indexX = i;
                                    indexY = j;
                                }
                            }
                            else if (map[i, j] == 2)
                            {
                                if (map_tum[i, j] != 1)
                                {
                                    Console.Write(start);
                                }
                                else
                                {
                                    Console.Write(' ');
                                }

                            }
                            else if (map[i, j] == 1)
                            {
                                if (map_tum[i, j] == 1)
                                {
                                    Console.Write(' ');
                                }
                                else
                                {
                                    Console.Write(wall);
                                }

                            }
                            else if (map[i, j] == 0)
                            {
                                if (map_tum[i, j] == 1)
                                {
                                    Console.Write(' ');
                                }
                                else
                                {
                                    Console.Write(' ');
                                }

                            }
                        }
                        Console.WriteLine();
                    }
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(player);
                }

                if (((indexX == playerX)&&(indexY == playerY)) || (key.KeyChar == 27))
                {
                    break;
                }
                
                Console.SetCursorPosition(playerY, playerX);

            }

            Console.SetCursorPosition(x, y+=2);
            Console.WriteLine();
            if (otvet == "1" && !poskaska)
            {
                Console.WriteLine("Поздравляю! Вы прошли обучение!");
            }
            else if(otvet == "2" && !poskaska)
            {
                Console.WriteLine("Поздравляю! Вы прошли средний уровень!");
            }
            else if (otvet == "3" && !poskaska)
            {
                Console.WriteLine("Поздравляю! Вы прошли HARD уровень! Вы сейчас потратили кучу времени на эту игру!");
            }
            else if (otvet == "4" && !poskaska)
            {
                Console.WriteLine("Поздравляю! Вы прошли HARD-Dop уровень! Вы сейчас потратили кучу времени на эту игру!");
            }
            else
            {
                Console.WriteLine("Не растраивайтесь! Попытайтесь еще раз!");
            }
            Console.WriteLine($"Вы прошли {count} шагов!");

            Console.ReadKey(true);
            Console.ReadKey(true);
            Console.ReadKey(true);
            Console.ReadKey(true);
        }
    }
}