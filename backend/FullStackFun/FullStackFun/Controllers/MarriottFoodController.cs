using FullStackFun.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace FullStackFun.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class MarriottFoodController : ControllerBase
    {
        private FoodDbContext _foodContext;
        
        public MarriottFoodController(FoodDbContext temp)
        {
            _foodContext = temp;
        }
        
        [HttpGet(Name = "GetMarriottFood")]
        public IEnumerable<MarriottFood> Get()
        {
            var foodlist = _foodContext.Foods.ToList();
            
            return (foodlist);
        }
    }
}