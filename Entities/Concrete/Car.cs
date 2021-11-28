using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MinFindex { get; set; }
        public bool IsRented { get; set; }
        public string Thumbnail { get; set; }
    }

}
