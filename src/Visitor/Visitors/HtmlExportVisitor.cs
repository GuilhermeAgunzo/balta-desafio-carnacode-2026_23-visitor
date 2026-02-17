using Visitor.Elements;

namespace Visitor.Visitors;

public class HtmlExportVisitor : IDocumentElementVisitor<string>
{
    public string Visit(Paragraph paragraph) =>
        $"<p style='font-family:{paragraph.FontFamily};font-size:{paragraph.FontSize}px'>{paragraph.Text}</p>";

    public string Visit(Image image) =>
        $"<img src='{image.Url}' width='{image.Width}' height='{image.Height}' alt='{image.Alt}' />";

    public string Visit(Table table)
    {
        var html = "<table>";
        foreach (var row in table.Cells)
        {
            html += "<tr>";
            foreach (var cell in row)
                html += $"<td>{cell}</td>";
            html += "</tr>";
        }
        html += "</table>";
        return html;
    }
}
