using lab5.Context;

namespace lab5;

public class Zad10
{
    public void Do()
    {
        var ctx = new CukierniaContext();

        List<string> orzechy = new List<string> {"pistacjowe", "laskowe", "brazylijskie"};
        using (ctx)
        {
            var toUpp = ctx.czekoladkis
                .Where(x => orzechy.Contains(x.orzechy ?? string.Empty))
                .OrderBy(x => x.nazwa);
            
            //gdy używasz toList() też działa

            foreach (var item in toUpp)
            {
                item.koszt *= (decimal) 1.12;
            }

            ctx.SaveChanges();

            foreach (var item in toUpp)
            {
                Console.WriteLine($"{item.nazwa} - {item.koszt.ToString("F2")}");
            }
            
        }
    }
}