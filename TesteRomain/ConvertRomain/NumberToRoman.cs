using System;
namespace NumberToRoman;

public class NumberToRoman {
  private int number;
  private string decimalPlace;
  private string numberConverted;

  public NumberToRoman(int number) {
    if(VerifyNumber(number)) {
      this.number = number;
    }
  }

  public string GetDecimalPlace() {
    return this.decimalPlace;
  }

  public string GetNumberConverted() {
    return this.numberConverted;
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
    if (number >=1 && number <= 3) {
      string resultRoman = new string('I', number);
      this.numberConverted = resultRoman;
    } else if (number == 5) {
      this.numberConverted = "V";
    } else if (number >=6 && number <= 8) {
      string resultRoman = "V" + new string('I', number - 5);
      this.numberConverted = resultRoman;
    } else {
      number+=1;
      this.SortNumber(number);
      string resultRoman = "I" + this.numberConverted;
      this.numberConverted = resultRoman;
    }

    this.decimalPlace = "I";
    return "Unidade: " + this.decimalPlace;
  }

  public string Dezena(int number) {
    string resultRoman = "";
    if (number >= 10 && number <= 39) {
      if(number % 10 == 0) {
        resultRoman = new string('X', number/10);
      } else  {
        // Esse else aqui pode ser transformado em uma função pois essa lógica se aplica há outros casos
        // Separando as unidades
        int unidade = number % 10;
        int dezena = number - unidade;

        // Convertendo as partes
        this.Unidade(unidade);
        string partUnity = this.numberConverted;

        this.Dezena(dezena);
        string partDezena = this.numberConverted;

        // Concatenando as partes
        resultRoman = partDezena + partUnity;
      }
      this.numberConverted = resultRoman;
    } else if (number == 50) {
      this.numberConverted = "L";
    } else if (number >= 60 && number <= 80) {
      resultRoman = "L" + new string('X', (number - 50)/10);
      this.numberConverted = resultRoman;
    } else {
      number += 10;
      this.SortNumber(number);
      resultRoman = "X" + this.numberConverted;
      this.numberConverted = resultRoman;
    }
    this.decimalPlace = "X";
    return "Dezena: " + this.decimalPlace;
  }

  public string Centena(int number) {
    if (number >= 100 && number <= 300) {
      string resultRoman = new string('C', number/100);
      this.numberConverted = resultRoman;
    }

    this.decimalPlace = "C";
    return "Centena: " + this.decimalPlace;
  }
  
  public string Milhar(int number) {
    this.decimalPlace = "M";
    return "Milhar: " + this.decimalPlace;
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