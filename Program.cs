namespace Cosmetics_store;

class Program
{
    public static void Main(string[] args)
    {
        RenderIntro();

        while (true)
        {
            ShowMainMenu();
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

                string input = Console.ReadLine();

                number = int.Parse(input);

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


    public static void ShowMainMenu()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Головне меню:");
        Console.WriteLine("1. Каталог товарiв");
        Console.WriteLine("2. Оформити замовлення");
        Console.WriteLine("3. Клiєнти");
        Console.WriteLine("4. Меню товарiв");
        Console.WriteLine("5. Статистика");
        Console.WriteLine("6. Вихiд");
        Console.ResetColor();
        Console.WriteLine("\n");
        Console.WriteLine();
        
        int choice = (int)GetUserInput("Виберiть пункт меню:");

        switch (choice)
        {
            case 1:
                ShowProductMenu();
                Return();
                break;
            case 2:
                ShowOrderMenu();
                Return();
                break;
            case 3:
                ShowClientsMenu();
                Return();
                break;
            case 4:
                ShowMenuTov();
                Return();
                break;
            case 5:
                ShowStatisticsMenu();
                Return();
                break;
            case 6:
                Console.WriteLine("Бувайте! Гарного дня!");
                Environment.Exit(0);
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неправильний вибiр");
                Console.WriteLine("==================");
                Console.WriteLine("Спробуйте ще раз");
                break;
                Console.ResetColor();
        }
    }

    private static void ShowProductMenu()
    {

        double priceLipstick = 310;
        double priceMascara = 250;
        double priceConcealer = 320;
        double pricePowder = 330;
        double priceCrayon = 190;
        double priceEyebrowGel = 150;
        double priceBrushes = 900;


        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Каталог товарiв: ");
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


    private static void ShowOrderMenu()
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
         double price = totalPrice-discountAmount;

        System.Console.WriteLine();
        Console.WriteLine("=== Підсумок покупки ===");
        Console.WriteLine($"Помада: {lipstick} шт., вартість за шт ({priceLipstick}), вартість: {totalLipstick} грн.");
        Console.WriteLine($"Туш: {mascara} шт., вартість за шт ({priceMascara}), вартість: {totalMascara} грн.");
        Console.WriteLine($"Консилер: {concealer} шт., вартість за шт ({priceConcealer}), вартість: {totalConcealer} грн.");
        Console.WriteLine($"Пудра: {powder} шт., вартість за шт ({pricePowder}), вартість: {totalPowder} грн.");
        Console.WriteLine($"Олiвець для брiв: {crayon} шт., вартість за шт ({priceCrayon}), вартість: {totalCrayon} грн.");
        Console.WriteLine($"Гель для брiв: {eyebrowGel} шт., вартість за шт ({priceEyebrowGel}), вартість: {totalEyebrowGel} грн.");
        Console.WriteLine($"Набір пензлів для макіяжу: {brushes} шт., вартість за шт ({priceBrushes}), вартість: {totalBrushes} грн.");
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


private static void ShowClientsMenu()
    {
        Console.WriteLine("Функцiя в розробцi");
    }

    private static void ShowMenuTov()
    {
        Console.WriteLine("========= МЕНЮ ТОВАРІВ =========");
        Console.WriteLine("1. Додати новий товар");
        Console.WriteLine("2. Переглянути всi товари");
        Console.WriteLine("3. Редагувати товар");
        Console.WriteLine("4. Видалити товар");
        Console.WriteLine("5. Пошук товару за назвою");
        Console.WriteLine("6. Сортувати за цiною / кiлькiстю");
        Console.WriteLine("7. Повернутись у головне меню");
        Console.WriteLine("--------------------------------");

        double choice = GetUserInput("Виберiть дiю:");

        if (choice > 0 && choice < 8 && choice != 2 && choice != 7)
        {
            Console.WriteLine("Фунцiя в розробцi");
            return;
        }
        else if (choice == 2)
        {
            ShowProductMenu();  
        }
        else if (choice == 7)
        {
            // ShowMainMenu();
        }
        else
        {
            Console.WriteLine("Неправильний пункт меню");
            return;
        }

    }

    private static void ShowStatisticsMenu()
    {
        Console.WriteLine("Фунцiя в розробцi");
        return;
    }
}
    
