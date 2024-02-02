using btl1.Models;
namespace btl1.Repository
{
    public interface IBrandRepository
    {
        Hangsanxuat Add(Hangsanxuat brand);
        Hangsanxuat Update(Hangsanxuat brand);
        Hangsanxuat Delete(int Mahang);
        Hangsanxuat Get(int Mahang);
        IEnumerable<Hangsanxuat> GetAllBrand();
    }
}
