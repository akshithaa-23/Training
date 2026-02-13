using ProductAPI.Models;
using ProductAPI.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>
        {
                new Product { ProductId = 1, ProductName = "Watch", ProductPrice = 10.0 },
                new Product{ ProductId = 2, ProductName = "Bell", ProductPrice = 20.0 },
                new Product { ProductId = 3, ProductName = "Remote", ProductPrice = 30.0 }
        };
        public ProductReadDTO AddProduct(ProductCreateDTO productCreateDTO)
        {
            var newProduct = new Product
            {
                ProductId = products.Count > 0 ? products.Max(p => p.ProductId) + 1 : 1,
                ProductName = productCreateDTO.ProductName,
                ProductPrice = productCreateDTO.ProductPrice
            };
            products.Add(newProduct);
            return new ProductReadDTO
            {
                ProductId = newProduct.ProductId,
                ProductName = newProduct.ProductName,
                ProductPrice = newProduct.ProductPrice
            };
        }

        public bool DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return false;
            }
            products.Remove(product);
            return true;
        }

        public List<ProductReadDTO> GetAllProducts()
        {
            return products.Select(p => new ProductReadDTO
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice
            }).ToList();
        }

        public ProductReadDTO GetProductById(int id)
        {
            var product =products.FirstOrDefault(p=> p.ProductId == id);
            if(product== null)
            {
                return null;
            }
            return new ProductReadDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
            };
        }

        public ProductReadDTO UpdateProduct(int id, ProductCreateDTO productCreateDTO)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return null;
            }
            product.ProductName = productCreateDTO.ProductName; 
            product.ProductPrice = productCreateDTO.ProductPrice;
            return new ProductReadDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice
            };
        }

    }
}
