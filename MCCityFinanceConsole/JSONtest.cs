namespace MCCityFinanceConsole;

public class JsonTester
{
    private readonly string _filePath;
    private readonly JsonFileManager _jsonFileManager;

    public JsonTester(string filePath)
    {
        _filePath = filePath;
        _jsonFileManager = new JsonFileManager(filePath);
    }

    public async Task TestJsonOperationsAsync()
    {
        FinancialData data = await _jsonFileManager.ReadAsync();

        if (data?.New != null)
        {
            data.Old = data.New;

            data.New = new EconomicData();

            await _jsonFileManager.WriteAsync(data);
        }
        else
        {
            Console.WriteLine("No 'new' data to copy to 'old'.");
        }
    }
}
