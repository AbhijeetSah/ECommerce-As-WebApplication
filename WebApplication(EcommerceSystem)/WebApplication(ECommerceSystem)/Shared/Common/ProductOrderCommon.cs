using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common
{
    public class ProductOrderCommon:Common
    {
		public string ProductReferenceId { get; set; }
		public string OrderId { get; set; }
		public string ProductDistinctId { get; set; }
		public string ProductName { get; set; }
		public string ProductVolume { get; set; }
		public string ProductPrice { get; set; }
		public string ShippingCharge      { get; set; }
		public string ProductSize { get; set; }
		public string ProductQuantity { get; set; }
		public string ShippingDistance { get; set; }
		public string TotalPrice { get; set; }
		public string ProductColor  { get; set; }
		public string ProductLink { get; set; }
		public string SupplierName { get; set; }
		public string SupplierEmail { get; set; }
		public string SupplierAddress { get; set; }
		public string SupplierContactNo { get; set; }
		public string SupplierLatitude { get; set; }
		public string SupplierLongitude { get; set; }
		public string CustomerName { get; set; }
		public string CustomerFullName { get; set; }
		public string DeliveryAddress { get; set; }
		public string DeliveryLatitude { get; set; }
		public string DeliveryLongitude { get; set; }
		public string CustomerContactNo { get; set; }
		public string PaymentOption { get; set; }
		public string DeliveryLocation { get; set; }
		public string DeliveredStatus { get; set; } //active for to be delivered and deactive for product delivered
		public string DocName { get; set; }

	}
}
