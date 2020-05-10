using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlbinsInventory.Data;
using AlbinsInventory.Models;

namespace AlbinsInventory.Pages.AddedItems
{
    public class EditModel : PageModel
    {
        private readonly AlbinsInventory.Data.AlbinsInventoryContext _context;

        public EditModel(AlbinsInventory.Data.AlbinsInventoryContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemsExists(Items.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ItemsExists(int id)
        {
            return _context.Items.Any(e => e.ID == id);
        }
    }
}
