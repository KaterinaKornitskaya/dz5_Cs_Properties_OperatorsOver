using System;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

// Задание 3
// Создайте приложение «Список книг для прочтения». 
// Приложение должно позволять добавлять книги в список,
// удалять книги из списка, проверять есть ли книга в 
// списке, и т. д. Используйте механизм свойств, перегрузки 
// операторов, индексаторов.
namespace task3;

internal class task3
{
    static void Main(string[] args)
    {
        BookList libr = new BookList();  // создание список - объекта класса BookList
       
        Console.WriteLine("Добавьте первую книгу");
        libr.AddBook(new Book());        // добавление перовй книги
        Console.WriteLine("Добавить еще книгу? Если да -  нажмите 1, если нет - нажмите 2");
        ConsoleKeyInfo choice;           // клавиша для выбора пользователем
        bool contin = true;
        while (contin)                   // цикл добавления книг
        {
            choice = Console.ReadKey();  // считываем нажатую клавишу
            switch (choice.Key)
            {
                case ConsoleKey.D1:            // если нажата 1
                    libr.AddBook(new Book());  // вызов метода Добавить книгу
                    Console.WriteLine("Добавить еще книгу? " +
                        "Если да -  нажмите 1, если нет - нажмите 2");
                    break;
                case ConsoleKey.D2:  // если нажата 2
                default:             // или другая клавиша - выход из цикла
                    contin = false;
                    break;
            }
        }
             
        Console.WriteLine("***********Меню**********");
        bool contin2 = true;
        while (contin2)  // цикл с меню для добавления других цикл, удаления, показа списка
        {          
            Console.WriteLine("1. Показать все книги");
            Console.WriteLine("2. Добавить еще одну книгу");
            Console.WriteLine("3. Удалить одну книгу");
            Console.WriteLine("4. Выход");
            choice = Console.ReadKey();
            switch (choice.Key)
            {
                case ConsoleKey.D1:             // если нажата 1
                    libr.Show_booklist();       // вызов метода Показать весь список
                    break;
                case ConsoleKey.D2:             // если нажата 2
                    libr.AddBook(new Book());   // вызов метода Добавить книгу                  
                    break;
                case ConsoleKey.D3:             // если нажата 3
                    libr.RemoveThisBook(libr);  // вызов метода Удалить определенную книгу
                    break;
                case ConsoleKey.D4:             // если нажата 4
                default:                        // или любая другая - выход из цикла
                    contin2 = false;
                    break;
            }
        }

        // пример использования перегруженных операторов + и -
        Console.WriteLine("--------------------------------");
        Book book1 = new Book("Book234");  // создаем новый объект Книга
        libr += book1;                     // добавить эту книгу в список
        Console.WriteLine("После добавления книги234 через оператор+:");
        libr.Show_booklist();
        libr -= book1;                     // удалить эту книгу из списка
        Console.WriteLine("После удаления книги234 через оператор+:");
        libr.Show_booklist();
    }

    class Book  // класс Книга
    {
        public string Name { get; set; }  // поле Название книги
        public Book(string name)          // конструктор с параметром
        {
            Name=name;
        }

        public Book()  // конструктор без параметра для ввода книг с клавиатуры
        {
            Console.WriteLine("(введите название книги)");
            Name = Console.ReadLine();
        }

        public void Show()  // метод для вывода книги в консоль
        {           
            Console.WriteLine($": {Name}");
        }
    }

    class BookList  // класс список книг
    {
        private List<Book> book_list;  // поле Список книг - инкапсулирвоанный динамический массив List

        public BookList()  // конструктор без параметров
        {
            book_list = new List<Book>();
        }

        public void AddBook(Book book)  // метод Добавление книги
        {
            book_list.Add(book);        // используем стандартный метод Add класса List
        }

        public void RemoveThisBook(BookList list)         // метод Удаление определенной книги
        {
            Console.WriteLine("Номер для удаления: ");
            int n = Convert.ToInt32(Console.ReadLine());  // ввод номера для удаления           
            book_list.RemoveAt(n-1);                      // используем стандартный метод RemoveAt класса List          
        }

        public void RemoveBook(Book book)  // метод Удаления книги для использования в перегрузке оператора -
        {
            book_list.Remove(book);        // используем стандартный метод Remove класса List    
        }

        public bool IsContain(Book book)      // метод Наличие книги в списке
        {
            return book_list.Contains(book);  // используем стандартный метод Contains класса List  
        }

        public static BookList operator +(BookList list, Book book)  // перегрузка оператора +
        {
            list.AddBook(book);  // реализация - вызываем метод Добавление книги
            return list;
        }


        public static BookList operator -(BookList list, Book book)  // перегрузка оператора -
        {
            list.RemoveBook(book);  // реализация - вызываем метод Удаление книги
            return list;
        }

        public void Show_booklist()  // метод Вывод списка книг в консоль
        {
            Console.WriteLine("********Book List********");
            for (int i = 0; i < book_list.Count; i++)  // цикл по кол-ау элементов в списке
            {              
                Console.Write("Book# " + (i+1));       // вывод номера по порядку
                book_list[i].Show();                   // вызов методв Вывод книги              
            }
            Console.WriteLine("*************************");
        }
    }
}
