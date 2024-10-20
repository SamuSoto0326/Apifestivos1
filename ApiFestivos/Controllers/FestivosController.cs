[ApiController]
[Route("api/[controller]")]
public class FestivosController : ControllerBase
{
    private readonly IFestivoService _festivoService;

    public FestivosController(IFestivoService festivoService)
    {
        _festivoService = festivoService;
    }

    // GET: api/festivos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FestivoDto>>> GetFestivos()
    {
        var festivos = await _festivoService.GetAllFestivosAsync();
        return Ok(festivos);
    }

    // GET: api/festivos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<FestivoDto>> GetFestivo(int id)
    {
        var festivo = await _festivoService.GetFestivoByIdAsync(id);
        if (festivo == null)
        {
            return NotFound();
        }
        return Ok(festivo);
    }

    // POST: api/festivos
    [HttpPost]
    public async Task<IActionResult> PostFestivo(FestivoDto festivo)
    {
        await _festivoService.AddFestivoAsync(festivo);
        return CreatedAtAction(nameof(GetFestivo), new { id = festivo.Id }, festivo);
    }

    // PUT: api/festivos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFestivo(int id, FestivoDto festivo)
    {
        await _festivoService.UpdateFestivoAsync(id, festivo);
        return NoContent();
    }

    // DELETE: api/festivos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFestivo(int id)
    {
        await _festivoService.DeleteFestivoAsync(id);
        return NoContent();
    }
}

