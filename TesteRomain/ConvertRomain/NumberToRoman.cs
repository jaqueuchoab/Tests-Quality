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

  public string TensUnitMoreZero(int number) {
    // Separando as unidades
    int unidade = number % 10;
    this.SortNumber(unidade);
    string partUnity = this.numberConverted;

    int dezena = number - unidade;
    this.SortNumber(dezena);
    string partDezena = this.numberConverted;
    
    // Concatenando as partes
    return (partDezena + partUnity);
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
        // Só converte dezenas em que a unidade é diferente de zero
        resultRoman = this.TensUnitMoreZero(number);
      }
      this.numberConverted = resultRoman;
    } else if (number >= 50 && number <= 59) {
        if(number % 10 == 0) {
          resultRoman =  "L";
        } else {
          resultRoman = this.TensUnitMoreZero(number);
        }
        this.numberConverted = resultRoman;
    } else if (number >= 60 && number <= 89) {
        if(number % 10 == 0) {
          resultRoman = "L" + new string('X', (number - 50)/10);
        } else {
          resultRoman = this.TensUnitMoreZero(number);
        }
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
    string resultRoman = "";
    if (number >= 100 && number <= 399) {
      if(number % 100 == 0) {
        resultRoman = new string('C', number/100);
      } else {
        resultRoman = this.TensUnitMoreZero(number);
      }
      this.numberConverted = resultRoman;
    } else if (number >= 500 && number <= 599) {
        if(number % 10 == 0) {
          resultRoman = "D";
        }
        this.numberConverted = resultRoman;
    } else if (number >= 600 && number <= 899) {
        if(number % 10 == 0) {
          resultRoman = "D" + new string('C', (number - 500)/100);
        }
        this.numberConverted = resultRoman;
    } else {
      number += 100;
      this.SortNumber(number);
      resultRoman = "C" + this.numberConverted;
      this.numberConverted = resultRoman;
    }

    this.decimalPlace = "C";
    return "Centena: " + this.decimalPlace;
  }
  
  public string Milhar(int number) {
    this.numberConverted = new string('M', number/1000);
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