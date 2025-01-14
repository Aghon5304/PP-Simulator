using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;
using Game;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;
using System;

namespace WebView.Pages
{
    public class gameModel : PageModel
    {
        public int Tura { get; private set; } = 0;
        public Map Map { get; } = new SmallTorusMap(10, 10);
        public List<IMappable> IMappables { get; } = new List<IMappable> { new Orc("Gorbag") };
        public List<Point> Positions { get; } = new List<Point> { new Point(2, 2) };
        public string Moves { get; } = "uuuuudddddlllllrrrrr";
        public string Ekran { get; private set; }
        public string CurrentMove { get; private set; }
        public string CurrentCreature { get; private set; }
        public RunGame RunGame { get; private init; }
        public string Tablica { get; private set; }
        public string Player { get; private set; }

        public gameModel()
        {
            RunGame = new RunGame(IMappables[0], Map, IMappables.Skip(1).ToArray(), DirectionParser.Parse(Moves), Positions.Skip(1).ToArray(), Positions[0]);
        }
        public string WypiszPlansze(Directions.Direction action)
        {
            RunGame.Run(action);
            return RunGame.wypisanie();
        }

        public void OnGet()
        {
            Tablica = HttpContext.Session.GetString("Tablica") ?? RunGame.wypisanie();
            Tura = HttpContext.Session.GetInt32("Tura") ?? 0;
            Player = HttpContext.Session.GetString("Player") ?? $"<div>You are playing: {IMappables[0]}</div><div>Your Health: {IMappables[0].Health}</div><div>Your Attack: {IMappables[0].Power}</div><div>Your lvl: {IMappables[0].Level}</div>";
        }

        public void OnPost(Directions.Direction action)
        {
            Player = $"<div>You are playing: {IMappables[0]}</div><div>Your Health: {IMappables[0].Health}</div><div>Your Attack: {IMappables[0].Power}</div><div>Your lvl: {IMappables[0].Level}</div>";
            Tablica = WypiszPlansze(action);
            HttpContext.Session.SetString("Tablica", Tablica);
            HttpContext.Session.SetInt32("Tura", ++Tura);
            HttpContext.Session.SetString("Player", Player);
        }
    }
}