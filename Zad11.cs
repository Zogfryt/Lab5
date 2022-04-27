using lab5.Context;
using Microsoft.EntityFrameworkCore;

namespace lab5;

public class Zad11
{
    public void Do()
    {
        var ctx = new CukierniaContext();

        using (ctx)
        {
            var result = ctx.czekoladkis.Where(x => EF.Functions.Like(x.nazwa, "Sm%")).OrderBy(x=>x.nazwa);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.nazwa}\n\n{item.opis}\n{item.koszt}");
                Console.WriteLine("--------------------------------------------");
            }
        }
    }
}