using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class ProductRepository
{
    private readonly AppDBContext _dBContext;
    public ProductRepository(AppDBContext dBContext)
    {
        _dBContext = dBContext;
    }

    public async Task<bool> CreateProduct(Product product) 
    {
        await _dBContext.Products.AddAsync(product);
        return _dBContext.SaveChanges() > 0;
    }

    public async Task<Product[]> GetAll()
    {
        return await _dBContext.Products.AsNoTracking().ToArrayAsync();
    }

    public async Task<bool> DeleteProduct(Guid productId)
    {
        var pro = await _dBContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

        if (pro == null) { return false; }

        _dBContext.Products.Remove(pro);

        return await _dBContext.SaveChangesAsync() > 0;
    }

    public async Task<bool>UpdateProduct(Product product)
    {

        _dBContext.Products.Update(product);

        return await _dBContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> FindProductbyId(Guid productId)
    {
        var product = await _dBContext.Products.SingleOrDefaultAsync(p => p.Id.Equals(productId));

        return product != null;
    }

    public async Task<Product?> GetProductbyId(Guid productId)
        => await _dBContext.Products.SingleOrDefaultAsync(p => p.Id.Equals(productId));
}
