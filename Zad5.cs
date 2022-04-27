using System.Text;
using lab5.Context;

namespace lab5;

public class Zad5
{
    public void Do()
    {
        var context = new CukierniaContext();

        using (context)
        {
            var list = context.kliencis
                .Join(context.zamowienia, k => k.idklienta, z => z.idklienta,
                    (k, z) => new {nazwa = k.nazwa, data = z.datarealizacji})
                .Where(x => x.data.Month == 11 || x.data.Month == 12).Take(30);
            
            foreach (var item in list)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(item.nazwa);
                sb.Append(" | ");
                sb.Append(item.data);
                Console.WriteLine(sb);
            }
        }



    }
}