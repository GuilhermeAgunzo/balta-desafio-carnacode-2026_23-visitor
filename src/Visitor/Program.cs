// DESAFIO: Sistema de Relatórios para Estrutura de Documentos
// PROBLEMA: Um sistema de documentos tem diferentes tipos de elementos (Parágrafo, Imagem, Tabela)
// e precisa realizar múltiplas operações (exportar HTML, PDF, contar palavras, validar). O código
// atual adiciona cada operação como método em cada classe, violando Open/Closed Principle

// Contexto: Sistema de documentos onde novos tipos de operações precisam ser
// adicionados frequentemente, mas tipos de elementos são relativamente estáveis

using Visitor;
using Visitor.Elements;
using Visitor.Visitors;

Console.WriteLine("=== Sistema de Documentos (Visitor Pattern) ===\n");

var doc = new Document("Relatório Anual");

doc.AddElement(new Paragraph("Este é o relatório anual da empresa."));
doc.AddElement(new Image("grafico.png", 800, 600));
doc.AddElement(new Paragraph("Abaixo os resultados financeiros do ano:"));
doc.AddElement(new Table(3, 4));
doc.AddElement(new Paragraph("Conclusão do relatório com recomendações."));

Console.WriteLine($"Documento: {doc.Title}");
Console.WriteLine($"Elementos: {doc.Elements.Count}\n");

Console.WriteLine("=== Contagem de Palavras ===");
var wordCountVisitor = new WordCountVisitor();
var wordCounts = doc.Accept(wordCountVisitor);
var totalWords = wordCounts.Sum();
Console.WriteLine($"Total de palavras: {totalWords}");

Console.WriteLine("\n=== Validação ===");
var validationVisitor = new ValidationVisitor();
var validations = doc.Accept(validationVisitor);
var allValid = validations.All(v => v);
Console.WriteLine($"Documento válido: {allValid}");

Console.WriteLine("\n=== Tempo de Leitura ===");
var readingTimeVisitor = new ReadingTimeVisitor();
var readingTimes = doc.Accept(readingTimeVisitor);
Console.WriteLine($"Tempo de leitura estimado: {readingTimes.Sum()} minuto(s)");

Console.WriteLine("\n=== Exportação HTML ===");
var htmlVisitor = new HtmlExportVisitor();
var htmlParts = doc.Accept(htmlVisitor);
var html = $"<html><head><title>{doc.Title}</title></head><body>{string.Join("", htmlParts)}</body></html>";
Console.WriteLine(html[..Math.Min(200, html.Length)] + "...");

Console.WriteLine("\n=== Exportação PDF ===");
var pdfVisitor = new PdfExportVisitor();
var pdfParts = doc.Accept(pdfVisitor);
var pdf = $"PDF_DOCUMENT({doc.Title}) {string.Join(" ", pdfParts)}";
Console.WriteLine(pdf[..Math.Min(150, pdf.Length)] + "...");
