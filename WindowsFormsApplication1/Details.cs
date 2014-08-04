using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Details : Form
    {

        public Details(List<Solution> list, Dictionary<int, int> panels, int index)
        {
            InitializeComponent();

            int[] wys = new int[12];
            for (int i = 0; i < 12; i++)
            {
                wys[i] = 0;
            }
            Solution sol = list[index];
            foreach (KeyValuePair<int, List<int>> item in sol.list)
            {
                foreach (int item1 in item.Value)
                {
                    if (item1 == 495)
                        wys[0] = wys[0] + 1;
                    else if (item1 == 500)
                        wys[1] = wys[1] + 1;
                    else if (item1 == 518)
                        wys[2] = wys[2] + 1;
                    else if (item1 == 520)
                        wys[3] = wys[3] + 1;
                    else if (item1 == 524)
                        wys[4] = wys[4] + 1;
                    else if (item1 == 526)
                        wys[5] = wys[5] + 1;
                    else if (item1 == 555)
                        wys[6] = wys[6] + 1;
                    else if (item1 == 557)
                        wys[7] = wys[7] + 1;
                    else if (item1 == 589)
                        wys[8] = wys[8] + 1;
                    else if (item1 == 625)
                        wys[9] = wys[9] + 1;
                    else if (item1 == 691)
                        wys[10] = wys[10] + 1;
                    else if (item1 == 741)
                        wys[11] = wys[11] + 1;
                }
            }

            int x = 0;
            foreach (KeyValuePair<int, int> item in panels)
            {
                this.dataGridView1.Rows.Add(item.Key, wys[x]);
                ++x;
            }

        }
    }
}
