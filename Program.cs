namespace Cosmetics_store;

class Program
{
    struct Product
    {
        public string Name;
        public double Price;
        public int QuantityInStock;  
        public bool Avaliability; 
    }
    static string futureProductsFile = "futureTovar_.txt";
    
    static void SaveFutureProductsToFile()
    {
        using (StreamWriter writer = new StreamWriter(futureProductsFile))
        {
            foreach (var p in products)
            {
                if (p.Avaliability == false)  // зберігаємо тільки ті, яких ще нема в наявності
                {
                    writer.WriteLine($"{p.Name}|{p.Price}|{p.QuantityInStock}|{p.Avaliability}");
                }
            }
        }
    }

    static void LoadFutureProductsFromFile()
    {
        products.Clear();

        if (!File.Exists(futureProductsFile))
            return;

        string[] lines = File.ReadAllLines(futureProductsFile);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length == 4)
            {
                Product p = new Product();
                p.Name = parts[0];
                p.Price = double.Parse(parts[1]);
                p.QuantityInStock = int.Parse(parts[2]);
                p.Avaliability = bool.Parse(parts[3]);

                products.Add(p);
            }
        }
    }

    static List<Product> products = new List<Product>();

    static bool GetBool(string prompt)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(prompt + " ");
            Console.ResetColor();

            string input = Console.ReadLine().Trim();

            if (input == "1") return true;
            if (input == "0") return false;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Помилка: введіть 1 (так) або 0 (ні)!");
            Console.ResetColor();
        }
    }

    static void AddProducts()
    {
        Console.WriteLine("\n=== Додавання товарів ===");

        for (int i = 0; i < 5; i++)
        {
            Product p = new Product();

            Console.WriteLine($"\nВведення товару №{i + 1}");

            Console.Write("Назва товару: ");
            p.Name = Console.ReadLine();

          
           p.Price = Shownumber("Ціна товару:");
            
            p.QuantityInStock = Shownumber("Кількість товару на складі (шт):");

            p.Avaliability = GetBool("Товар в наявності? (1 - так, 0 - ні):");

            products.Add(p);
        }
        SaveFutureProductsToFile();
        Console.WriteLine("\nУспішно додано 5 товарів!");
    }


    static void ShowAllProducts()
    { ShowProductMenu(); 
        Console.WriteLine("\n=== Список товарів ===");

        if (products.Count == 0)
        {
            Console.WriteLine("Немає збережених товарів.");
            return;
        }

        int index = 1;
        foreach (var p in products)
        {
            Console.WriteLine($"{index}. {p.Name} ціна: {p.Price} грн, кількість на складі {p.QuantityInStock},чи є в наявності в магазині: {p.Avaliability} ");
            index++;
        }
      
    }

    public static void Main(string[] args)
    {
        LoadFutureProductsFromFile(); 
        RenderIntro();
        bool working = true;

        while (working)
        {
            working = ShowMainMenu();
        }
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

            int choice = (int)GetUserInput("Оберiть пункт:");

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


    public static void Return()
    {
        Console.WriteLine("для продовження роботи натиснiть будь яку клавiшу");
        Console.ReadKey();
    }

    public static void RenderIntro()
    {
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("====== Ласкаво просимо до Cosmetics_store ======");
        Console.WriteLine("-------------------------------------------------");
        Console.ResetColor();
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


    public static double GetUserInput(string prompt = "Введiть число:")
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(prompt + " ");

        bool isNumber = Double.TryParse(Console.ReadLine(), out double choice);

        if (!isNumber)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ви ввели не число, введiть число яке відповiдає Вашому запиту");
            Console.ResetColor();
            return GetUserInput(prompt);
        }

        Console.ResetColor();

        return choice;
    }


    public static bool ShowMainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== ГОЛОВНЕ МЕНЮ =====");
        Console.WriteLine("1. Каталог товарiв");
        Console.WriteLine("2. Оформити замовлення");
        Console.WriteLine("3. Вхід для адміністратора");
        Console.WriteLine("4. Вихiд");
        Console.WriteLine();

        int choice = (int)GetUserInput("Виберiть пункт меню:");

        switch (choice)
        {
            case 1:
                ShowProductMenu();
                Return();
                return true;

            case 2:
                ShowOrderMenu();
                Return();
                return true;

            case 3:
                Admin();
                Return();
                return true;

            case 4:
                Console.WriteLine("Бувайте! Гарного дня!");
                return false;
            default:
                Console.WriteLine("Неправильний вибiр, спробуйте ще раз.");
                return true;
        }
    }


    static void ShowProductMenu()
    {

        double priceLipstick = 310;
        double priceMascara = 250;
        double priceConcealer = 320;
        double pricePowder = 330;
        double priceCrayon = 190;
        double priceEyebrowGel = 150;
        double priceBrushes = 900;


        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Каталог товарiв:");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"1. Помада - {priceLipstick} грн");
        Console.WriteLine($"2. Туш - {priceMascara} грн");
        Console.WriteLine($"3. Консилер - {priceConcealer} грн");
        Console.WriteLine($"4. Пудра - {pricePowder} грн");
        Console.WriteLine($"5. Олiвець для брiв - {priceCrayon} грн");
        Console.WriteLine($"6. Гель для брiв - {priceEyebrowGel} грн");
        Console.WriteLine($"7. Набiр пензлiв для макiяжу - {priceBrushes} грн");
        Console.ResetColor();
    }


    static void ShowOrderMenu()
    {
        double priceLipstick = 310;
        double priceMascara = 250;
        double priceConcealer = 320;
        double pricePowder = 330;
        double priceCrayon = 190;
        double priceEyebrowGel = 150;
        double priceBrushes = 900;

        double lipstick = Shownumber("Введiть кiлькiсть помад (шт.):");
        double mascara = Shownumber("Введiть кiлькiсть туш для вiй (шт.):");
        double concealer = Shownumber("Введiть кiлькiсть консилерiв (шт.):");
        double powder = Shownumber("Введiть кiлькiсть пудри (шт.):");
        double crayon = Shownumber("Введiть кiлькiсть олiвцiв для брiв (шт.):");
        double eyebrowGel = Shownumber("Введiть кiлькiсть гелiв для брiв (шт.):");
        double brushes = Shownumber("Введiть кiлькiсть наборiв пензлiв для макiяжу (шт.):");

        double totalLipstick = lipstick * priceLipstick;
        double totalMascara = mascara * priceMascara;
        double totalConcealer = concealer * priceConcealer;
        double totalPowder = powder * pricePowder;
        double totalCrayon = crayon * priceCrayon;
        double totalEyebrowGel = eyebrowGel * priceEyebrowGel;
        double totalBrushes = brushes * priceBrushes;

        double totalPrice = totalLipstick + totalMascara + totalConcealer + totalPowder + totalCrayon +
                            totalEyebrowGel + totalBrushes;

        Console.ForegroundColor = ConsoleColor.Gray;

        double discountPercentage = 5;
        if (totalPrice >= 1000 && totalPrice < 5000)
            discountPercentage = 15;
        else if (totalPrice >= 5000 && totalPrice < 10000)
            discountPercentage = 25;
        else if (totalPrice >= 10000)
            discountPercentage = 50;

        double discountAmount = Math.Round(totalPrice * (discountPercentage / 100));
        double price = totalPrice - discountAmount;

        Console.WriteLine();
        Console.WriteLine("=== Підсумок покупки ===");
        Console.WriteLine($"Помада: {lipstick} шт., вартість за шт ({priceLipstick}), вартість: {totalLipstick} грн.");
        Console.WriteLine($"Туш: {mascara} шт., вартість за шт ({priceMascara}), вартість: {totalMascara} грн.");
        Console.WriteLine(
            $"Консилер: {concealer} шт., вартість за шт ({priceConcealer}), вартість: {totalConcealer} грн.");
        Console.WriteLine($"Пудра: {powder} шт., вартість за шт ({pricePowder}), вартість: {totalPowder} грн.");
        Console.WriteLine(
            $"Олiвець для брiв: {crayon} шт., вартість за шт ({priceCrayon}), вартість: {totalCrayon} грн.");
        Console.WriteLine(
            $"Гель для брiв: {eyebrowGel} шт., вартість за шт ({priceEyebrowGel}), вартість: {totalEyebrowGel} грн.");
        Console.WriteLine(
            $"Набір пензлів для макіяжу: {brushes} шт., вартість за шт ({priceBrushes}), вартість: {totalBrushes} грн.");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n--- Деталi замовлення ---");
        Console.WriteLine($"Загальна вартiсть без знижки: {totalPrice} грн");
        Console.WriteLine($"Знижка ({discountPercentage}%): {discountAmount} грн");
        Console.WriteLine($"Вартiсть з знижкою: {price} грн");
        Console.WriteLine("Ваше замовлення успiшно оформлено! Гарного дня");
        Console.ResetColor();


        System.Console.WriteLine("Дякуємо за вашу покупку!");


    }


    static void ShowClientsMenu()
    {
        Console.WriteLine("Функцiя в розробцi");
    }

    static void ShowMenuTov()
    {
        while (true)
        {
            Console.WriteLine("========= МЕНЮ ТОВАРІВ =========");
            Console.WriteLine("1. Додати нові товари, які згодом з'являться в продажі (5 шт)");
            Console.WriteLine("2. Звіт");
            Console.WriteLine("3. Редагувати товар (в розробці)");
            Console.WriteLine("4. Видалити товар (в розробці)");
            Console.WriteLine("5. Пошук товару за назвою (в розробці)");
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
                    ShowAllProducts();
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
                    Console.WriteLine("Функція в розробці або неправильний вибір.");
                    Program.Return();
                    break;
            }
        }
    }



    static void ShowStatisticsMenu()
    {
        Console.WriteLine("\n=== СТАТИСТИКА ТОВАРІВ, ЯКІ ЗГОДОМ З'ЯВЛЯТЬСЬ В ПРОДАЖІ ===");

        if (products.Count == 0)
        {
            Console.WriteLine("Немає даних для аналізу – список товарів порожній. Ви не додали нових товарів");
            return;
        }

        double total = 0;
        int count = products.Count;
        int countAbove500 = 0;

        double minPrice = double.MaxValue;
        double maxPrice = double.MinValue;

        string minName = "";
        string maxName = "";

        foreach (var p in products)
        {
            total += p.Price;

            if (p.Price > 500)
                countAbove500++;

            if (p.Price < minPrice)
            {
                minPrice = p.Price;
                minName = p.Name;
            }

            if (p.Price > maxPrice)
            {
                maxPrice = p.Price;
                maxName = p.Name;
            }
        }

        double average = total / count;

        Console.WriteLine($"Загальна сума всіх товарів: {total} грн");
        Console.WriteLine($"Середня ціна товарів: {Math.Round(average, 2)} грн");
        Console.WriteLine($"Кількість товарів: {count}");
        Console.WriteLine($"Кількість товарів з ціною > 500 грн: {countAbove500}");
        Console.WriteLine($"Найдешевший товар: {minName} — {minPrice} грн");
        Console.WriteLine($"Найдорожчий товар: {maxName} — {maxPrice} грн");

        Console.WriteLine("\nНатисніть будь-яку клавішу, щоб продовжити...");
        Console.ReadKey();
    }
}

    
