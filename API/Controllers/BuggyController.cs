
namespace API.Controllers;
public class BuggyController : BaseApiController
{
    private readonly StoreContext _storeContext;
    public BuggyController(StoreContext context)
    {
        _storeContext = context;
    }
    [HttpGet("NotFound")]
    public ActionResult GetNotFoundRequest()
    {
        var thing = _storeContext.Products.Find(444);

        return thing is null ? NotFound(new ApiResponse(404)) : Ok();
    }
    //500 error
    [HttpGet("servererror")]
    public ActionResult GetServerError()
    {
        var thing = _storeContext.Products.Find(444);

        var thingToReturn = thing.ToString();
        return Ok();
    }

    [HttpGet("badrequest")]
    public ActionResult GetBadRequest()
    {
        return BadRequest(new ApiResponse(400));
    }
    [HttpGet("badrequest/{id}")]
    public ActionResult GetNotFoundRequest(int id)
    {
        return Ok();
    }

}
