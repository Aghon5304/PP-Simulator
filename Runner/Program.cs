using Simulator.Maps;
using static Simulator.Directions;
using Simulator;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

internal class Program
{
    static void Main()
    {
		//var v = new SmallSquareMap(5);
		//var p = new Point(1, 0);
		//Console.WriteLine( v.NextDiagonal(p,Direction.Down));
		//Lab5a();
		//Lab5b();
		var jsonOptions = new JsonSerializerOptions { WriteIndented = true, ReferenceHandler = ReferenceHandler.Preserve };
		//Orc o1 = new Orc("Gorbag", 3, 5);
		////string json = JsonSerializer.Serialize(o1, jsonOptions);

		//// Punkt się nie serializuje
		//Point p1 = new(1, 2);
		//      string json = JsonSerializer.Serialize(p1);
		//      Point deserialization = JsonSerializer.Deserialize<Point>(json);
		//Console.WriteLine(json);
		//Console.WriteLine(deserialization);

		//      using (FileStream fs = new("data.json", FileMode.Create))
		//{
		//	JsonSerializer.Serialize(fs, o1,jsonOptions);
		//}
		//using (FileStream fs = new("data.json", FileMode.Open))
		//{
		//	var o2 = JsonSerializer.Deserialize<Orc>(fs, jsonOptions);
		//          Console.WriteLine(o2);
		////}
		//      Orc o1 = new Orc("Gorbag", 3, 5);
		//      Orc o2 = new Orc("Gorogu", 2, 1);
		//      List<Orc> list = [o1, o2, o1];
		//      Console.WriteLine(list[0] == list[2]);
		//      string json = JsonSerializer.Serialize(list, jsonOptions);
		//      Console.WriteLine(json);
		//      List<Orc> deserialized = JsonSerializer.Deserialize<List<Orc>>(json, jsonOptions)!;
		//      Console.WriteLine(deserialized[0] == deserialized[2]);
		var options = new JsonSerializerOptions { WriteIndented = true };

		List<IMappable> mapables = [
			new Orc("Gorbag", 3, 5),
	new Elf("Elandor", 2, 7),
	new Animals { Description = "Rasbbits", Size = 10 },
	new Birds { Description = "Eagles", Size = 15 },
	new Birds { Description = "Emu", Size = 8, CanFly = false }
		];

		string json = JsonSerializer.Serialize(mapables, options);
		Console.WriteLine("\nJSON:");
		Console.WriteLine(json);

		List<IMappable> deserialized =
			JsonSerializer.Deserialize<List<IMappable>>(json, options)!;
	}

	static void Lab5a()
    {
        try
        {

            var r = new Rectangle(1, 2, 3, 4);
            Console.WriteLine(r.ToString());
            r = new Rectangle(5, 3, 4, 2);
            Console.WriteLine(r.ToString());
            r = new Rectangle(4, 4, 3, 2);
            Point a = new(3, 5);
            Point b = new(2, 1);
            Console.WriteLine(r.ToString());
            r = new Rectangle(a,b);
            Console.WriteLine(r.ToString());
            r = new Rectangle(1, 1, 1, 4);
            Console.WriteLine(r.ToString());
        }
        catch ( Exception ex)
        {

            Console.WriteLine(ex.Message);
        }
    }
    static void Lab5b()
    {
        var map = new SmallSquareMap(10);
        Point p = new(1, 1);
        Console.WriteLine($"Punkt :{p}");
        Console.WriteLine(map.Next(p, Direction.Up).ToString());
        Console.WriteLine(map.Next(p, Direction.Right).ToString());
        Console.WriteLine(map.Next(p, Direction.Down).ToString());
        Console.WriteLine(map.Next(p, Direction.Left).ToString());
        Console.WriteLine(map.NextDiagonal(p, Direction.Up).ToString());
        Console.WriteLine(map.NextDiagonal(p, Direction.Right).ToString());
        Console.WriteLine(map.NextDiagonal(p, Direction.Down).ToString());
        Console.WriteLine(map.NextDiagonal(p, Direction.Left).ToString());
    }
}
