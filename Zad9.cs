using lab5.Context;

namespace lab5;

public class Zad9
{
    public void Do()
    {
        var ctx = new CukierniaContext();

        using (ctx)
        {
            var result = ctx.zamowienia.OrderByDescending(x => x.datarealizacji).ThenBy(x => x.idzamowienia).Take(10);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.idzamowienia} | {item.datarealizacji} | {item.idklienta}");
            }
        }
    }
}