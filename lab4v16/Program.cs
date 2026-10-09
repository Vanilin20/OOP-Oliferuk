using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Document[] docs =
{
    new Document("report.bin", 120),
    new TextDocument("essay.txt", 45, 1200),
    new ImageDocument("photo.png", 2048, "1920x1080")
};

// Поліморфізм (override)
foreach (Document d in docs)
    d.Open();

// Унікальні методи
((TextDocument)docs[1]).EditContent();
((ImageDocument)docs[2]).ResizeImage("800x600");

// new: результат залежить від типу посилання
TextDocument text = new TextDocument("note.txt", 10, 300);
Document viaBase = text;
Console.WriteLine(text.GetDocumentType());    // Текстовий документ
Console.WriteLine(viaBase.GetDocumentType()); // Документ

class Document
{
    private string _fileName;
    private int _fileSize;

    public string FileName { get => _fileName; set => _fileName = value; }
    public int FileSize { get => _fileSize; set => _fileSize = value; }

    public Document(string fileName, int fileSize)
    {
        _fileName = fileName;
        _fileSize = fileSize;
    }

    public virtual void Open() => Console.WriteLine($"Відкриття {FileName} ({FileSize} КБ)");

    public string GetDocumentType() => "Документ";
}

class TextDocument : Document
{
    private int _wordCount;
    public int WordCount { get => _wordCount; set => _wordCount = value; }

    public TextDocument(string fileName, int fileSize, int wordCount) : base(fileName, fileSize)
    {
        _wordCount = wordCount;
    }

    public override void Open()
    {
        base.Open();
        Console.WriteLine($"Текстовий редактор: {WordCount} слів");
    }

    public void EditContent()
    {
        WordCount += 50;
        Console.WriteLine($"Слів після редагування: {WordCount}");
    }

    public new string GetDocumentType() => "Текстовий документ";
}

class ImageDocument : Document
{
    private string _resolution;
    public string Resolution { get => _resolution; set => _resolution = value; }

    public ImageDocument(string fileName, int fileSize, string resolution) : base(fileName, fileSize)
    {
        _resolution = resolution;
    }

    public override void Open() => Console.WriteLine($"Переглядач зображень: {FileName}, {Resolution}");

    public void ResizeImage(string newResolution)
    {
        Resolution = newResolution;
        Console.WriteLine($"Розмір змінено на {Resolution}");
    }
}