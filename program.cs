while (true)
{   
    Console.WriteLine("Tjena!\nVälkommen till kontroll av svenska personnummer");

    // Ändra textfärgen till turkos
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Ange ditt personnummer 10 eller 12 siffror");
    string pnr = Console.ReadLine();

    if (pnr.Length == 10 || pnr.Length == 12)
    {
        // Extrahera datumdel
        string dateformat;
        string datepart;

        if (pnr.Length == 12) // om användaren matar in 12 siffror ÅÅÅÅMMDD
        {
            datepart = pnr.Substring(0, 8); // de första 8 siffrorna
            dateformat = "yyyyMMdd";
        }
        else
        {
            datepart = pnr.Substring(0, 6); // de första 6 siffrorna
            dateformat = "yyMMdd";
        }

        // Validera datum
        if (DateTime.TryParseExact(datepart, dateformat, null, System.Globalization.DateTimeStyles.None, out DateTime Datumet))
        {
            Console.WriteLine($"Födelsedatum: {Datumet.ToShortDateString()}");
        }
        else
        {
            Console.WriteLine("Ogiltigt datum i personnumret!");
            continue; // Be användaren försöka igen
        }

        // Kontrollera kontrollsiffra
        int kontrollsiffra = int.Parse(pnr[^1].ToString());
        string firstNineDigits = pnr.Length == 12 ? pnr.Substring(2, 9) : pnr.Substring(0, 9);
        int expectedControlDigit = CalculateLuhn(firstNineDigits);

        if (kontrollsiffra == expectedControlDigit)
        {
            Console.WriteLine("Personnumret är giltigt!");
        }
        else
        {
            Console.WriteLine("Personnumret är ogiltigt!");
        }
        // Kontrollera kön baserat på den nästsista siffran
        int genderDigit = pnr.Length == 12 ? int.Parse(pnr[10].ToString()) : int.Parse(pnr[8].ToString());

        if (genderDigit % 2 == 0)
        {
            Console.WriteLine("Kön: Kvinna");
        }
        else
        {
            Console.WriteLine("Kön: Man");
        }

        // Fråga om användaren vill fortsätta
        Console.WriteLine("Vill du mata in ett annat personnummer? (ja/nej)");
        string svar = Console.ReadLine()?.ToLower();
        if (svar == "nej")
        {
            Console.WriteLine("Programmet avslutas. Tack!");
            break;
        }

        Console.Clear(); // Töm skärmen för nästa inmatning
    }
    else
    {
        Console.WriteLine("Ogiltigt personnummer. Försök igen!");
        Console.WriteLine("Tryck på valfri tangent");
        Console.ReadKey();
        Console.Clear();
    }
}

// Kontrollera kontrollsiffran med Luhn-algoritmen
int CalculateLuhn(string digits)
{
    int sum = 0;

    for (int i = 0; i < digits.Length; i++)
    {
        int digit = int.Parse(digits[i].ToString());

        // Multiplicera varannan siffra med 2 (börja från höger)
        if ((digits.Length - i) % 2 == 1)
        {
            digit *= 2;
            if (digit > 9) digit -= 9; // Justera tvåsiffriga resultat
        }

        sum += digit;
    }

    return (10 - (sum % 10)) % 10; // Returnera kontrollsiffran
}
