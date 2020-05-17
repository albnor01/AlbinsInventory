using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //för datumhanteringen 
using System.ComponentModel.DataAnnotations.Schema;//för ändrin av dattum 

namespace AlbinsInventory.Models
{
    public class Items
    {
        public int ID { get; set; } //id på förmeåelet 
        public string Item { get; set; } // föremålen 
       
        [Display(Name = "Added date")] // Den grafiska represntaitnen se: Pages/AddedItems/Index.cshtml file. 
        [DataType(DataType.Date)] //datumhantering  (frivilligt alternativ )
        public DateTime AddedDate { get; set; }
        public string Category { get; set; }//kategorin av föremål 
        
        [Column(TypeName = "decimal(18, 2)")] //Möjligör valutor i dattabasen
        public decimal Price { get; set; }//priset
    }
}
