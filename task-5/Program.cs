class Program
{
    public static void Main(string[] args)
    {
        var inputFileName = "input.txt";
        var outputFileName = "output.txt";

        string contents;
        try
        {
            contents = File.ReadAllText(inputFileName);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File {inputFileName} not found");
            return;
        }

        var numberOfLines = contents.Split(".").Length;
        var numberOfWords = contents.Split(' ').Length;
        
        using (var writer = File.CreateText(outputFileName))
        {
            writer.WriteLine($"Number of lines: {numberOfLines}");
            writer.WriteLine($"Number of words: {numberOfWords}");
        }
    }
}

