using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AlbinsInventory.Data;
using AlbinsInventory.Models;

namespace AlbinsInventory.Pages.AddedItems
{
    public class CreateModel : PageModel
    {
        private readonly AlbinsInventory.Data.AlbinsInventoryContext _context;

        public CreateModel(AlbinsInventory.Data.AlbinsInventoryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Items Items { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Items.Add(Items);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
