using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;//för datumhanteringen 

namespace AlbinsInventory.Models
{
    public class Items
    {
        public int ID { get; set; } //id på förmeåelet 
        public string Item { get; set; } // föremålen 

        [DataType(DataType.Date)] //datumhantering  (frivilligt alternativ )
        public DateTime AddedDate { get; set; }
        public string Category { get; set; }//kategorin av föremål 
        public decimal Price { get; set; }//priset
    }
}
