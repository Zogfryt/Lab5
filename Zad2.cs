using lab5.Context;
using lab5.Entities;

namespace lab5;

public class Zad2
{
    public void Do()
    {
        var context = new CukierniaContext();

        using (context)
        {
            var score = context.czekoladkis.Where(x => (double) x.koszt > 0.3)
                .OrderBy(x => x.nazwa)
                .Select(x => new czekoladki
                {
                    nazwa = x.nazwa, czekolada = x.czekolada, idczekoladki = x.idczekoladki, koszt = x.koszt,
                    masa = x.masa, nadzienie = x.nadzienie, opis = x.opis, orzechy = x.orzechy
                });
            
            foreach (var item in score)
            {
                Console.Out.WriteLine(item.nazwa + " | " + item.koszt);
            }
        }
    }
}