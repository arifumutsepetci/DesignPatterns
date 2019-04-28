using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel=new StandardKernel();
            kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope(); //performans artışı sağlıyor.

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();

            Console.ReadLine();
        }
    }


    interface IProductDal
    {
        void Save();
    }
    class EfProductDal:IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with EF");  //şu an biz bu metota bağımlıyız. böyle yazmamalıyız.
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with NH");  //şu an biz bu metota bağımlıyız. böyle yazmamalıyız.
        }
    }

    class ProductManager //business code. 
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        {
        _productDal.Save();
        }
    }
}
