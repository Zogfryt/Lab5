using System.Text;
using lab5.Context;

namespace lab5;

public class Zad6
{
    public void Do()
    {
        var ctx = new CukierniaContext();

        using (ctx)
        {
            var result = ctx.kliencis.GroupBy(x => new {x.miejscowosc, x.kod})
                .Select(x => new {x.Key.miejscowosc, x.Key.kod, count = x.Count()})
                .OrderByDescending(x => x.count)
                .ThenBy(x => x.miejscowosc)
                .ThenBy(x => x.kod)
                .Take(10);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.miejscowosc} | {item.kod} | {item.count}");
            }
        }

    }
}