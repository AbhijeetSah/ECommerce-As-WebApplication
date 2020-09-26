using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common
{
    public class ComputerCommon:Common
    {
        public string ProductReferenceId { get; set; }
        public string ProductDestintId { get; set; }
        public string Brand { get; set; }
        public string ProductName { get; set; }

        //general detail

        public string ModelNo { get; set; }
        public string PartNumbers { get; set; }
        public string InTheBox { get; set; }
        public string Series { get; set; }     
        public string Color { get; set; }
        public string SuitableFor { get; set; }
        public string TouchScreen { get; set; } 
        public string Sensor { get; set; }   
        public string SoundEnhancement { get; set; }  

        //processor feature
        public string ProcessorBrand { get; set; }
        public string ProcessorName { get; set; }
        public string ProcessorGeneration { get; set; }
        public string ProcessorVariant { get; set; }
        public string ProcessorCore { get; set; }
        public string ProcessorClockSpeed { get; set; }

        //memory and storage
        public string HDDCapacity { get; set; }   
        public string SSD { get; set; }   
        public string SSDVersiom { get; set; }   
        public string SSDCapacity { get; set; }   
        public string RAM { get; set; }
        public string RAMType { get; set; }
        public string RAMFrequency { get; set; }
        public string Cache { get; set; }
        public string RPM { get; set; }
        public string GraphicProcessor { get; set; }
        public string GraphicProcessorBrand { get; set; }
        public string GraphicProcessorCapacity { get; set; }
        public string GraphicProcessorGen { get; set; }       
        public string OpeatingSystem { get; set; }


        //port and slot features
        public string MicIn { get; set; }
        public string RJ45 { get; set; }
        public string USBPort { get; set; }
        public string HDMIPort { get; set; }        
        public string MultiCardSlot { get; set; }
        public string FirePort { get; set; }
        public string TypeCPort { get; set; }

        //display features
        public string ScreenSize { get; set; }
        public string Resolution { get; set; }
        public string ScreenType { get; set; }
        public string InternalMic { get; set; }
        public string Speakers { get; set; }
        public string OtherDisplayFeature { get; set; }



        //connectivityFeatures
        public string Ethernet { get; set; }        
        public string InternetConnectivity { get; set; } 
        public string BluetoothSuppoert { get; set; } 
        public string BluetoothVersion { get; set; }
        public string WIFI { get; set; } 
        public string WIFIVersion { get; set; }
        public string WifiHotspot { get; set; } 

       
        public string Width { get; set; }
        public string Height { get; set; }
        public string Depth { get; set; }
        public string Weight { get; set; }

        //Battery And Power
        public string BatteryBackup { get; set; }
        public string PowerSupply { get; set; }
        public string BatteryCell { get; set; }
        public string BatteryRemovable { get; set; } 

        //CameraDetail
        public string WebCam { get; set; }  
        public string LockPort { get; set; }
        public string Keyboard { get; set; }   
        public string KeyboardLight { get; set; }
        public string PointerDevice { get; set; }
        public string AdditionalFeatures { get; set; }

        public string Quantity { get; set; }
        public string ProductDescription { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierContactNo { get; set; }
        public string ProductPrice { get; set; }
        public string OfferedPrice { get; set; }
        public string DiscountPercent { get; set; }
        public string DiscountAmount { get; set; }
        public string Warrenty { get; set; }
        public string WarrentyCondition { get; set; }
        public string WarrentyPeriod { get; set; }
        public string ReplacementPeriod { get; set; }
        public string Highlights { get; set; }
        public string TermsAndConditions { get; set; }
        public string QuickLinksSEOTag { get; set; }
        public string ProductReviewed { get; set; }
        public string Doc1 { get; set; }
        public string Doc2 { get; set; }
        public List<DocumentUpload> Doc { get; set; }

    }
    


}
