using Microsoft.AspNetCore.Mvc;

namespace ColorBox.Controllers;

[ApiController]
[Route("[controller]")]
public class PaletteController : ControllerBase
{
    private string fileName = "colors.json";
    private readonly ILogger<PaletteController> _logger;
    private List<PaletteColor> colorList;
    public PaletteController(ILogger<PaletteController> logger)
    {
        _logger = logger;

        var color1 = new PaletteColor(0, "#111");
        var color2 = new PaletteColor(1, "#444");
        var color3 = new PaletteColor(2, "#888");
        var color4 = new PaletteColor(3, "#AAA");

        colorList = new List<PaletteColor> {color1, color2, color3, color4};
    }

    [HttpGet()]
    public List<PaletteColor> Get()
    {
        return colorList;
    }
    
    [HttpPost()]
    public List<PaletteColor> Post(List<string> colors)
    {
        colorList = new List<PaletteColor>();
        var id = 0;
        colors.ForEach(color => colorList.Add(new PaletteColor(id++, color)));
        return colorList;
    }
}
