using JOUHOU_T_App.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOUHOU_T_App
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
            LoadDataPatient();
        }

        //LoadData to dataGridView
        private void LoadDataPatient()
        {
            try
            {
                JOUHOU_TEntities context = new JOUHOU_TEntities();
                gridViewInfo.DataSource = context.JOUHOU_T.Select(x => new { x.ID, x.PATIENTS_NAME, x.PATIENTS_ADDRESS, x.GROUP_T.GROUP_NAME }).OrderBy(j => j.ID).ToList();
                gridViewInfo.Columns[0].Visible = false;
                gridViewInfo.Columns[1].HeaderText = "Patients Name";
                gridViewInfo.Columns[2].HeaderText = "Patients Address";
                gridViewInfo.Columns[3].HeaderText = "Group";

            }
            catch (Exception ex)
            {
                // process logging

                MessageBox.Show("Lỗi data", "Thông báo", MessageBoxButtons.OK);
            }
        }
        // Opent form Patient when click
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            var fPatient = new Patient();
            this.Hide();
            fPatient.ShowDialog();
            this.LoadDataPatient();
            this.Show();
        }
    }
}
