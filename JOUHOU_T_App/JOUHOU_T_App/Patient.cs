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
                JOUHOU_TEntities context = new JOUHOU_TEntities();

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
                    var group = byte.Parse(nGroup.Value.ToString());

                    var isExitstGroup = context.GROUP_T.Where(x => x.GROUP_NAME == group).FirstOrDefault();

                    var patient = new JOUHOU_T
                    {
                        PATIENTS_NAME = txbName.Text,
                        PATIENTS_ADDRESS = txbAddress.Text,
                    };
                    // insert data to database if exitst group
                    if (isExitstGroup == null)
                    {
                        var group_T = new GROUP_T
                        {
                            GROUP_NAME = group,
                        };
                        group_T.JOUHOU_T.Add(patient);
                        context.GROUP_T.Add(group_T);
                    }
                    else
                    {
                        //inser partient
                        patient.GROUP_T = isExitstGroup;
                        context.JOUHOU_T.Add(patient);
                    }
                    //save to database
                    context.SaveChanges();
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
    }
}
