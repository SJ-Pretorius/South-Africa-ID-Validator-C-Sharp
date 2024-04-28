using System;

public class IDValidator
{
    public static void Main()
    {
        while (true)
        {
            Console.Write("\nEnter a South African ID number (Enter 0 to exit): ");
            string input = Console.ReadLine();

            bool luhn;
            if (input.Length == 13 && !System.Text.RegularExpressions.Regex.IsMatch(input, @".*[a-zA-Z].*"))
            {
                luhn = IsValidLuhn(input);
            }
            else if (input.Equals("0"))
            {
                break;
            }
            else
            {
                Console.Write("No ID number detected.\n");
                continue;
            }

            string validate;
            if (luhn)
            {
                validate = "ID number " + input + " is valid.";
            }
            else
            {
                validate = "ID number " + input + " is invalid.";
            }

            Console.Write(validate + "\n ");
        }
    }

    public static bool IsValidLuhn(string number)
    {
        int checksum = int.Parse(number.Substring(number.Length - 1));
        int total = 0;

        for (int i = number.Length - 2; i >= 0; i--)
        {
            int sum = 0;
            int digit = int.Parse(number.Substring(i, 1));

            if (i % 2 == number.Length % 2)
            {
                digit = digit * 2;
            }

            sum = digit / 10 + digit % 10;
            total += sum;
        }

        return total % 10 != 0 ? 10 - total % 10 == checksum : checksum == 0;
    }
}
