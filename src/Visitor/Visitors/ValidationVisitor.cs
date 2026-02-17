using Visitor.Elements;

namespace Visitor.Visitors;

public class ValidationVisitor : IDocumentElementVisitor<bool>
{
    public bool Visit(Paragraph paragraph) =>
        !string.IsNullOrEmpty(paragraph.Text) && paragraph.Text.Length < 1000;

    public bool Visit(Image image) =>
        !string.IsNullOrEmpty(image.Url) && image.Width > 0 && image.Height > 0;

    public bool Visit(Table table) =>
        table.Rows > 0 && table.Columns > 0 && table.Cells.Count == table.Rows;
}
