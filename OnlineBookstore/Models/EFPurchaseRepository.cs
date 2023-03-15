using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context;

        public EFPurchaseRepository(BookstoreContext bsc)
        {
            context = bsc;
        }

        public IQueryable<Purchase> Purchases => context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void RecordPurchase(Purchase pch)
        {
            context.AttachRange(pch.Lines.Select(x => x.Book));

            if (pch.PurchaseId == 0)
            {
                context.Purchases.Add(pch);
            }

            context.SaveChanges();
        }
    }
}
