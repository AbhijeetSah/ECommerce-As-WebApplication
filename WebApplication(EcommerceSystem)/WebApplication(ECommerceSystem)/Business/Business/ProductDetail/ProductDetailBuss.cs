using Reposatory.Repository.ProductDetail;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business.ProductDetail
{
    public class ProductDetailBuss :IProductDetailBuss
    {
        IProductDetailRepo repo;
        public ProductDetailBuss(ProductDetailRepo _repo)
        {
            repo = _repo;
        }
        public List<ProductSearchCommon> Search(string SearchData)
        {
            return repo.Search(SearchData);
        }
        public List<string> GetSearchFilterForComputer(string flag)
        {
            return repo.GetSearchFilterForComputer(flag);
        }
        public List<string> GetSearchFilterForClothes(string flag)
        {
            return repo.GetSearchFilterForClothes(flag);
        }public List<string> GetSearchFilterForGroceries(string flag)
        {
            return repo.GetSearchFilterForGroceries(flag);
        }public List<string> GetSearchFilterForGadget(string flag)
        {
            return repo.GetSearchFilterForGadget(flag);
        }
        public List<ClothesCommon> FilterClothes(string minPrice, string maxPrice, string[] Brand, string[] ProductName, string[] ProductSize, string[] ProductFor, string[] Color)
        {
            return repo.FilterClothes(minPrice, maxPrice, Brand, ProductName, ProductSize, ProductFor, Color);
        }
        public List<ComputerCommon> FilterComputer(string minPrice, string maxPrice, string[] Brand, string[] Series, string[] ProcessorBrand, string[] ScreenSize, string[] OpeatingSystem, string[] GraphicProcessorCapacity, string[] HDDCapacity, string[] SuitableFor, string[] GraphicProcessorBrand, string[] TouchScreen, string[] RamType, string[] ProcessorGeneration, string[] RAM, string[] GraphicProcessorGen, string[] SSD, string[] SSDVersiom, string[] SSDCapacity)
        {
            return repo.FilterComputer(minPrice, maxPrice, Brand, Series, ProcessorBrand, ScreenSize, OpeatingSystem, GraphicProcessorCapacity, HDDCapacity, SuitableFor, GraphicProcessorBrand, TouchScreen, RamType, ProcessorGeneration, RAM, GraphicProcessorGen, SSD, SSDVersiom, SSDCapacity);
        }
        public List<GroceriesCommon> FilterGroceries(string minPrice, string maxPrice, string[] Brand, string[] ProductName, string[] QuantityPerVolume)
        {
            return repo.FilterGroceries(minPrice, maxPrice, Brand, ProductName, QuantityPerVolume);
        }
        public List<GadgetCommon> FilterGadget(string minPrice, string maxPrice, string[] Brand, string[] ProductName, string[] BrowseType, string[] SimType, string[] TouchScreen, string[] Color, string[] InternalStorage, string[] OpeatingSystem, string[] ProcessorCore, string[] PrimaryCameraDetail, string[] FrontCameraDetail, string[] DisplaySize, string[] Resolution, string[] BatteryCapacity, string[] BatteryRemovable, string[] NetworkType, string[] InternetConnectivity)
        {
            return repo.FilterGadget(minPrice, maxPrice, Brand, ProductName, BrowseType, SimType, TouchScreen, Color, InternalStorage, OpeatingSystem, ProcessorCore, PrimaryCameraDetail, FrontCameraDetail, DisplaySize, Resolution, BatteryCapacity, BatteryRemovable, NetworkType, InternetConnectivity);
        }

        public List<ClothesCommon> GetClothesDetail(string ProductReferenceId)
        {
            return repo.GetClothesDetail(ProductReferenceId);
        }
        public List<ComputerCommon> GetComputerDetail(string ProductReferenceId)
        {
            return repo.GetComputerDetail(ProductReferenceId);
        }

        public List<GroceriesCommon> GetGroceriesDetail(string ProductReferenceId)
        {
            return repo.GetGroceriesDetail(ProductReferenceId);
        }
        public List<GadgetCommon> GetGadgetDetail(string ProductReferenceId)
        {
            return repo.GetGadgetDetail(ProductReferenceId);
        }

        public ProductRateCommon ProductRating(string ProductReferenceId)
        {
            return repo.ProductRating(ProductReferenceId);
        }

        public DbResponse PushComment(string ProductReferenceId, string CommentTo, string CommentMessage, string User )
        {
            return repo.PushComment(ProductReferenceId, CommentTo, CommentMessage, User);
        }
        public List<CommentCommon> LoadComment(string ProductReferenceId)
        {
            return repo.LoadComment(ProductReferenceId);
        }

        public DbResponse RateNow(string ProductReferenceId, string rating, string user)
        {
            return repo.RateNow(ProductReferenceId, rating, user);
        }


    }
}
