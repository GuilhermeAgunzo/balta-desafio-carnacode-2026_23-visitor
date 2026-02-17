using Visitor.Elements;

namespace Visitor.Visitors;

public class WordCountVisitor : IDocumentElementVisitor<int>
{
    public int Visit(Paragraph paragraph) =>
        paragraph.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

    public int Visit(Image image) => 0;

    public int Visit(Table table)
    {
        int total = 0;
        foreach (var row in table.Cells)
            foreach (var cell in row)
                total += cell.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        return total;
    }
}
