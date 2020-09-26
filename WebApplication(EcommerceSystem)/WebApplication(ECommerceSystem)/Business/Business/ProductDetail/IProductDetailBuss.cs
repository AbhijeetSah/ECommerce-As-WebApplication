using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.ProductDetail
{
    public interface IProductDetailBuss
    {
        List<ProductSearchCommon> Search(string SearchData);
        List<string> GetSearchFilterForComputer(string flag);
        List<string> GetSearchFilterForClothes(string flag);
        List<string> GetSearchFilterForGroceries(string flag);
        List<string> GetSearchFilterForGadget(string flag);
        List<ClothesCommon> FilterClothes(string minPrice, string maxPrice, string[] Brand, string[] ProductName, string[] ProductSize, string[] ProductFor, string[] Color);
        List<ComputerCommon> FilterComputer(string minPrice, string maxPrice, string[] Brand, string[] Series, string[] ProcessorBrand, string[] ScreenSize, string[] OpeatingSystem, string[] GraphicProcessorCapacity, string[] HDDCapacity, string[] SuitableFor, string[] GraphicProcessorBrand, string[] TouchScreen, string[] RamType, string[] ProcessorGeneration, string[] RAM, string[] GraphicProcessorGen, string[] SSD, string[] SSDVersiom, string[] SSDCapacity);
        List<GroceriesCommon> FilterGroceries(string minPrice, string maxPrice, string[] Brand, string[] ProductName, string[] QuantityPerVolume);
        List<GadgetCommon> FilterGadget(string minPrice, string maxPrice, string[] Brand, string[] ProductName, string[] BrowseType, string[] SimType, string[] TouchScreen, string[] Color, string[] InternalStorage, string[] OpeatingSystem, string[] ProcessorCore, string[] PrimaryCameraDetail, string[] FrontCameraDetail, string[] DisplaySize, string[] Resolution, string[] BatteryCapacity, string[] BatteryRemovable, string[] NetworkType, string[] InternetConnectivity);


        List<ClothesCommon> GetClothesDetail( string id);
        List<ComputerCommon> GetComputerDetail( string id);
        List<GroceriesCommon> GetGroceriesDetail( string id);
        List<GadgetCommon> GetGadgetDetail( string id);
        ProductRateCommon ProductRating(string ProductReferenceId);
        DbResponse PushComment(string ProductReferenceId,string CommentTo,string NewComment, string User);
        List<CommentCommon> LoadComment(string ProductReferenceId);
        DbResponse RateNow(string ProductReferenceId, string rating, string user);

    }
}
