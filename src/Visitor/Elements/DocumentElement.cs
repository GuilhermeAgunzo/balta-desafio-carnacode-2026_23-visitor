namespace Visitor.Elements;

public abstract class DocumentElement
{
    public abstract void Render();
    public abstract TResult Accept<TResult>(IDocumentElementVisitor<TResult> visitor);
}
