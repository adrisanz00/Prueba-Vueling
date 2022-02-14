using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class ModelCurrency
    {
        public ModelCurrency() { }
        public int Id { get; set; }
        public string From { get; set; } = "";
        public string To { get; set; } = "";
        public double Rate { get; set; }
    }
}
