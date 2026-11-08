// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;

Console.WriteLine("Wie lang soll dein Passwort sein?");
int laenge = int.Parse(Console.ReadLine());

string zeichen = "abcdefghijklmnopqrstuvwxyz";
Console.WriteLine("Großbuchstaben? (j/n)");
if (Console.ReadLine() == "j") { zeichen += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
Console.WriteLine("Zahlen? (j/n)");
if (Console.ReadLine() == "j") { zeichen += "0123456789"; }
Console.WriteLine("Sonderzeichen? (j/n)");
if (Console.ReadLine() == "j") { zeichen += "!?#$%&"; }

string passwort = ErzeugePasswort(laenge, zeichen);
Console.WriteLine("Dein Passwort: " + passwort);
Console.WriteLine("Stärke: " + PruefeStaerke(passwort));

// ----- Gerät 1: Passwort machen -----
static string ErzeugePasswort(int laenge, string zeichen)
{
    string passwort = "";
    for (int i = 0; i < laenge; i++)
    {
        int position = RandomNumberGenerator.GetInt32(zeichen.Length);
        passwort += zeichen[position];
    }
    return passwort;
}

// ----- Gerät 2: Stärke prüfen -----
static string PruefeStaerke(string passwort)
{
    int punkte = 0;
    if (passwort.Length >= 12) { punkte++; }
    if (passwort.Any(char.IsUpper)) { punkte++; }
    if (passwort.Any(char.IsLower)) { punkte++; }
    if (passwort.Any(char.IsDigit)) { punkte++; }
    if (passwort.Any(c => !char.IsLetterOrDigit(c))) { punkte++; }

    if (punkte <= 2) { return "Schwach"; }
    if (punkte <= 4) { return "Mittel"; }
    return "Stark";
}