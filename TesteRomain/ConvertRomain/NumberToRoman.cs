using System;
namespace NumberToRoman;

public class NumberToRoman {
  private int number;
  private string decimalPlace;
  private string numberConverted;

  public NumberToRoman(int number = 0) {
    if(number != 0 && VerifyNumber(number)) {
      this.number = number;
    }
  }

  public int GetNumber() {
    return this.number;
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

  public string SortNumber(int number = 0) {
    int tamanhoNumber = 0;
    if(number != 0 && VerifyNumber(number)) {
      tamanhoNumber = number.ToString().Length;
    }

    switch (tamanhoNumber)
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
    string resultRoman = "";

    if (number >=1 && number <= 3) {
      resultRoman = new string('I', number);
    } else if (number == 5) {
      resultRoman = "V";
    } else if (number >=6 && number <= 8) {
      resultRoman = "V" + new string('I', number - 5);
    } else {
      if(number == 4) {
        resultRoman = "IV";
      } else if(number == 9) {
        resultRoman = "IX";
      }
    }
    this.numberConverted = resultRoman;
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
    } else if (number >= 60 && number <= 89) {
        if(number % 10 == 0) {
          resultRoman = "L" + new string('X', (number - 50)/10);
        } else {
          resultRoman = this.TensUnitMoreZero(number);
        }
    } else {
      string precedente = "";
      int resto = 0;

      if(number >= 40 && number <= 49) {
        precedente = "XL";
        resto = number % 10;
      } else if(number >= 90 && number <= 99) {
        precedente = "XC";
        resto = number % 10;
      }

      this.Unidade(resto);
      resultRoman = precedente + this.numberConverted;
    }
    this.numberConverted = resultRoman;
    this.decimalPlace = "X";
    return "Dezena: " + this.decimalPlace;
  }

  public string Centena(int number) {
    string resultRoman = "";

    if (number >= 100 && number <= 399) {
      if(number % 100 == 0) {
        resultRoman = new string('C', number/100);
      } else {
        resultRoman = this.HundredsTensMoreZero(number);
      }
    } else if (number >= 500 && number <= 599) {
        if(number % 100 == 0) {
          resultRoman = "D";
        } else {
          resultRoman = this.HundredsTensMoreZero(number);

        }
    } else if (number >= 600 && number <= 899) {
        if(number % 100 == 0) {
          resultRoman = "D" + new string('C', (number - 500)/100);

        } else {
          resultRoman = this.HundredsTensMoreZero(number);
        }
    } else {
      int resto = 0;
      if(number >= 400 && number <= 499) {
        resto = number % 100;
        if(resto >= 10) {
          this.Dezena(resto);
        } else {
          this.Unidade(resto);
        }
        resultRoman = "CD" + this.numberConverted;
      } else if(number >= 900 && number <= 999) {
        resto = number % 100;
        if(resto >= 10) {
          this.Dezena(resto);
        } else {
          this.Unidade(resto);
        }
        resultRoman = "CM" + this.numberConverted;
      }
    }
    
    this.numberConverted = resultRoman;

    this.decimalPlace = "C";
    return "Centena: " + this.decimalPlace;
  }
  
  public string Milhar(int number) {
    string resultRoman = "";
    if (number >= 1000 && number <= 3999) {
      if(number % 1000 == 0) {
        resultRoman = new string('M', number/1000);
      } else {
        resultRoman = this.MilenialHundredMoreZero(number);
      }
      this.numberConverted = resultRoman;
    }

    this.decimalPlace = "M";
    return "Milhar: " + this.decimalPlace;
  }

  public string TensUnitMoreZero(int number) {
    // Separando as unidades
    int unidade = number % 10;
    this.Unidade(unidade);
    string partUnity = this.numberConverted;

    int dezena = number - unidade;
    this.Dezena(dezena);
    string partDezena = this.numberConverted;
    
    // Concatenando as partes
    return (partDezena + partUnity);
  }

  public string HundredsTensMoreZero(int number) {
    int dezena = number % 100;
    if(dezena < 10) {
      Unidade(dezena);
    } else {
      Dezena(dezena);
    }
    string partTens = this.numberConverted;

    int Centena = number - dezena;
    this.Centena(Centena);
    string partHundred = this.numberConverted;
    
    // Concatenando as partes
    return (partHundred + partTens);
  }

  public string MilenialHundredMoreZero(int number) {
    int centena = number % 1000;
    if(centena < 100) {
      if(centena < 10) {
        this.Unidade(centena);
      } else {
        this.Dezena(centena);
      }
    } else {
      this.Centena(centena);
    }
    string partHundred = this.numberConverted;

    int milhar = number - centena;
    this.Milhar(milhar);
    string partMilenial = this.numberConverted;

    // Concatenando as partes
    return (partMilenial + partHundred);
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