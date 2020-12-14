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
    public partial class frmThem : Form
    {
        public frmThem()
        {
            InitializeComponent();
        }
        void AddClassroom()
        {
            Classroom classroom = new Classroom
            {
                ID = Guid.NewGuid().ToString(),
                Name = txtTenLop.Text,
                Room = txtPhongHoc.Text
            };
            var db = new QLSVDBContext();
            var obj = db.Classrooms.Where(e => e.Name == classroom.Name).FirstOrDefault();
         
            if (obj == null)
            {
                db.Classrooms.Add(classroom);
                db.SaveChanges();
                MessageBox.Show("Bạn đã thêm thành công");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Bạn không thể thêm lớp này được");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            AddClassroom();
        }
    }
}
