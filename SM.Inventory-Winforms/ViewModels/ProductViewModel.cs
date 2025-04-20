using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.DataLayer.Models;

namespace SM.ViewModels
{
    public class ProductViewModel : Product
    {
        public string? CategoryName { get; set; }
    }
}
