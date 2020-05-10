using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AlbinsInventory.Data;
using AlbinsInventory.Models;

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

        public async Task OnGetAsync()
        {
            Items = await _context.Items.ToListAsync();
        }
    }
}
