using System.Threading.Tasks;

namespace KittyApp.Contracts
{
    public interface IKittyService
    {
        Task<byte[]> FlipKittyImage(string imageUrl);
        Task<byte[]> RotateKittyImageWithText(string imageUrl, string text);
    }
}
