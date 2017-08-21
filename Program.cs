using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace модульное_задание
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ListOfUsers = new string[3] { "t1-denis", "t2-pasha", "t3-oleg" };
            string[] BlockedUsers = new string[] { };
            int[] ScoreArray = new int[1] { 0 };
            GoLibrary(ListOfUsers, BlockedUsers, ScoreArray);

            Console.ReadKey();
        }

        static void GoLibrary(string[] array, string[] blockarray, int[] scorearray)
        {
            Login(array, blockarray, scorearray);
        }
        static void Login(string[] array, string[] blockarray, int[] scorearray)
        {
            Console.WriteLine("введите пароль");
            string pass = Console.ReadLine();
            switch (pass)
            {
                case "admin":
                    Console.WriteLine("Sie sind admin");
                    AdminMenu(array, blockarray, scorearray);
                    break;
                case "user":
                    Console.WriteLine("Sie sind user");
                    UserMenu(array, blockarray, scorearray);
                    break;
                default:
                    Console.WriteLine("Der Pass is' unklar");
                    break;
            }
        }
        static void AdminMenu(string[] array, string[] blockarray, int[] scorearray)
        {
            Console.Clear();
            Console.WriteLine("Admin menu: ");
            Console.WriteLine("нажмите 1 что бы просмотреть список счетов с указанием имени");
            Console.WriteLine("нажмите 2 для блокировки пользователя от входа в систему");
            Console.WriteLine("нажмите 3 что бы разблокировать только блокированных пользователей");
            Console.WriteLine("нажмите 4 что бы добавлять новый счет(нового пользователя).");
            Console.WriteLine("нажмите 5 что бы посмотреть список заблокированных пользователей");
            Console.WriteLine("нажмите 6 что бы удалить юзера");
            Console.WriteLine("Enter 7 to exit");

            string ans = Console.ReadLine();

            switch (ans)
            {
                case "1":
                    ListOfUsers(array, blockarray, scorearray);
                    break;
                case "2":
                    BlockUser(array, blockarray, scorearray);
                    break;
                case "3":
                    UnBlockUser(array, blockarray, scorearray);
                    break;
                case "4":
                    AddUser(array, blockarray, scorearray);
                    break;
                case "5":
                    ListOfBlockUsers(array, blockarray, scorearray);
                    break;
                case "6":
                    DeleteUser(array, blockarray, scorearray);
                    break;
                case "7":
                    Exit();
                    break;
                default:
                    Console.WriteLine("unklare Nummer");
                    break;
            }
        }
        static void UserMenu(string[] array, string[] blockarray, int[] scorearray)
        {
            Console.Clear();
            Console.WriteLine("User menu: ");
            Console.WriteLine("нажмите 1 что бы посмотреть свой счет");
            Console.WriteLine("нажмите 2 для пополнения счета");
            Console.WriteLine("нажмите 3 для снятия денег");            
            Console.WriteLine("нажмите 4 для выхода из программы");

            string ans = Console.ReadLine();
            switch (ans)
            {
                case "1":
                    MyScore(array, blockarray, scorearray);
                    break;
                case "2":
                    AddScore(array, blockarray, scorearray);
                    break;
                case "3":
                    AusScore(array, blockarray, scorearray);
                    break;
                case "5":
                    Exit();
                    break;
            }
        }




        static void ListOfUsers(string[] array, string[] blockarray, int[] scorearray)          
        {
            Console.Clear();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.WriteLine();
            
            Console.WriteLine("нажмите 0 для выходы в меню");
            string exit = Console.ReadLine();
            if (exit == "0")
            {
                AdminMenu(array, blockarray, scorearray);
            }
        }





        
        static void BlockUser(string[] array, string[] blockarray, int[] scorearray)
        {
            Console.Clear();
            Console.WriteLine("введите юзера которого хотите заблокировать");
            string takebook = Console.ReadLine();

            string[] NewUserArray = new string[] { };
            bool FindBook = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == takebook)
                {
                    FindBook = true;
                    break;
                }
            }
            if (FindBook)
            {
                NewUserArray = new string[blockarray.Length + 1];
                NewUserArray[NewUserArray.Length - 1] = takebook;
                Console.WriteLine("юзер заблокирован");
            }
            else
            {
                Console.WriteLine("не найдена");
            }
            Console.WriteLine("Enter 0 to return to the main menu or anything to exit");
            string exit = Console.ReadLine();
            if (exit == "0")
            {
                AdminMenu(array, NewUserArray, scorearray);
            }            
        }




        static void UnBlockUser(string[] array, string[] blockarray, int[] scorearray)
        {
            Console.Clear();
            Console.WriteLine("введите имя пользователя которого хотите разблокировать");
            string ReturnUser = Console.ReadLine();
            string[] NewUserArray;
            int countj = 0;
            if (blockarray.Length <= 1)
            {
                NewUserArray = new string[] { };            //обнулили 
            }
            else
            {
                NewUserArray = new string[blockarray.Length - 1];
            }

            for (int i = 0; i < blockarray.Length; i++)
            {
                if (blockarray[i] == ReturnUser)
                {
                    continue;
                }
                else
                {
                    NewUserArray[countj] = blockarray[i];
                    countj += 1;
                }
            }
            Console.WriteLine("пользователь разблокирован");
            Console.WriteLine("Enter 0 to return to the main menu or anything to exit");
            string exit = Console.ReadLine();
            if (exit == "0")
            {
                AdminMenu(array, NewUserArray, scorearray);
            }
        }





        static void ListOfBlockUsers(string[] array, string[] blockarray, int[] scorearray)
        {
            Console.Clear();
            for (int i = 0; i < blockarray.Length; i++)
            {
                Console.WriteLine(blockarray[i]);
            }
            Console.WriteLine();
            
            Console.WriteLine("нажмите 0 для выходы в меню");
            string exit = Console.ReadLine();
            if (exit == "0")
            {
                AdminMenu(array, blockarray, scorearray);
            }
        }






        static void AddUser(string[] array, string[] blockarray, int[] scorearray)
        {
            Console.Clear();
            Console.WriteLine("введите нового пользователя");
            string NewBook = Console.ReadLine();
            string[] NewArray = new string[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                NewArray[i] = array[i];
            }
            NewArray[NewArray.Length - 1] = NewBook;
            Console.WriteLine();
            Console.WriteLine("новый пользователь успешно добавлен");
            Console.WriteLine("нажмите 0 для выходы в меню");
            string exit = Console.ReadLine();
            if (exit == "0")
            {
                AdminMenu(NewArray, blockarray, scorearray);
            }
        }


        static void DeleteUser(string[] array, string[] blockarray, int[] scorearray)
        {
            Console.Clear();
            Console.WriteLine("введите пользователя которого хотите удалить");
            string DelBook = Console.ReadLine();

            string[] NewDelArr = new string[array.Length - 1];
            int countj = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != DelBook)
                {
                    NewDelArr[countj] = array[i];
                    countj += 1;
                }                               //предосмотреть сит с пользователем которого нету
            }
            Console.WriteLine("Enter 0 to return to the main menu or anything to exit");
            string exit = Console.ReadLine();
            if (exit == "0")
            {
                AdminMenu(NewDelArr, blockarray, scorearray);
            }
        }




        static void MyScore(string[] array, string[] blockarray, int[] scorearray)
        {
            Console.Clear();
            for (int i = 0; i < scorearray.Length; i++)
            {
                Console.WriteLine(scorearray[i]);
            }
            Console.WriteLine();
            
            Console.WriteLine("нажмите 0 для выходы в меню");
            string exit = Console.ReadLine();
            if (exit == "0")
            {
                UserMenu(array, blockarray, scorearray);
            }
        }



        static void AddScore(string[] array, string[] blockarray, int[] scorearray)
        {
            Console.Clear();
            Console.WriteLine("введите сумму для пополнения своего счета");
            int NewScore = int.Parse(Console.ReadLine());
            scorearray[0] += NewScore;
            //int[] NewArray = new int[scorearray.Length + 1];
            //for (int i = 0; i < scorearray.Length; i++)
            //{
            //    NewArray[i] = scorearray[i];
            //}
            //NewArray[NewArray.Length - 1] = NewScore;
            Console.WriteLine();
            Console.WriteLine("счет успешно пополнен");
            Console.WriteLine("нажмите 0 для выходы в меню");
            string exit = Console.ReadLine();
            if (exit == "0")
            {
                UserMenu(array, blockarray, scorearray);
            }
        }






        static void AusScore(string[] array, string[] blockarray, int[] scorearray)
        {
            Console.Clear();
            Console.WriteLine("введите сумму для снятия со своего счета");
            int NewScore = int.Parse(Console.ReadLine());
            if (scorearray[0] != 0 && scorearray[0] >= NewScore)
            {
                scorearray[0] -= NewScore;
            }
            else
            {
                Console.WriteLine("маленький остаток");
            }
            Console.WriteLine();
            
            Console.WriteLine("нажмите 0 для выходы в меню");
            string exit = Console.ReadLine();
            if (exit == "0")
            {
                UserMenu(array, blockarray, scorearray);
            }

        }





        static void Exit()
        {
            Console.WriteLine("enter the enter ");
        }
    }
}
