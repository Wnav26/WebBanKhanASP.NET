using System;
using System.Collections.Generic;

namespace btl1.Models;

public partial class Donhang
{
    public int Madon { get; set; }

    public DateTime? Ngaydat { get; set; }

    public int? Tinhtrang { get; set; }

    public int? MaNguoidung { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual Nguoidung? MaNguoidungNavigation { get; set; }
}
