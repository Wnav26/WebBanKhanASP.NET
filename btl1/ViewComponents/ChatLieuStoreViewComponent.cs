using btl1.Models;
using btl1.Repository;
using Microsoft.AspNetCore.Mvc;
namespace btl1.ViewComponents
{
	public class ChatLieuStoreViewComponent : ViewComponent
	{
		private readonly IChatLieuRepository _ChatLieu;
		public ChatLieuStoreViewComponent(IChatLieuRepository _chatLieuRepository)
		{
			_ChatLieu = _chatLieuRepository;
		}
		public IViewComponentResult Invoke()
		{
			var ChatLieu = _ChatLieu.GetAllCL().OrderBy(x => x.MaCl);
			return View(ChatLieu);
		}
	}
}
