using AutoMapper;
using DataBase.Repositories.DTOModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Seminar3Application.Abstractions;
using AppDbContext = DataBase.DataContext;
using ProductDto = DataBase.Repositories.DTOModels.ProductDTO;
using ProductEntity = Core.Models.Product;

namespace Seminar3Application.Services; 

public class StorageFilling: IStorageFilling {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;

    public StorageFilling(AppDbContext context, IMapper mapper, IMemoryCache cache) {
        _context = context;
        _mapper = mapper;
        _cache = cache;
    }
    public IEnumerable<ProductDTO> GetProducts(int storeId) {
        using (_context) {
            if (_cache.TryGetValue("products", out List<ProductDto> products))
                return products;

            products = _context.Products
                .Where(p => p.Storages.Any(s => s.Id == storeId))
                .Select(x => _mapper.Map<ProductDTO>(x))
                .ToList();
            _cache.Set("products", products, TimeSpan.FromMinutes(30));

            return products;
        }
    }
}