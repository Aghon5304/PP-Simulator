using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;

namespace WebView.Pages
{
    public class IndexModel : PageModel
    {
        public Map Map { get; set; } = new SmallTorusMap(10, 10);
        public string Moves { get; set; } = "uuuuudddddlllllrrrrr";
    }

}
