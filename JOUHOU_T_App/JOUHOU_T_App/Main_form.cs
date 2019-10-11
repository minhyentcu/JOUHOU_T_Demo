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

using System.Data.OleDb;

using System.Data.Sql;
using System.Data.SqlClient;
using JOUHOU_T_App.DAO;

namespace JOUHOU_T_App
{
    public partial class Main_form : Form
    {
        OleDbConnection cnn;

        // OleDbDataAdapter adapter;

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
                DataProvider dataProvider = new DataProvider();
                var querey = "select PATIENTS_NAME, PATIENTS_ADDRESS ,GROUP_NAME  from JOUHOU_T  J ,GROUP_T G WHERE  J.GROUP_ID=G.GROUP_ID ORDER BY J.ID  ASC";
                var data = dataProvider.ExcuteQuery(querey);
                gridViewInfo.DataSource = data;
                gridViewInfo.Columns[0].HeaderText = "名前";
                gridViewInfo.Columns[1].HeaderText = "住所";
                gridViewInfo.Columns[2].HeaderText = "グループ";
                gridViewInfo.EnableHeadersVisualStyles = false;
                gridViewInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            }
            catch (Exception ex)
            {
                // process logging

                MessageBox.Show("数字しか入力できません。", "Thông báo", MessageBoxButtons.OK);
            }
        }
        // Opent form Patient when click
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            var fPatient = new Patient();
            fPatient.ShowDialog();
            this.LoadDataPatient();
            this.Show();
        }
    }
}
