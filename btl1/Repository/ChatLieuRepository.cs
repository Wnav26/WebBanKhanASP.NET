using btl1.Models;

namespace btl1.Repository
{
	public class ChatLieuRepository : IChatLieuRepository
	{
		private readonly QlbanKhanContext _context;
		public ChatLieuRepository(QlbanKhanContext context) {
			_context = context;
		}
		public ChatLieu Add(ChatLieu ChatLieu)
		{
			_context.ChatLieus.Add(ChatLieu);
			_context.SaveChanges();
			return ChatLieu;
		}

		public ChatLieu Delete(int maCL)
		{
			throw new NotImplementedException();
		}

		public ChatLieu Get(int maCL)
		{
			return _context.ChatLieus.Find(maCL);
		}

		public IEnumerable<ChatLieu> GetAllCL()
		{
			return _context.ChatLieus;
		}

		public ChatLieu Update(ChatLieu ChatLieu)
		{
			_context.Update(ChatLieu);
			_context.SaveChanges();
			return ChatLieu;
		}
	}
}
