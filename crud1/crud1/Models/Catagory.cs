using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace crud1.Models
{
    public class Catagory
    {
        public Catagory()
        {
            Products = new List<Product>();
            
        }

        [Key]
        public int Catgory_Id { get; set; }

        [Required(ErrorMessage = "name should required")] 
        [MinLength(3, ErrorMessage = "Name should contain at list three latter")]

        public String CatgoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}