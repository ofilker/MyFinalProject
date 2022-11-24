using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;//ürün listesi oluşturduk boş bir şekilde,tüm metotların dışında tanımladık(Global Değişken)
        //bu global değişkenler alt çizgi ile gösterilirler
        public InMemoryProductDal() //Bellekte referans aldığı zaman çalışacak olan bloktur bu(ctor)
        {
            _products = new List<Product>() {
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
            new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
            new Product{ProductId=5,CategoryId=2,ProductName="Bardak",UnitPrice=85,UnitsInStock=1}
            };//Product{} içinde ctrl+space yaparsan sana alanları getirir. Sanki bu bize bir veritabanından geliyormuş gibi oldu
        }
        public void Add(Product product)
        {
            _products.Add(product);//Add listenin bir fonksiyonu zaten. _products bir listeydi. 
        }

        public void Delete(Product product) //Remove(product) ile çalışmaz,Bu yeni bir adresi silmeye çalışır ve olmaz. String olsa silerdi,
            //Referans tip böyle silinmez,geri dönüp aynı Id ye sahip adresi bulup silmemiz gerekir
        {
            Product productToDelete = null;
            productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
            //SingleOrDefault:_products ı tek tek dolaşıp tek bir eleman bulmaya yarar,Lambda işareti(=>)
            //p burada tek tek dolaşırken verdiğiniz takma isim
            //_products.SingleOrDefault(P=>)  :  Bu kısım foreach kısmıdır
            //p.ProductId==product.ProductId  :  Bu kısım da if şartıdır
            //Eşit ise productToDelete  e eşitlemiş oluruz
            //Burada FirstOrDefault da olur,First de kullansak olurdu. 


            //Uzun yol
            //Product productToDelete = null; //burada newleyip refnum atamaya gerek yok,zaten p nin refnumunu alıcaz biz. 
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId) 
            //    {
            //        productToDelete= p;
            //    }
            //}
            //_products.Remove(productToDelete); Yukarıda linq ile yaptık(language integrated query,dile gömülü sorgulama
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
            // where içindeki koşulu sağlayan tüm elemanları bulur,yeni bir liste haline getirir ve onu döndürür
            //sqlde de where o şartı sağlayanları tablo yapıyprdu ya,aynısı
            //p her bir ürün demek,sağdaki de koşulu,o koşulu sağlıyorsan hoop listeye ekleniyorsun
        }

        public void Update(Product product) // product ekrandan gelen datadır
        {
            Product productToUpdate = null;
            productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.CategoryId=product.CategoryId;
            productToUpdate.UnitPrice=product.UnitPrice;
            productToUpdate.UnitsInStock=product.UnitsInStock;
        }
    }
}
