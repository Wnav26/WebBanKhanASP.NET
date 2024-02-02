using btl1.Models;

namespace btl1.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly QlbanKhanContext _context;
        public BrandRepository(QlbanKhanContext context)
        {
            _context = context;
        }
        public Hangsanxuat Add(Hangsanxuat brand)
        {
            _context.Hangsanxuats.Add(brand);
            _context.SaveChanges();
            return brand;
        }

        public Hangsanxuat Delete(int Mahang)
        {
            throw new NotImplementedException();
        }

        public Hangsanxuat Get(int Mahang)
        {
            return _context.Hangsanxuats.Find(Mahang);
        }

        public IEnumerable<Hangsanxuat> GetAllBrand()
        {
            return _context.Hangsanxuats;
        }

        public Hangsanxuat Update(Hangsanxuat brand)
        {
            _context.Update(brand);
            _context.SaveChanges();
            return brand;
        }
    }
}
