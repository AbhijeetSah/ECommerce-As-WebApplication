using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reposatory.Repository.Clothes;
using Shared.Common;

namespace Business.Business.Clothes
{
    public class ClothesBuss : IClothesBuss
    {
        IClothesRepo repo;
        public ClothesBuss(ClothesRepo _repo)
        {
            repo = _repo;
        }
        public List<ClothesCommon> GetGridList(GridParam gridParam)
        {
            return repo.GetGridList(gridParam);
        }
        public List<ClothesCommon> GetList(string User, string id)
        {
            return repo.GetList(User, id);
        }

        public DbResponse Manage(ClothesCommon model)
        {
            return repo.Manage(model);
        }
        public DbResponse RecordDocument(string User, string docExt, string docName, string fulldocname, string ProductReferenceId, string ProductDistinctId, string View, string Color)
        {
            return repo.RecordDocument(User, docExt, docName, fulldocname, ProductReferenceId, ProductDistinctId, View, Color);
        }
        public List<ProductSearchCommon> ShowClothes()
        {
            return repo.ShowClothes();
        }public List<ClothesCommon> GetClothes()
        {
            return repo.GetClothes();
        }public List<ClothesCommon> GetTopClothes()
        {
            return repo.GetTopClothes();
        }



    }
}
