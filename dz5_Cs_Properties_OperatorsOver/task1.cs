using System.Security.Principal;

namespace dz5_Cs_Properties_OperatorsOver;

// Задание 1
// Ранее в одном из практических заданий вы создавали класс «Журнал».
// Добавьте к уже созданному классу информацию о количестве сотрудников.
// Выполните перегрузку + (для увеличения количества сотрудников на
// указанну, величину), — (для уменьшения количества сотрудников
// на указанную величину), == (проверка на равенство количества
// сотрудников), < и > (проверка на меньше или больше количества
// сотрудников), != и Equals.Используйте механизм свойств для полей класса.
internal class task1
{
    static void Main(string[] args)
    {
        Journal j1 = new Journal  // создание и инициализация объекта 1
        {
            J_name = "Vogue",
            Year = 1892,
            J_description = "Журнал о моде",
            Tel = 112233,
            Email = "...@net",
            Staff_number = 1300
        };
        Journal j2 = new Journal  // создание и инициализация объекта 2
        {
            J_name = "Esquire",
            Year = 1933,
            J_description = "Журнал об известных людях современности",
            Tel = 888999,
            Email = "...@net",
            Staff_number = 1500
        };
        j1.Show();  // вывод объекта 1 в консоль
        j2.Show();  // вывод объекта 2 в консоль

        Console.WriteLine("Хотите изменить колличество персонала в журналах?" +
           "Выберите соответствующий пункт:");
        Console.WriteLine($"1. Увеличить кол-во персонала в журнале {j1.J_name}");
        Console.WriteLine($"2. Увеличить кол-во персонала в журнале {j2.J_name}");
        Console.WriteLine($"3. Уменьшить кол-во персонала в журнале {j1.J_name}");
        Console.WriteLine($"4. Уменьшить кол-во персонала в журнале {j2.J_name}");
        Console.WriteLine("5. Не изменять");
        
        ConsoleKeyInfo choice;  // клавиша для выбора пользователем
        bool contin = true;     // булевая переменная для продолжения цикла
        while(contin)           // продолжаем пока contin = true
        {
            choice = Console.ReadKey();  // считываем нажатую пользователем клавишу
            switch(choice.Key)           // в зависимости от свойтсва Key нажатой клавиши:
            {
                case ConsoleKey.D1:      // если нажата клавиша 1
                    j1++;                // увеличиваем кол-во персонала в журнале 1
                    Next();              
                    break;                      
                case ConsoleKey.D2:      // если нажата клавиша 2
                    j2++;                // увеличиваем кол-во персонала в журнале 2
                    Next();              
                    break;               
                case ConsoleKey.D3:      // если нажата клавиша 3
                    j1--;                // уменьшаем кол-во персонала в журнале 1
                    Next();              
                    break;               
                case ConsoleKey.D4:      // если нажата клавиша 4
                    j2--;                // уменьшаем кол-во персонала в журнале 2
                    Next();              
                    break;               
                case ConsoleKey.D5:      // если нажата клавиша 5
                default:                 // или любая другая
                    contin = false;      // не продолжать цикл
                    break;
            }
        } 

        j1.Show();  // вывод объекта 1 в консоль
        j2.Show();  // вывод объекта 2 в консоль

        // пример работы с перегруженными операторами ==, !=, <, > для поля Кол-во персонала:
        Console.WriteLine($"Колличество персонала в журнале {j1.J_name} и журнале {j2.J_name} равно? - {j1==j2}");
        Console.WriteLine($"Колличество персонала в журнале {j1.J_name} и журнале {j2.J_name} не равно? - {j1!=j2}");
        Console.WriteLine($"Колличество персонала в журнале {j1.J_name} больше, чем в журнале {j2.J_name}? - {j1>j2}");
        Console.WriteLine($"Колличество персонала в журнале {j1.J_name} меньше, чем в журнале {j2.J_name}? - {j1<j2}");
    }

    static void Next()  // метод "Следующий пункт меню"
    {
        Console.ForegroundColor = ConsoleColor.Green;  // вывод следующей строки в зеленом цвете
        Console.WriteLine("Выбирайте пункт меню дальше...");
        Console.ForegroundColor = ConsoleColor.White;  // возврат к стандартному (белому) цвету
    }

