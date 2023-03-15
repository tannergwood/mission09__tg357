using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;

namespace OnlineBookstore.Components
{
    public class BasketSummaryViewComponent : ViewComponent
    {
        private Basket bskt;
        public BasketSummaryViewComponent(Basket basketService)
        {
            bskt = basketService;
        }

        public IViewComponentResult Invoke()
        {
            return View(bskt);
        }
    }
}
