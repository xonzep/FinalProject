using Final.CoreRewrite.Actions;

namespace Final.CoreRewrite.UI;

public static class InputManager
{
        public static bool IsKeyPressed(ConsoleKey key)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                return keyInfo.Key == key;
            }
    
            return false;
        }
    
        public static int UserInputInt(string prompt, int range)
        {
            int input = 1;
            bool isInRange = false;
            Console.WriteLine(prompt);
            string? userInput = Console.ReadLine();
    
            while (!isInRange)
                if (!int.TryParse(userInput, out input))
                {
                    Console.WriteLine(
                        $"That is not a number.");
                    userInput = Console.ReadLine() ?? string.Empty;
                }
                else if (input > range)
                {
                    Console.WriteLine(
                        $"That number is not in range.");
                    userInput = Console.ReadLine() ?? string.Empty;
                }
                else
                {
                    isInRange = true;
                }
    
            return input;
        }
    
        public static string UserInputText(string prompt)
        {
            string userInput;
    
            while (true)
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine()!;
    
                if (userInput.Length is > 1 and <= 8 && !userInput.Any(char.IsDigit))
                    break;
    
                Console.WriteLine(
                    "Invalid name. Name must be more than 1 character and no more than 8. It cannot continue numbers.");
            }
    
            return userInput;
        }
    
        public static int GetActionName(List<IActions> actionsList, string actionName)
        {
            for (int i = 0; i < actionsList.Count; i++)
            {
                if (actionsList[i].GetName() == actionName)
                {
                    return i;
                }
            }
            return -1; //if it doesn't match.
        } 
}