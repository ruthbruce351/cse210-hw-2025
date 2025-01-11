using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddNewEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        string[] lines = System.IO.File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            {
                Entry anEntry = new Entry();
                anEntry._date = parts[0];
                anEntry._promptText = parts[1];
                anEntry._entryText = parts[2];
                _entries.Add(anEntry);
            }
        }
    }
}