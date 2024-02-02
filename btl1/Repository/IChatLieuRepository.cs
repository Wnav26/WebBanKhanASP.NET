using btl1.Models;
namespace btl1.Repository
{
	public interface IChatLieuRepository
	{
		ChatLieu Add(ChatLieu ChatLieu);
		ChatLieu Update(ChatLieu ChatLieu);
		ChatLieu Delete(int maCL);
		ChatLieu Get(int maCL);
		IEnumerable<ChatLieu> GetAllCL();
	}
}
