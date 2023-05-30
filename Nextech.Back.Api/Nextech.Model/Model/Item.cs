namespace Nextech.Core.Model;

public class Item
{
    public int id { get; set; } //The item's unique id.

    public bool deleted { get; set; }   //true if the item is deleted.

    public string type { get; set; } // The type of item.One of "job", "story", "comment", "poll", or "pollopt".

    public string by { get; set; } // The username of the item's author.

    public int time { get; set; } // Creation date of the item, in Unix Time.

    public string text { get; set; }    // The comment, story or poll text. HTML.

    public bool dead { get; set; }    // true if the item is dead.

    public string parent { get; set; } // The comment's parent: either another comment or the relevant story.

    public string poll { get; set; } // The pollopt's associated poll.

    public int[] kids { get; set; } // The ids of the item's comments, in ranked display order.

    public string url { get; set; } // The URL of the story.

    public int score { get; set; } // The story's score, or the votes for a pollopt.

    public string title { get; set; } // The title of the story, poll or job.HTML.

    public int[] parts { get; set; } // A list of related pollopts, in display order.

    public string descendants { get; set; } // In the case of stories or polls, the total comment count.

    public DateTime NewsDate
    {
        get
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dateTime.AddSeconds(time).ToLocalTime();
        }
    }
}
