namespace MovieSearchBackend.Data.DTOs;

public class UserDTO
{
    public required string name { get; set; }
    public string? email { get; set; }
    public string? biography { get; set; }
    public int roleId { get; set; }
}
