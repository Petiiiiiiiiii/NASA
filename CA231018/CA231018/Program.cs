using CA231018;
using System.Text;

static int ByteMeret(List<Request> requests) 
{
    return requests
        .Sum(r => r.Meret);
}
static bool Domain(Request ember) 
{
    if (char.IsDigit(ember.Cim[ember.Cim.Length - 1]))
        return false;
    else
        return true;
}
static int DomainesDB(List<Request> requests) 
{
    var domainesek = new List<Request>();

    for (int i = 0; i < requests.Count; i++)
    {
        if (Domain(requests[i]))
            domainesek.Add(requests[i]);
    }

    return domainesek.Count;
}
static Dictionary<string, int> Statisztika(List<Request> requests) 
{
    var f9 = requests.GroupBy(gb => gb.HttpKod);

    var f9dic = new Dictionary<string, int>();

    foreach (var item in f9)
    {
        f9dic.Add(item.Key, item.Count());
    }

    return f9dic;
}


var sr = new StreamReader(
    path: @"..\..\..\src\NASAlog.txt",
    encoding: Encoding.UTF8);

var requests = new List<Request>();

while (!sr.EndOfStream)
    requests.Add(new Request(sr.ReadLine()));

var f5 = requests.Count();

Console.WriteLine($"5. feladat: Kérések száma: {f5}");
Console.WriteLine($"6. feladat: Válaszok összes mérete: {ByteMeret(requests)} byte");
Console.WriteLine($"8. feladat: Domain-es kérések: {((double)DomainesDB(requests) / (double)f5) * 100:.00}%");
Console.WriteLine($"9. feladat: Statisztika:");

foreach (var item in Statisztika(requests))
    Console.WriteLine($"\t {item.Key}: {item.Value} db");


Console.ReadKey();