    class Journal  // класс Журнал
    {
        private string j_name;  // закрытая переменная Название 
        public string J_name    // свойство, обслуживает поле Название
        {
            get { return j_name; }
            set { if (value != "") j_name = value; }
        }

        private int year;  // закрытая переменная Год_выпуска
        public int Year    // свойство, обслуживает поле Год_выпуска
        {
            get { return year; }
            set { if (value != 0) year =  value; }
        }

        private string j_description;  // закрытая переменная Описание
        public string J_description    // свойство, обслуживает поле Описание
        {
            get { return j_description; }
            set { if (value != "") j_description = value; }
        }

        private long tel;  // закрытая переменная Телефон
        public long Tel    // свойство, обслуживает поле Телефон
        {
            get { return tel; }
            set { if (value != 0) tel = value; }
        }

        private string email;  // закрытая переменная Email
        public string Email    // свойство, обслуживает поле Email
        {
            get { return email; }
            set { if (value != "") email = value; }
        }

        private int staff_number;  // закрытая переменная Колличество_персонала
        public int Staff_number    // свойство, обслуживает поле Колличество_персонала
        {
            get { return staff_number; }
            set { if (value != 0) staff_number = value; }
        }

        public void Show()  // метод для вывода в консоль
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\n\t***{J_name}***" +
                $"\nJournal title: \t\t{J_name} " +
                $"\nJournal description: \t{J_description}" +
                $"\nYear of foundation: \t{Year}" +
                $"\nContact tel.: \t\t{Tel} " +
                $"\nContact Email: \t\t{Email}" +
                $"\nNumber of employees: \t{Staff_number}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // перегрузка оператора ++ для увеличения колличества персонала
        public static Journal operator ++(Journal obj)  
        {
            Console.WriteLine("Введите число для увеличения:");
            int x = 0;  // переменная для ввода пользователем
            try         // генерируем исключение
            {
                x = Convert.ToInt32(Console.ReadLine());  // ввод пользователем числа для увеличения
            }
            catch (FormatException ex)  // перехватываем исключение - возможный неверный формат ввода
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);  // вывод сообщения исключения
                Console.ForegroundColor = ConsoleColor.White;
            }
            obj.Staff_number +=x;  // применяем увеличение к полю Колл-во_персонала
            return obj;
        }

        // перегрузка оператора -- для уменьшения колличества персонала
        public static Journal operator --(Journal obj)
        {
            Console.WriteLine("Введите число для уменьшения:");
            int x = 0;  // переменная для ввода пользователем
            try         // генерируем исключение
            {
                x = Convert.ToInt32(Console.ReadLine());  // ввод пользователем числа для уменьшения
            }
            catch (FormatException ex)  // перехватываем исключение - возможный неверный формат ввода
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);  // вывод сообщения исключения
                Console.ForegroundColor = ConsoleColor.White;
            }
            obj.Staff_number -=x;  // применяем уменьшение к полю Колл-во_персонала
            return obj;
        }

        // перегрузка оператора == (сравниваем кол-во персонала двух разных объектов)
        public static bool operator== (Journal obj1, Journal obj2)
        {
            return obj1.Staff_number == obj2.Staff_number;  // если == выводим True, иначе False
        }

        // перегрузка оператора != (сравниваем кол-во персонала двух разных объектов)
        public static bool operator!= (Journal obj1, Journal obj2)
        {
            return obj1.Staff_number != obj2.Staff_number;  // если != выводим True, иначе False
        }

        // перегрузка оператора > (сравниваем кол-во персонала двух разных объектов)
        public static bool operator> (Journal obj1, Journal obj2)
        {
            if (obj1.Staff_number > obj2.Staff_number) 
                return true;    // если кол-во персонала в 1ом объекте больше - выводит True
            else return false;  // иначе False
        }

        // перегрузка оператора < (сравниваем кол-во персонала двух разных объектов)
        public static bool operator< (Journal obj1, Journal obj2)
        {
            if (obj1.Staff_number < obj2.Staff_number) 
                return true;    // если кол-во персонала в 1ом объекте меньше - выводит True
            else return false;  // иначе False
        }        
    }
}