using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var pairs = new List<string>();

        foreach (var word in words)
        {
            string reverse = $"{word[1]}{word[0]}";

            if (word != reverse && wordSet.Contains(reverse))
            {
                pairs.Add($"{word} & {reverse}");
            }
        }

        // Each pair was found twice, so remove duplicates.
        var uniquePairs = new HashSet<string>();

        foreach (var pair in pairs)
        {
            var parts = pair.Split(" & ");
            string reversePair = $"{parts[1]} & {parts[0]}";

            if (!uniquePairs.Contains(reversePair))
            {
                uniquePairs.Add(pair);
            }
        }

        return uniquePairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
        {
            return false;
        }

        var letters = new Dictionary<char, int>();

        foreach (char letter in word1)
        {
            if (letters.ContainsKey(letter))
            {
                letters[letter]++;
            }
            else
            {
                letters[letter] = 1;
            }
        }

        foreach (char letter in word2)
        {
            if (!letters.ContainsKey(letter))
            {
                return false;
            }

            letters[letter]--;

            if (letters[letter] < 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Read earthquake JSON data from USGS and return earthquake
    /// locations and magnitudes.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var earthquakes = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            earthquakes.Add(
                $"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
        }

        return earthquakes.ToArray();
    }
}