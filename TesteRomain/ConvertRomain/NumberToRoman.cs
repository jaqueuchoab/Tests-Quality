using System;
namespace NumberToRoman;

public class NumberToRoman {
  private int number;
  private string decimalPlace;

  public NumberToRoman(int number) {
    if(VerifyNumber(number)) {
      this.number = number;
    }
  }

  public static bool VerifyNumber(int number) {
    if (number < 1 || number > 3999 || number == 0) {
      throw new ArgumentOutOfRangeException("O número deve estar entre 1-3999 e ser diferente de 0.");
    } else {
      return true;
    }
  }

  public string SortNumber(int number) {
    int tamanhonumber = number.ToString().Length;

    switch (tamanhonumber)
    {
      case 1:
        return Unidade(number);
        break;
      case 2:
        return Dezena(number);
        break;
      case 3:
        return Centena(number);
        break;
      case 4:
        return Milhar(number);
        break;
      default:
        Console.WriteLine("Número fora do intervalo permitido.");
        return "";
    }
  }

  public string Unidade(int number) {
    return "Unidade";
  }

  public string Dezena(int number) {
    return "Dezena";
  }

  public string Centena(int number) {
    return "Centena";
  }
  
  public string Milhar(int number) {
    return "Milhar";
  }

  public static string Convert(int number) {
    if (number == 1) return "I";
    if (number == 2) return "II";
    if (number == 3) return "III";
    if (number == 4) return "IV";
    if (number == 5) return "V";
    return "";
  }
}