using Visitor.Elements;

namespace Visitor;

public interface IDocumentElementVisitor<out TResult>
{
    TResult Visit(Paragraph paragraph);
    TResult Visit(Image image);
    TResult Visit(Table table);
}
