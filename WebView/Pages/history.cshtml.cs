using System.Diagnostics.Metrics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;
using SimConsole;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System.Web;

namespace WebView.Pages
{
    public class historyModel : PageModel
    {

        public int Tura { get; private set; }
        public static SmallTorusMap map { get; } = new SmallTorusMap(10, 10);
        public static List<IMappable> IMappables { get;} = [ new Orc("Gorbag"), new Elf("Elandor"), new Animals("Królików"), new Birds("Strusie", canFly: true), new Birds("Or³y", canFly: false)];
        public static List<Point >Positions { get;} = [ new(2, 2), new(3, 1), new(4, 5), new(1, 3), new(2, 1) ];
        public  static string Moves { get; } = "uuuuudddddlllllrrrrr";
        public string Ekran { get; private set; }
        public string CurrentMove { get; private set; }
        public string CurrentCreature { get; private set; }
        public SimulationHistory simLog { get;} = new(new(map, IMappables, Positions, Moves));
        public LogVisulizer logVisulizer { get;}
        public historyModel()
        {
            logVisulizer = new LogVisulizer(simLog);
        }
        public void OnGet()
        {
            Tura = HttpContext.Session.GetInt32("Tura") ?? 0;
            Ekran = HttpContext.Session.GetString("Ekran") ?? logVisulizer.Draw(Tura).Replace("\n", "<br>");
            CurrentCreature = HttpContext.Session.GetString("CurrentCreature") ?? simLog.TurnLogs[Tura].Mappable;
            CurrentMove = HttpContext.Session.GetString("CurrentMove") ?? simLog.TurnLogs[Tura].Move;
        }

        public void OnPost(string action)
        {
            Tura = HttpContext.Session.GetInt32("Tura") ?? 0;
            if (action == "inc" && Tura < simLog.TurnLogs.Count-1)
            {
                Tura++;
            }
            else if (Tura > 0 && action == "dec")
            {
                Tura--;
            }
            if (Tura >= 0 && Tura < simLog.TurnLogs.Count)
            {
                HttpContext.Session.SetString("CurrentCreature", CurrentCreature=simLog.TurnLogs[Tura].Mappable);
                HttpContext.Session.SetString("CurrentMove", CurrentMove=simLog.TurnLogs[Tura].Move);
                HttpContext.Session.SetString("Ekran", Ekran=logVisulizer.Draw(Tura).Replace("\n", "<br>"));
                HttpContext.Session.SetInt32("Tura", Tura);
            }
        }
    }
}