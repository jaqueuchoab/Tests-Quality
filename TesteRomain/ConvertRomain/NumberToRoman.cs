using System;
namespace NumberToRoman;

public static class NumberToRoman {
  public static string Converter(int numero)
  {
    if (numero == 1) return "I";
    if (numero == 2) return "II";
    if (numero == 3) return "III";
    if (numero == 4) return "IV";
    if (numero == 5) return "V";
    return "";
  }
}