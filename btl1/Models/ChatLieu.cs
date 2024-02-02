using System;
using System.Collections.Generic;

namespace btl1.Models;

public partial class ChatLieu
{
    public int MaCl { get; set; }

    public string? TenCl { get; set; }

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
