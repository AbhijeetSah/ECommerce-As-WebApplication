using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.Repository.ProductDetail
{
    public class ProductDetailRepo : IProductDetailRepo
    {
        RepositoryDao dao;
        public ProductDetailRepo()
        {
            dao = new RepositoryDao();
        }

        public List<ProductSearchCommon> Search(string SearchData)
        {
            var list = new List<ProductSearchCommon>();
            var listComputer = new List<ComputerCommon>();
            var listClothes = new List<ClothesCommon>();
            var listGroceries = new List<GroceriesCommon>();
            var listGadget = new List<GadgetCommon>();

            var sql = "EXEC proc_ProductDetail ";
            sql += " @Flag = " + dao.FilterString("Search");
            sql += ", @SearchData= " + dao.FilterString(SearchData);
            //sql += ", @TableName=" + dao.FilterString("tblComputer");
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var table = item["TableName"].ToString();
                    if (table == "tblComputer")
                    {
                        var computer = new ComputerCommon()
                        {
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            Brand = item["Brand"].ToString(),
                            OfferedPrice=item["OfferedPrice"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            DiscountPercent =item["DiscountPercent"].ToString(),
                            DiscountAmount=item["DiscountAmount"].ToString(),
                            WarrentyPeriod =item["WarrentyPeriod"].ToString(),
                            //ProductReviewed=item["ProductReviewed"].ToString(),
                            Doc1=item["Doc1"].ToString(),
                            Doc2=item["Doc2"].ToString()

                        };
                        listComputer.Add(computer);
                    }
                    else if (table == "tblGadget")
                    {

                        var gadget = new GadgetCommon()
                        {
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            Brand = item["Brand"].ToString(),
                            OfferedPrice = item["OfferedPrice"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            DiscountAmount = item["DiscountAmount"].ToString(),
                            WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                           // ProductReviewed = item["ProductReviewed"].ToString(),
                            Doc1 = item["Doc1"].ToString(),
                            Doc2 = item["Doc2"].ToString()

                        };
                        listGadget.Add(gadget);

                    }
                    else if (table == "tblGroceries")
                    {

                        var groceries = new GroceriesCommon()
                        {
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            Brand = item["Brand"].ToString(),
                            OfferedPrice = item["OfferedPrice"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            DiscountAmount = item["DiscountAmount"].ToString(),
                            WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                            //ProductReviewed = item["ProductReviewed"].ToString(),
                            Doc1 = item["Doc1"].ToString(),
                            Doc2 = item["Doc2"].ToString()

                        };
                        listGroceries.Add(groceries);

                    }
                    else if (table == "tblClothes")
                    {

                        var clothes = new ClothesCommon()
                        {
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            Brand = item["Brand"].ToString(),
                            OfferedPrice = item["OfferedPrice"].ToString(),
                            ProductPrice= item["ProductPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            DiscountAmount = item["DiscountAmount"].ToString(),
                            WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                            //ProductReviewed = item["ProductReviewed"].ToString(),
                            Doc1 = item["Doc1"].ToString(),
                            Doc2 = item["Doc2"].ToString()

                        };
                        listClothes.Add(clothes);

                    }

                }
            }
            if (null != dt)
            {
                var productSearch = new ProductSearchCommon()
                {
                    ClothesList = listClothes,
                    GadgetList = listGadget,
                    GroceriesList = listGroceries,
                    ComputerList = listComputer
                };
                list.Add(productSearch);
            }
            
            return list;

        }

        public List<string> GetSearchFilterForComputer(string flag)
        {
            var list = new List<string>();
            var sql = "EXEC proc_ProductDetail ";
            sql += " @Flag = " + dao.FilterString(flag);
            sql += ", @TableName=" + dao.FilterString("tblComputer");
            var dt = dao.ExecuteDataTable(sql);
            if(null != dt)
            {
                foreach(System.Data.DataRow item in dt.Rows)
                {
                    var dataValue = item[flag.ToString()].ToString();
                    list.Add(dataValue);
                }
            }
            return list;

        }

        public List<string> GetSearchFilterForClothes(string flag)
        {
            var list = new List<string>();
            var sql = "EXEC proc_ProductDetail ";
            sql += " @Flag = " + dao.FilterString(flag);
            sql += ", @TableName=" + dao.FilterString("tblClothes");
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var dataValue = item[flag.ToString()].ToString();
                    list.Add(dataValue);
                }
            }
            return list;

        }
        public List<string> GetSearchFilterForGroceries(string flag)
        {
            var list = new List<string>();
            var sql = "EXEC proc_ProductDetail ";
            sql += " @Flag = " + dao.FilterString(flag);
            sql += ", @TableName=" + dao.FilterString("tblGroceries");
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var dataValue = item[flag.ToString()].ToString();
                    list.Add(dataValue);
                }
            }
            return list;

        }
        public List<string> GetSearchFilterForGadget(string flag)
        {
            var list = new List<string>();
            var sql = "EXEC proc_ProductDetail ";
            sql += " @Flag = " + dao.FilterString(flag);
            sql += ", @TableName=" + dao.FilterString("tblGadget");
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var dataValue = item[flag.ToString()].ToString();
                    list.Add(dataValue);
                }
            }
            return list;

        }
        public List<ClothesCommon> FilterClothes(string minPrice, string maxPrice, string[] Brand, string[] ProductName, string[] ProductSize, string[] ProductFor, string[] Color)
        {
            var list = new List<ClothesCommon>();
            var sql = "Exec proc_FilterProduct ";
            sql += " @flag=" + dao.FilterString("FilterClothes");
            sql += " , @minPrice = " + dao.FilterString(minPrice == null ? "" : minPrice.ToString());
            sql += " , @maxPrice = " + dao.FilterString(maxPrice == null ? "" : maxPrice.ToString());
            sql += " , @Brand = " + (Brand!=null  ? dao.FilterArrayString(Brand) : dao.FilterString(""));
            sql += " , @ProductName = " + (ProductName!=null ? dao.FilterArrayString(ProductName) : dao.FilterString(""));
            sql += " , @Size = " + (ProductSize !=null  ? dao.FilterArrayString(ProductSize) : dao.FilterString(""));
            sql += " , @ProductFor = " + (ProductFor !=null ? dao.FilterArrayString(ProductFor) : dao.FilterString(""));
            sql += " , @Color = " + (Color !=null ? dao.FilterArrayString(Color) : dao.FilterString(""));
            var dt = dao.ExecuteDataTable(sql);
            if(null != dt)
            {
                foreach(System.Data.DataRow item in dt.Rows)
                {
                    var clothesitem = new ClothesCommon()
                    {
                        ProductReferenceId = item["ProductReferenceId"].ToString(),
                        ProductDestintId = item["ProductDestintId"].ToString(),
                        ProductName = item["ProductName"].ToString(),
                        Brand = item["Brand"].ToString(),
                        OfferedPrice = item["OfferedPrice"].ToString(),
                        ProductPrice = item["ProductPrice"].ToString(),
                        DiscountPercent = item["DiscountPercent"].ToString(),
                        DiscountAmount = item["DiscountAmount"].ToString(),
                        WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                        //ProductReviewed = item["ProductReviewed"].ToString(),
                        Doc1 = item["Doc1"].ToString(),
                        Doc2 = item["Doc2"].ToString()
                    };
                    list.Add(clothesitem);
                }
            }

            return list;
        }

        public List<ComputerCommon> FilterComputer(string minPrice, string maxPrice, string[] Brand, string[] Series, string[] ProcessorBrand, string[] ScreenSize, string[] OpeatingSystem, string[] GraphicProcessorCapacity, string[] HDDCapacity, string[] SuitableFor, string[] GraphicProcessorBrand, string[] TouchScreen, string[] RamType, string[] ProcessorGeneration, string[] RAM, string[] GraphicProcessorGen, string[] SSD, string[] SSDVersiom, string[] SSDCapacity)
        {
            var list = new List<ComputerCommon>();
            var sql = "Exec proc_FilterProduct ";
            sql += " @flag=" + dao.FilterString("FilterComputer");
            sql += " , @minPrice = " + dao.FilterString(minPrice == null ? "" : minPrice.ToString());
            sql += " , @maxPrice = " + dao.FilterString(maxPrice == null ? "" : maxPrice.ToString());
            sql += " , @Brand = " + (Brand != null ? dao.FilterArrayString(Brand) : dao.FilterString(""));
            sql += " , @Series = " + (Series != null ? dao.FilterArrayString(Series) : dao.FilterString(""));
            sql += " , @ProcessorBrand = " + (ProcessorBrand != null ? dao.FilterArrayString(ProcessorBrand) : dao.FilterString(""));
            sql += " , @ScreenSize = " + (ScreenSize != null ? dao.FilterArrayString(ScreenSize) : dao.FilterString(""));
            sql += " , @OpeatingSystem = " + (OpeatingSystem != null ? dao.FilterArrayString(OpeatingSystem) : dao.FilterString(""));
            sql += " , @GraphicProcessorCapacity = " + (GraphicProcessorCapacity != null ? dao.FilterArrayString(GraphicProcessorCapacity) : dao.FilterString(""));
            sql += " , @HDDCapacity = " + (HDDCapacity != null ? dao.FilterArrayString(HDDCapacity) : dao.FilterString(""));
            sql += " , @SuitableFor = " + (SuitableFor != null ? dao.FilterArrayString(SuitableFor) : dao.FilterString(""));
            sql += " , @GraphicProcessorBrand = " + (GraphicProcessorBrand != null ? dao.FilterArrayString(GraphicProcessorBrand) : dao.FilterString(""));
            sql += " , @TouchScreen = " + (TouchScreen != null ? dao.FilterArrayString(TouchScreen) : dao.FilterString(""));
            sql += " , @RamType = " + (RamType != null ? dao.FilterArrayString(RamType) : dao.FilterString(""));
            sql += " , @ProcessorGeneration = " + (ProcessorGeneration != null ? dao.FilterArrayString(ProcessorGeneration) : dao.FilterString(""));
            sql += " , @RAM = " + (RAM != null ? dao.FilterArrayString(RAM) : dao.FilterString(""));
            sql += " , @GraphicProcessorGen = " + (GraphicProcessorGen != null ? dao.FilterArrayString(GraphicProcessorGen) : dao.FilterString(""));
            sql += " , @SSD = " + (SSD != null ? dao.FilterArrayString(SSD) : dao.FilterString(""));
            sql += " , @SSDVersiom = " + (SSDVersiom != null ? dao.FilterArrayString(SSDVersiom) : dao.FilterString(""));
            //sql += " , @SSDVersiom = " + (SSDCapacity != null ? dao.FilterArrayString(SSDCapacity) : dao.FilterString(""));
            
            
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var Computeritem = new ComputerCommon()
                    {
                        ProductReferenceId = item["ProductReferenceId"].ToString(),
                        ProductDestintId = item["ProductDestintId"].ToString(),
                        ProductName = item["ProductName"].ToString(),
                        Brand = item["Brand"].ToString(),
                        OfferedPrice = item["OfferedPrice"].ToString(),
                        ProductPrice = item["ProductPrice"].ToString(),
                        DiscountPercent = item["DiscountPercent"].ToString(),
                        DiscountAmount = item["DiscountAmount"].ToString(),
                        WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                        //ProductReviewed = item["ProductReviewed"].ToString(),
                        Doc1 = item["Doc1"].ToString(),
                        Doc2 = item["Doc2"].ToString()
                    };
                    list.Add(Computeritem);
                }
            }

            return list;




        }

        public List<GroceriesCommon> FilterGroceries(string minPrice, string maxPrice, string[] Brand, string[] ProductName, string[] QuantityPerVolume)
        {
            var list = new List<GroceriesCommon>();
            var sql = "Exec proc_FilterProduct ";
            sql += " @flag=" + dao.FilterString("FilterGroceries");
            sql += " , @minPrice = " + dao.FilterString(minPrice == null ? "" : minPrice.ToString());
            sql += " , @maxPrice = " + dao.FilterString(maxPrice == null ? "" : maxPrice.ToString());
            sql += " , @Brand = " + (Brand != null ? dao.FilterArrayString(Brand) : dao.FilterString(""));
            sql += " , @ProductName = " + (ProductName != null ? dao.FilterArrayString(ProductName) : dao.FilterString(""));
            sql += " , @QuantityPerVolume = " + (QuantityPerVolume != null ? dao.FilterArrayString(QuantityPerVolume) : dao.FilterString(""));
            
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var Groceriesitem = new GroceriesCommon()
                    {
                        ProductReferenceId = item["ProductReferenceId"].ToString(),
                        ProductDestintId = item["ProductDestintId"].ToString(),
                        ProductName = item["ProductName"].ToString(),
                        Brand = item["Brand"].ToString(),
                        OfferedPrice = item["OfferedPrice"].ToString(),
                        ProductPrice = item["ProductPrice"].ToString(),
                        DiscountPercent = item["DiscountPercent"].ToString(),
                        DiscountAmount = item["DiscountAmount"].ToString(),
                        WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                        //ProductReviewed = item["ProductReviewed"].ToString(),
                        Doc1 = item["Doc1"].ToString(),
                        Doc2 = item["Doc2"].ToString()
                    };
                    list.Add(Groceriesitem);
                }
            }

            return list;
        }

        public List<GadgetCommon> FilterGadget(string minPrice, string maxPrice, string[] Brand, string[] ProductName, string[] BrowseType, string[] SimType, string[] TouchScreen, string[] Color, string[] InternalStorage, string[] OpeatingSystem, string[] ProcessorCore, string[] PrimaryCameraDetail, string[] FrontCameraDetail, string[] DisplaySize, string[] Resolution, string[] BatteryCapacity, string[] BatteryRemovable, string[] NetworkType, string[] InternetConnectivity)
        {
            var list = new List<GadgetCommon>();
            var sql = "Exec proc_FilterProduct ";
            sql += " @flag=" + dao.FilterString("FilterGadget");
            sql += " , @minPrice = " + dao.FilterString(minPrice == null ? "" : minPrice.ToString());
            sql += " , @maxPrice = " + dao.FilterString(maxPrice == null ? "" : maxPrice.ToString());
            sql += " , @Brand = " + (Brand != null ? dao.FilterArrayString(Brand) : dao.FilterString(""));
            sql += " , @ProductName = " + (ProductName != null ? dao.FilterArrayString(ProductName) : dao.FilterString(""));
            sql += " , @BrowseType = " + (BrowseType != null ? dao.FilterArrayString(BrowseType) : dao.FilterString(""));
            sql += " , @SimType = " + (SimType != null ? dao.FilterArrayString(SimType) : dao.FilterString(""));
            sql += " , @TouchScreen = " + (TouchScreen != null ? dao.FilterArrayString(TouchScreen) : dao.FilterString(""));
            sql += " , @Color = " + (Color != null ? dao.FilterArrayString(Color) : dao.FilterString(""));
            sql += " , @InternalStorage = " + (InternalStorage != null ? dao.FilterArrayString(InternalStorage) : dao.FilterString(""));
            sql += " , @OpeatingSystem = " + (OpeatingSystem != null ? dao.FilterArrayString(OpeatingSystem) : dao.FilterString(""));
            sql += " , @ProcessorCore = " + (ProcessorCore != null ? dao.FilterArrayString(ProcessorCore) : dao.FilterString(""));
            sql += " , @PrimaryCameraDetail = " + (PrimaryCameraDetail != null ? dao.FilterArrayString(PrimaryCameraDetail) : dao.FilterString(""));
            sql += " , @FrontCameraDetail = " + (FrontCameraDetail != null ? dao.FilterArrayString(FrontCameraDetail) : dao.FilterString(""));
            sql += " , @DisplaySize = " + (DisplaySize != null ? dao.FilterArrayString(DisplaySize) : dao.FilterString(""));
            sql += " , @Resolution = " + (Resolution != null ? dao.FilterArrayString(Resolution) : dao.FilterString(""));
            sql += " , @BatteryCapacity = " + (BatteryCapacity != null ? dao.FilterArrayString(BatteryCapacity) : dao.FilterString(""));
            sql += " , @BatteryRemovable = " + (BatteryRemovable != null ? dao.FilterArrayString(BatteryRemovable) : dao.FilterString(""));
            sql += " , @NetworkType = " + (NetworkType != null ? dao.FilterArrayString(NetworkType) : dao.FilterString(""));
            sql += " , @InternetConnectivity = " + (InternetConnectivity != null ? dao.FilterArrayString(InternetConnectivity) : dao.FilterString(""));
            

            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var Gadgetitem = new GadgetCommon()
                    {
                        ProductReferenceId = item["ProductReferenceId"].ToString(),
                        ProductDestintId = item["ProductDestintId"].ToString(),
                        ProductName = item["ProductName"].ToString(),
                        Brand = item["Brand"].ToString(),
                        OfferedPrice = item["OfferedPrice"].ToString(),
                        ProductPrice = item["ProductPrice"].ToString(),
                        DiscountPercent = item["DiscountPercent"].ToString(),
                        DiscountAmount = item["DiscountAmount"].ToString(),
                        WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                        //ProductReviewed = item["ProductReviewed"].ToString(),
                        Doc1 = item["Doc1"].ToString(),
                        Doc2 = item["Doc2"].ToString()
                    };
                    list.Add(Gadgetitem);
                }
            }

            return list;
        }

        public List<ClothesCommon> GetClothesDetail(string ProductReferenceid)
        {
            var list = new List<ClothesCommon>();
            try
            {
                var sql = "EXEC proc_ProductDetailInfo ";
                sql += " @FLAG = " + dao.FilterString("ClothesDetail");
                
                sql += ",@ProductReferenceId = " + dao.FilterString(ProductReferenceid.ToString());

                var ds = dao.ExecuteDataset(sql);

                if (null != ds.Tables[0])
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                    {
                        var common = new ClothesCommon()
                        {
                            UniqueId = Convert.ToInt32(item["RowId"]),
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            Brand = item["Brand"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            CreatedDate = item["CreatedDate"].ToString(),
                            ProductDescription = item["ProductDescription"].ToString(),
                            ProductFor = item["ProductFor"].ToString(),
                            SupplierEmail = item["SupplierEmail"].ToString(),
                            SupplierAddress = item["SupplierAddress"].ToString(),
                            SupplierContactNo = item["SupplierContactNo"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            OfferedPrice = item["OfferedPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            DiscountAmount = item["DiscountAmount"].ToString(),
                            Warrenty = item["Warrenty"].ToString(),
                            WarrentyCondition = item["WarrentyCondition"].ToString(),
                            WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                            Highlights = item["Highlights"].ToString(),
                            Specification = item["Specification"].ToString(),
                            TermsAndConditions = item["TermsAndConditions"].ToString(),
                            QuickLinksSEOTag = item["QuickLinksSEOTag"].ToString(),
                            ProductReviewed = item["ProductReviewed"].ToString(),
                            CreatedBy = item["CreatedBy"].ToString(),
                            //CreatedDate = item["CreatedDate"].ToString(),
                            //CreatedDate = item["CreatedDate"].ToString(),


                        };

                        var ProductSizeList = new List<ProductSizeCommon>();
                        if (ds.Tables.Count > 1)
                        {
                            if (null != ds.Tables[1])
                            {
                                foreach (System.Data.DataRow item1 in ds.Tables[1].Rows)
                                {
                                    var ProductSizes = new ProductSizeCommon()
                                    {

                                        ProductReferenceId = item1["ProductReferenceId"].ToString(),
                                        ProductId = item1["ProductId"].ToString(),
                                        ScaleType = item1["ScaleType"].ToString(),
                                        Size = item1["Size"].ToString(),
                                        BrandSize = item1["BrandSize"].ToString(),
                                        SizeDescription = item1["SizeDescription"].ToString(),



                                    };
                                    ProductSizeList.Add(ProductSizes);
                                }
                            }
                        }
                        common.ProductSizes = ProductSizeList;

                        var QBySizeAndColorList = new List<QuantityBySizeAndColorCommon>();
                        if (ds.Tables.Count > 2)
                        {
                            if (null != ds.Tables[2])
                            {
                                foreach (System.Data.DataRow item1 in ds.Tables[2].Rows)
                                {
                                    var QBySizeAndColor = new QuantityBySizeAndColorCommon()
                                    {
                                        QBySizeAndColorId = item1["QBySizeAndColorId"].ToString(),
                                        ProductReferenceId = item1["ProductReferenceId"].ToString(),
                                        ProductDestintId = item1["ProductDestintId"].ToString(),
                                        ColorId = item1["ColorId"].ToString(),
                                        SizeId = item1["SizeId"].ToString(),
                                        Quantity = item1["Quantity"].ToString(),

                                    };
                                    QBySizeAndColorList.Add(QBySizeAndColor);
                                }
                            }
                        }
                        common.QBySizeAndColor = QBySizeAndColorList;

                        var DocList = new List<DocumentUpload>();
                        if (ds.Tables.Count > 3)
                        {
                            if (null != ds.Tables[3])
                            {
                                foreach (System.Data.DataRow item2 in ds.Tables[3].Rows)
                                {
                                    var Doc = new DocumentUpload()
                                    {
                                        View = item2["Viewof"].ToString(),
                                        Color = item2["Color"].ToString(),
                                        DocName = item2["DocName"].ToString(),


                                    };
                                    DocList.Add(Doc);
                                }
                            }
                        }
                        common.Doc = DocList;

                        var ColorList = new List<ColorsCommon>();
                        if (ds.Tables.Count > 5)
                        {
                            if (null != ds.Tables[4])
                            {
                                foreach (System.Data.DataRow item3 in ds.Tables[4].Rows)
                                {
                                    var color = new ColorsCommon()
                                    {
                                        ColorId = item3["ColorId"].ToString(),
                                        ColorName = item3["ColorName"].ToString(),
                                        ColorCode = item3["ColorCode"].ToString(),


                                    };
                                    ColorList.Add(color);
                                }
                            }
                        }
                        common.Colors = ColorList;
                       


                        sn++;
                        list.Add(common);
                    }
                }
            }
            catch (Exception e)
            {
                return list;
            }

            return list;
        }


        public List<ComputerCommon> GetComputerDetail(string ProductReferenceId)
        {
            var list = new List<ComputerCommon>();
            try
            {
                var sql = "EXEC proc_ProductDetailInfo ";
                sql += " @FLAG = " + dao.FilterString("ComputerDetail");
                
                sql += ",@ProductReferenceId = " + dao.FilterString(ProductReferenceId.ToString());

                var ds = dao.ExecuteDataset(sql);

                if (null != ds.Tables[0])
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                    {
                        var common = new ComputerCommon()
                        {
                            UniqueId = Convert.ToInt32(item["RowId"]),
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            Brand = item["Brand"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            CreatedDate = item["CreatedDate"].ToString(),
                            ProductDescription = item["ProductDescription"].ToString(),


                            ModelNo = item["ModelNo"].ToString(),
                            PartNumbers = item["PartNumbers"].ToString(),
                            InTheBox = item["InTheBox"].ToString(),
                            Series = item["Series"].ToString(),
                            Color = item["Color"].ToString(),
                            SuitableFor = item["SuitableFor"].ToString(),
                            TouchScreen = item["TouchScreen"].ToString(),
                            Sensor = item["Sensor"].ToString(),
                            SoundEnhancement = item["SoundEnhancement"].ToString(),
                            ProcessorBrand = item["ProcessorBrand"].ToString(),
                            ProcessorName = item["ProcessorName"].ToString(),
                            ProcessorGeneration = item["ProcessorGeneration"].ToString(),
                            ProcessorVariant = item["ProcessorVariant"].ToString(),
                            ProcessorCore = item["ProcessorCore"].ToString(),
                            ProcessorClockSpeed = item["ProcessorClockSpeed"].ToString(),
                            HDDCapacity = item["HDDCapacity"].ToString(),
                            SSD = item["SSD"].ToString(),
                            SSDVersiom = item["SSDVersiom"].ToString(),
                            SSDCapacity = item["SSDCapacity"].ToString(),
                            RAM = item["RAM"].ToString(),
                            RAMType = item["RAMType"].ToString(),
                            RAMFrequency = item["RAMFrequency"].ToString(),
                            Cache = item["Cache"].ToString(),
                            RPM = item["RPM"].ToString(),
                            GraphicProcessor = item["GraphicProcessor"].ToString(),
                            GraphicProcessorBrand = item["GraphicProcessorBrand"].ToString(),
                            GraphicProcessorCapacity = item["GraphicProcessorCapacity"].ToString(),
                            GraphicProcessorGen = item["GraphicProcessorGen"].ToString(),
                            OpeatingSystem = item["OpeatingSystem"].ToString(),
                            MicIn = item["MicIn"].ToString(),
                            RJ45 = item["RJ45"].ToString(),
                            USBPort = item["USBPort"].ToString(),
                            HDMIPort = item["HDMIPort"].ToString(),
                            MultiCardSlot = item["MultiCardSlot"].ToString(),
                            FirePort = item["FirePort"].ToString(),
                            TypeCPort = item["TypeCPort"].ToString(),
                            ScreenSize = item["ScreenSize"].ToString(),
                            Resolution = item["Resolution"].ToString(),
                            ScreenType = item["ScreenType"].ToString(),
                            InternalMic = item["InternalMic"].ToString(),
                            Speakers = item["Speakers"].ToString(),
                            OtherDisplayFeature = item["OtherDisplayFeature"].ToString(),

                            Ethernet = item["Ethernet"].ToString(),
                            InternetConnectivity = item["InternetConnectivity"].ToString(),
                            BluetoothSuppoert = item["BluetoothSuppoert"].ToString(),
                            BluetoothVersion = item["BluetoothVersion"].ToString(),
                            WIFI = item["WIFI"].ToString(),
                            WIFIVersion = item["WIFIVersion"].ToString(),
                            WifiHotspot = item["WifiHotspot"].ToString(),

                            Width = item["Width"].ToString(),
                            Height = item["Height"].ToString(),
                            Depth = item["Depth"].ToString(),
                            Weight = item["Weight"].ToString(),
                            BatteryBackup = item["BatteryBackup"].ToString(),
                            PowerSupply = item["PowerSupply"].ToString(),
                            BatteryCell = item["BatteryCell"].ToString(),
                            BatteryRemovable = item["BatteryRemovable"].ToString(),

                            WebCam = item["WebCam"].ToString(),
                            LockPort = item["LockPort"].ToString(),
                            Keyboard = item["Keyboard"].ToString(),
                            KeyboardLight = item["KeyboardLight"].ToString(),
                            PointerDevice = item["PointerDevice"].ToString(),
                            AdditionalFeatures = item["AdditionalFeatures"].ToString(),
                            Quantity = item["Quantity"].ToString(),

                            SupplierEmail = item["SupplierEmail"].ToString(),
                            SupplierAddress = item["SupplierAddress"].ToString(),
                            SupplierContactNo = item["SupplierContactNo"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            OfferedPrice = item["OfferedPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            DiscountAmount = item["DiscountAmount"].ToString(),
                            Warrenty = item["Warrenty"].ToString(),
                            WarrentyCondition = item["WarrentyCondition"].ToString(),
                            WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                            Highlights = item["Highlights"].ToString(),

                            TermsAndConditions = item["TermsAndConditions"].ToString(),
                            QuickLinksSEOTag = item["QuickLinksSEOTag"].ToString(),
                            ProductReviewed = item["ProductReviewed"].ToString(),
                            CreatedBy = item["CreatedBy"].ToString(),



                        };



                        var DocList = new List<DocumentUpload>();
                        if (ds.Tables.Count > 1)
                        {
                            if (null != ds.Tables[1])
                            {
                                foreach (System.Data.DataRow item2 in ds.Tables[1].Rows)
                                {
                                    var Doc = new DocumentUpload()
                                    {
                                        View = item2["Viewof"].ToString(),
                                        Color = item2["Color"].ToString(),
                                        DocName = item2["DocName"].ToString(),


                                    };
                                    DocList.Add(Doc);
                                }
                            }
                        }
                        common.Doc = DocList;



                        sn++;
                        list.Add(common);
                    }
                }
            }
            catch (Exception e)
            {
                return list;
            }

            return list;
        }


        public List<GroceriesCommon> GetGroceriesDetail(string ProductReferenceId)
        {
            var list = new List<GroceriesCommon>();
            try
            {
                var sql = "EXEC proc_ProductDetailInfo ";
                sql += " @FLAG = " + dao.FilterString("GroceriesDetail");                
                sql += ",@ProductReferenceId = " + dao.FilterString(ProductReferenceId.ToString());

                var ds = dao.ExecuteDataset(sql);

                if (null != ds.Tables[0])
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                    {
                        var common = new GroceriesCommon()
                        {
                            UniqueId = Convert.ToInt32(item["RowId"]),
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            Brand = item["Brand"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            ProductUnit = item["ProductUnit"].ToString(),
                            QuntityUnit = item["QuntityUnit"].ToString(),
                            ProductVolume = item["ProductVolume"].ToString(),
                            QuantityPerVolume = item["QuantityPerVolume"].ToString(),

                            ProductDescription = item["ProductDescription"].ToString(),
                            SupplierEmail = item["SupplierEmail"].ToString(),
                            SupplierAddress = item["SupplierAddress"].ToString(),
                            SupplierContactNo = item["SupplierContactNo"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            OfferedPrice = item["OfferedPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            DiscountAmount = item["DiscountAmount"].ToString(),
                            Warrenty = item["Warrenty"].ToString(),
                            WarrentyCondition = item["WarrentyCondition"].ToString(),
                            WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                            Highlights = item["Highlights"].ToString(),
                            Specification = item["Specification"].ToString(),
                            TermsAndConditions = item["TermsAndConditions"].ToString(),
                            QuickLinksSEOTag = item["QuickLinksSEOTag"].ToString(),
                            ProductReviewed = item["ProductReviewed"].ToString(),
                            User = item["CreatedBy"].ToString(),
                            CreatedDate = item["CreatedDate"].ToString(),


                        };


                        var DocList = new List<DocumentUpload>();
                        if (ds.Tables.Count > 1)
                        {
                            if (null != ds.Tables[1])
                            {
                                foreach (System.Data.DataRow item1 in ds.Tables[1].Rows)
                                {
                                    var Doc = new DocumentUpload()
                                    {
                                        View = item1["Viewof"].ToString(),
                                        Color = item1["Color"].ToString(),
                                        DocName = item1["DocName"].ToString(),


                                    };
                                    DocList.Add(Doc);
                                }
                            }
                        }
                        common.Doc = DocList;



                        sn++;
                        list.Add(common);
                    }
                }
            }
            catch (Exception e)
            {
                return list;
            }

            return list;
        }
        public List<GadgetCommon> GetGadgetDetail(string ProductReferenceId)
        {
            var list = new List<GadgetCommon>();
            try
            {
                var sql = "EXEC proc_ProductDetailInfo ";
                sql += " @FLAG = " + dao.FilterString("GadgetDetail");
                sql += ",@ProductReferenceId = " + dao.FilterString(ProductReferenceId.ToString());

                var ds = dao.ExecuteDataset(sql);

                if (null != ds.Tables[0])
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                    {
                        var common = new GadgetCommon()
                        {
                            UniqueId = Convert.ToInt32(item["RowId"]),
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            Brand = item["Brand"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            CreatedDate = item["CreatedDate"].ToString(),
                            ProductDescription = item["ProductDescription"].ToString(),


                            ModelNo = item["ModelNo"].ToString(),
                            ModelName = item["ModelName"].ToString(),
                            InTheBox = item["InTheBox"].ToString(),
                            Color = item["Color"].ToString(),
                            BrowseType = item["BrowseType"].ToString(),
                            SimType = item["SimType"].ToString(),
                            SimSize = item["SimSize"].ToString(),
                            HybridSimSlot = item["HybridSimSlot"].ToString(),
                            TouchScreen = item["TouchScreen"].ToString(),
                            Sensor = item["Sensor"].ToString(),
                            OTGCompatable = item["OTGCompatable"].ToString(),
                            QuickCharging = item["QuickCharging"].ToString(),
                            SoundEnhancement = item["SoundEnhancement"].ToString(),
                            PrimaryCameraDetail = item["PrimaryCameraDetail"].ToString(),
                            PrimaryCameraFeatures = item["PrimaryCameraFeatures"].ToString(),
                            FrontCameraDetail = item["FrontCameraDetail"].ToString(),
                            FrontCameraFeatures = item["FrontCameraFeatures"].ToString(),
                            Flash = item["Flash"].ToString(),
                            FrameRate = item["FrameRate"].ToString(),
                            OpeatingSystem = item["OpeatingSystem"].ToString(),
                            ProcessorType = item["ProcessorType"].ToString(),
                            ProcessorCore = item["ProcessorCore"].ToString(),
                            ProcessorClockSpeed = item["ProcessorClockSpeed"].ToString(),
                            OSFrequency = item["OSFrequency"].ToString(),
                            InternalStorage = item["InternalStorage"].ToString(),
                            RAM = item["RAM"].ToString(),
                            ExpandableStorage = item["ExpandableStorage"].ToString(),
                            SupprtedMemoryCardType = item["SupprtedMemoryCardType"].ToString(),
                            MemoryCardSlotTypes = item["MemoryCardSlotTypes"].ToString(),
                            DisplaySize = item["DisplaySize"].ToString(),
                            Resolution = item["Resolution"].ToString(),
                            ResolutionType = item["ResolutionType"].ToString(),
                            GPU = item["GPU"].ToString(),
                            GraphicPPI = item["GraphicPPI"].ToString(),
                            OtherDisplayFeature = item["OtherDisplayFeature"].ToString(),
                            Width = item["Width"].ToString(),
                            Height = item["Height"].ToString(),
                            Depth = item["Depth"].ToString(),
                            Weight = item["Weight"].ToString(),
                            BatteryCapacity = item["BatteryCapacity"].ToString(),
                            BatteryFeatures = item["BatteryFeatures"].ToString(),
                            BatteryRemovable = item["BatteryRemovable"].ToString(),
                            NetworkType = item["NetworkType"].ToString(),
                            SupportedNetwork = item["SupportedNetwork"].ToString(),
                            InternetConnectivity = item["InternetConnectivity"].ToString(),
                            BluetoothSuppoert = item["BluetoothSuppoert"].ToString(),
                            WIFI = item["WIFI"].ToString(),
                            WIFIVersion = item["WIFIVersion"].ToString(),
                            WifiHotspot = item["WifiHotspot"].ToString(),
                            USBConnectivity = item["USBConnectivity"].ToString(),
                            AudioJack = item["AudioJack"].ToString(),
                            ChargerType = item["ChargerType"].ToString(),
                            Quantity = item["Quantity"].ToString(),

                            SupplierEmail = item["SupplierEmail"].ToString(),
                            SupplierAddress = item["SupplierAddress"].ToString(),
                            SupplierContactNo = item["SupplierContactNo"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            OfferedPrice = item["OfferedPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            DiscountAmount = item["DiscountAmount"].ToString(),
                            Warrenty = item["Warrenty"].ToString(),
                            WarrentyCondition = item["WarrentyCondition"].ToString(),
                            WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                            Highlights = item["Highlights"].ToString(),

                            TermsAndConditions = item["TermsAndConditions"].ToString(),
                            QuickLinksSEOTag = item["QuickLinksSEOTag"].ToString(),
                            ProductReviewed = item["ProductReviewed"].ToString(),
                            User = item["CreatedBy"].ToString(),



                        };



                        var DocList = new List<DocumentUpload>();
                        if (ds.Tables.Count > 1)
                        {
                            if (null != ds.Tables[1])
                            {
                                foreach (System.Data.DataRow item2 in ds.Tables[1].Rows)
                                {
                                    var Doc = new DocumentUpload()
                                    {
                                        View = item2["Viewof"].ToString(),
                                        Color = item2["Color"].ToString(),
                                        DocName = item2["DocName"].ToString(),


                                    };
                                    DocList.Add(Doc);
                                }
                            }
                        }
                        common.Doc = DocList;



                        sn++;
                        list.Add(common);
                    }
                }
            }
            catch (Exception e)
            {
                return list;
            }

            return list;
        }
        public ProductRateCommon ProductRating(string ProductReferenceId)
        {
            var common = new ProductRateCommon();
            var sql = "Exec proc_ProductDetailInfo ";
            sql += "@flag= " + dao.FilterString("productRated");
            sql += ",@ProductReferenceId = " + dao.FilterString(ProductReferenceId.ToString());

            var ds = dao.ExecuteDataset(sql);
            if (ds.Tables[0] != null)
            {
                foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                {
                    var data = new ProductRateCommon()
                    {
                        ProductReferenceId = item["ProductReferenceId"].ToString(),
                        ProductDistinctId = item["ProductDistinctId"].ToString(),
                        CountOneRating = item["CountOneRating"].ToString(),
                        CountTwoRating = item["CountTwoRating"].ToString(),
                        CountThreeRating = item["CountThreeRating"].ToString(),
                        CountFourRating = item["CountFourRating"].ToString(),
                        CountFiveRating = item["CountFiveRating"].ToString()
                    };
                    common = data;
                }

                
            }

            return common;

        }

        public DbResponse PushComment(string ProductReferenceId, string CommentTo, string CommentMessage, string User)
        {
            var sql = "Exec proc_ProductDetailInfo ";
            sql += " @flag= " + dao.FilterString("PushComment");
            sql += ",@ProductReferenceId = " + dao.FilterString(ProductReferenceId == null ? "" : ProductReferenceId);
            sql += ",@CommentTo = " + dao.FilterString(CommentTo == null ? "" : CommentTo);
            sql += ",@CommentMessage = " + dao.FilterString(CommentMessage == null ? "" : CommentMessage);
            sql += ",@User = " + dao.FilterString(User == null ? "" : User);

            return dao.ParseDbResponse(sql);

            //return repo.PushComment(ProductReferenceId, CommentTo, CommentMessage, User);
        }
        public List<CommentCommon> LoadComment(string ProductReferenceId)
        {
            var list = new List<CommentCommon>();
            var sql = "Exec proc_ProductDetailInfo ";
            sql += " @flag=" + dao.FilterString("LoadComment");
            sql += ", @ProductReferenceId= " + dao.FilterString(ProductReferenceId == null ? "" : ProductReferenceId);
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach(System.Data.DataRow item in dt.Rows)
                {
                    var data = new CommentCommon()
                    {
                        ProductReferenceId = item["ProductReferenceId"].ToString(),
                        RowId = item["RowId"].ToString(),
                        CommentMessage = item["CommentMessage"].ToString(),
                        CommentBy = item["CommentBy"].ToString(),
                        CommentTo = item["CommentTo"].ToString(),

                    };
                    list.Add(data);

                }
            }


            return list;

        }

        public DbResponse RateNow(string ProductReferenceId, string rating, string user)
        {
            var sql = "Exec proc_ProductDetailInfo ";
            sql += " @flag= " + dao.FilterString("rateNow");
            sql += ",@ProductReferenceId = " + dao.FilterString(ProductReferenceId == null ? "" : ProductReferenceId);
            sql += ",@Rating = " + dao.FilterString(rating == null ? "" : rating);           
            sql += ",@User = " + dao.FilterString(user == null ? "" : user);

            return dao.ParseDbResponse(sql);

            //return repo.PushComment(ProductReferenceId, CommentTo, CommentMessage, User);
        }


    }
}
