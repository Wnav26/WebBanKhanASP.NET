using System;
using System.Collections.Generic;

namespace btl1.Models;

public partial class Sanpham
{
    public int Masp { get; set; }

    public string? Tensp { get; set; }

    public decimal? Giatien { get; set; }

    public int? Soluong { get; set; }

    public string? Mota { get; set; }

    public bool? Sanphammoi { get; set; }

    public string? Anhbia { get; set; }

    public int? Mahang { get; set; }

    public int? MaCl { get; set; }

    public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; } = new List<Chitietdonhang>();

    public virtual ChatLieu? MaClNavigation { get; set; }
}
