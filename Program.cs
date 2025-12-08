namespace Cosmetics_store;
using System;
using System.Collections.Generic;
class Products
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Products(string name, int price)
    {
        Name = name;
        Price = price;
    }
}

class Program
{
    static List<int> numbers = new List<int>();
    
    static List<Products> products = new List<Products>
    {
        new Products("Помада", 310),
        new Products("Туш", 250),
        new Products("Консилер", 320),
        new Products("Пудра", 330),
        new Products("Олівець для брів", 190),
        new Products("Гель для брів", 150),
        new Products("Набір пензлів", 900)
    };
    public static void Return()
    {
        Console.WriteLine("для продовження роботи натиснiть будь яку клавiшу");
        Console.ReadKey();
    }

    static int GetUserInput(string message)
    {
        while (true)
        {
            Console.Write(message);
            string prompt = Console.ReadLine();

            if (int.TryParse(prompt, out int result))
            {
                return result;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введіть число!");
                Console.ResetColor();
            }
        }
    }

    public static int Shownumber(string prompt = "Введiть кiлькiсть:")
    {
        int number = 0;
        bool validInput = false;

        while (!validInput)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(prompt + " ");
                Console.ResetColor();

                number = Convert.ToInt32(Console.ReadLine());

                if (number < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка: кiлькiсть не може бути вiд’ємною! Спробуйте ще раз.");
                    Console.ResetColor();
                    continue;
                }

                validInput = true;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка: введено не число! Спробуйте ще раз.");
                Console.ResetColor();
            }
            catch (OverflowException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вибачте, занадто велика кількісь товару!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Непередбачена помилка: {ex.Message}");
                Console.ResetColor();
            }
        }

        return number;
    }

    static void Main()
    {
        Hellow();
        ShowMainMenu();
    }

    public static void Hellow()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("====== Ласкаво просимо до Cosmetics_store ======");
        Console.WriteLine("-------------------------------------------------");
        Console.ResetColor();
    }

    public static void ShowTextMainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== ГОЛОВНЕ МЕНЮ =====");
        Console.WriteLine("1. Каталог товарiв");
        Console.WriteLine("2. Оформити замовлення");
        Console.WriteLine("3. Вхід для адміністратора");
        Console.WriteLine("4. Вихiд");
        Console.WriteLine();
    }

    public static bool ShowMainMenu()
    {
        while (true)
        {
            ShowTextMainMenu(); 
            int choice = GetUserInput("Виберiть пункт меню:");

            switch (choice)
            {
                case 1:
                    ShowProductMenu();
                    Return();
                    continue;

                case 2:
                    ShowOrderMenu();
                    Return();
                    continue;

                case 3:
                    Admin();
                    Return();
                    continue;
                case 4:
                    Console.WriteLine("Бувайте! Гарного дня!");
                    return false;
                default:
                    Console.WriteLine("Неправильний вибiр, спробуйте ще раз.");
                    ShowTextMainMenu();
                    continue;
            }
        }
    }

    static void ShowProductMenu()
    {
        Console.WriteLine("\n===== КАТАЛОГ ТОВАРІВ =====");

        for (int i = 0; i < products.Count; i++)
            Console.WriteLine($"{i + 1}. {products[i].Name} — {products[i].Price} грн");
        
    }


  static void ShowOrderMenu()
  {
      Console.WriteLine("=== Введення кількості товарів ===");
  
      numbers.Clear();
      for (int i = 0; i < products.Count; i++)
      {
          int q = Shownumber($"Введіть кількість \"{products[i].Name}\" (шт.): ");
          numbers.Add(q);
      }
  
      Console.WriteLine("\nДані успішно збережено!\n");
      ShowTotal();
  }



  static void ShowTotal()
  {
      int total = 0;

      Console.WriteLine("=== Ваше замовлення ===");

      for (int i = 0; i < products.Count; i++)
      {
          int sum = numbers[i] * products[i].Price;
          total += sum;

          Console.WriteLine($"{products[i].Name} — {numbers[i]} шт. × {products[i].Price} грн = {sum} грн");
      }

      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"\nЗагальна сума: {total} грн");
      Console.ResetColor();
  }


    static void Admin()
    {
        Console.Write("Введiть логiн: ");
        string login = Console.ReadLine().Trim();

        if (login != "Yulia")
        {
            Console.WriteLine("Невiрний логiн. Доступ заборонено.");
            ShowMainMenu();
            return;
        }

        const string adminPassword = "Semediy";
        int attempts = 3;

        while (attempts > 0)
        {
            Console.Write("Введiть пароль: ");
            string inputPassword = Console.ReadLine();

            if (inputPassword == adminPassword)
            {
                Console.WriteLine("\nДоступ дозволено! Вiтаю, адмiнiстраторе.");
                ShowAdminMenu();
                return;
            }

            attempts--;

            if (attempts > 0)
            {
                Console.WriteLine($"Неправильний пароль. Залишилось спроб: {attempts}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Доступ заблоковано. Програму завершено.");
                Console.ResetColor();
                Environment.Exit(0);
            }
        }
    }

    static void ShowAdminMenu()
    {
        while (true)
        {
            Console.WriteLine("\n====== АДМIНІСТРАТОРСЬКЕ МЕНЮ ======");
            Console.WriteLine("1. Меню товарiв");
            Console.WriteLine("2. Клiєнти");
            Console.WriteLine("3. Повернутись у головне меню");
            Console.WriteLine("=============================");

            int choice = GetUserInput("Оберiть пункт:");

            switch (choice)
            {
                case 1:
                    ShowMenuTov();
                    break;
                case 2:
                    ShowClientsMenu();
                    break;
                case 3:
                    ShowMainMenu();
                    break;
                default:
                    Console.WriteLine("Невiрний вибiр. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void ShowMenuTov()
    {
        while (true)
        {
            Console.WriteLine("========= МЕНЮ ТОВАРІВ =========");
            Console.WriteLine("1. Додати нові товари");
            Console.WriteLine("2. Звіт. Виведення всіх елементів у вигляді таблиці");
            Console.WriteLine("3. Видалити товар");
            Console.WriteLine("4. Пошук товару за назвою ");
            Console.WriteLine("5. Сортування ");
            Console.WriteLine("6. Статистика доданих товарів ");
            Console.WriteLine("7. Повернутись у адміністраторське меню");
            Console.WriteLine("--------------------------------");

            double choice = GetUserInput("Виберіть дію:");

            switch (choice)
            {
                case 1:
                    AddProducts();
                    Program.Return();
                    break;
                case 2:
                    ShowAllTablProducts();
                    Program.Return();
                    break;
                case 3:
                    ShowDellteProducts();
                    Program.Return();
                    break;
                case 4:
                    ShowSearchProduct();
                    Program.Return();
                    break;
                case 5:
                    BubleSort();
                    Program.Return();
                    break;
                case 6:
                    ShowStatisticsMenu();
                    Program.Return();
                    break;
                case 7:
                    ShowAdminMenu();
                    Program.Return();
                    break;

                default:
                    Console.WriteLine("Неправильний вибір.");
                    Program.Return();
                    break;
            }
        }
    }

    static void ShowClientsMenu()
    {
        Console.WriteLine("Функцiя в розробцi");
    }
    static void AddProducts()
    {
        Console.Write("Скільки товарів бажаєте додати? ");
        int count = Shownumber();

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Введіть назву товару #{i + 1}: ");
            string name = Console.ReadLine();

            Console.Write("Введіть ціну товару: ");
            int price = Shownumber();

            products.Add(new Products(name, price));
        }

        Console.WriteLine("Товар додано");
    }

    static void ShowAllTablProducts()
    {
        Console.WriteLine("\n=== ВСІ ТОВАРИ ===");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"|{"ID",-5}|{"Назва",-25}  |{"Ціна",-10}|");
        Console.WriteLine("------------------------------------------");

        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"|{i,-5}| {products[i].Name,-25} |{products[i].Price,-10}|");
        }

        Console.WriteLine("------------------------------------------");
    }

    static void ShowDellteProducts()
    {
        ShowAllTablProducts();

        Console.Write("Введіть ID товару для видалення: ");
        int id = Shownumber();

        if (id < 0 || id >= products.Count)
        {
            Console.WriteLine("Помилка: неправильний індекс!");
            return;
        }

        Console.WriteLine($"Товар видалено.");
        products.RemoveAt(id);
    }

    static void ShowSearchProduct()
    {
        Console.Write("Введіть назву товару: ");
        string name = Console.ReadLine();

        Products item = products.Find(p => p.Name == name);

        if (item == null)
        {
            Console.WriteLine("Не знайдено!");
            return;
        }

        Console.WriteLine($"Назва: {item.Name}, ціна: {item.Price} грн");
    } 
    static void BubleSort()
    {
        for (int i = 0; i < products.Count - 1; i++)
        {
            for (int j = 0; j < products.Count - i - 1; j++)
            {
                if (products[j].Price > products[j + 1].Price)
                {
                    Products temp = products[j];
                    products[j] = products[j + 1];
                    products[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Bubble Sort виконано (сортування за ціною).");
        BuiltInSort();
    }
    static void BuiltInSort()
    {
        products.Sort((x, y) => x.Price.CompareTo(y.Price));
        Console.WriteLine("List.Sort() виконано (сортування за ціною).");
    }

    static void ShowStatisticsMenu()
    {
        Console.WriteLine("\n=== СТАТИСТИКА ===");

        if (products.Count == 0)
        {
            Console.WriteLine("Колекція порожня!");
            return;
        }

        int min = products[0].Price;
        int max = products[0].Price;
        int sum = 0;

        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].Price < min) min = products[i].Price;
            if (products[i].Price > max) max = products[i].Price;

            sum += products[i].Price;
        }

        double avg = (double)sum / products.Count;

        Console.WriteLine($"Кількість товарів: {products.Count}");
        Console.WriteLine($"Мінімальна ціна: {min} грн");
        Console.WriteLine($"Максимальна ціна: {max} грн");
        Console.WriteLine($"Сумарна вартість усіх товарів: {sum} грн");
        Console.WriteLine($"Середня ціна: {avg:F2} грн");
    }


}