using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.Repository.Gadget
{
    public class GadgetRepo : IGadgetRepo
    {
        RepositoryDao dao;
        public GadgetRepo()
        {
            dao = new RepositoryDao();
        }

        public List<GadgetCommon> GetGridList(GridParam gridParam)
        {
            var list = new List<GadgetCommon>();
            try
            {
                var sql = "EXEC proc_tblGadget ";
                sql += " @FLAG = " + dao.FilterString("A");
                sql += ",@User = " + dao.FilterString(gridParam.UserName);
                sql += ",@Search = " + dao.FilterString(gridParam.Search);
                sql += ",@DisplayLength = " + dao.FilterString(gridParam.DisplayLength.ToString());
                sql += ",@DisplayStart = " + dao.FilterString(gridParam.DisplayStart.ToString());
                sql += ",@SortDir = " + dao.FilterString(gridParam.SortDir);
                sql += ",@SortCol = " + dao.FilterString(gridParam.SortCol.ToString());
                var dt = dao.ExecuteDataTable(sql);

                if (null != dt)
                {
                    int sn = 1;
                    foreach (System.Data.DataRow item in dt.Rows)
                    {
                        var common = new GadgetCommon()
                        {
                            UniqueId = Convert.ToInt32(item["RowId"]),
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            Brand = item["Brand"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            ModelNo=item["ModelNo"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            
                            User = item["CreatedBy"].ToString(),
                            CreatedDate = item["CreatedDate"].ToString(),
                            FilterCount = item["FilterCount"].ToString(),
                        };
                        sn++;
                        list.Add(common);
                    }
                }
                return list;
            }

            catch (Exception e)
            {
                return list;
            }

        }


        public List<GadgetCommon> GetList(string user, string id)
        {
            var list = new List<GadgetCommon>();
            try
            {
                var sql = "EXEC proc_tblGadget ";
                sql += " @FLAG = " + dao.FilterString((id != "0" ? "S" : "A"));
                sql += ",@User = " + dao.FilterString(user);
                sql += ",@RowId = " + dao.FilterString(id.ToString());

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
                            BluetoothVersion = item["BluetoothVersion"].ToString(),
                            WIFI = item["WIFI"].ToString(),
                            WIFIVersion = item["WIFIVersion"].ToString(),
                            WifiHotspot = item["WifiHotspot"].ToString(),
                            USBConnectivity = item["USBConnectivity"].ToString(),
                            AudioJack = item["AudioJack"].ToString(),
                            ChargerType = item["ChargerType"].ToString(),
                            Quantity =item["Quantity"].ToString(),

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
                            ReplacementPeriod=item["ReplacementPeriod"].ToString(),
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

        public DbResponse Manage(GadgetCommon model)
        {
            

            try
            {
                var sql = "EXEC proc_tblGadget ";
                sql += " @flag = " + dao.FilterString((model.UniqueId > 0 ? "U" : "I"));
                sql += ",@User = " + dao.FilterString(model.User);
                sql += ",@RowId = " + dao.FilterString(model.UniqueId.ToString());
                sql += ",@ProductReferenceId = " + dao.FilterString(model.ProductReferenceId == null ? "" : model.ProductReferenceId.ToString());
                sql += ",@ProductDestintId=" + dao.FilterString(model.ProductDestintId == null ? "" : model.ProductDestintId.ToString());
                sql += ",@Brand=" + dao.FilterString(model.Brand == null ? "" : model.Brand.ToString());
                sql += ",@ProductName=" + dao.FilterString(model.ProductName == null ? "" : model.ProductName.ToString());


                sql += ",@ModelNo  =" + dao.FilterString(model.ModelNo == null ? "" : model.ModelNo.ToString());
                sql += ",@ModelName  =" + dao.FilterString(model.ModelName ==null? "" : model.ModelName.ToString());                
                sql += ",@InTheBox  =" + dao.FilterString(model.InTheBox == null? "" : model.InTheBox.ToString());
                sql += ",@Color  =" + dao.FilterString(model.Color == null? "" : model.Color.ToString());
                sql += ",@BrowseType  =" + dao.FilterString(model.BrowseType == null? "" : model.BrowseType.ToString());
                sql += ",@SimType  =" + dao.FilterString(model.SimType == null? "" : model.SimType.ToString());
                sql += ",@SimSize  =" + dao.FilterString(model.SimSize == null? "" : model.SimSize.ToString());
                sql += ",@HybridSimSlot  =" + dao.FilterString(model.HybridSimSlot == null ? "" : model.HybridSimSlot.ToString());
                sql += ",@TouchScreen  =" + dao.FilterString(model.TouchScreen == null? "" : model.TouchScreen.ToString());
                sql += ",@Sensor  =" + dao.FilterString(model.Sensor == null? "" : model.Sensor.ToString());
                sql += ",@OTGCompatable  =" + dao.FilterString(model.OTGCompatable == null? "" : model.OTGCompatable.ToString());
                sql += ",@QuickCharging  =" + dao.FilterString(model.QuickCharging == null? "" : model.QuickCharging.ToString());
                sql += ",@SoundEnhancement  =" + dao.FilterString(model.SoundEnhancement == null? "" : model.SoundEnhancement.ToString());
                sql += ",@PrimaryCameraDetail  =" + dao.FilterString(model.PrimaryCameraDetail == null? "" : model.PrimaryCameraDetail.ToString());
                sql += ",@PrimaryCameraFeatures  =" + dao.FilterString(model.PrimaryCameraFeatures == null? "" : model.PrimaryCameraFeatures.ToString());
                sql += ",@FrontCameraDetail  =" + dao.FilterString(model.FrontCameraDetail == null? "" : model.FrontCameraDetail.ToString());
                sql += ",@FrontCameraFeatures  =" + dao.FilterString(model.FrontCameraFeatures == null? "" : model.FrontCameraFeatures.ToString());
                sql += ",@Flash  =" + dao.FilterString(model.Flash == null? "" : model.Flash.ToString());
                sql += ",@FrameRate  =" + dao.FilterString(model.FrameRate == null? "" : model.FrameRate.ToString());
                sql += ",@OpeatingSystem  =" + dao.FilterString(model.OpeatingSystem == null? "" : model.OpeatingSystem.ToString());
                sql += ",@ProcessorType  =" + dao.FilterString(model.ProcessorType == null? "" : model.ProcessorType.ToString());
                sql += ",@ProcessorCore  =" + dao.FilterString(model.ProcessorCore == null? "" : model.ProcessorCore.ToString());
                sql += ",@ProcessorClockSpeed  =" + dao.FilterString(model.ProcessorClockSpeed == null? "" : model.ProcessorClockSpeed.ToString());
                sql += ",@OSFrequency  =" + dao.FilterString(model.OSFrequency == null? "" : model.OSFrequency.ToString());
                sql += ",@InternalStorage  =" + dao.FilterString(model.InternalStorage == null? "" : model.InternalStorage.ToString());
                sql += ",@RAM  =" + dao.FilterString(model.RAM == null? "" : model.RAM.ToString());
                sql += ",@ExpandableStorage  =" + dao.FilterString(model.ExpandableStorage == null? "" : model.ExpandableStorage.ToString());
                sql += ",@SupprtedMemoryCardType  =" + dao.FilterString(model.SupprtedMemoryCardType == null? "" : model.SupprtedMemoryCardType.ToString());
                sql += ",@MemoryCardSlotTypes  =" + dao.FilterString(model.MemoryCardSlotTypes == null? "" : model.MemoryCardSlotTypes.ToString());
                sql += ",@DisplaySize  =" + dao.FilterString(model.DisplaySize == null? "" : model.DisplaySize.ToString());
                sql += ",@Resolution  =" + dao.FilterString(model.Resolution == null? "" : model.Resolution.ToString());
                sql += ",@ResolutionType  =" + dao.FilterString(model.ResolutionType == null? "" : model.ResolutionType.ToString());
                sql += ",@GPU  =" + dao.FilterString(model.GPU == null? "" : model.GPU.ToString());
                sql += ",@GraphicPPI  =" + dao.FilterString(model.GraphicPPI == null? "" : model.GraphicPPI.ToString());
                sql += ",@OtherDisplayFeature  =" + dao.FilterString(model.OtherDisplayFeature == null? "" : model.OtherDisplayFeature.ToString());
                sql += ",@Width  =" + dao.FilterString(model.Width == null? "" : model.Width.ToString());
                sql += ",@Height  =" + dao.FilterString(model.Height == null? "" : model.Height.ToString());
                sql += ",@Depth  =" + dao.FilterString(model.Depth == null? "" : model.Depth.ToString());
                sql += ",@Weight  =" + dao.FilterString(model.Weight == null? "" : model.Weight.ToString());
                sql += ",@BatteryCapacity  =" + dao.FilterString(model.BatteryCapacity == null? "" : model.BatteryCapacity.ToString());
                sql += ",@BatteryFeatures  =" + dao.FilterString(model.BatteryFeatures == null? "" : model.BatteryFeatures.ToString());
                sql += ",@BatteryRemovable  =" + dao.FilterString(model.BatteryRemovable == null? "" : model.BatteryRemovable.ToString());
                sql += ",@NetworkType  =" + dao.FilterString(model.NetworkType == null? "" : model.NetworkType.ToString());
                sql += ",@SupportedNetwork  =" + dao.FilterString(model.SupportedNetwork == null? "" : model.SupportedNetwork.ToString());
                sql += ",@InternetConnectivity  =" + dao.FilterString(model.InternetConnectivity == null? "" : model.InternetConnectivity.ToString());
                sql += ",@BluetoothSuppoert  =" + dao.FilterString(model.BluetoothSuppoert == null? "" : model.BluetoothSuppoert.ToString());
                sql += ",@BluetoothVersion  =" + dao.FilterString(model.BluetoothVersion == null? "" : model.BluetoothVersion.ToString());
                sql += ",@WIFI  =" + dao.FilterString(model.WIFI == null? "" : model.WIFI.ToString());
                sql += ",@WIFIVersion  =" + dao.FilterString(model.WIFIVersion == null? "" : model.WIFIVersion.ToString());
                sql += ",@WifiHotspot  =" + dao.FilterString(model.WifiHotspot == null? "" : model.WifiHotspot.ToString());
                sql += ",@USBConnectivity  =" + dao.FilterString(model.USBConnectivity == null? "" : model.USBConnectivity.ToString());
                sql += ",@AudioJack  =" + dao.FilterString(model.AudioJack == null? "" : model.AudioJack.ToString());
                sql += ",@ChargerType  =" + dao.FilterString(model.ChargerType == null? "" : model.ChargerType.ToString());
                sql += ",@Quantity  =" + dao.FilterString(model.Quantity == null? "" : model.Quantity.ToString());

                sql += ",@OfferedPrice=" + dao.FilterString(model.OfferedPrice == null ? "" : model.OfferedPrice.ToString());
                sql += ",@DiscountPercent=" + dao.FilterString(model.DiscountPercent == null ? "" : model.DiscountPercent.ToString());
                sql += ",@DiscountAmount=" + dao.FilterString(model.DiscountAmount == null ? "" : model.DiscountAmount.ToString());
                sql += ",@ProductPrice=" + dao.FilterString(model.ProductPrice == null ? "" : model.ProductPrice.ToString());
                sql += ",@QuickLinksSEOTag=" + dao.FilterString(model.QuickLinksSEOTag == null ? "" : model.QuickLinksSEOTag.ToString());
                sql += ",@Warrenty=" + dao.FilterString(model.Warrenty == null ? "" : model.Warrenty.ToString());
                sql += ",@WarrentyPeriod=" + dao.FilterString(model.WarrentyPeriod == null ? "" : model.WarrentyPeriod.ToString());
                sql += ",@WarrentyCondition=" + dao.FilterString(model.WarrentyCondition == null ? "" : model.WarrentyCondition.ToString());
                sql += ",@ProductDescription=" + dao.FilterString(model.ProductDescription == null ? "" : model.ProductDescription.ToString());
                sql += ",@TermsAndConditions=" + dao.FilterString(model.TermsAndConditions == null ? "" : model.TermsAndConditions.ToString());
                sql += ",@Highlights=" + dao.FilterString(model.Highlights == null ? "" : model.Highlights.ToString());
                sql += ",@ReplacementPeriod=" + dao.FilterString(model.ReplacementPeriod == null ? "" : model.ReplacementPeriod.ToString());



                return dao.ParseDbResponse(sql);
            }
            catch (Exception ex)
            {
                return dao.ExceptionDbResponse(ex.Message);
            }

        }


        public DbResponse RecordDocument(string User, string docExt, string docName, string fulldocname, string ProductReferenceId, string ProductDistinctId, string View, string Color)
        {
            try
            {
                var sql = "EXEC proc_tblDocUpload ";
                sql += "@flag= " + dao.FilterString("DocUpload");
                sql += ",@User = " + dao.FilterString(User);
                sql += ",@DocFor = " + dao.FilterString("Mobile");
                sql += ",@DocExt = " + dao.FilterString(docExt);
                sql += ",@DocName = " + dao.FilterString(docName);
                sql += ",@DocPath = " + dao.FilterString(fulldocname);
                sql += ",@ProductReferenceId = " + dao.FilterString(ProductReferenceId);
                sql += ",@ProductDistinctId = " + dao.FilterString(ProductDistinctId);
                sql += ",@Viewof = " + dao.FilterString(View);
                sql += ",@Color = " + dao.FilterString(Color);
                //sql += ",@User = " + dao.FilterString(ProductDistinctId);

                return dao.ParseDbResponse(sql);

            }
            catch (Exception ex)
            {
                return dao.ExceptionDbResponse(ex.Message);

            }
            //return dao.RecordDocument(User, docExt, docName, fulldocname, ProductReferenceId, ProductDistinctId, View, Color);
        }


        public List<ProductSearchCommon> ShowGadget()
        {
            var list = new List<ProductSearchCommon>();
            var gadgetList = new List<GadgetCommon>();
            var sql = "Exec proc_tblGadget";
            sql += " @Flag = " + dao.FilterString("ShowGadget");
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var table = item["TableName"].ToString();
                    if (table == "tblGadget")
                    {
                        var Gadget = new GadgetCommon()
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
                            //ProductReviewed=item["ProductReviewed"].ToString(),
                            Doc1 = item["Doc1"].ToString(),
                            Doc2 = item["Doc2"].ToString()

                        };
                        gadgetList.Add(Gadget);
                    }
                }
            }
            if (null != dt)
            {
                var productSearch = new ProductSearchCommon()
                {
                    GadgetList = gadgetList

                };
                list.Add(productSearch);
            }
            return list;


        }

        public List<GadgetCommon> GetGadget()
        {
            //var list = new List<ProductSearchCommon>();
            var gadgetList = new List<GadgetCommon>();
            var sql = "Exec proc_tblGadget";
            sql += " @Flag = " + dao.FilterString("ShowGadget");
            var dt = dao.ExecuteDataTable(sql);
            if (null != dt)
            {
                foreach (System.Data.DataRow item in dt.Rows)
                {
                    var table = item["TableName"].ToString();
                    if (table == "tblGadget")
                    {
                        var Gadget = new GadgetCommon()
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
                            //ProductReviewed=item["ProductReviewed"].ToString(),
                            Doc1 = item["Doc1"].ToString(),
                            Doc2 = item["Doc2"].ToString()

                        };
                        gadgetList.Add(Gadget);
                    }
                }
            }
           
            return gadgetList;


        }



    }
}
