namespace MusicApi.Entities;

public class Member
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int CountryId { get; set; }
    public bool Gender { get; set; }
    public string Instrument { get; set; } = "";
    
    // public Countrie? PlaceOfBirth { get; set; }
    public ICollection<BandMember> BandMembers { get; set; }
    
}