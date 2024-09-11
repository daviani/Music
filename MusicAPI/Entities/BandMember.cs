using System.Text.Json.Serialization;

namespace MusicApi.Entities;

public class BandMember
{
    public int BandId { get; set; }
    [JsonIgnore]
    public Band Band { get; set; }
    
    public int MemberId { get; set; }
    [JsonIgnore]
    public Member Member { get; set; }
    
}