using System;


namespace Contacts
{
    class Program
    {
        static void Main(string[] args)
        {
            Users ar = new Users();

            Console.WriteLine("Enter capacity of your contact list: (WARNING: capacity of your contact can NOT be changed) ");
            string capacity = Console.ReadLine();
            int capacityy = 0;
            bool render = false;
            if (Users.AllNumber(capacity))
            {
                capacityy = Convert.ToInt32(capacity);
                render = true;
            }
            else{
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Failed: Please enter a valid number");
                Console.ResetColor();
            }

            Users[] arr = new Users[capacityy];

            while (render)
            {
                Menu();
                string option = Console.ReadLine();
                int options = -1;
                if (Users.AllNumber(option))
                {
                    options = Convert.ToInt32(option);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Failed: Please enter a valid number");
                    Console.ResetColor();
                    continue;
                }

                switch (options)
                {
                    case 1:
                        ar.AddContant(arr);
                        break;

                    case 2:
                        ar.VeiwContats(arr);
                        break;

                    case 3:
                        ar.SearchContacts(arr);
                        break;

                    case 4:
                        ar.DeleteContact(arr);
                        break;

                    case 5:
                        SortMenu();
                        int sOption = Convert.ToInt32(Console.ReadLine());
                        switch (sOption)
                        {
                            case 1:
                                ar.SortContatsByName(arr);
                                Users.sortedMessage(ar,arr);
                                break;
                            case 2:
                                ar.SortContatsByNumber(arr);
                                Users.sortedMessage(ar,arr);
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Failed: Please enter a valid number ! ");
                                Console.ResetColor();
                                break;
                        }
                        break;

                    case 6:
                        render = false;
                        Console.WriteLine("Press ENTER to EXIT");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Failed: Please enter a valid number ! ");
                        Console.ResetColor();
                        break;
                }
            }

            Console.ReadKey();


        }


        public static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine("\t\t\t\t  *MENU*");  //also can use .PadLeft() method instead of \t
            Console.WriteLine("");
            Console.WriteLine("\t\t Write one of below options and press \'Enter\'");
            Console.WriteLine("");
            Console.WriteLine("\t\t 1-Add a new contact\t  2-See contact list");
            Console.WriteLine("");
            Console.WriteLine("\t\t 3-Search\t\t  4-Delete");
            Console.WriteLine("");
            Console.WriteLine("\t\t 5-Sort \t\t  6-Exit");
            Console.WriteLine("");
        }

        public static void SortMenu()
        {
            Console.WriteLine("\t\t\t\t  *SortMenu*");  //also can use .PadLeft() method instead of \t
            Console.WriteLine("");
            Console.WriteLine("\t\t Write one of below options and press \'Enter\'");
            Console.WriteLine("");
            Console.WriteLine("\t\t 1-Sort by Name\t\t  2-Sort by Number");
            Console.WriteLine("");
        }


        struct Users
        {
            public string _name;
            public string _number;

