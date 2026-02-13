using Microsoft.AspNetCore.SignalR;
using ProductAPI.DTO;

namespace ProductAPI.Services
{
    public interface IProductService
    {
        List<ProductReadDTO> GetAllProducts();
        ProductReadDTO GetProductById(int id);
        ProductReadDTO AddProduct(ProductCreateDTO productCreateDTO);
        ProductReadDTO UpdateProduct(int id, ProductCreateDTO productCreateDTO);// or ProductReadDTO UpdateProduct(int id, ProductCreateDTO productCreateDTO);(to give true or false)

        bool DeleteProduct(int id);
        
    }
}
