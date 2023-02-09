using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ColorBox.Controllers;


[ApiController]
[Route("[controller]")]
public class PaletteController : ControllerBase
{
    private string fileName = "colors.json";
    private readonly ILogger<PaletteController> _logger;
    public PaletteController(ILogger<PaletteController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public ContentResult Get()
    {
        try
        {
            var fileText = System.IO.File.ReadAllText(fileName);
            //var colorList = JsonSerializer.Deserialize<FileContents>(fileText);
            return this.Content(fileText, "application/json");
        }
        catch(Exception ex) 
        {
            
            var color1 = new PaletteColor(0, "#111");
            var color2 = new PaletteColor(1, "#444");
            var color3 = new PaletteColor(2, "#888");
            var color4 = new PaletteColor(3, "#AAA");

            var colorList = new List<PaletteColor> {color1, color2, color3, color4};
            var serialized = JsonSerializer.Serialize(colorList);
            return this.Content(serialized, "application/json");
        }

    }
    
    [HttpPost()]
    public List<PaletteColor> Post(List<string> colors)
    {
        var colorList = new List<PaletteColor>();
        var id = 0;
        colors.ForEach(color => colorList.Add(new PaletteColor(id++, color)));
        var jsonString = JsonSerializer.Serialize(colorList);
        System.IO.File.WriteAllText(fileName, jsonString);
        return colorList;
    }
}
