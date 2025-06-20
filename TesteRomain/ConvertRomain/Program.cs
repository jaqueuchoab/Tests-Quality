namespace ConvertRomain;
using NumberToRoman;

class Program
{
  static void Main(string[] args)
  {
    NumberToRoman numberToRoman = new NumberToRoman();

    Console.WriteLine("Bem-vindo ao conversor de números para romanos!");
    Console.WriteLine("Digite um número entre 1 e 3999 para convertê-lo em numeral romano.");
    Console.WriteLine("Digite 0 para encerrar.");
    Console.WriteLine();

    do {
      
      Console.Write("Digite um número: ");
      int number = int.Parse(Console.ReadLine());

      if (number == 0) {
        Console.WriteLine("Saindo do programa...");
        break;
      }

      numberToRoman.SortNumber(number);
      string numberConverted = numberToRoman.GetNumberConverted();

      Console.WriteLine($"Número convertido: {numberConverted}");
      Console.WriteLine();
    } while (true);
  }
}

