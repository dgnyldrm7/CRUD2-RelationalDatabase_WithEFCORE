using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace crud_productList.Models
{
    public class Repository
    {
        public static int Idcound = 0;

        //private liste oluşturduk
        private static readonly List<Product> _repositoryList = new();

        /*
        static Repository()
        {
            _repositoryList.Add(new Product { Id = 1, Description = "Iphone 11" , inputGroupFile02 = "1.jpg" , IsActive = true , Price = 50000 } );
            _repositoryList.Add(new Product { Id = 2, Description = "Iphone 11" , inputGroupFile02 = "2.jpg" , IsActive = true , Price = 60000 } );
            _repositoryList.Add(new Product { Id = 3, Description = "Iphone 11" , inputGroupFile02 = "3.jpg" , IsActive = true , Price = 78000 } );
            _repositoryList.Add(new Product { Id = 4, Description = "Mac" , inputGroupFile02 = "2.jpg" , IsActive = true , Price = 88000 } );
            _repositoryList.Add(new Product { Id = 6, Description = "Mac" , inputGroupFile02 = "1.jpg" , IsActive = true , Price = 88000 } );
            _repositoryList.Add(new Product { Id = 7, Description = "Mac" , inputGroupFile02 = "3.jpg" , IsActive = true , Price = 88000 } );
            _repositoryList.Add(new Product { Id = 8, Description = "Mac" , inputGroupFile02 = "1.jpg" , IsActive = true , Price = 88000 } );
        }
        */


        //listeyi get ile return yapıcaz.
        public static List<Product> Products
        {
            get 
            { return _repositoryList; 
            } 
        }

        //listeye product ekleme.
        public static void AddProduct(Product product)
        {
            product.Id = Idcound + 1;
            Idcound++;
            _repositoryList.Add(product);
        }

    }
}
