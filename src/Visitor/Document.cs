using Visitor.Elements;

namespace Visitor;

public class Document
{
    public string Title { get; set; }
    public List<DocumentElement> Elements { get; set; }

    public Document(string title)
    {
        Title = title;
        Elements = [];
    }

    public void AddElement(DocumentElement element) => Elements.Add(element);

    public List<TResult> Accept<TResult>(IDocumentElementVisitor<TResult> visitor) =>
        Elements.Select(e => e.Accept(visitor)).ToList();
}
