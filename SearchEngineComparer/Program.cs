using System;
using SearchEngineApi.Model;
using SearchEngineApi;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngineComparer
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
                throw new InvalidOperationException("No arguments received");

            var globalResults = new List<TokenResult>();
            try
            {
                var engines = SearchEngines.AvailableSearchEngines().Where(en => en.Active);
                var queryResults = new List<TokenResult>();
                foreach(var query in args)
                {
                    var resultString = $"{query}: ";
                    foreach(var engine in engines)
                    {
                        if (!engine.Active) continue;
                        switch(engine.Type)
                        {
                            case SearchEngineResultType.Json:
                                var queryEngine = (JsonSearchEngine)engine;
                                var result = queryEngine.GetResults(query).GetAwaiter().GetResult();
                                queryResults.Add(new TokenResult(query, queryEngine.Id, result));
                                resultString += $"{engine.Id}: {result} ";
                                break;
                        }
                    }
                    //Print query results
                    Console.WriteLine(resultString);
                }

                foreach(var engine in engines)
                { 
                    //Get engine winner
                    var engineWinner = FindResult(queryResults.Where(qr => qr.Engine == engine.Id).ToList());
                    Console.WriteLine($"{engine.Id} Winner: {engineWinner.Query}");
                }

                var totalWinner = FindResult(queryResults);
                Console.WriteLine($"Total Winner: {totalWinner.Query}");
            }
            catch(Exception e)
            { 
                Console.WriteLine("Error ocurred");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        static TokenResult FindResult(List<TokenResult> queryResults)
        {
            var max = queryResults.Max(qr => qr.Result);
            return queryResults.Where(qr => qr.Result == max).First();
        }
    }

    public struct TokenResult{
        public string Query { get; }
        public string Engine { get; }
        public long Result { get; }

        public TokenResult(string query, string engine, long result)
        {
            Query = query;
            Engine = engine;
            Result = result;
        }
    }
}
