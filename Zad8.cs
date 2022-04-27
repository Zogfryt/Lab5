using lab5.Context;

namespace lab5;

public class Zad8
{
    public void Do()
    {
        var ctx = new CukierniaContext();

        using (ctx)
        {
            var cities = ctx.kliencis
                .GroupBy(x => x.miejscowosc)
                .Select(x => new {miejscowosc = x.Key, count = x.Count()})
                .Where(x => x.count >= 5)
                .Select(x => x.miejscowosc).ToList();

            var result = ctx.kliencis.GroupBy(x=>x.miejscowosc).Where(x => cities.Contains(x.Key)).Select(x=> new {x.Key, listOfNames=  x.Select(c => c.nazwa).ToList()}).ToDictionary(key => key.Key, val => val.listOfNames);

            foreach (var klient in result.Keys)
            {
                Console.WriteLine($"{klient} :");
                foreach (var name in result[klient])
                {
                    Console.WriteLine(name);
                }

                Console.WriteLine("----------------------------------");
            }

            // foreach (var item in result)
            // {
            //     Console.WriteLine(item.Key);
            //     foreach (var klient in item.listOfNames)
            //     {
            //         Console.WriteLine(klient);
            //     }
            //
            //     Console.WriteLine("------------------");
            // }
            
        }
    }
}