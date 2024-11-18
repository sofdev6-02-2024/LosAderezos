using Backend.DTOs.WithoutID;

namespace Backend.Services.ServiceInterfaces;

public interface ITokenservice
{
    public UserFullInfoDTO PostToken(CreateTokenDTO sessionPostDto);
    public bool GetCookie(Guid userId);
    public UserFullInfoDTO RefreshToken(TokenWithoutIdDTO oldToken);
    public UserFullInfoDTO GetTokenUser(Guid userId);
    public bool IsTokenValid(Guid userId);
}
