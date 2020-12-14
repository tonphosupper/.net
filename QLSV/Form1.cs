using QLSV.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadClassroom();
        }
        /// <summary>
        /// Lấy danh sách lớp học có trong CSDL
        /// </summary>
        void LoadClassroom()
        {
            var db = new QLSVDBContext();
            var ls = db.Classrooms.ToList();
            dataGridView1.DataSource = ls;
        }
        /*void AddClassroom()
        {
            Classroom classroom = new Classroom
            {
                ID = Guid.NewGuid().ToString(),
                Name = "TinK41E",
                Room = "Lab5"
            };
            var db = new QLSVDBContext();
            var obj = db.Classrooms.Where(e => e.Name == classroom.Name).FirstOrDefault();
            if (obj == null)
            {
                db.Classrooms.Add(classroom);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Bạn không thể thêm lớp này được");
            }
        }*/

        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                var keyword = txtKeyword.Text;
                var db = new QLSVDBContext();
                var ls=
                db.Classrooms.Where(t => t.Name.Contains(keyword)||t.Room.Contains(keyword)
                ).ToList();
                dataGridView1.DataSource = ls;
            }
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            var f = new frmThem();
            var rs = f.ShowDialog();
            if (rs == DialogResult.OK)
            {
                LoadClassroom();
            }
        }
    }
}
