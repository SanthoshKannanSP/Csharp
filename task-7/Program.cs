class Program
{
    private static Random _randomGenerator = new Random();
    
    public static async Task Main(string[] args)
    {
        
        var appleStockPrice = FetchStockPrice("AAPL");
        var microsoftStockPrice =  FetchStockPrice("MSFT");
        var nvidiaStockPrice =  FetchStockPrice("NVDA");
        int[] stockPrices;
        try
        {
            stockPrices = await Task.WhenAll(appleStockPrice, microsoftStockPrice, nvidiaStockPrice);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Fetching the Data!");
            return;
        }

        var totalPrice = stockPrices.Sum();
        
        Console.WriteLine($"Total stock price is {totalPrice}");
    }

    private static async Task<int> FetchStockPrice(string stockCode)
    {
        var waitTime = _randomGenerator.Next(1, 5) * 1000;
        await Task.Delay(waitTime);
        var stockPrice = _randomGenerator.Next(50, 100);
        return stockPrice;
    }
}