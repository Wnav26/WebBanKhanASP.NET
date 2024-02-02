using System;
using System.Collections.Generic;

namespace btl1.Models;

public partial class Nguoidung
{
    public int MaNguoiDung { get; set; }

    public string? Hoten { get; set; }

    public string? Email { get; set; }

    public string? Dienthoai { get; set; }

    public string? Matkhau { get; set; }

    public int? Idquyen { get; set; }

    public string? Diachi { get; set; }

    public virtual ICollection<Donhang> Donhangs { get; set; } = new List<Donhang>();

    public virtual PhanQuyen? IdquyenNavigation { get; set; }
}
