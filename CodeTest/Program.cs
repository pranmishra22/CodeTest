using System.Text;

bool continueRunning = true;
while (continueRunning)
{
    Console.WriteLine("Enter text:");
    string text = Console.ReadLine() ?? "";
    Console.WriteLine("Enter sub text:");
    string subtext = Console.ReadLine() ?? "";
    if (!String.IsNullOrEmpty(text) && !String.IsNullOrEmpty(subtext))
        Console.WriteLine("Matching positions are: " + TextMatching(text.ToLower(), subtext.ToLower()));
    else
        Console.WriteLine("Missing text or subtext!");

    Console.WriteLine("Do you wish to continue? (Y/N)");
    string continueInput = Console.ReadLine() ?? "";
    if (String.IsNullOrEmpty(continueInput) || (!String.IsNullOrEmpty(continueInput) && continueInput.ToLower() != "y"))
        continueRunning = false;
}

StringBuilder TextMatching(string text, string subtext)
{
    //1st letter should be in between 0-(text length - sub text length)
    int lastCheckIndex = text.Length - subtext.Length;
    StringBuilder sb = new();

    for (int i = 0; i <= lastCheckIndex; i++)
    {
        for (int j = 0; j < subtext.Length; j++)
        {
            bool check = text[i + j] == subtext[j];
            if (check && j + 1 == subtext.Length)
            { sb.Append(i + 1 + " "); i += j; break; }
            if (check)
                continue;
            else
                break;
        }
    }
    return sb;
}