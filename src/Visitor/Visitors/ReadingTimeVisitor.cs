using Visitor.Elements;

namespace Visitor.Visitors;

public class ReadingTimeVisitor : IDocumentElementVisitor<int>
{
    private const int WordsPerMinute = 200;

    private readonly WordCountVisitor _wordCountVisitor = new();

    public int Visit(Paragraph paragraph) =>
        paragraph.Accept(_wordCountVisitor) / WordsPerMinute;

    public int Visit(Image image) => 0;

    public int Visit(Table table) =>
        table.Accept(_wordCountVisitor) / WordsPerMinute;
}
