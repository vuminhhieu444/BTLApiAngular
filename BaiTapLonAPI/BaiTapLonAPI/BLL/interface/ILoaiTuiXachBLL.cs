﻿using BaiTapLonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaiTapLonAPI.BLL
{
    public interface ILoaiTuiXachBLL
    {
        List<LoaiTuiXach> getdataloaituixach();
        void addloai(string tenloai, string mota);
        void delloai(string maloai);
        void Updateloai(string maloai, string tenloai, string mota);
        List<LoaiTuiXach> Loaituipaginate(int pageIndex);
        LoaiTuiXach GetLoaiTuiByID(int id);
    }
}