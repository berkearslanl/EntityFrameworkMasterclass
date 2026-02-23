using EntityFrameworkMasterclass.Context;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkMasterclass.ViewComponents.StatisticsViewComponents
{
    public class _StatisticsWidgetComponentPartial : ViewComponent
    {
        private readonly EfContext _context;

        public _StatisticsWidgetComponentPartial(EfContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            //kategori sayısı
            ViewBag.categoryCount = _context.Categories.Count();

            //aktif kategorilerin sayısı
            ViewBag.activeCategoryCount = _context.Categories.Where(x => x.CategoryStatus == true).Count();

            //en yüksek fiyatlı ürünün fiyatı
            ViewBag.productMaxPrice = _context.Products.Max(x => x.ProductPrice);

            //en yüksek fiyatlı ürünün ismi
            var maxProductName = _context.Products.OrderByDescending(x => x.ProductPrice).FirstOrDefault();
            ViewBag.productMaxPriceName = maxProductName?.ProductName;

            //en düşük fiyatlı ürünün fiyatı
            ViewBag.productMinPrice = _context.Products.Min(x => x.ProductPrice);

            //en düşük fiyatlı ürünün ismi
            var minProductName = _context.Products.OrderBy(x => x.ProductPrice).FirstOrDefault();
            ViewBag.productMinPriceName = minProductName?.ProductName;

            //DİĞER YÖNTEM
            ViewBag.productMaxPriceProductName = _context.Products.Where(x => x.ProductPrice == (_context.Products.Max(x => x.ProductPrice))).Select(y => y.ProductName).FirstOrDefault();

            //toplam ürün stok sayısı
            ViewBag.totalSumProductStock = _context.Products.Sum(x => x.ProductStock);

            //toplam ürün sayısı
            ViewBag.totalProduct = _context.Products.Count();

            //ortalama stok sayısı
            ViewBag.averageProductStock = _context.Products.Average(x => x.ProductStock);

            //ortalama ürün fiyatı
            ViewBag.averageProductPrice = _context.Products.Average(x => x.ProductPrice);

            //fiyatı 1000 tl'den yüksek olan ürün sayısı
            ViewBag.biggerPriceThen1000ProductCount = _context.Products.Where(x => x.ProductPrice > 1000).Count();

            //fiyatı 1000 tl'den küçük olan ürün sayısı
            ViewBag.smallerPriceThen1000ProductCount = _context.Products.Where(x => x.ProductPrice < 1000).Count();

            //id'si 4 olan ürünün adı
            ViewBag.getIdIs4ProductName = _context.Products.Where(x => x.ProductId == 4).Select(y => y.ProductName).FirstOrDefault();

            //id'si 4 olan ürünün fiyatı
            ViewBag.getIdIs4ProductPrice = _context.Products.Where(x => x.ProductId == 4).Select(y => y.ProductPrice).FirstOrDefault();

            //stok sayısı 50 ve 100 arasında olan ürünlerin sayısı
            ViewBag.stockCountBetween50and100Count = _context.Products.Where(x => x.ProductStock > 50 && x.ProductStock < 100).Count();

            //stok sayısı 50 ve 100 arasında olan ürünlerin ortalama fiyatı
            ViewBag.stockCount50and100AvgPrice = _context.Products.Where(x => x.ProductStock > 50 && x.ProductStock < 100).Average(y => y.ProductPrice);

















            return View();
        }
    }
}
