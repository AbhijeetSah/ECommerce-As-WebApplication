using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common
{
    public class ClothesCommon : Common
    {
		//public int MyProperty { get; set; }
		//public string RowId { get; set; }
		public string ProductReferenceId { get; set; } //id to represent the unique clothes in all table
		public string ProductDestintId { get; set; } //id for same having diffent color
		public string Brand{ get; set; } //product brand
		public string ProductName { get; set; } //product name
		public string ProductDescription { get; set; }//information about product
		public string ProductFor { get; set; }//male or  female
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
		public string Specification { get; set; }	//to provide specified description about the clothes
		public string TermsAndConditions { get; set; } // terms and condition for the product
		public string QuickLinksSEOTag { get; set; } // for searching the product with keyword
		public string ProductReviewed { get; set; } // product reviewed By people who visited and bought the product
		public string Doc1 { get; set; } // product reviewed By people who visited and bought the product
		public string Doc2 { get; set; } // product reviewed By people who visited and bought the product
		public List<ColorsCommon> Colors { get; set; }
		public List<ProductSizeCommon> ProductSizes { get; set; }
		public List<QuantityBySizeAndColorCommon> QBySizeAndColor { get; set; }
		public List<DocumentUpload> Doc { get; set; }

		//public string CreatedBy{ get; set; }  
		//public string CreatedDate { get; set; }

	}


	public class ProductSizeCommon
	{
		public string RowId { get; set; }
		public string ProductReferenceId { get; set; } // foreign key references tblclothes(ProductReferenceId) ON DELETE CASCADE ON UPDATE CASCADE,
		public string ProductId { get; set; } //this field is refered in quantity by size and color
		public string ScaleType { get; set; }	//cm, meter, inches, year
		public string Size { get; set; }    //large medium small xl xxl etc
		public string BrandSize { get; set; } //size define by brand different than normal soze for large,medium, smaall and xl
		public string SizeDescription { get; set; } // should be in json format  eg "SizeDescription":["Chest": "36","Length":"18","shoulder":"12",...],
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
	}

	public class QuantityBySizeAndColorCommon
	{
		
		public string QBySizeAndColorId { get; set; }
		public string ProductReferenceId { get; set; }  // foreign Key references tblClothes(ProductReferenceId) ON DELETE CASCADE ON UPDATE CASCADE,
		public string ProductDestintId { get; set; }    // foreign key References tblClothes(ProductDestintId) ON DELETE CASCADE ON UPDATE CASCADE,
		public string ColorId { get; set; } //foreign Key references tblColors(ColorHexCode) ON DELETE CASCADE ON UPDATE CASCADE,
		public string SizeId { get; set; }  //foreign Key REFERENCES tblProductSize(ProductId) ON DELETE CASCADE ON UPDATE CASCADE,
		public string Quantity { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedDate { get; set; }
	}

}
