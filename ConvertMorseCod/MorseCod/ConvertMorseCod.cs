using System;
using System.Collections.Generic;
namespace MorseCod;

public class ConvertMorseCod {
  private string frase;
  private string fraseConvertida;

  public ConvertMorseCod(string frase = null) {
    if (frase == null || frase.Length == 0) {
      throw new ArgumentException("A frase não pode ser nula ou vazia.");
    }

    this.frase = frase;
    this.fraseConvertida = string.Empty;
  }

  Dictionary<string, string> morseCod = new Dictionary <string, string> 
  {
    { "a", ".-" },
    { "b", "-..." },
    { "c", "-.-." },
    { "d", "-.." },
    { "e", "." },
    { "f", "..-." },
    { "g", "--." },
    { "h", "...." },
    { "i", ".." },
    { "j", ".---" },
    { "k", "-.-" },
    { "l", ".-.." },
    { "m", "--" },
    { "n", "-." },
    { "o", "---" },
    { "p", ".--." },
    { "q", "--.-" },
    { "r", ".-." },
    { "s", "..." },
    { "t", "-" },
    { "u", "..-" },
    { "v", "...-" },
    { "w", ".--" },
    { "x", "-..-" },
    { "y", "-.--" },
    { "z", "--.." },
    { "0", "-----" },
    { "1", ".----" },
    { "2", "..---" },
    { "3", "...--" },
    { "4", "....-" },
    { "5", "....." },
    { "6", "-...." },
    { "7", "--..." },
    { "8", "---.." },
    { "9", "----." },
  };

  private string[] SliceFrase() {
    return this.frase.ToLower().Split(' ');
  }

  public string StringToMorse() {
    string[] palavras = SliceFrase();

    foreach (var palavra in palavras)
    {
      foreach (char letra in palavra) {
        if(morseCod.TryGetValue(letra.ToString(), out string cod)) {
          fraseConvertida += cod + " ";
        } else {
          throw new ArgumentException($"Caractere '{letra}' não é suportado.");
        }
      }
    }

    return fraseConvertida.TrimEnd();
  }
}