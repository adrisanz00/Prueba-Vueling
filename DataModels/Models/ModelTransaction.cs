using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class ModelTransaction
    {
        public int Id { get; set; }
        public string SKU { get; set; } = "";
        public double Amount { get; set; }
        public string Currency { get; set; } = "";
    }
}
