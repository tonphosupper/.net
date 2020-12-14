using AppQLSV.DAL;
using AppQLSV.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppQLSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gridLopHoc.AutoGenerateColumns = false;
            gridSinhVien.AutoGenerateColumns = false;
            LoadDanhSachLopHoc();
            //thêmsv

            LoadDanhSachSinhVien();

        }
        void LoadDanhSachLopHoc()
        {
            AppQLSVDBContext db = new AppQLSVDBContext();
            var ls = db.Classrooms.OrderBy(e => e.Name) .ToList();
            bdsLopHoc.DataSource = ls;

            gridLopHoc.DataSource = bdsLopHoc;
        }
        private void btnThemLop_Click(object sender, EventArgs e)
        {
            var f = new frmLopChiTiet();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachLopHoc();
            }
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            var lopDangChon = bdsLopHoc.Current as Classroom;
            if (lopDangChon != null)
            {
                var rs=MessageBox.Show(
                    "Bạn có thực sự muốn xóa không?",
                    "Chú ý",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                    );
                if (rs == DialogResult.OK)
                {
                    AppQLSVDBContext db = new AppQLSVDBContext();
                    var lop = db.Classrooms.Where(t => t.ID == lopDangChon.ID).FirstOrDefault();
                    if (lop != null)
                    {
                        db.Classrooms.Remove(lop);
                        db.SaveChanges();
                        LoadDanhSachLopHoc();
                    }
                }
            }
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
        {
            var lopDangChon = bdsLopHoc.Current as Classroom;

            var f = new frmLopChiTiet(lopDangChon);
            if (lopDangChon != null)
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachLopHoc();
                }
            }
        }

        private void bdsLopHoc_CurrentChanged(object sender, EventArgs e)
        {
            var lopDangChon = bdsLopHoc.Current as Classroom;
            if (lopDangChon != null)
            {
                var db = new AppQLSVDBContext();
                var dsSV = db.Students.Where(t => t.IDClassroom == lopDangChon.ID).ToList();
                bdsSinhVien.DataSource = dsSV;
                gridSinhVien.DataSource = bdsSinhVien;
            }
        }
        // Sinh viên
        void LoadDanhSachSinhVien()
        {
            AppQLSVDBContext db = new AppQLSVDBContext();
            var ls = db.Students.OrderBy(e => e.LastName).ToList();        
            bdsSinhVien.DataSource = ls;
            gridSinhVien.DataSource = bdsSinhVien;

        }

        private void btnThemSinhVien_Click(object sender, EventArgs e)
        {
            var f = new frmSvChiTiet();
            if (f.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachSinhVien();             
            }
        }

        private void btnSuaSinhVien_Click(object sender, EventArgs e)
        {
            
            var sinhVienDangChon = bdsSinhVien.Current as Student;
           
            var f = new frmSvChiTiet(sinhVienDangChon);
            
            if (sinhVienDangChon != null)
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachSinhVien();
                }
            }
        }
        private void btnXoaSinhVien_Click(object sender, EventArgs e)
        {
            var sinhVienDangChon = bdsSinhVien.Current as Student;
            if (sinhVienDangChon != null)
            {
                var rs = MessageBox.Show(
                   "Bạn có thực sự muốn xóa không?",
                    "Chú ý",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                    );
                if(rs == DialogResult.OK)
                {
                    AppQLSVDBContext db = new AppQLSVDBContext();
                    var sv = db.Students.Where(t => t.ID == sinhVienDangChon.ID).FirstOrDefault();
                    if (sv != null)
                    {
                        db.Students.Remove(sv);
                        db.SaveChanges();
                        LoadDanhSachSinhVien();
                    }
                }
            }
        }

        private void gridSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
