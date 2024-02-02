using System;
using System.Collections.Generic;

namespace btl1.Models;

public partial class PhanQuyen
{
    public int Idquyen { get; set; }

    public string? TenQuyen { get; set; }

    public virtual ICollection<Nguoidung> Nguoidungs { get; set; } = new List<Nguoidung>();
}
