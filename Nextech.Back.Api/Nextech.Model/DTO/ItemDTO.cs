
using Nextech.Core.DTO.Enums;

namespace Nextech.Core.DTO;

public class ItemDTO
{
    public int ID { get; set; }
    public string Title { get; set; }
    public eItemType Type { get; set; }
    public DateTime Date { get; set; }
    public string Text { get; set; }
    public string Url { get; set; }
    public string By { get; set; }


    public bool IsDeleted { get; set; } 
    
    public bool IsDead { get; set; } 

    public string Parent { get; set; }

    public string Poll { get; set; } 

    public int[] Kids { get; set; } 

    public int Score { get; set; } 

    public int[] Parts { get; set; } // A list of related pollopts, in display order.

    public string Descendants { get; set; } // In the case of stories or polls, the total comment count.
}
