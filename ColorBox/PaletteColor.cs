namespace ColorBox;

public class PaletteColor
{
    public int Id { get; set; }
    public string? HexCode { get; set; }

    public PaletteColor (int _id, string _hexCode)
    {
        Id = _id;
        HexCode = _hexCode;
    }
}
