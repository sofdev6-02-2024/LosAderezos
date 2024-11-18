using AutoMapper;
using Backend.DTOs.WithID;
using Backend.DTOs.WithoutID;
using Backend.Entities;
using Backend.Services.ServiceInterfaces;
using DB;

namespace Backend.Services;

public class StockService : IStockService
{
    private readonly IStockDAO _stockDao;
    private readonly IProductDAO _productDao;
    private readonly ICategoryDAO _categoryDao;
    private readonly IProductCategoriesDAO _productCategoriesDao;
    private readonly ISubsidiaryService _subsidiaryService;
    private readonly IMapper _mapper;

    public StockService(IStockDAO stockDao, IMapper mapper, IProductDAO productDao, ICategoryDAO categoryDao, IProductCategoriesDAO productCategoriesDao, ISubsidiaryService subsidiaryService)
    {
        _stockDao = stockDao;
        _mapper = mapper;
        _productDao = productDao;
        _categoryDao = categoryDao;
        _productCategoriesDao = productCategoriesDao;
        _subsidiaryService = subsidiaryService;
    }

    public async Task<List<StockDTO>> GetStocks()
    {
        return _stockDao.ReadAll().Select(stock =>
        {
            var product = _productDao.Read(stock.ProductId);
            var matches = _productCategoriesDao.GetProductCategoriesByProductId(stock.ProductId);
            List<Category> categories = new List<Category>();
            foreach (ProductCategories match in matches)
            {
                var category = _categoryDao.Read(match.CategoryId);
                if (category != null)
                {
                    categories.Add(category);    
                }
            }
            return _mapper.Map<StockDTO>((stock, product, categories));
        }).ToList();
    }

    public async Task<StockDTO?> GetStockById(Guid stockId)
    {
        var stock = _stockDao.Read(stockId);
        List<Category> categories = new List<Category>();
        var matches = _productCategoriesDao.GetProductCategoriesByProductId(stock.ProductId);
        foreach (ProductCategories match in matches)
        {
            var category = _categoryDao.Read(match.CategoryId);
            if (category != null)
            {
                categories.Add(category);    
            }
        }
        return _mapper.Map<StockDTO>((stock, _productDao.Read(stock.ProductId), categories));
    }

    public async Task<List<StockDTO>> GetStocksBySubsidiaryId(Guid subsidiaryId)
    {
        return _stockDao.ReadAll().Where(s => s.SubsidiaryId == subsidiaryId).Select(s => {
            List<Category> categories = new List<Category>();
            var matches = _productCategoriesDao.GetProductCategoriesByProductId(s.ProductId);
            foreach (ProductCategories match in matches)
            {
                var category = _categoryDao.Read(match.CategoryId);
                if (category != null)
                {
                    categories.Add(category);    
                }
            }
            var product = _productDao.Read(s.ProductId);
            return _mapper.Map<StockDTO>((s, product, categories));
        }).ToList();
    }

    public async Task<List<StockDTO>> GetStocksByProductId(Guid productId)
    {
        
        return _stockDao.ReadAll().Where(s => s.ProductId == productId).Select(s => {
            List<Category> categories = new List<Category>();
            var matches = _productCategoriesDao.GetProductCategoriesByProductId(s.ProductId);
            foreach (ProductCategories match in matches)
            {
                var category = _categoryDao.Read(match.CategoryId);
                if (category != null)
                {
                    categories.Add(category);    
                }
            }
            var product = _productDao.Read(s.ProductId);
            return _mapper.Map<StockDTO>((s, product, categories));
        }).ToList();
    }

    public async Task<StockDTO?> GetStocksBySubsidiaryAndProductId(Guid subsidiaryId, Guid productId)
    {
        var stock = _stockDao.ReadAll().FirstOrDefault(s => s.SubsidiaryId == subsidiaryId && s.ProductId == productId);
        var product = _productDao.Read(productId);
        List<Category> categories = new List<Category>();
        if (stock != null)
        {
            var matches = _productCategoriesDao.GetProductCategoriesByProductId(stock.ProductId);
            foreach (ProductCategories match in matches)
            {
                var category = _categoryDao.Read(match.CategoryId);
                if (category != null)
                {
                    categories.Add(category);    
                }
            }
            return _mapper.Map<StockDTO>((stock, product, categories));
        }

        return null;
    }

    public async Task<List<OtherSubsidiariesProductsDTO>> GetOtherSubsidiariesProducts(Guid companyId, Guid productId)
    {
        var companySubsidiaries = await _subsidiaryService.GetSubsidiariesByCompanyId(companyId);
        List<OtherSubsidiariesProductsDTO> result = new List<OtherSubsidiariesProductsDTO>();
        foreach (SubsidiaryDTO subsidiary in companySubsidiaries)
        {
            var stock = await GetStocksBySubsidiaryAndProductId(subsidiary.SubsidiaryId, productId);
            if (stock != null)
            {
                result.Add(_mapper.Map<OtherSubsidiariesProductsDTO>((subsidiary, stock)));    
            }
            
        }
        return result;
    }

    public async Task<StockDTO> CreateStock(StockWithoutIDDTO stock)
    {
        Guid guid = Guid.NewGuid();
        _stockDao.Create(_mapper.Map<Stock>((stock, guid)));
        var createdStock = _stockDao.Read(guid);
        List<Category> categories = new List<Category>();
        var matches = _productCategoriesDao.GetProductCategoriesByProductId(stock.ProductId);
        foreach (ProductCategories match in matches)
        {
            var category = _categoryDao.Read(match.CategoryId);
            if (category != null)
            {
                categories.Add(category);    
            }
        }

        return _mapper.Map<StockDTO>((createdStock, _productDao.Read(stock.ProductId), categories));
    }

    public async Task<StockDTO> UpdateStock(StockWithoutIDDTO stock, Guid stockId)
    {
        _stockDao.Update(_mapper.Map<Stock>((stock, stockId)));
        var updatedStock = _stockDao.Read(stockId);
        List<Category> categories = new List<Category>();
        var matches = _productCategoriesDao.GetProductCategoriesByProductId(stock.ProductId);
        foreach (ProductCategories match in matches)
        {
            var category = _categoryDao.Read(match.CategoryId);
            if (category != null)
            {
                categories.Add(category);    
            }
        }

        return _mapper.Map<StockDTO>((updatedStock, _productDao.Read(stock.ProductId), categories));
    }
}
