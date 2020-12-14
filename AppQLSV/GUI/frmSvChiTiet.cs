using AppQLSV.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppQLSV.GUI
{
    public partial class frmSvChiTiet : Form
    {
        Student sinhVien;
        public frmSvChiTiet()
        {
            //Thêm mới
            InitializeComponent();
          
            this.Text = "Thêm mới sinh viên";
        }
        public frmSvChiTiet(Student sinhVien)
        {
            //Chỉnh sửa
            InitializeComponent();
            this.Text = "Chỉnh sửa danh sách sinh viên";
            this.sinhVien = sinhVien;
            txtID.Text = this.sinhVien.ID;
            txtFirstName.Text = this.sinhVien.FirstName;
            txtLastName.Text = this.sinhVien.LastName;
            dtpBirthDay.Value = (DateTime)this.sinhVien.DateOfBirth;
            txtPlaceOfBirth.Text = this.sinhVien.PlaceOfBirth;
            txtGender.Text=this.sinhVien.Gender.ToString();
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var maSV = txtID.Text;
            var firstName = txtFirstName.Text;
            var lastName = txtLastName.Text;
            var DOB = dtpBirthDay.Value;
            var POB = txtPlaceOfBirth.Text;
            var GD = txtGender.Text;
            

            var IdClassRoom = txtIDClassroom.Text;
            if (this.sinhVien == null)
            {
                var sv = new Student
                {
                    ID = maSV,
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = DOB,
                    PlaceOfBirth = POB,
                    Gender = int.Parse(GD),
                    IDClassroom = IdClassRoom
                };
                var db = new AppQLSVDBContext();
                db.Students.Add(sv);
                db.SaveChanges();

                DialogResult = DialogResult.OK;
            }
            else
            {
                var db = new AppQLSVDBContext();
                var sv = db.Students.Where(a => a.ID == sinhVien.ID).FirstOrDefault();
                sv.ID = maSV;
                sv.FirstName = firstName;
                sv.LastName = lastName;
                sv.DateOfBirth = DOB;
                sv.PlaceOfBirth = POB;
                sv.Gender = int.Parse(GD);
                sv.IDClassroom = IdClassRoom;
                db.SaveChanges();
                DialogResult = DialogResult.OK;

            }
        }

        private void frmSvChiTiet_Load(object sender, EventArgs e)
        {

        }
    }
}
