using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Common
{
    public class GadgetCommon:Common 
    {
        public string ProductReferenceId { get; set; } 
        public string ProductDestintId { get; set; } 
        public string Brand { get; set; } 
        public string ProductName { get; set; }

        //general detail

        public string ModelNo { get; set; }
        public string ModelName { get; set; }
        public string InTheBox { get; set; }  
        public string Color { get; set; }         
        public string BrowseType { get; set; }  //smartphone
        public string SimType { get; set; } //dual
        public string SimSize { get; set; } //nano
        public string HybridSimSlot { get; set; }   //yes/No
        public string TouchScreen { get; set; }  //Yes/No
        public string Sensor { get; set; }  //fingerprint scanner
        public string OTGCompatable { get; set; } //Yes/No
        public string QuickCharging { get; set; } //Yes/no
        public string SoundEnhancement { get; set; }  //speaker detail

        //CameraDetail
        public string PrimaryCameraDetail { get; set; }  //backcamera /rear camera
        public string PrimaryCameraFeatures { get; set; }
        public string FrontCameraDetail { get; set; }   //front camera
        public string FrontCameraFeatures { get; set; }
        public string Flash { get; set; }
        public string FrameRate { get; set; }

        

        //OperatingSystem and processor feature
        public string OpeatingSystem { get; set; }
        public string ProcessorType { get; set; }
        public string ProcessorCore { get; set; }
        public string ProcessorClockSpeed { get; set; }
        public string OSFrequency { get; set; }

        //memory and storage
        public string InternalStorage { get; set; }   //rom
        public string RAM { get; set; }
        public string ExpandableStorage { get; set; }
        public string SupprtedMemoryCardType { get; set; }
        public string MemoryCardSlotTypes { get; set; }

        //display features
        public string DisplaySize { get; set; }
        public string Resolution { get; set; }
        public string ResolutionType { get; set; }
        public string GPU { get; set; }
        public string GraphicPPI { get; set; }
        public string OtherDisplayFeature { get; set; }


        //dimension
        public string Width { get; set; }
        public string Height { get; set; }
        public string Depth { get; set; }
        public string Weight { get; set; }


        //Battery And Power
        public string BatteryCapacity { get; set; }
        public string BatteryFeatures { get; set; }
        public string BatteryRemovable { get; set; } //yes/no

        //connectivityFeatures
        public string NetworkType { get; set; } //4G/3G/2G
        public string SupportedNetwork { get; set; } //LTE,GSM, WCDMA
        public string InternetConnectivity { get; set; } //4G,3Gwifi
        public string BluetoothSuppoert { get; set; } //yes/no
        public string BluetoothVersion { get; set; } 
        public string WIFI { get; set; } //yes/no
        public string WIFIVersion { get; set; } 
        public string WifiHotspot { get; set; } //yes/no
        public string USBConnectivity { get; set; } //yes/no
        public string AudioJack { get; set; } 
        public string ChargerType { get; set; } //C type
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
