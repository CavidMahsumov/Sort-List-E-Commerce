using E_Commerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.WebUI.Helper
{
    public class HelperContainer
    {
        static public ObservableCollection<Product> Products { get; set; }
        static public int Cat { get; set; }
    }
}
