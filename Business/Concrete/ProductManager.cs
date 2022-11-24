using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService //business sadece IProductDal ı bilir
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları
            //InMemoryProductDal ınMemoryProductDal= new InMemoryProductDal(); bu olmaz,bir iş sınıfı başka sınıfları newlemez
            return _productDal.GetAll();
        }
    }
}
