using System;
using System.IO;

class Input{
    public static void inputFile(ref string file){
        Console.Write("Masukkan file: ");
        string fileName = Console.ReadLine();
        file = File.ReadAllText(fileName);
    }
}