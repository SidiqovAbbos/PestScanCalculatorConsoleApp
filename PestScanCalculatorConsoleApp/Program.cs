// See https://aka.ms/new-console-template for more information
using PestScanCalculatorConsoleApp.Model;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

WriteLineMessage("----------------------------------------------------");
WriteLineMessage("******* Welcome to PestScan calculator app! ********");
WriteLineMessage("----------------------------------------------------");

string type = "";
Calculator calculator = new();
while (type != "q")
{
	try
	{
		if (type == "x") // Clear calculator value
		{
			calculator = new Calculator();
			type = string.Empty;
		}

		if (type == string.Empty) // Initialize the first value
		{
			WriteMessage("Type the first value: ");
			double a = double.Parse(ReadValue("0"));
			calculator = new Calculator(a);
        }

        // Instruction of using operators
        WriteLineMessage("");
        WriteLineMessage("----------------------", ConsoleColor.Yellow);
		WriteLineMessage("1. Addition (default)", ConsoleColor.Yellow);
		WriteLineMessage("2. Subtraction", ConsoleColor.Yellow);
		WriteLineMessage("3. Multiplication", ConsoleColor.Yellow);
		WriteLineMessage("4. Division", ConsoleColor.Yellow);
        WriteLineMessage("----------------------", ConsoleColor.Yellow);

		WriteLineMessage("");
        WriteMessage("Chouse your operator (1/2/3/4): ");
		Operation operation = (Operation) int.Parse(ReadValue("1"));

		// Second value reader
		WriteLineMessage("");
		WriteMessage("Type the second value: ");
		double b = double.Parse(ReadValue("0"));

		double oldResult = calculator.Result;

		// Calculate the result by operation type 
		calculator = operation switch 
		{
			Operation.Addition => calculator.AddTo(b),
			Operation.Subtraction => calculator.SubtractTo(b),
			Operation.Multiplication => calculator.MultiplTo(b),
			Operation.Division => calculator.DivTo(b),
			_ => throw new NotImplementedException()
        };

		// Result message
		WriteLineMessage("");
		WriteLineMessage($"{oldResult} {GetOperationSymbol(operation)} {b} = {calculator.Result}", ConsoleColor.Green);

        // Some commands of using this app
        WriteLineMessage("");
        WriteLineMessage("Type 'q' - to leave this app.", ConsoleColor.Yellow);
        WriteLineMessage("Type 'x' - to clear the calculator.", ConsoleColor.Yellow);
        WriteLineMessage("Press 'Enter' - to continue. (default)", ConsoleColor.Yellow);

        WriteLineMessage("");
        WriteMessage("Type your command: ");
		type = ReadValue("any");
    }
	catch (Exception ex)
	{
        WriteLineMessage("");
        WriteLineMessage(ex.Message, ConsoleColor.Red);
		WriteMessage("Do you whant to continue (y/n) default(y): ");
		if (ReadValue("y") == "n")
			break;

	}
}

#region Helper Methods
static void WriteMessage(string message, ConsoleColor color = ConsoleColor.White)
{
    var lastColor = Console.ForegroundColor;
    Console.ForegroundColor = color;
    Console.Write(message);
    Console.ForegroundColor = lastColor;
}

static void WriteLineMessage(string message, ConsoleColor color = ConsoleColor.White)
{
    var lastColor = Console.ForegroundColor;
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ForegroundColor = lastColor;
}

static string ReadValue(string def)
{
	var read = Console.ReadLine();
	if (string.IsNullOrEmpty(read))
		return def;
	return read;
}

static string GetOperationSymbol(Operation operation)
{
	return operation.GetType().GetMember(operation.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;
}
#endregion


