namespace API.Dtos;

    public class ProductToReturnDto:BaseEntity
    {
         public string Name { get; set; } = string.Empty;
        public string Description { get; set; }= string.Empty;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }= string.Empty;
        public  string  ProductType { get; set; }
        public  string  ProductBrand { get; set; }
    }
