using System;
using MorseCod;

class Program {
  public static void Main(string[] args) {
    ConvertMorseCod convertMorseCod = new ConvertMorseCod("Hello World");
    string conversao = convertMorseCod.StringToMorse();

    Console.WriteLine("Frase convertida: " + conversao);
  }
}