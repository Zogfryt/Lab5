using lab5.Context;

namespace lab5;

public class Zad4
{
    public void Do()
    {
        var context = new CukierniaContext();

        using (context)
        {
            var czekoladka = context.czekoladkis.Where(x => x.nazwa.Equals("Marcepanki")).Single();

            czekoladka.koszt += (decimal) 1.1;
            context.SaveChanges();

            var score = context.czekoladkis.OrderByDescending(x => x.koszt).Take(10);
            
            foreach (var item in score)
            {
                Console.WriteLine(item.koszt);
            }
        }
    }
}