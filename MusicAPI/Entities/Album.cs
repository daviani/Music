namespace MusicApi.Entities;

public class Album
{
    public int Id { get; set; }
    public string Titre { get; set; } = "";
    public int BandId { get; set; } 
    
    // Propriété de navigation pour la relation avec Band
    public Band? Bands{ get; set; }
}