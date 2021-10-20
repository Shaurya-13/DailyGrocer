using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyShop.Main.Models
{
    public abstract class BaseE
    {
        public string Id { get; set; }
        public DateTimeOffset Created{get;set;}
        public BaseE() 
        {
            this.Id = Guid.NewGuid().ToString();
            this.Created = DateTime.Now;
        }
    }
}
