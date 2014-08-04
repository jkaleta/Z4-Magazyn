using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class ResultView : Form
    {
        #region Members
        int max;
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();
        List<int> list3 = new List<int>();
        List<int> list4 = new List<int>();
        List<int> list5 = new List<int>();
        List<int> list6 = new List<int>();
        List<int> list7 = new List<int>();
        List<int> list8 = new List<int>();

        DataTable dt;

        #endregion

        public ResultView(List<Solution> list, int index)
        {
            InitializeComponent();

            Dictionary<int, List<int>> kolejka = list[index].list;
            
            foreach (KeyValuePair<int, List<int>> item in kolejka.OrderBy(a => a.Value.Count))
            {
                max = item.Value.Count;
            }

            foreach (KeyValuePair<int, List<int>> item in kolejka)
            {
                if (item.Key == 1) list1 = item.Value;
                if (item.Key == 2) list2 = item.Value;
                if (item.Key == 3) list3 = item.Value;
                if (item.Key == 4) list4 = item.Value;
                if (item.Key == 5) list5 = item.Value;
                if (item.Key == 6) list6 = item.Value;
                if (item.Key == 7) list7 = item.Value;
                if (item.Key == 8) list8 = item.Value;
            }

            list1.Sort();
            list2.Sort();
            list3.Sort();
            list4.Sort();
            list5.Sort();
            list6.Sort();
            list7.Sort();
            list8.Sort();

            for (int i = list1.Count; i < max; i++) list1.Add(0);
            for (int i = list2.Count; i < max; i++) list2.Add(0);
            for (int i = list3.Count; i < max; i++) list3.Add(0);
            for (int i = list4.Count; i < max; i++) list4.Add(0);
            for (int i = list5.Count; i < max; i++) list5.Add(0);
            for (int i = list6.Count; i < max; i++) list6.Add(0);
            for (int i = list7.Count; i < max; i++) list7.Add(0);
            for (int i = list8.Count; i < max; i++) list8.Add(0);

            for (int i = 0; i < list1.Count ; i++)
            {
                this.dataGridView1.Rows.Add(i+1, list1[i].ToString(), list2[i].ToString(), list3[i].ToString(), list4[i].ToString(), list5[i].ToString(), list6[i].ToString(), list7[i].ToString(), list8[i].ToString());
            }

        }

        // Zapisywanie do pliku CSV - działa, ale jeszcze nie tak jakby się chciało
        #region SaveToFile

        private void bSaveFile_Click(object sender, EventArgs e)
        {
            dt = GetDataTable();

            if (dt == null) MessageBox.Show("ty bucu");

            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText("test.csv", sb.ToString());
            File.Open("test.csv", FileMode.Append);


        }

        public DataTable GetDataTable()
        {
            DataTable dtLocalC = new DataTable();
            dtLocalC.Columns.Add("Nofream");
            dtLocalC.Columns.Add("Column1");
            dtLocalC.Columns.Add("Column2");
            dtLocalC.Columns.Add("Column3");
            dtLocalC.Columns.Add("Column4");

            DataRow drLocal = null;
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                drLocal = dtLocalC.NewRow();
                drLocal["Nofream"] = dr.Cells["Nofream"].Value;
                drLocal["Column1"] = dr.Cells["Column1"].Value;
                drLocal["Column2"] = dr.Cells["Column2"].Value;
                drLocal["Column3"] = dr.Cells["Column3"].Value;
                drLocal["Column4"] = dr.Cells["Column4"].Value;
                dtLocalC.Rows.Add(drLocal);
            }

            return dtLocalC;
        }

        #endregion
    }
}
