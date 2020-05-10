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
    public class DeleteModel : PageModel
    {
        private readonly AlbinsInventory.Data.AlbinsInventoryContext _context;

        public DeleteModel(AlbinsInventory.Data.AlbinsInventoryContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Items = await _context.Items.FindAsync(id);

            if (Items != null)
            {
                _context.Items.Remove(Items);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
