using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace crud1.Models
{
    
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required (ErrorMessage ="name should required")]
        [MinLength(3,ErrorMessage ="Name should contain at list three latter")]
         
        public String ProductName { get; set; }


        [ForeignKey("Catagory")]
        public int Catgory_Id { get; set; }

        public virtual Catagory Catagory { get; set; }



    }
}