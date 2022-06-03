namespace SquadManager.Services.Configuration;

public class JwtConfiguration
{
    public string Secret { get; set; } = null!;
    public int ExpirationTime { get; set; }
}
