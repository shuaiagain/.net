using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using mvcTwo.ViewModels;

namespace mvcTwo.ViewModels.SPA
{
    public class MainViewModel
    {
        public string UserName { get; set; }
        public FooterViewModel FooterData { get; set; }//New Property
    }
}
