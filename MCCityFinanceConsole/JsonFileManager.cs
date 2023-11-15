namespace MCCityFinanceConsole;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

public class JsonFileManager
{
    private readonly string _filePath;

    public JsonFileManager(string filePath)
    {
        _filePath = filePath;
    }

    public async Task<FinancialData> ReadAsync()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, // Ignore case sensitivity
            ReadCommentHandling = JsonCommentHandling.Skip, 
            AllowTrailingCommas = true 
        };

        using (FileStream fs = File.OpenRead(_filePath))
        {
            return await JsonSerializer.DeserializeAsync<FinancialData>(fs, options);
        }
    }

    
    public async Task WriteAsync(FinancialData data)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Convert property names to camelCase
            WriteIndented = true // Pretty print the JSON
        };

        // Wrap the FileStream in a using statement to ensure it's disposed properly
        using (FileStream fs = File.Create(_filePath))
        {
            await JsonSerializer.SerializeAsync(fs, data, options);
            await fs.FlushAsync(); // Explicitly flush the stream
        } // FileStream is disposed here, ensuring the file is saved
    }


}