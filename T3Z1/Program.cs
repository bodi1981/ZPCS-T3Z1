using System;
using System.Globalization;

namespace T3Z1
{
    class Program
    {
        private static bool running = true;
        static void Main(string[] args)
        {
            while (running)
            {
                try
                {
                    Console.Write("Podaj imię: ");
                    string name = Console.ReadLine();
                    Console.Write("Podaj rok urodzenia: ");
                    string year = Console.ReadLine();
                    Console.Write("Podaj miesiąc urodzenia: ");
                    string month = Console.ReadLine();
                    Console.Write("Podaj dzień urodzenia: ");
                    string day = Console.ReadLine();
                    Console.Write("Podaj miejsce urodzenia: ");
                    string place = Console.ReadLine();

                    month = (month.Length == 1) ? $"0{month}" : month;
                    day = (day.Length == 1) ? $"0{day}" : day;

                    string dateOfBirth = $"{year}-{month}-{day}";

                    if (!ValidateDate(dateOfBirth))
                        throw new Exception("Podana data jest nieprawidłowa");

                    int age = CalculateAge(dateOfBirth);

                    Console.WriteLine($"Cześć {name} urodziłeś się w {place} i masz {age} lat");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Czy chcesz kontynouwać? Jeśli tak to wciśnij: t, jeśli nie to wciśnij dowolny klawisz");
                    char pressedKey = Console.ReadKey(true).KeyChar;

                    switch (Char.ToUpper(pressedKey))
                    {
                        case 'T':
                            running = true;
                            break;
                        default:
                            running = false;
                            break;
                    }
                }
            }
            

        }

        private static int CalculateAge(string dob)
        {
            DateTime dateOfBirth = DateTime.ParseExact(dob, "yyyy-MM-dd", CultureInfo.CurrentCulture);
            int actualDayOfYear = DateTime.Now.DayOfYear;
            int birthDayOfYear = dateOfBirth.DayOfYear;
            int actualYear = DateTime.Now.Year;
            int birthYear = dateOfBirth.Year;

            return (actualDayOfYear < birthDayOfYear) ? (actualYear - birthYear - 1) : (actualYear - birthYear);
        }

        private static bool ValidateDate(string date)
        {
            return DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime result);
        }
    }
}
