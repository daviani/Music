namespace MusicApi.Entities;

public class Band
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Status { get; set; } = "";
    public int FormedIn { get; set; }
    public string Genre { get; set; } = "";
    // Clé étrangère pour la relation avec Country
    public int CountryId { get; set; }

    // Propriété de navigation pour la relation avec Country
    public Countrie? Countries { get; set; }
    
    public ICollection<BandMember> BandMembers { get; set; }

}