using System.Diagnostics;
//m1chael888

namespace mathgame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            var matchHistory = new List<string>();

            Menu();

            void Menu()
            {
                bool done = false;
                while (!done) // loop prompt untill a valid input is provided
                {
                    // prompt user input
                    Console.WriteLine("- MathGame1337 Menu - Choose an option by entering its correpsonding number");
                    Console.WriteLine("1 Play");
                    Console.WriteLine("2 Match History");
                    Console.WriteLine("3 Exit game");
                    string input = Console.ReadLine();

                    switch (input) // handle user input
                    {
                        case "1":
                            stopwatch.Start();
                            Console.WriteLine();
                            done = true;
                            StartGame();
                            break;
                        case "2":
                            done = true;
                            ShowMatchHistory();
                            break;
                        case "3":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid selection, try again\n");
                            break;
                    }
                }
            }

            void StartGame(int score = 0, int count = 0)
            {
                while (true)
                {
                    float answer = Question(count + 1); // question method generates question and provides its answer
                    count++;
                    int attempt = Convert.ToInt32(Console.ReadLine());

                    // handle user input
                    if (answer == attempt)
                    {
                        score++;
                        Console.WriteLine($"Correct! Score updated: {score}/{count}");
                    }
                    else Console.WriteLine($"Incorrect. Better luck next time");

                    bool done = false;
                    while (!done)
                    {
                        // prompt navigation input
                        Console.WriteLine("\nWhats next? Choose an option by entering its correpsonding number");
                        Console.WriteLine("1 Play again");
                        Console.WriteLine("2 End game and return to menu");
                        Console.WriteLine("3 Exit game");
                        string input = Console.ReadLine();

                        switch (input)
                        {
                            case "1":
                                done = true;
                                Console.Clear();
                                StartGame(score, count);
                                break;
                            case "2":
                                stopwatch.Stop();
                                int gameNumber = matchHistory.Count + 1;

                                Console.WriteLine($"Time elapsed in game: {stopwatch.ToString()}s");
                                if (count > 0) matchHistory.Add($"Game {gameNumber} Score: {score}/{count}");

                                done = true;
                                Console.Clear();
                                Menu();
                                break;
                            case "3":
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid selection, try again");
                                break;
                        }
                    }
                }
            }

            float Question(int count)
            {
                char[] operators = { '+', '-', 'x', '/' };
                var random = new Random();
                char? operation = 'o';
                bool done = false;

                while (!done)
                {
                    // prompt user input for operation mode
                    Console.WriteLine("Choose an operation mode");
                    Console.WriteLine("1 Addition +");
                    Console.WriteLine("2 Subtraction -");
                    Console.WriteLine("3 Multiplication x");
                    Console.WriteLine("4 Division /");
                    Console.WriteLine("5 Random");
                    string input = Console.ReadLine();
                    
                    switch (input)
                    {
                        case "1":
                            operation = '+';
                            done = true;
                            continue;
                        case "2":
                            operation = '-';
                            done = true;
                            continue;
                        case "3":
                            operation = '*';
                            done = true;
                            continue;
                        case "4":
                            operation = '/';
                            done = true;
                            continue;
                        case "5":
                            operation = operators[random.Next(4)];
                            done = true;
                            continue;
                        default:
                            Console.WriteLine("Invalid selection, try again\n");
                            break;
                    }
                }

                float num1 = random.Next(101);
                float num2 = random.Next(101);
                float answer = 0;

                // reroll numbers if answer isnt an integer or dividing by 0
                if (operation == '/')
                {
                    while (num1 % num2 != 0 || num2 == 0)
                    {
                        num1 = random.Next(101);
                        num2 = random.Next(101);
                    }
                }

                // perform relevant operation on nums
                switch (operation)
                {
                    case '+':
                        answer = num1 + num2;
                        break;
                    case '-':
                        answer = num1 - num2;
                        break;
                    case 'x':
                        answer = num1 * num2;
                        break;
                    case '/':
                        answer = num1 / num2;
                        break;
                }

                Console.WriteLine($"Question {count}: {num1} {operation} {num2} = ?");
                return answer;
            }

            void ShowMatchHistory()
            {
                Console.WriteLine();
                // display each previous game saved in list
                if (matchHistory.Count > 0)
                {
                    Console.WriteLine("- Your recent games -");
                    foreach (var match in matchHistory)
                    {
                        Console.WriteLine(match);
                    }
                }
                else Console.WriteLine("You havent played any games in this session");

                bool done = false;

                while (!done)
                {
                    // prompt user input
                    Console.WriteLine("\nWhats next? Choose an option by entering its correpsonding number");
                    Console.WriteLine("1 Back to menu");
                    Console.WriteLine("2 Exit game");
                    string input2 = Console.ReadLine();

                    switch (input2)
                    {
                        case "1":
                            Console.WriteLine("");
                            done = true;
                            Console.Clear();
                            Menu();
                            break;
                        case "2":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid selection, try again");
                            break;
                    }
                }
            }
        }
    }
}
