using System.Xml.Linq;

// Ранее в одном из практических заданий вы создавали класс «Магазин».
// Добавьте к уже созданному классу информацию о площади магазина.
// Выполните перегрузку + (для увеличения площади магазина на указанную 
// величину), — (для уменьшения площади магазина на 
// указанную величину), == (проверка на равенство площадей магазинов),
// < и > (проверка на меньше или больше площади магазина),
// != и Equals.Используйте механизм свойств для полей класса.
namespace task2_class_Shop;

internal class task2
{
    static void Main(string[] args)
    {
        Shop sh1 = new Shop("shop1", "qqqqqqqq", 223344, 12.1);  // создание объекта Магазин1
        sh1.Show();  // вывод магазина1 в консоль

        Shop sh2 = new Shop("shop2", "xxxxxxxx", 556677, 12.1);  // создание объекта Магазин2
        //Shop sh2 = new Shop();  // создание путем ввода с клавиатуры
        sh2.Show();  // вывод магазина2 в консоль

        Console.WriteLine();
        Console.WriteLine($"Колличество созданных магазинов: " +
            $"{Shop.count}");  // статическая переменная считает кол-во созданных объектов

        Console.WriteLine("Увеличение площади первого магазина:");
        sh1++;  // применение перегуженного оператора ++
        Console.WriteLine("Увеличение площади второго магазина:");
        sh2++;  // применение перегуженного оператора --

        sh1.Show();
        sh2.Show();

        Console.WriteLine("--------------------");
        if (sh1 == sh2)  // применение перегуженного оператора ==
            Console.WriteLine("Площадь магазинов равна");
        if (sh1 != sh2)  // применение перегуженного оператора !=
            Console.WriteLine("Площадь магазинов НЕ равна");
    }
}

class Shop
{
    public static int count = 0;  // статическое поле для подсчета кол-ва магазинов
   
    private string name;  // поле Название магазина
    public string Name    // свойство, обслуживающее поле Название
    {
        get { return name; }
        set { if (value != "") name = value; }
    }

    private string description;  // поле Описание магазина
    public string Description    // свойство, обслуживающее поле Описание
    {
        get { return description; }
        set { if (value != "") description = value; }
    }

    private long tel;  // поле Телефон
    public long Tel    // свойство, обслуживающее поле Телефон
    {
        get { return tel; }
        set { if (value != 0) tel = value; }
    }

    private double area;  // поле Площадь
    public double Area    // свойство, обслуживающее поле Площадь
    {
        get { return area; }
        set { if (value != 0) area = value; }
    }

    public Shop(string name, string description, long tel, double area)  // конструктор с параметрами
    {
        Name=name;     
        Description=description;
        Tel=tel;      
        Area=area;
        count++;
    }

    public Shop()  // конструктор без параметров
    {
        Console.WriteLine("Enter shop name: ");
        Name=Console.ReadLine();
        Console.WriteLine("Enter shop description: ");
        Description=Console.ReadLine();
        Console.WriteLine("Enter shop tel: ");
        Tel=Convert.ToInt64(Console.ReadLine());
        Console.WriteLine("Enter shop area: ");
        try { Area=Convert.ToDouble(Console.ReadLine()); }
        catch (Exception ex)
        { Console.WriteLine(ex.Message); }
        count++;
    }

    public void Show()  // метод для вывода магазина в консоль
    {
        Console.WriteLine("\n**************Shop***************" +
            $"\nShop name:\t\t{Name}" +
            $"\nShop description:\t{Description}" +
            $"\nShop tel\t\t{Tel}" +
            $"\nShop area\t\t{Area}");
        Console.WriteLine("*********************************");
    }

    public static Shop operator++(Shop obj)  // перегрузка оператора ++
    {
        Console.WriteLine("Введите число, на которое хотите увеличить площадь: ");
        double n = Convert.ToDouble(Console.ReadLine());  // ввод числа пользователем
        obj.Area += n;  // поле Площадь увеличивается на введенное значение
        return obj;
    }

    public static Shop operator --(Shop obj)  // перегрузка оператора --
    {
        Console.WriteLine("Введите число, на которое хотите уменьшить площадь: ");
        double n = Convert.ToDouble(Console.ReadLine());  // ввод числа пользователем
        obj.Area -= n;  // поле Площадь уменьшается на введенное значение
        return obj;
    }

    public static bool operator == (Shop obj1, Shop obj2)  // перегрузка оператора ==
    {
        return obj1.Area == obj2.Area;  // в случае, если площади равны, возвращает true
    }

    public static bool operator != (Shop obj1, Shop obj2)  // перегрузка оператора !=
    {
        return !(obj1 == obj2);  // в случае, если площади НЕ равны, возвращает true
    }
}
