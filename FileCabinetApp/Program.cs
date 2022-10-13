using System.Globalization;
using System.Text;

namespace FileCabinetApp
{
    public static class Program
    {
        private const string DeveloperName = "Stanislau Zaitsau";
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";
        private const int CommandHelpIndex = 0;
        private const int DescriptionHelpIndex = 1;
        private const int ExplanationHelpIndex = 2;
        private static FileCabinetService fileCabinetService = new FileCabinetService();

        private static bool isRunning = true;

        private static Tuple<string, Action<string>>[] commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("help", PrintHelp),
            new Tuple<string, Action<string>>("exit", Exit),
            new Tuple<string, Action<string>>("stat", Stat),
            new Tuple<string, Action<string>>("create", Create),
            new Tuple<string, Action<string>>("list", List),
            new Tuple<string, Action<string>>("edit", Edit),
            new Tuple<string, Action<string>>("find", Find),
        };

        private static string[][] helpMessages = new string[][]
        {
            new string[] { "help", "prints the help screen", "The 'help' command prints the help screen." },
            new string[] { "exit", "exits the application", "The 'exit' command exits the application." },
            new string[] { "stat", "shows the number of records", "The 'stat' command shows the number of records." },
            new string[] { "create", "creates a new profile in records.", "The 'create' command creates a new profile in records." },
            new string[] { "list", "shows all records.", "The 'list' command shows all records." },
            new string[] { "edit", "edits a record.", "The 'edit' command edits a record." },
            new string[] { "find", "finding list of elements in record which satisfing some criteria.", "The 'find' command is finding list of elements in record which satisfing some criteria." },
        };

        public static void Main(string[] args)
        {
            Console.WriteLine($"File Cabinet Application, developed by {Program.DeveloperName}");
            Console.WriteLine(Program.HintMessage);
            Console.WriteLine();

            do
            {
                Console.Write("> ");
                var line = Console.ReadLine();
                var inputs = line != null ? line.Split(' ', 2) : new string[] { string.Empty, string.Empty };
                const int commandIndex = 0;
                var command = inputs[commandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(Program.HintMessage);
                    continue;
                }

                var index = Array.FindIndex(commands, 0, commands.Length, i => i.Item1.Equals(command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    const int parametersIndex = 1;
                    var parameters = inputs.Length > 1 ? inputs[parametersIndex] : string.Empty;
                    commands[index].Item2(parameters);
                }
                else
                {
                    PrintMissedCommandInfo(command);
                }
            }
            while (isRunning);
        }

        private static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }

        private static void PrintHelp(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                var index = Array.FindIndex(helpMessages, 0, helpMessages.Length, i => string.Equals(i[Program.CommandHelpIndex], parameters, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    Console.WriteLine(helpMessages[index][Program.ExplanationHelpIndex]);
                }
                else
                {
                    Console.WriteLine($"There is no explanation for '{parameters}' command.");
                }
            }
            else
            {
                Console.WriteLine("Available commands:");

                foreach (var helpMessage in helpMessages)
                {
                    Console.WriteLine("\t{0}\t- {1}", helpMessage[Program.CommandHelpIndex], helpMessage[Program.DescriptionHelpIndex]);
                }
            }

            Console.WriteLine();
        }

