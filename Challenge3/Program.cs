string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\reports.txt");
string content = File.ReadAllText(path);
var reportsList = content.Split("\r\n");
var numberOfSafeReports = 0;

foreach (var report in reportsList)
{
    var splitReport = report.Split(" ").Select(x => Convert.ToInt32(x)).ToList();

    var ascendingReport = splitReport.Select(x => x).OrderBy(x => x).ToList();
    var descendingReport = splitReport.Select(x => x).OrderByDescending(x => x).ToList();
    
    if (!descendingReport.SequenceEqual(splitReport) && !ascendingReport.SequenceEqual(splitReport))
    {
        continue;
    }

    for (int i = 0; i < splitReport.Count; i++)
    {
        // last element, we're done
        if (i == splitReport.Count - 1)
        {
            numberOfSafeReports++;
            continue;
        }

        var firstReport = splitReport[i];
        var secondReport = splitReport[i+1];

        if (firstReport == secondReport)
        {
            break;
        }

        var difference = 0;
        
        if (firstReport > secondReport)
        {
            difference = firstReport - secondReport;
        }
        else
        {
            difference = secondReport - firstReport;
        }

        // too much of a difference, unsafe!
        if (difference > 3)
        {
            break;
        }
    }
}

Console.WriteLine(numberOfSafeReports);