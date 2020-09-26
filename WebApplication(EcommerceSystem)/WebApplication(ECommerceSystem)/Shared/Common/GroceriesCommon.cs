using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common
{
    public class GroceriesCommon :Common
    {
		//public int MyProperty { get; set; }
		//public string RowId { get; set; }
		public string ProductReferenceId { get; set; } //id to represent the unique clothes in all table
		public string ProductDestintId { get; set; } //id for same having diffent color
		public string Brand { get; set; } //product brand
		public string ProductName { get; set; } //product name

		public string ProductUnit { get; set; }     //pouches/ packet/ tube
		public string QuntityUnit { get; set; }     // kg gm ltr 
		public string ProductVolume { get; set; }   // 5 packet //
		public string QuantityPerVolume { get; set; }  //1kg 2 kg 20kg

		public string ProductDescription { get; set; }//information about product
		public string SupplierEmail { get; set; }//for notification
		public string SupplierAddress { get; set; } //for defining the address in view pae
		public string SupplierContactNo { get; set; } // to contact supplier for delivering product
		public string ProductPrice { get; set; }
		public string OfferedPrice { get; set; }
		public string DiscountPercent { get; set; }
		public string DiscountAmount { get; set; }
		public string Warrenty { get; set; } //warrenty should be yes or no
		public string WarrentyCondition { get; set; }
		public string WarrentyPeriod { get; set; }
		public string Highlights { get; set; } //to provide hight information about the product
		public string Specification { get; set; }   //to provide specified description about the clothes
		public string TermsAndConditions { get; set; } // terms and condition for the product
		public string QuickLinksSEOTag { get; set; } // for searching the product with keyword
		public string ProductReviewed { get; set; } // product reviewed By people who visited and bought the product
		public string Doc1 { get; set; } // product reviewed By people who visited and bought the product
		public string Doc2 { get; set; } // product reviewed By people who visited and bought the product


		

		public List<DocumentUpload> Doc { get; set; }
	}
}
