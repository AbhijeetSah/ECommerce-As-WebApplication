using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Common;


namespace Reposatory.Repository.Clothes
{
    public interface IClothesRepo
    {
        List<ClothesCommon> GetGridList(GridParam gridParam);
        List<ClothesCommon> GetList(string User, string id);

        DbResponse Manage(ClothesCommon model);
        DbResponse RecordDocument(string User, string docExt, string docName, string fulldocname, string ProductReferenceId, string ProductDistinctId, string View, string Color);

        List<ProductSearchCommon> ShowClothes();
        List<ClothesCommon> GetClothes();
        List<ClothesCommon> GetTopClothes();

    }
}
