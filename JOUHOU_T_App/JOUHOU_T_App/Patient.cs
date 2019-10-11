using JOUHOU_T_App.DAO;
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
    public partial class Patient : Form
    {
        DataProvider dataProvider = new DataProvider();
        public Patient()
        {
            InitializeComponent();
            btnAdd.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var message = string.Empty;

                if (txbName.Text.Length > 10)
                {
                    message = "Tên không hợp lệ";
                }
                if (txbAddress.Text.Length > 20)
                {
                    message = "Địa chỉ không hợp lệ";
                }
                if (nGroup.Value > 9 || nGroup.Value < 0)
                {
                    message = "Nhóm bệnh nhân không hợp lệ";
                }

                if (!string.IsNullOrEmpty(message))
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK);
                }

                else
                {
                    // Insert data to database
                    var isInsert = true;
                    var groupName = byte.Parse(nGroup.Value.ToString());

                    var groupId = GetGroupPatientId(groupName);

                    if (groupId > 0)
                    {
                        isInsert = InsertPatient(txbName.Text, txbAddress.Text, groupId);
                    }
                    else
                    {
                        groupId = InsertGroup(groupName);
                        if (groupId > 0)
                        {
                            isInsert = InsertPatient(txbName.Text, txbAddress.Text, groupId);
                        }
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // prossess logging
                MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void TxbName_TextChanged(object sender, EventArgs e)
        {
            //check enable btnAdd
            btnAdd.Enabled = !string.IsNullOrEmpty(txbName.Text);
        }

        private int GetGroupPatientId(int groupName)
        {
            string query = $"SELECT * FROM GROUP_T WHERE GROUP_NAME = {groupName}";
            DataTable data = dataProvider.ExcuteQuery(query);
            if (data.Rows.Count > 0)
            {
                return Convert.ToInt32(data.Rows[0]["GROUP_ID"]);
            }
            return -1;
        }


        private int InsertGroup(int name)
        {
            string query = $"INSERT INTO GROUP_T ( GROUP_NAME ) VALUES  ({name})";
            int result = dataProvider.ExcuteNonQueryForGroup(query);

            return result;
        }

        private bool InsertPatient(string name, string address, int groupId)
        {
            string query = $"INSERT INTO JOUHOU_T ( PATIENTS_NAME,PATIENTS_ADDRESS, GROUP_ID) VALUES  ('{name}','{address}',{groupId})";
            int result = dataProvider.ExcuteNonQuery(query);

            return result > 0;
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }
    }
}
