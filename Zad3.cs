using System.Text;
using lab5.Context;
using lab5.Entities;

namespace lab5;

public class Zad3
{
    public void Do()
    {
        var context = new CukierniaContext();

        using (context)
        {
            var score = context.czekoladkis
                .Where(x => x.orzechy == "laskowe")
                .OrderBy(x => x.koszt)
                .ThenByDescending(x => x.nazwa)
                .Select(x => new czekoladki {nazwa = x.nazwa, koszt = x.koszt, orzechy = x.orzechy});

            foreach (var item in score)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(item.nazwa);
                sb.Append(" with ");
                sb.Append(item.orzechy);
                sb.Append(" Nuts - ");
                sb.Append(item.koszt);
                Console.Out.WriteLine(sb);
            }
        }
    }
}