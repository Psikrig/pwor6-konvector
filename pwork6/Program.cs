using pwork6;

while (true)
{
    Console.WriteLine("введите путь");
    string path = Console.ReadLine();
    string ext = Path.GetExtension(path);
    if (ext == ".txt")
    {
        Class1.txt(path, ext);
    }
    if (ext == ".json")
    {
        Class1.json(path, ext);
    }
    if (ext == ".xml")
    {
        Class1.xml(path, ext);
    }
}