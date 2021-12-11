﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BaiTapLonAPI.DAL;
using Microsoft.Data.SqlClient;
using BaiTapLonAPI.Models;
using BaiTapLonAPI.DAL.DataHelper;

namespace BaiTapLonAPI.BLL
{
    public class LoaiTuiXachBLL:ILoaiTuiXachBLL
    {
        DataTable dt;
        ILoaiRepository _dats;
        public LoaiTuiXachBLL(ILoaiRepository dats)
        {
            this._dats = dats;
        }
        public List<LoaiTuiXach> getdataloaituixach()
        {
            List<LoaiTuiXach> li = new List<LoaiTuiXach>();
            dt = new DataTable();
            dt = _dats.getloai();
            LoaiTuiXach loai;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                loai = new LoaiTuiXach();
                loai.MaLoaiTuiXach = int.Parse(dt.Rows[i][0].ToString());
                loai.TenLoai = dt.Rows[i][1].ToString();
                loai.MoTa = dt.Rows[i][2].ToString();
                li.Add(loai);
            }
            return li;
        }
        public void addloai(string tenloai, string mota)
        {
            _dats.addloaituixach(tenloai, mota);
        }
        public void delloai(string maloai)
        {
            _dats.Delloaituixach(maloai);
        }
        public void Updateloai(string maloai, string tenloai, string mota)
        {
            _dats.Updateloaitui(maloai,tenloai,mota);
        }
        public List<LoaiTuiXach> Loaituipaginate(int pageIndex)
        {
            dt = new DataTable();
            dt = _dats.getAllPaginate(pageIndex);
            LoaiTuiXach Loaitui;
            List<LoaiTuiXach> tuiLi = new List<LoaiTuiXach>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Loaitui = new LoaiTuiXach();
                Loaitui.MaLoaiTuiXach = int.Parse(dt.Rows[i][1].ToString());
                Loaitui.TenLoai = dt.Rows[i][2].ToString();
                Loaitui.MoTa = dt.Rows[i][3].ToString();
                tuiLi.Add(Loaitui);
            }
            return tuiLi;
        }
        public LoaiTuiXach GetLoaiTuiByID(int id)
        {
            LoaiTuiXach Type = new LoaiTuiXach();
            //dt = new DataTable();
            dt = _dats.GetLoaiTuiByID(id);
            Type.MaLoaiTuiXach = int.Parse(dt.Rows[0][0].ToString());
            Type.TenLoai = dt.Rows[0][1].ToString();
            Type.MoTa = dt.Rows[0][2].ToString();
            return Type;
        }
    }
}
