namespace Nextech.Core.Util;

public static class Parameters
{
    public static int MaxDegreeOfParallelism => 8;
    public static string TopStoriesUrl => "https://hacker-news.firebaseio.com/v0/topstories.json";
    public static string ItemInfoUrl => "https://hacker-news.firebaseio.com/v0/item/{{id}}.json";
    public static string UpdatedItemsUrl => "https://hacker-news.firebaseio.com/v0/updates.json";
}