        private static void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            isRunning = false;
        }

        private static void Stat(string parameters)
        {
            var recordsCount = Program.fileCabinetService.GetStat();
            Console.WriteLine($"{recordsCount} record(s).");
        }

        private static void Create(string parameters)
        {
            while (true)
            {
                try
                {
                    Console.Write("First name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Age: ");
                    short age = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Date of birth: ");
                    string dateOfBirth = Console.ReadLine();
                    DateTime birthday = DateTime.Parse(dateOfBirth, CultureInfo.CreateSpecificCulture("en-US"));
                    Console.Write("Income per year: ");
                    decimal incomePerYear = Convert.ToDecimal(Console.ReadLine());
                    int profileId = fileCabinetService.CreateRecord(firstName, lastName, age, birthday, incomePerYear);
                    Console.WriteLine($"Record #{profileId} is created.");
                    break;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try again:");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try again:");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valid Date of Birth format is mm/dd/yyyy.");
                    Console.WriteLine("Try again:");
                }
            }
        }

        private static void Edit(string parameters)
        {
            try
            {
                int id = Convert.ToInt32(parameters);
                if (id < fileCabinetService.GetStat())
                {
                    throw new ArgumentException($"Record #{id} is not found.");
                }

                Console.Write("First name: ");
                string? firstName = Console.ReadLine();
                Console.Write("Last name: ");
                string? lastName = Console.ReadLine();
                Console.Write("Age: ");
                short age = Convert.ToInt16(Console.ReadLine());
                Console.Write("Date of birth: ");
                string dateOfBirth = Console.ReadLine();
                DateTime birthday = DateTime.Parse(dateOfBirth, CultureInfo.CreateSpecificCulture("en-US"));
                Console.Write("Income per year: ");
                decimal incomePerYear = Convert.ToDecimal(Console.ReadLine());
                fileCabinetService.EditRecord(id, firstName, lastName, age, birthday, incomePerYear);
                Console.WriteLine($"Record #{id} is updated.");
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Valid Date of Birth format is mm/dd/yyyy.");
            }
        }

        private static void List(string parameters)
        {
            var records = fileCabinetService.GetRecords();
            foreach (var record in records)
            {
                Console.WriteLine(record);
            }
        }

        private static void Find(string parameters)
        {
            try
            {
                string[] criteriaAndElement = parameters.Split(' ');
                if (criteriaAndElement.Length != 2)
                {
                    throw new ArgumentException("Find command must look like this:\nfind {criteria} {parameter to compare}");
                }

                string criteria = criteriaAndElement[0].ToLower();
                string element = criteriaAndElement[1].ToLower();

                switch (criteria)
                {
                    case "firstname":
                        if (element is null)
                        {
                            throw new ArgumentNullException("First name length must cosists from 2 to 60 letters.");
                        }

                        PrintFind(EFindCriteria.FirstName, element);
                        break;
                    case "lastname":
                        if (element is null)
                        {
                            throw new ArgumentNullException("Last name length must cosists from 2 to 60 letters.");
                        }

                        PrintFind(EFindCriteria.LastName, element);
                        break;
                    case "age":
                        int age;
                        if (!Int32.TryParse(element, out age))
                        {
                            throw new ArgumentException("Must be integer.");
                        }

                        PrintFind(EFindCriteria.Age, element);
                        break;
                    case "dateofbirth":
                        DateTime dateOfBirth;
                        if (!DateTime.TryParse(element, out dateOfBirth))
                        {
                            throw new ArgumentException("Valid date of birth format: mm/dd/yyyy.");
                        }

                        PrintFind(EFindCriteria.DataOfBirth, element);
                        break;
                    case "incomeperyear":
                        double incomePerYear;
                        if (!Double.TryParse(element, out incomePerYear))
                        {
                            throw new ArgumentException("Must be real number.");
                        }

                        PrintFind(EFindCriteria.IncomePerYear, element);
                        break;
                    case "id":
                        int id;
                        if (!Int32.TryParse(element, out id))
                        {
                            throw new ArgumentException("Must integer number.");
                        }

                        PrintFind(EFindCriteria.Id, element);
                        break;
                    default:
                        throw new ArgumentException("Field are availible to find:\n||||||||||||||||\n->FirstName\n->LastName\n->Age\n->DateOfBirth\n->IncomePerYear\n->Id\n||||||||||||||||");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintFind(EFindCriteria criteria, string element)
        {
            foreach (var el in fileCabinetService.Find(criteria, element))
            {
                Console.WriteLine(el);
            }
        }
    }
}