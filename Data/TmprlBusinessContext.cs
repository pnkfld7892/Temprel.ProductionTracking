using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Temprel.ProductionTracking.Data.Entities;
using Temprel.ProductionTracking.Data.Models;
using System.Threading.Tasks;

namespace Temprel.ProductionTracking.Data
{
    public sealed class TmprlBusinessContext : IDisposable
    {
        private TemprelEntities context;
        private bool disposed;
        public TmprlBusinessContext()
        {
            context = new TemprelEntities();
        }

        /// <summary>
        /// Old code
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public OrderModel GetOrder(string orderNo)
        {
            if (context.oe_hdr.Find(orderNo) != null)
            {
                oe_hdr tmpHdr = context.oe_hdr.Where(h => h.order_no == orderNo.ToString()).FirstOrDefault();
                ICollection<oe_line> tmpLines = context.oe_line.Where(l => l.oe_hdr.order_no == tmpHdr.order_no).ToArray();
                customer tmpCust = context.customers.Where(c => c.customer_id == tmpHdr.customer_id).FirstOrDefault();
                return new OrderModel(tmpHdr, tmpLines, tmpCust);
            }
            else throw new ArgumentException("Order Not Found!");
            
        }

        /// <summary>
        /// Returns an Oe_HdrModel object if found
        /// </summary>
        /// <param name="orderNo">The order Number to look for</param>
        /// <returns><see cref="Oe_HdrModel"/></returns>
        public Oe_HdrModel GetOe_Hdr(string orderNo)
        {
            if (context.oe_hdr.Find(orderNo) != null)
            {
                oe_hdr tmpHdr = context.oe_hdr.Where(h => h.order_no == orderNo).FirstOrDefault();
                customer tmpCust = context.customers.Where(c => c.customer_id == tmpHdr.customer_id).FirstOrDefault();
                return new Oe_HdrModel(tmpHdr, tmpCust);
            }
            else throw new ArgumentException("Order Not Found!");
        }

        /// <summary>
        /// Returns an Oe_lineModel object if found
        /// </summary>
        /// <param name="orderNo">The order number to search for</param>
        /// <returns></returns>
        public Oe_LineModel GetOe_Line(string orderNo)
        {
            if (context.oe_hdr.Find(orderNo) != null)
            {
                ICollection<oe_line> tmpLines = context.oe_line.Where(l => l.oe_hdr.order_no == orderNo).ToArray();
                return new Oe_LineModel(tmpLines);
            }
            else
                throw new ArgumentException("Order Not Found!");
        }

        public bool IsSalesOrder(string orderNo)
        {
            var isOrder = context.oe_hdr.Find(orderNo);

            if (isOrder != null)
                return true;
            else
                return false;
        }

        public bool IsProdOrder(string orderNo)
        {
            Decimal.TryParse(orderNo, out decimal orderNoDec);
            var order = context.prod_order_hdr.Find(orderNoDec);
            if (order != null)
                return true;
            else
                return false;
        }
        public ICollection<status> GetStatuses()
        {
            return context.status.ToArray();
        }

        public void UpdateOrder(OrderModel order)
        {
            var tempHdr = context.oe_hdr.Find(order.Hdr.order_no);
            if(tempHdr == null)
            {
                throw new ArgumentException(nameof(UpdateOrder), "Order Not Found");
            }

            context.Entry(order.Hdr).CurrentValues.SetValues(order.Hdr);

            foreach(var ln in order.Lines)
            {
                context.Entry(ln).CurrentValues.SetValues(ln);
            }

            context.SaveChanges();
        }

        //TODO: Create UpdateOrder that takes a Production Order
        /*
            public void UpdateOrder(ProductionOrderModel order()
            {
            }
        */

        #region IDisposable Support

        /// <summary>
        /// Performs Application defined disposal tasks
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed || disposing)
                return;
            if (context != null)
                context.Dispose();
            disposed = true;
            #endregion


        }
    }
}
