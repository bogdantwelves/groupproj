using Abc.Data;
using Abc.Infra;

namespace Abc.Soft.Web.Client;

public sealed class MoneyHttpRepo(HttpClient http)
    : HttpRepo<Money>(http, "api/money"), IMoneyRepo;
