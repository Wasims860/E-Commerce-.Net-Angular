namespace API.Controllers;
public class ProductsController : BaseApiController
{
    private readonly IGeniricRepository<Product> _productRepo;
    private readonly IGeniricRepository<ProductType> _productTypeRepo;
    private readonly IGeniricRepository<ProductBrand> _productBrandRepo;
    private readonly IMapper _mappr;

    public ProductsController(IGeniricRepository<Product> productRepo,
    IGeniricRepository<ProductType> productTypeRepo,
     IGeniricRepository<ProductBrand> productBrandRepo,
     IMapper mappr)
    {
        _productRepo = productRepo;
        _productTypeRepo = productTypeRepo;
        _productBrandRepo = productBrandRepo;
        _mappr = mappr;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
    {
        var spec = new ProductsWithTypesAndBrandSpecification();
        var products = await _productRepo.ListAsync(spec);
        return Ok(_mappr.Map<IReadOnlyList<ProductToReturnDto>>(products));
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
    {
        var spec = new ProductsWithTypesAndBrandSpecification(id);
        var product = await _productRepo.GetEntityWithSpec(spec);
        if (product == null) return NotFound(new ApiResponse(404));
        return _mappr.Map<ProductToReturnDto>(product);
    }
    [HttpGet("Brands")]
    public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
    {
        var productBrands = await _productBrandRepo.ListAllAsync();
        return Ok(productBrands);
    }
    [HttpGet("Types")]
    public async Task<ActionResult<List<ProductType>>> GetProductTypes()
    {
        var productTypes = await _productTypeRepo.ListAllAsync();
        return Ok(productTypes);
    }

}



