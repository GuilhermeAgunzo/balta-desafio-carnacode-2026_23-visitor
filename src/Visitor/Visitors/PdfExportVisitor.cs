using Visitor.Elements;

namespace Visitor.Visitors;

public class PdfExportVisitor : IDocumentElementVisitor<string>
{
    public string Visit(Paragraph paragraph) =>
        $"PDF_TEXT({paragraph.Text}, {paragraph.FontFamily}, {paragraph.FontSize})";

    public string Visit(Image image) =>
        $"PDF_IMAGE({image.Url}, {image.Width}, {image.Height})";

    public string Visit(Table table) =>
        $"PDF_TABLE({table.Rows}, {table.Columns}, data...)";
}
