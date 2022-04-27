using lab5.Context;

namespace lab5;

public class Zad7
{
    public void Do()
    {
        var ctx = new CukierniaContext();

        using (ctx)
        {
            var result = ctx.kliencis
                .Where(x => x.idklienta == 73)
                .Join(ctx.zamowienia, k => k.idklienta, z => z.idklienta,
                    (k, z) => new {k.idklienta, k.nazwa, z.idzamowienia, z.datarealizacji})
                .OrderBy(x => x.idzamowienia).ToList();

            Console.WriteLine($"Kod: {result[0].idklienta}, Nazwa: {result[0].nazwa}: ");

            foreach (var k in result)
            {
                Console.WriteLine($"{k.idzamowienia} - {k.datarealizacji}");
            }
        }
    }
}