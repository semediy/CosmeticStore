namespace Cosmetics_store;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\n--- Вас, вiтає магазин 'Cosmetics store' ---");
        Console.ResetColor();
        double priceLipstick = 310;
        double priceMascara = 250;
        double priceConcealer = 320;
        double pricePowder = 330;
        double priceCrayon = 190;
        double priceEyebrowGel = 150;
        double priceBrushes = 900;
        
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Каталог товарiв: ");
        Console.ResetColor();
        Console.WriteLine($"$ 1. Помада {priceLipstick}");
        Console.WriteLine($"$ 2. Туш {priceMascara}");
        Console.WriteLine($"3. Консилер - {priceConcealer} грн");
        Console.WriteLine($"4. Пудра - {pricePowder} грн");
        Console.WriteLine($"5. Олiвець для брiв - {priceCrayon} грн");
        Console.WriteLine($"6. Гель для брiв - {priceEyebrowGel} грн");
        Console.WriteLine($"7. Набiр пензлiв для макiяжу - {priceBrushes} грн");
        
        Console.Write("Введiть кiлькiсть помад (шт.)");
        double lipstick = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введiть кiлькiсть туш для вiй (шт.)");
        double mascara = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введiть кiлькiсть Консилерiв (шт.)");
        double concealer = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введiть кiлькiсть пудри (шт.)");
        double powder = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введiть кiлькiсть олiвцiв для брiв (шт.)");
        double crayon = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введiть кiлькiсть гелей для брiв (шт.)");
        double eyebrowGel = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введiть кiлькiсть наборiв пензлiв для макiяжу  (шт.)");
        double brushes = Convert.ToDouble(Console.ReadLine());
        
        double totalLipstick = lipstick * priceLipstick;
        double totalMascara = mascara * priceMascara;
        double totalConcealer = concealer * priceConcealer;
        double totalPowder = powder * pricePowder;
        double totalCrayon = crayon * priceCrayon;
        double totalEyebrowGel = eyebrowGel * priceEyebrowGel;
        double totalBrushes = brushes * priceBrushes;
        
        double totalPrice = totalLipstick + totalMascara + totalConcealer + totalPowder + totalCrayon + totalEyebrowGel +  totalBrushes;
        double discountPercentage = 5;
        double discountAmount = totalPrice * (discountPercentage / 100);
        double finalPrice = totalPrice - discountAmount;
        
        double roundedPrice = Math.Round(finalPrice, 0);
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n--- Деталi замовлення ---");
        Console.WriteLine($"Загальна вартiсть без знижки: {totalPrice} грн");
        Console.WriteLine($"Знижка ({discountPercentage}%): {discountAmount} грн");
        Console.WriteLine($"Пiдсумкова сума до сплати з округленням до 0 знаків {roundedPrice}");
        Console.WriteLine("Ваше замовлення успішно оформлено! Гарного дня");
        Console.ResetColor();

    }
    
}