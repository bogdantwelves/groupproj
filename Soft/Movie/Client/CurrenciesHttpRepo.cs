using Abc.Data;
using Abc.Infra;

namespace Abc.Soft.Web.Client;

public sealed class CurrenciesHttpRepo(HttpClient http)
    : HttpRepo<Currency>(http, "api/currencies"), ICurrenciesRepo;
