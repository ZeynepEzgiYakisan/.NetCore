using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyEfCore.Data.Entities
{
   // [Table(name:"Category",Schema ="c")]
    public class Customer
    {
        //[Key]
        public int Number { get; set; }

        public string Name { get; set; }

        public string Surnmae { get; set; }
    
    }
}
