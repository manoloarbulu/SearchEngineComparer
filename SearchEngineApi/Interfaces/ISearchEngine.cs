using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngineApi.Interfaces
{
    public interface ISearchEngine<K>
    {
        string Id { get; }
        string BaseAddress { get; }
        Dictionary<string, string> Parameters { get; }
        string ParameterQuery { get; }
        string ResultPath { get; }
        SearchEngineResultType Type { get; }
        bool Active { get; }
        string ContentType { get; }

        Task<K> GetResults(string query);
    }

    public interface ISearchEngineLong : ISearchEngine<long>
    {

    }
}
