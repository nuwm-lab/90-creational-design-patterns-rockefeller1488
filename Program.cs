using System;
using System.Text;

// Клас для зберігання тексту документації
public class Documentation
{
    public StringBuilder Content { get; private set; } = new StringBuilder();

    public void AddText(string text)
    {
        Content.AppendLine(text);
    }

    public override string ToString()
    {
        return Content.ToString();
    }
}

// Інтерфейс для будівельника документації
public interface IDocumentationBuilder
{
    void BuildHeader(string title);
    void BuildSection(string sectionTitle, string sectionContent);
    void BuildNote(string note);
    Documentation GetDocumentation();
}

// Реалізація будівельника документації
public class DocumentationBuilder : IDocumentationBuilder
{
    private Documentation _documentation;

    public DocumentationBuilder()
    {
        _documentation = new Documentation();
    }

    public void BuildHeader(string title)
    {
        _documentation.AddText($"# {title}");
    }

    public void BuildSection(string sectionTitle, string sectionContent)
    {
        _documentation.AddText($"## {sectionTitle}");
        _documentation.AddText(sectionContent);
    }

    public void BuildNote(string note)
    {
        _documentation.AddText($"**Note:** {note}");
    }

    public Documentation GetDocumentation()
    {
        return _documentation;
    }
}

// Клас для управління процесом побудови документації
public class DocumentationDirector
{
    private IDocumentationBuilder _builder;

    public DocumentationDirector(IDocumentationBuilder builder)
    {
        _builder = builder;
    }

    public Documentation BuildDocumentation()
    {
        _builder.BuildHeader("Military Strategy Scenario");
        _builder.BuildSection("Introduction", "This document describes a military strategy scenario.");
        _builder.BuildSection("Units", "Various units are available, including infantry, tanks, and aircraft.");
        _builder.BuildNote("Ensure the scenario is balanced.");
        
        return _builder.GetDocumentation();
    }
}

// Тестування
class Program
{
    static void Main()
    {
        IDocumentationBuilder builder = new DocumentationBuilder();
        DocumentationDirector director = new DocumentationDirector(builder);
        
        Documentation documentation = director.BuildDocumentation();
        
        Console.WriteLine(documentation);
    }
}
