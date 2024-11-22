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

    public  List<StockFullInfoDTO> GetStocks()
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
            return _mapper.Map<StockFullInfoDTO>((stock, product, categories));
        }).ToList();
    }

    public StockFullInfoDTO? GetStockById(Guid stockId)
    {
        var stock = _stockDao.Read(stockId);
        List<Category> categories = new List<Category>();
        if (stock == null)
        {
            return null;
        }
        var matches = _productCategoriesDao.GetProductCategoriesByProductId(stock.ProductId);
        foreach (ProductCategories match in matches)
        {
            var category = _categoryDao.Read(match.CategoryId);
            if (category != null)
            {
                categories.Add(category);    
            }
        }
        return _mapper.Map<StockFullInfoDTO>((stock, _productDao.Read(stock.ProductId), categories));
    }

    public List<StockFullInfoDTO> GetStocksBySubsidiaryId(Guid subsidiaryId)
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
            return _mapper.Map<StockFullInfoDTO>((s, product, categories));
        }).ToList();
    }

    public List<StockFullInfoDTO> GetStocksByProductId(Guid productId)
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
            return _mapper.Map<StockFullInfoDTO>((s, product, categories));
        }).ToList();
    }

    public StockFullInfoDTO? GetStocksBySubsidiaryAndProductId(Guid subsidiaryId, Guid productId)
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
            return _mapper.Map<StockFullInfoDTO>((stock, product, categories));
        }

        return null;
    }

    public List<OtherSubsidiariesProductsDTO> GetOtherSubsidiariesProducts(Guid companyId, Guid productId)
    {
        var companySubsidiaries = _subsidiaryService.GetSubsidiariesByCompanyId(companyId);
        List<OtherSubsidiariesProductsDTO> result = new List<OtherSubsidiariesProductsDTO>();
        foreach (SubsidiaryDTO subsidiary in companySubsidiaries)
        {
            var stock = GetStocksBySubsidiaryAndProductId(subsidiary.SubsidiaryId, productId);
            if (stock != null && stock.Quantity > 0)
            {
                result.Add(_mapper.Map<OtherSubsidiariesProductsDTO>((subsidiary, stock)));    
            }
            
        }
        return result;
    }

    public StockFullInfoDTO CreateStock(StockWithoutIDDTO stock)
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

        return _mapper.Map<StockFullInfoDTO>((createdStock, _productDao.Read(stock.ProductId), categories));
    }

    public StockFullInfoDTO UpdateStock(StockWithoutIDDTO stock, Guid stockId)
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

        return _mapper.Map<StockFullInfoDTO>((updatedStock, _productDao.Read(stock.ProductId), categories));
    }
    
    public List<StockFullInfoDTO> UpdateStocks(List<StockDTO> stocks)
    {
        var updatedStocks = new List<StockFullInfoDTO>();
        foreach (var stock in stocks)
        {
            var updatedStockEntity = _mapper.Map<Stock>(stock);
            _stockDao.Update(updatedStockEntity);

            var updatedStock = _stockDao.Read(stock.StockId);
            if (updatedStock != null)
            {
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
                var stockDto = _mapper.Map<StockFullInfoDTO>((updatedStock, _productDao.Read(stock.ProductId), categories));
                updatedStocks.Add(stockDto);
            }
        }
        return updatedStocks;
    }
    
    public StockFullInfoDTO? GetStocksBySubsidiaryAndProductCode(Guid subsidiaryId, string productCode)
    {
        var product = _productDao.ReadAll().FirstOrDefault(p => p.Code == productCode);
        if (product == null)
        {
            return null; 
        }
        var stock = _stockDao.ReadAll().FirstOrDefault(s => s.SubsidiaryId == subsidiaryId && s.ProductId == product.ProductId);
        if (stock == null)
        {
            return null;
        }
        List<Category> categories = new List<Category>();
        var matches = _productCategoriesDao.GetProductCategoriesByProductId(product.ProductId);
        foreach (ProductCategories match in matches)
        {
            var category = _categoryDao.Read(match.CategoryId);
            if (category != null)
            {
                categories.Add(category);
            }
        }
        return _mapper.Map<StockFullInfoDTO>((stock, product, categories));
    }
    
}
