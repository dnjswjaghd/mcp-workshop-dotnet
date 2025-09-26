
using MyMonkeyApp;

namespace MyMonkeyApp;

internal class Program
{
	private static readonly string[] AsciiArts = new[]
	{
		"  (\\__/)",
		"  (=\'.\'=)",
		"  (\")_(\")   몽키~!",
		"   w  c( ..)o   (",
		"    \\__(-)    __)",
		"        몽키가 나타났다!",
		"   (o o)",
		"  /  V  \\",
		" /(  _  )\\",
		"   ^^ ^^   원숭이 파워!"
	};

	private static void ShowRandomAsciiArt()
	{
		var rnd = new Random();
		Console.WriteLine(AsciiArts[rnd.Next(AsciiArts.Length)]);
	}

	public static async Task Main(string[] args)
	{
		while (true)
		{
			Console.Clear();
			ShowRandomAsciiArt();
			Console.WriteLine("\n===== Monkey App Menu =====");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Get details for a specific monkey by name");
			Console.WriteLine("3. Get a random monkey");
			Console.WriteLine("4. Exit app");
			Console.Write("Select an option: ");

			var input = Console.ReadLine();
			Console.WriteLine();

			switch (input)
			{
				case "1":
					var monkeys = await MonkeyHelper.GetMonkeysAsync();
					Console.WriteLine("| Name                 | Location                | Population |");
					Console.WriteLine("-------------------------------------------------------------");
					foreach (var m in monkeys)
					{
						Console.WriteLine($"| {m.Name,-20} | {m.Location,-22} | {m.Population,9} |");
					}
					break;
				case "2":
					Console.Write("Enter monkey name: ");
					var name = Console.ReadLine();
					var monkey = await MonkeyHelper.GetMonkeyByNameAsync(name ?? "");
					if (monkey != null)
					{
						Console.WriteLine($"Name: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}\nLatitude: {monkey.Latitude}\nLongitude: {monkey.Longitude}");
					}
					else
					{
						Console.WriteLine("Monkey not found.");
					}
					break;
				case "3":
					var randomMonkey = await MonkeyHelper.GetRandomMonkeyAsync();
					if (randomMonkey != null)
					{
						Console.WriteLine($"Random Monkey: {randomMonkey.Name}\nLocation: {randomMonkey.Location}\nPopulation: {randomMonkey.Population}\nDetails: {randomMonkey.Details}");
						Console.WriteLine($"Random monkey picked {MonkeyHelper.GetRandomMonkeyAccessCount()} times.");
					}
					else
					{
						Console.WriteLine("No monkeys available.");
					}
					break;
				case "4":
					Console.WriteLine("Goodbye!");
					return;
				default:
					Console.WriteLine("Invalid option. Try again.");
					break;
			}

			Console.WriteLine("\nPress Enter to continue...");
			Console.ReadLine();
		}
	}
}
