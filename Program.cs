using RiskSystemsTest;

class Program
{
    static void Main(string[] args)
    {
        // Ler a data de referência
        DateTime referenceDate = DateTime.Parse(Console.ReadLine());

        // Ler o número de trades
        
        int n = int.Parse(Console.ReadLine());

        List<ITrade> trades = new List<ITrade>();

        // Ler as trades
        for (int i = 0; i < n; i++)
        {
            string[] tradeData = Console.ReadLine().Split(' ');
            double value = double.Parse(tradeData[0]);
            string clientSector = tradeData[1];
            DateTime nextPaymentDate = DateTime.Parse(tradeData[2]);
           // bool isPoliticallyExposed = bool.Parse(tradeData[3]); // New input for PEP

            trades.Add(new Trade(value, clientSector, nextPaymentDate));
        }

        // Classificar trades
        var classifier = new TradeClassifier();
        foreach (var trade in trades)
        {
            string category = classifier.ClassifyTrade(trade, referenceDate);
            Console.WriteLine(category);
        }
    }
}
