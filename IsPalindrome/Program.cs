using System.Text;

namespace IsPalindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Declaring variables
            char cUserChoice = ' ';
            string sUserInput = string.Empty;
            while (true)
            {
                // Welcome message
                WelcomeApp("check is palindrome on a string input");
                // ask user to enter the word to check if it is palindrome or not
                ReadString("word you want to check", out sUserInput);
                // applay the logic to check if the word is palindrome or not
                CheckPalindrome(sUserInput);



                // To read user choice to continue in the app again and validate the user input
                if (!IsChar("y to continue in the application else enter n", out cUserChoice))
                    return;
                // Convert the character to lower 
                cUserChoice = Char.ToLower(cUserChoice);
                // To check the user input in the right format (y,n)
                if (!IsInRightFormat(cUserChoice))
                    return;
                // To check if the user want to continue or not
                if (!WantToContinue(cUserChoice))
                    return;
            }

        }

        // This region contains the main methods used in the application
        #region main-methods

        // 1) this method to welcome user in the beginning of the application
        static void WelcomeApp(String welcomeMessage)
        {
            Console.Clear();
            Console.WriteLine("*********************************************************************************");
            Console.WriteLine($"  Welcome to {welcomeMessage} Application!");
            Console.WriteLine("  This app is designed to make your life easier.");
            Console.WriteLine("  Let's get started!");
            Console.WriteLine("  Developed by: Mohammed Salem");
            Console.WriteLine("*********************************************************************************");
        }

        // 2) this method to print message in a beatiful form
        static void Print(String message)
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("---------------------------------------------------------------------------------");
        }

        // 3) this method to read and validate character from the user
        static bool IsChar(string field, out char cInput)
        {
            Console.Write($"Please, enter {field}: ");
            if (!char.TryParse(Console.ReadLine(), out cInput))
            {
                Print("Please, enter a valid character");
                return false;
            }
            return true;
        }

        // 4) this method to check that the user entered (y,n) only
        static bool IsInRightFormat(char input)
        {
            if (input == 'y' || input == 'n')
                return true;
            Print("Please, enter (y) to continue in the application again else enter (n)");
            return false;
        }

        // 5) this method to check the user choice if he wants to continue in the app or not
        static bool WantToContinue(char input)
        {
            if (input == 'y')
                return true;
            Print("The program ended : see you soon again");
            return false;
        }

        // 6) this method to read a string from user
        static void ReadString(string field, out string value)
        {
            Console.Write($"Please enter the {field}: ");
            value = Console.ReadLine();
        }

        // 7) this method to check if the string is palindrome or not
        static void CheckPalindrome(string input)
        {
            // for ignoring case sensitivity
            input = input.ToLower();
            // for removing all whitespaces from the string
            string sClearWhitespaces = RemoveAllSapces(input);
            // for reversing the string
            string sReversedWord = ReverseString(sClearWhitespaces);
            // apply palidrome logic
            if (IsPalindrome(sClearWhitespaces, sReversedWord))
                Print("This word is palindrome");
            else
                Print("This word is not palindrome");
        }

        // 8) This method to reverse the string
        static string ReverseString(string input)
        {
            StringBuilder sbReversed = new StringBuilder();
            for (int nCounter=input.Length-1;nCounter>=0;nCounter--)
                sbReversed.Append(input[nCounter]);
            return sbReversed.ToString();
        }

        // 9) This method to remove all whitespaces from the string
        static string RemoveAllSapces(string input)
        {
            StringBuilder sbWithoutSpaces = new StringBuilder();
            for (int nCounter = 0; nCounter < input.Length; ++nCounter)
            {
                if (input[nCounter] != ' ')
                    sbWithoutSpaces.Append(input[nCounter]);
            }
            return sbWithoutSpaces.ToString();
        }

        // 10) to check if the string is palindrome or not
        static bool IsPalindrome(string input1,string input2)
        {
            for (int nCounter=0;nCounter<=input1.Length-1;++nCounter)
            {
                if (input1[nCounter] == input2[nCounter])
                    continue;
                else
                    return false;
            }
            return true;
        }
       
        #endregion


    }
}