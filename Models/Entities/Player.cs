using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLBApp.Models.Entities
{
    public class Player
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int TeamID { get; set; }

        
    }
}
