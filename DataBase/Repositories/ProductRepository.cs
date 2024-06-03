using AutoMapper;
using Core.Models;
using DataBase.Repositories.Abstraction;
using DataBase.Repositories.DTOModels;
using Microsoft.Extensions.Caching.Memory;
using Category = DataBase.Repositories.DTOModels.Category;

namespace DataBase.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;

    public ProductRepository(IMapper mapper, IMemoryCache cache)
    {
        _mapper = mapper;
        _cache = cache;
    }

    public int AddCategory(Category group)
    {
        using (var context = new DataContext())
        {
            var entityGroup = context.Categories.FirstOrDefault(x => x.Name.ToLower() == group.Name.ToLower());
            if (entityGroup == null)
            {
                entityGroup = _mapper.Map<Core.Models.Category>(group);
                context.Categories.Add(entityGroup);
                context.SaveChanges();
                _cache.Remove("groups");
            }

            return entityGroup.Id;
        }
    }

    public IEnumerable<Category>? GetCategories()
    {
        if (_cache.TryGetValue("groups", out List<Category>? groups))
        {
            return groups;
        }

        using (var context = new DataContext())
        {
            var groupsList = context.Categories.Select(x => _mapper.Map<Category>(x)).ToList();
            _cache.Set("groups", groupsList, TimeSpan.FromMinutes(30));
            return groupsList;
        }
    }

    public int AddProduct(ProductDTO product)
    {
        using (var context = new DataContext())
        {
            var entityProduct = context.Products.FirstOrDefault(x => x.Name.ToLower() == product.Name.ToLower());
            if (entityProduct == null)
            {
                entityProduct = _mapper.Map<Product>(product);
                context.Products.Add(entityProduct);
                context.SaveChanges();
                _cache.Remove("products");
            }

            return entityProduct.Id;
        }
    }

    public IEnumerable<ProductDTO>? GetProducts()
    {
        if (_cache.TryGetValue("products", out List<ProductDTO>? products))
        {
            return products;
        }

        using (var context = new DataContext())
        {
            var productList = context.Products.Select(x => _mapper.Map<ProductDTO>(x)).ToList();
            _cache.Set("product", productList, TimeSpan.FromMinutes(30));
            return productList;
        }
    }
}