            public void AddContant(Users[] ar)
            {
                int n = ar.Length;
                int c = 0;
                for (int m = 0; m < n; m++)
                {
                    if (ar[m]._name == null && ar[m]._number == null)
                    {
                        c++;
                    }
                }
                if (c == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Failed: Contact list is full, Please delete some contacts before add new one !");
                        Console.ResetColor();
                        return;
                    }

                Console.WriteLine("Enter new contact\'s NAME: ");
                string name = Console.ReadLine();
                if (name == "")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Failed: Name space can\'t be empty !");
                    Console.ResetColor();
                    return;
                }
                Console.WriteLine("Enter new contact\'s NUMBER: ");
                string number = Console.ReadLine();
                if (number == "")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Failed: Number space can\'t be empty !");
                    Console.ResetColor();
                    return;
                }
                if (AllNumber(number))
                {
                    for (int i = 0; i < n; i++)
                        {
                            if (ar[i]._name == null && ar[i]._number == null)
                            {
                                ar[i]._name = name;
                                ar[i]._number = number;
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\nSuccess: new contact saved");
                                Console.ResetColor();
                                break;
                            }
                    }
                }else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Failed: Please enter a valid number !");
                    Console.ResetColor();
                }
                
            }

            public void VeiwContats(Users[] ar)
            {

                int c = 0;
                for (int k = 0; k < ar.Length; k++)
                {
                    if (ar[k]._name==null && ar[k]._number == null)
                    {
                        c++;
                    }
                }
                if (c == ar.Length)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Failed: There is nothing to show !");
                    Console.ResetColor();
                }

                for (int k = 0; k < ar.Length - 1; k++)
                {
                    if (ar[k]._name == null && ar[k]._number == null && ar[k + 1]._name != null && ar[k + 1]._number != null)
                    {
                        Users temp = ar[k];
                        ar[k] = ar[k + 1];
                        ar[k + 1] = temp;
                    }
                }

                for (int i=0;i<ar.Length;i++)
                {
                    if(ar[i]._name!=null && ar[i]._number!=null)
                        Console.WriteLine("{0}  name: {1} , number: {2}", i+1, ar[i]._name, ar[i]._number);

                }
            }

            public void SortContatsByName(Users[] ar)
            {
                for (int i = 0; i < ar.Length - 1; i++)
                {
                    for (int j = i + 1; j < ar.Length; j++)
                    {
                        if (ar[i]._name != null && ar[j]._name != null && (string.Compare(ar[i]._name, ar[j]._name) == 1) )
                        {
                            Users temp = ar[i];
                            ar[i] = ar[j];
                            ar[j] = temp;
                        }
                    }
                }
            }

            public void SortContatsByNumber(Users[] ar)
            {
                for (int i = 0; i < ar.Length - 1; i++)
                {
                    for (int j = i + 1; j < ar.Length; j++)
                    {
                        if (ar[i]._number != null && ar[j]._number != null && (string.Compare(ar[i]._number, ar[j]._number) == 1))
                        {
                            Users temp = ar[i];
                            ar[i] = ar[j];
                            ar[j] = temp;
                        }
                    }
                }
            }

            public void SearchContacts(Users[] ar)
            {
                int c = 0;
                for (int k = 0; k < ar.Length; k++)
                {
                    if (ar[k]._name == null && ar[k]._number == null)
                    {
                        c++;
                    }
                }

                if (c == ar.Length)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Failed: Contact is empty !");
                    Console.ResetColor();
                    return;
                }
                Console.WriteLine("Enter a part of thing you want to find: (it can be apart of number or apart of name)");
                string aPart = Convert.ToString(Console.ReadLine());
                foreach (Users i in ar)
                {
                    if (i._name != null && i._number != null && (i._name.Contains(aPart) || i._number.Contains(aPart)))
                    {
                        Console.WriteLine("name: {0} , number: {1}", i._name, i._number);
                    }

                }
            }


            public void DeleteContact(Users[] ar)
            {
                int c = 0;
                for (int k = 0; k < ar.Length; k++)
                {
                    if (ar[k]._name == null && ar[k]._number == null)
                    {
                        c++;
                    }
                }
                
                if (c == ar.Length)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Failed: Contact is empty !");
                    Console.ResetColor();
                    return;
                }

                VeiwContats(ar);
                
                Console.WriteLine("Which contact you want to delete? (enter side number) ");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num > ar.Length  || ar[num - 1]._number == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Failed: Number you entered is out of range !");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Success: contact " + ar[num - 1]._name + " successfully deleted");
                    Console.ResetColor();
                    ar[num - 1]._name = null;
                    ar[num - 1]._number = null;
                }
            }

            public static bool AllNumber(string s)
            {
                foreach (char c in s)
                {
                    if (Char.IsLetter(c))
                        return false;
                }
                return true;
            }

            public static void sortedMessage(Users ar, Users[]arr)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Success: sorted, Do you want to see sorted contactlist?(y/n)");
                Console.ResetColor();
                char answere = Convert.ToChar(Console.ReadLine());
                if (answere == 'y')
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    ar.VeiwContats(arr);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Success: Sorted \nRedirecting to menu ... ");
                    Console.ResetColor();
                }
            }




        }
    }
}
