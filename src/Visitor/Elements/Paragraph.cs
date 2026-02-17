namespace Visitor.Elements;

public class Paragraph : DocumentElement
{
    public string Text { get; set; }
    public string FontFamily { get; set; }
    public int FontSize { get; set; }

    public Paragraph(string text)
    {
        Text = text;
        FontFamily = "Arial";
        FontSize = 12;
    }

    public override void Render()
    {
        Console.WriteLine($"[Parágrafo] {Text}");
    }

    public override TResult Accept<TResult>(IDocumentElementVisitor<TResult> visitor) => visitor.Visit(this);
}
