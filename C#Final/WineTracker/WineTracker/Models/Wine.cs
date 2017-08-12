using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WineTracker.Models
{

    public class Wine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int WineId { get; set; }
        public string WineName { get; set; }
        public virtual string Winery  { get; set; }
        public virtual WineType Type { get; set; }
        public int Year { get; set; }
        public string Grape { get; set; }
        public int Quantity { get; set; }

        public enum WineType
        {
            Red,
            White,
            Rose,
            Bubbles,
            Dessert
        }
    }

}