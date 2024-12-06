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


leftList.Sort();
rightList.Sort();

var distances = new List<int>();
for (int i = 0; i < leftList.Count; i++)
{
    if (leftList[i] < rightList[i])
    {
        distances.Add(rightList[i] - leftList[i]);
    }
    else
    {
        distances.Add(leftList[i] - rightList[i]);
    }
}

var finalAnswer = distances.Sum();
Console.WriteLine(finalAnswer);