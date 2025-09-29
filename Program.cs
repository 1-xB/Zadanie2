namespace Zadanie2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Podaj lokalizacje pliku : ");
            var filePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Nie podano żadnej ścieżki!");
                return;
            }
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Podany plik nie istnieje!");
                return;
            }

            var fileContent = File.ReadAllText(filePath).Replace("praca", "job");
            var directory = Path.GetDirectoryName(filePath);
            var newFileName = Path.GetFileNameWithoutExtension(filePath) + "_changed" + DateTime.Now.ToString("ddMMyyyy") + Path.GetExtension(filePath);
            var newFilePath = Path.Combine(directory, newFileName);

            if (File.Exists(newFilePath))
            {
                Console.WriteLine($"Plik : {newFilePath} już istnieje. Zostanie on zastąpiony przez nowy.");
                File.Delete(newFilePath);
            }
            
            File.WriteAllText(newFilePath, fileContent);
            Console.WriteLine("Plik został pomyślnie zapisany w : " + newFilePath);
        }
        catch (Exception e)
        {
            Console.WriteLine("Coś poszło nie tak podczas wykonywania kodu. Błąd : " + e.Message);
        }
    }
}