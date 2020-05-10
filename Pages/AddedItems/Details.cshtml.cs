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
    public class DetailsModel : PageModel
    {
        private readonly AlbinsInventory.Data.AlbinsInventoryContext _context;

        public DetailsModel(AlbinsInventory.Data.AlbinsInventoryContext context)
        {
            _context = context;
        }

        public Items Items { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Items = await _context.Items.FirstOrDefaultAsync(m => m.ID == id);

            if (Items == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
