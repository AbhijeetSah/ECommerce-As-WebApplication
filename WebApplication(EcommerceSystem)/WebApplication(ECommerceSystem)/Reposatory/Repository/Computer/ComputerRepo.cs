using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposatory.Repository.Computer
{
    public class ComputerRepo : IComputerRepo
    {
        RepositoryDao dao;
        public ComputerRepo()
        {
            dao = new RepositoryDao();
        }
        public List<ComputerCommon> GetGridList(GridParam gridParam)
        {
            var list = new List<ComputerCommon>();
            try
            {
                var sql = "EXEC proc_tblComputer ";
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
                        var common = new ComputerCommon()
                        {
                            UniqueId = Convert.ToInt32(item["RowId"]),
                            ProductReferenceId = item["ProductReferenceId"].ToString(),
                            ProductDestintId = item["ProductDestintId"].ToString(),
                            Brand = item["Brand"].ToString(),
                            ProductName = item["ProductName"].ToString(),
                            ModelNo = item["ModelNo"].ToString(),
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


        public List<ComputerCommon> GetList(string user, string id)
        {
            var list = new List<ComputerCommon>();
            try
            {
                var sql = "EXEC proc_tblComputer ";
                sql += " @FLAG = " + dao.FilterString((id != "0" ? "S" : "A"));
                sql += ",@User = " + dao.FilterString(user);
                sql += ",@RowId = " + dao.FilterString(id.ToString());

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

        public DbResponse Manage(ComputerCommon model)
        {


            try
            {
                var sql = "EXEC proc_tblComputer ";
                sql += " @flag = " + dao.FilterString((model.UniqueId > 0 ? "U" : "I"));
                sql += ",@User = " + dao.FilterString(model.User);
                sql += ",@RowId = " + dao.FilterString(model.UniqueId.ToString());
                sql += ",@ProductReferenceId = " + dao.FilterString(model.ProductReferenceId == null ? "" : model.ProductReferenceId.ToString());
                sql += ",@ProductDestintId=" + dao.FilterString(model.ProductDestintId == null ? "" : model.ProductDestintId.ToString());
                sql += ",@Brand=" + dao.FilterString(model.Brand == null ? "" : model.Brand.ToString());
                sql += ",@ProductName=" + dao.FilterString(model.ProductName == null ? "" : model.ProductName.ToString());


                sql += ",@ModelNo  =" + dao.FilterString(model.ModelNo == null ? "" : model.ModelNo.ToString());
                sql += ",@PartNumbers  =" + dao.FilterString(model.PartNumbers == null ? "" : model.PartNumbers.ToString());
                sql += ",@InTheBox  =" + dao.FilterString(model.InTheBox == null ? "" : model.InTheBox.ToString());
                sql += ",@Series  =" + dao.FilterString(model.Series == null ? "" : model.Series.ToString());
                sql += ",@Color  =" + dao.FilterString(model.Color == null ? "" : model.Color.ToString());
                sql += ",@SuitableFor  =" + dao.FilterString(model.SuitableFor == null ? "" : model.SuitableFor.ToString());
                sql += ",@TouchScreen  =" + dao.FilterString(model.TouchScreen == null ? "" : model.TouchScreen.ToString());
                sql += ",@Sensor  =" + dao.FilterString(model.Sensor == null ? "" : model.Sensor.ToString());
                sql += ",@SoundEnhancement  =" + dao.FilterString(model.SoundEnhancement == null ? "" : model.SoundEnhancement.ToString());

                sql += ",@ProcessorBrand  =" + dao.FilterString(model.ProcessorBrand == null ? "" : model.ProcessorBrand.ToString());
                sql += ",@ProcessorName  =" + dao.FilterString(model.ProcessorName == null ? "" : model.ProcessorName.ToString());
                sql += ",@ProcessorGeneration  =" + dao.FilterString(model.ProcessorGeneration == null ? "" : model.ProcessorGeneration.ToString());
                sql += ",@ProcessorVariant  =" + dao.FilterString(model.ProcessorVariant == null ? "" : model.ProcessorVariant.ToString());
                sql += ",@ProcessorCore  =" + dao.FilterString(model.ProcessorCore == null ? "" : model.ProcessorCore.ToString());
                sql += ",@ProcessorClockSpeed  =" + dao.FilterString(model.ProcessorClockSpeed == null ? "" : model.ProcessorClockSpeed.ToString());

                sql += ",@HDDCapacity  =" + dao.FilterString(model.HDDCapacity == null ? "" : model.HDDCapacity.ToString());
                sql += ",@SSD  =" + dao.FilterString(model.SSD == null ? "" : model.SSD.ToString());
                sql += ",@SSDVersiom  =" + dao.FilterString(model.SSDVersiom == null ? "" : model.SSDVersiom.ToString());
                sql += ",@SSDCapacity  =" + dao.FilterString(model.SSDCapacity == null ? "" : model.SSDCapacity.ToString());
                sql += ",@RAM  =" + dao.FilterString(model.RAM == null ? "" : model.RAM.ToString());
                sql += ",@RAMType  =" + dao.FilterString(model.RAMType == null ? "" : model.RAMType.ToString());
                sql += ",@RAMFrequency  =" + dao.FilterString(model.RAMFrequency == null ? "" : model.RAMFrequency.ToString());
                sql += ",@Cache  =" + dao.FilterString(model.Cache == null ? "" : model.Cache.ToString());
                sql += ",@RPM  =" + dao.FilterString(model.RPM == null ? "" : model.RPM.ToString());
                sql += ",@GraphicProcessor  =" + dao.FilterString(model.GraphicProcessor == null ? "" : model.GraphicProcessor.ToString());
                sql += ",@GraphicProcessorBrand  =" + dao.FilterString(model.GraphicProcessorBrand == null ? "" : model.GraphicProcessorBrand.ToString());
                sql += ",@GraphicProcessorCapacity  =" + dao.FilterString(model.GraphicProcessorCapacity == null ? "" : model.GraphicProcessorCapacity.ToString());
                sql += ",@GraphicProcessorGen  =" + dao.FilterString(model.GraphicProcessorGen == null ? "" : model.GraphicProcessorGen.ToString());
                sql += ",@OpeatingSystem  =" + dao.FilterString(model.OpeatingSystem == null ? "" : model.OpeatingSystem.ToString());
                sql += ",@MicIn  =" + dao.FilterString(model.MicIn == null ? "" : model.MicIn.ToString());

                sql += ",@RJ45  =" + dao.FilterString(model.RJ45 == null ? "" : model.RJ45.ToString());
                sql += ",@USBPort  =" + dao.FilterString(model.USBPort == null ? "" : model.USBPort.ToString());
                sql += ",@HDMIPort  =" + dao.FilterString(model.HDMIPort == null ? "" : model.HDMIPort.ToString());
                sql += ",@MultiCardSlot  =" + dao.FilterString(model.MultiCardSlot == null ? "" : model.MultiCardSlot.ToString());
                sql += ",@FirePort  =" + dao.FilterString(model.FirePort == null ? "" : model.FirePort.ToString());
                sql += ",@TypeCPort  =" + dao.FilterString(model.TypeCPort == null ? "" : model.TypeCPort.ToString());
                sql += ",@ScreenSize  =" + dao.FilterString(model.ScreenSize == null ? "" : model.ScreenSize.ToString());
                sql += ",@Resolution  =" + dao.FilterString(model.Resolution == null ? "" : model.Resolution.ToString());
                sql += ",@ScreenType  =" + dao.FilterString(model.ScreenType == null ? "" : model.ScreenType.ToString());
                sql += ",@InternalMic  =" + dao.FilterString(model.InternalMic == null ? "" : model.InternalMic.ToString());
                sql += ",@Speakers  =" + dao.FilterString(model.Speakers == null ? "" : model.Speakers.ToString());
                sql += ",@OtherDisplayFeature  =" + dao.FilterString(model.OtherDisplayFeature == null ? "" : model.OtherDisplayFeature.ToString());

                sql += ",@Ethernet  =" + dao.FilterString(model.Ethernet == null ? "" : model.Ethernet.ToString());
                sql += ",@InternetConnectivity  =" + dao.FilterString(model.InternetConnectivity == null ? "" : model.InternetConnectivity.ToString());
                sql += ",@BluetoothSuppoert  =" + dao.FilterString(model.BluetoothSuppoert == null ? "" : model.BluetoothSuppoert.ToString());
                sql += ",@BluetoothVersion  =" + dao.FilterString(model.BluetoothVersion == null ? "" : model.BluetoothVersion.ToString());
                sql += ",@WIFI  =" + dao.FilterString(model.WIFI == null ? "" : model.WIFI.ToString());
                sql += ",@WIFIVersion  =" + dao.FilterString(model.WIFIVersion == null ? "" : model.WIFIVersion.ToString());
                sql += ",@WifiHotspot  =" + dao.FilterString(model.WifiHotspot == null ? "" : model.WifiHotspot.ToString());
                sql += ",@Width  =" + dao.FilterString(model.Width == null ? "" : model.Width.ToString());
                sql += ",@Height  =" + dao.FilterString(model.Height == null ? "" : model.Height.ToString());
                sql += ",@Depth  =" + dao.FilterString(model.Depth == null ? "" : model.Depth.ToString());
                sql += ",@Weight  =" + dao.FilterString(model.Weight == null ? "" : model.Weight.ToString());

                sql += ",@BatteryBackup  =" + dao.FilterString(model.BatteryBackup == null ? "" : model.BatteryBackup.ToString());
                sql += ",@PowerSupply  =" + dao.FilterString(model.PowerSupply == null ? "" : model.PowerSupply.ToString());
                sql += ",@BatteryCell  =" + dao.FilterString(model.BatteryCell == null ? "" : model.BatteryCell.ToString());
                sql += ",@BatteryRemovable  =" + dao.FilterString(model.BatteryRemovable == null ? "" : model.BatteryRemovable.ToString());

                sql += ",@WebCam  =" + dao.FilterString(model.WebCam == null ? "" : model.WebCam.ToString());
                sql += ",@LockPort  =" + dao.FilterString(model.LockPort == null ? "" : model.LockPort.ToString());
                sql += ",@Keyboard  =" + dao.FilterString(model.Keyboard == null ? "" : model.Keyboard.ToString());
                sql += ",@KeyboardLight  =" + dao.FilterString(model.KeyboardLight == null ? "" : model.KeyboardLight.ToString()); 
                sql += ",@PointerDevice  =" + dao.FilterString(model.PointerDevice == null ? "" : model.PointerDevice.ToString()); 
                sql += ",@AdditionalFeatures  =" + dao.FilterString(model.AdditionalFeatures == null ? "" : model.AdditionalFeatures.ToString()); 
                sql += ",@Quantity  =" + dao.FilterString(model.Quantity == null ? "" : model.Quantity.ToString()); 
                
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
                sql += ",@DocFor = " + dao.FilterString("Laptop");
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

        public List<ProductSearchCommon> ShowComputer()
        {
            var list = new List<ProductSearchCommon>();
            var computerList = new List<ComputerCommon>();
            var sql = "Exec proc_tblComputer";
            sql += " @Flag = " + dao.FilterString("ShowComputer");
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
                            OfferedPrice = item["OfferedPrice"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            DiscountAmount = item["DiscountAmount"].ToString(),
                            WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                            //ProductReviewed=item["ProductReviewed"].ToString(),
                            Doc1 = item["Doc1"].ToString(),
                            Doc2 = item["Doc2"].ToString()

                        };
                        computerList.Add(computer);
                    }
                }
            }
            if (null != dt)
            {
                var productSearch = new ProductSearchCommon()
                {
                    ComputerList = computerList

                };
                list.Add(productSearch);
            }
            return list;


        }
        public List<ComputerCommon> GetComputer()
        {
            //var list = new List<ProductSearchCommon>();
            var computerList = new List<ComputerCommon>();
            var sql = "Exec proc_tblComputer";
            sql += " @Flag = " + dao.FilterString("ShowComputer");
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
                            OfferedPrice = item["OfferedPrice"].ToString(),
                            ProductPrice = item["ProductPrice"].ToString(),
                            DiscountPercent = item["DiscountPercent"].ToString(),
                            DiscountAmount = item["DiscountAmount"].ToString(),
                            WarrentyPeriod = item["WarrentyPeriod"].ToString(),
                            //ProductReviewed=item["ProductReviewed"].ToString(),
                            Doc1 = item["Doc1"].ToString(),
                            Doc2 = item["Doc2"].ToString()

                        };
                        computerList.Add(computer);
                    }
                }
            }
            
            return computerList;


        }


    }
}
