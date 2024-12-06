using System.Text.RegularExpressions;

string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\list.txt");
string content = File.ReadAllText(path);
var matches = Regex.Matches(content, @"\b\d{5}\b");

var leftList = new List<int>();
var rightList = new List<int>();

for (int i = 0; i < matches.Count; i++)
{
    var matchValue = Convert.ToInt32(matches[i].ToString());

    if (i % 2 == 0)
    {
        leftList.Add(matchValue);
    }
    else
    {
        rightList.Add(matchValue);
    }
}

var similarityScore = 0;
foreach (var left in leftList)
{
    var filteredRightList = rightList.Where(x => x == left).ToList();
    if (filteredRightList.Count > 0)
    {
        similarityScore += left * filteredRightList.Count;
    }
}

Console.WriteLine(similarityScore);