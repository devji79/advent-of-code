var lines = File.ReadAllLines("input.txt");

var messageLength = lines[0].Length;
var bitCount = new int[messageLength, 2];

foreach(var line in lines)
{
    for(var i = 0; i < line.Length; i++)
    {
        if(line[i] == '0')
        {
            bitCount[i, 0]++;
        } else
        {
            bitCount[i, 1]++;
        }
    }
}

var gammeRateString = string.Empty;
var epsilonRateString = string.Empty;

for(var i = 0; i < messageLength; i++)
{
    if(bitCount[i, 0] > bitCount[i, 1])
    {
        gammeRateString += "0";
        epsilonRateString += "1";
    } else if(bitCount[i, 0] < bitCount[i, 1])
    {
        gammeRateString += "1";
        epsilonRateString += "0";
    }
}

Console.WriteLine($"gamma binary: {gammeRateString}; epsilon binary: {epsilonRateString}");
var gammaRate = Convert.ToInt32(gammeRateString, 2);
var epsilonRate = Convert.ToInt32(epsilonRateString, 2);
Console.WriteLine($"gamma rate: {gammaRate}; epsilon rate: {epsilonRate}");
Console.WriteLine($"power consumption: {gammaRate * epsilonRate}");


var oxygenGeneratorRatings = lines;
while (oxygenGeneratorRatings.Length > 1)
{
    for(var i = 0; i < messageLength; i++)
    {
        if(bitCount[i, 0] > bitCount[i, 1])
        {
            oxygenGeneratorRatings = oxygenGeneratorRatings.Where(ogr => ogr[i] == '0').ToArray();
        }
        else
        {
            oxygenGeneratorRatings = oxygenGeneratorRatings.Where(ogr => ogr[i] == '1').ToArray();
        }

        if(oxygenGeneratorRatings.Length == 1)
        {
            break;
        }
    }
}


var co2ScrubberRatings = lines;
while (co2ScrubberRatings.Length > 1)
{
    for (var i = 0; i < messageLength; i++)
    {
        if (bitCount[i, 1] < bitCount[i, 0])
        {
            co2ScrubberRatings = co2ScrubberRatings.Where(co2sr => co2sr[i] == '1').ToArray();
        }
        else
        {
            co2ScrubberRatings = co2ScrubberRatings.Where(co2sr => co2sr[i] == '0').ToArray();
        }

        if (co2ScrubberRatings.Length == 1)
        {
            break;
        }
    }
}

Console.WriteLine($"oxygen generator binary: {oxygenGeneratorRatings.First()}; co2 scrubber binary: {co2ScrubberRatings.First()}");
var oxygenGeneratorRating = Convert.ToInt32(oxygenGeneratorRatings.First(), 2);
var co2ScrubberRating = Convert.ToInt32(co2ScrubberRatings.First(), 2);
Console.WriteLine($"oxygen generator rating: {oxygenGeneratorRating}; co2 scrubber rating: {co2ScrubberRating}");
Console.WriteLine($"life support rating: {oxygenGeneratorRating * co2ScrubberRating}");


int Day3_2(string[] lines)
{
    var oxyFil = Filter(lines, true)[0];
    Console.WriteLine("oxyBin: " + oxyFil);
    var oxy = Convert.ToInt32(Filter(lines, true)[0], 2);
    Console.WriteLine("oxy:" + oxy);
    var co2Fil = Filter(lines, false)[0];
    Console.WriteLine("co2Fil: " + co2Fil);
    var co2 = Convert.ToInt32(co2Fil, 2);
    Console.WriteLine("co2:" + co2);

    Console.WriteLine("ls:" + (oxy*co2));
    return oxy * co2;
}

string[] FilterPos(string[] lines, int pos, bool most)
{
    var counter = lines.Count(x => x[pos] == '1');

    var half = (int)Math.Ceiling(lines.Length / 2f);
    var keep = ((most && counter >= half) || (!most && counter < half)) ? '1' : '0';

    return lines.Where(x => x[pos] == keep).ToArray();
}

string[] Filter(string[] lines, bool most)
{
    for (var pos = 0; ; pos++)
    {
        lines = FilterPos(lines, pos, most);
        if (lines.Length == 1)
        {
            return lines;
        }
    }
}

Day3_2(lines);