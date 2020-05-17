using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlbinsInventory.Data;
using AlbinsInventory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlbinsInventory.Pages.AddedItems
{
    public class IndexModel : PageModel
    {
        private readonly AlbinsInventory.Data.AlbinsInventoryContext _context;

        public IndexModel(AlbinsInventory.Data.AlbinsInventoryContext context)
        {
            _context = context;
        }

        public IList<Items> Items { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
      
        public SelectList Category { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ItemCategory { get; set; }

        public async Task OnGetAsync()
        {
            // Använder  LINQ för att genera en lista av katergorer .
            IQueryable<string> genreQuery = from m in _context.Items
                                            orderby m.Category 
                                            select m.Category;

            var items = from m in _context.Items
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                items = items.Where(s => s.Item.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ItemCategory))
            {
                items = items.Where(x => x.Category == ItemCategory);
            }
            Category = new SelectList(await genreQuery.Distinct().ToListAsync()); //listan av katergorer 
            Items = await items.ToListAsync();
        }
    }
}
