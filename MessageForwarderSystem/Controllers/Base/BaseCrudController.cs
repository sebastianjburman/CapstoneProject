namespace MessageForwarderSystem.Controllers.Base;


[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
//[Authorize]  // uncomment if needed
public abstract class BaseCrudController<TEntity, TController> : ControllerBase
    where TEntity : BaseModel, new()
    where TController : class
{
    protected readonly IDataServiceBase<TEntity> DataServiceBase;
    protected ILogger<TController> Logger;

    protected BaseCrudController(ILogger<TController> logger,IDataServiceBase<TEntity> dataServiceBase)
    {
        DataServiceBase = dataServiceBase;
        Logger = logger;
    }

    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [SwaggerResponse(401, "Unauthorized access attempted")]
    [ApiVersion("1.0")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
    {
        return Ok(await DataServiceBase.GetAllAsync());
    }


    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(204, "No content")]
    [SwaggerResponse(400, "The request was invalid")]
    [SwaggerResponse(401, "Unauthorized access attempted")]
    [ApiVersion("1.0")]
    [HttpGet("{id}")]
    public async Task<ActionResult<TEntity>> GetOne(int id)
    {
        var entity = await DataServiceBase.FindAsync(id);

        if (entity == null)
        {
            return NoContent();
        }

        return Ok(entity);
    }

    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [SwaggerResponse(401, "Unauthorized access attempted")]
    [HttpPut("{id}")]
    [ApiVersion("1.0")]
    public async Task<IActionResult> UpdateOne(int id, [FromBody]TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            await DataServiceBase.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            //This shows an example with the custom exception
            //Should handle more gracefully
            return BadRequest(ex);
        }
        return Ok(entity);
    }

    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(201, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [SwaggerResponse(401, "Unauthorized access attempted")]
    [HttpPost]
    [ApiVersion("1.0")]
    public async Task<ActionResult<TEntity>> AddOne(TEntity entity)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            await DataServiceBase.AddAsync(entity);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

        return CreatedAtAction(nameof(GetOne), new { id = entity.Id }, entity);
    }

    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [SwaggerResponse(401, "Unauthorized access attempted")]
    [HttpDelete("{id}")]
    [ApiVersion("1.0")]
    public async Task<ActionResult<TEntity>> DeleteOne(int id, TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        try
        {
            await DataServiceBase.DeleteAsync(entity);
        }
        catch (Exception ex)
        {
            //Should handle more gracefully
            return new BadRequestObjectResult(ex.GetBaseException()?.Message);
        }
        return Ok();
    }
}