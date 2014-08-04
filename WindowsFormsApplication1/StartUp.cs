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
    public partial class StartUp : Form
    {

        #region Members

        private Progress prg;
        private int Max;
        private int Tolerance;
        private int Step;
        private int NofTry;
        private int NofSolution;
        private int Interspace;
        private Dictionary<int, int> borders;
        private Dictionary<int, int> panels;
        private Dictionary<int, int> panelsprior;
        public List<Solution> NumberOfsolutions;
        public Random rand;

        private ResultView resView;
        private Details det;

        private DataGridView data;
        private DataTable dt;

        #endregion

        #region Construction

        public StartUp()
        {
            InitializeComponent();

            Default();
            rand = new Random();
            
        }

        #endregion

        #region Buttons_Click

        private void bSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Zmiany zostały zapisane");
        }

        private void bDefault_Click(object sender, EventArgs e)
        {
            Default();
        }

        private void bStart_Click(object sender, EventArgs e)
        {

            if (resView != null) resView.Close();
            if (det != null) det.Close();

            prg = new Progress(Max, Tolerance, Step, NofTry, NofSolution, borders, panels, panelsprior, Interspace, rand);

            prg.DataAvailable += new EventHandler(prg_DataAvailable);
            prg.Show();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Methods

        public void Default()
        {
            #region Default_Data
            
            Max = 0;    
            Tolerance = 0;  
            Step = 5;   
            NofTry = 100;   
            NofSolution = 25;   
            Interspace = 170;   

            borders = new Dictionary<int, int>
            {        
                {1, 9423},
                {2, 11567},
                {3, 9039},
                {4, 11599},
                {5, 9007},
                {6, 11592},
                {7, 8971},
                {8, 11623}
            };

            
            panelsprior = new Dictionary<int, int> 
            {
                {495, 0},
                {500, 3},
                {518, 0},
                {520, 0},
                {524, 0},
                {526, 4},
                {555, 0},
                {557, 0},
                {589, 0},
                {625, 0},
                {691, 0},
                {741, 0}
            };

            panels = new Dictionary<int, int> 
            {
                {495, 3},
                {500, 10},
                {518, 30},
                {520, 10},
                {524, 3},
                {526, 7},
                {555, 34},
                {557, 8},
                {589, 2},
                {625, 2},
                {691, 2},
                {741, 2}
            };

            #endregion

            LoadData();
        }

        private void LoadData()
        {
            txt_Max.Text = Max.ToString();
            txt_Tolerance.Text = Tolerance.ToString();
            txt_Step.Text = Step.ToString();
            txt_NofTry.Text = NofTry.ToString();
            txt_NofSolution.Text = NofSolution.ToString();
            txt_Interspace.Text = Interspace.ToString();

            if (borders.ContainsKey(1)) { txt1_Store.Text = borders[1].ToString(); check1_Store.Checked = true; } else { check1_Store.Checked = false; }
            if (borders.ContainsKey(2)) { txt2_Store.Text = borders[2].ToString(); check2_Store.Checked = true; } else { check2_Store.Checked = false; }
            if (borders.ContainsKey(3)) { txt3_Store.Text = borders[3].ToString(); check3_Store.Checked = true; } else { check3_Store.Checked = false; }
            if (borders.ContainsKey(4)) { txt4_Store.Text = borders[4].ToString(); check4_Store.Checked = true; } else { check4_Store.Checked = false; }
            if (borders.ContainsKey(5)) { txt5_Store.Text = borders[5].ToString(); check5_Store.Checked = true; } else { check5_Store.Checked = false; }
            if (borders.ContainsKey(6)) { txt6_Store.Text = borders[6].ToString(); check6_Store.Checked = true; } else { check6_Store.Checked = false; }
            if (borders.ContainsKey(7)) { txt7_Store.Text = borders[7].ToString(); check7_Store.Checked = true; } else { check7_Store.Checked = false; }
            if (borders.ContainsKey(8)) { txt8_Store.Text = borders[8].ToString(); check8_Store.Checked = true; } else { check8_Store.Checked = false; }

            if (panels.ContainsKey(495)) { txt1_Panel.Text = panels[495].ToString(); txt1_PanelPrior.Text = panelsprior[495].ToString(); check1_Panel.Checked = true; } else { check1_Panel.Checked = false; }
            if (panels.ContainsKey(500)) { txt2_Panel.Text = panels[500].ToString(); txt2_PanelPrior.Text = panelsprior[500].ToString(); check2_Panel.Checked = true; } else { check2_Panel.Checked = false; }
            if (panels.ContainsKey(518)) { txt3_Panel.Text = panels[518].ToString(); txt3_PanelPrior.Text = panelsprior[518].ToString(); check3_Panel.Checked = true; } else { check3_Panel.Checked = false; }
            if (panels.ContainsKey(520)) { txt4_Panel.Text = panels[520].ToString(); txt4_PanelPrior.Text = panelsprior[520].ToString(); check4_Panel.Checked = true; } else { check4_Panel.Checked = false; }
            if (panels.ContainsKey(524)) { txt5_Panel.Text = panels[524].ToString(); txt5_PanelPrior.Text = panelsprior[524].ToString(); check5_Panel.Checked = true; } else { check5_Panel.Checked = false; }
            if (panels.ContainsKey(526)) { txt6_Panel.Text = panels[526].ToString(); txt6_PanelPrior.Text = panelsprior[526].ToString(); check6_Panel.Checked = true; } else { check6_Panel.Checked = false; }
            if (panels.ContainsKey(555)) { txt7_Panel.Text = panels[555].ToString(); txt7_PanelPrior.Text = panelsprior[555].ToString(); check7_Panel.Checked = true; } else { check7_Panel.Checked = false; }
            if (panels.ContainsKey(557)) { txt8_Panel.Text = panels[557].ToString(); txt8_PanelPrior.Text = panelsprior[557].ToString(); check8_Panel.Checked = true; } else { check8_Panel.Checked = false; }
            if (panels.ContainsKey(589)) { txt9_Panel.Text = panels[589].ToString(); txt9_PanelPrior.Text = panelsprior[589].ToString(); check9_Panel.Checked = true; } else { check9_Panel.Checked = false; }
            if (panels.ContainsKey(625)) { txt10_Panel.Text = panels[625].ToString(); txt10_PanelPrior.Text = panelsprior[625].ToString(); check10_Panel.Checked = true; } else { check10_Panel.Checked = false; }
            if (panels.ContainsKey(691)) { txt11_Panel.Text = panels[691].ToString(); txt11_PanelPrior.Text = panelsprior[691].ToString(); check11_Panel.Checked = true; } else { check11_Panel.Checked = false; }
            if (panels.ContainsKey(741)) { txt12_Panel.Text = panels[741].ToString(); txt12_PanelPrior.Text = panelsprior[741].ToString(); check12_Panel.Checked = true; } else { check12_Panel.Checked = false; }
        }

        private void SaveData()
        {
            Max = Convert.ToInt32(txt_Max.Text);
            Tolerance = Convert.ToInt32(txt_Tolerance.Text);
            Step = Convert.ToInt32(txt_Step.Text);
            NofTry = Convert.ToInt32(txt_NofTry.Text);
            NofSolution = Convert.ToInt32(txt_NofSolution.Text);

            if (check1_Store.Checked) { borders[1] = Convert.ToInt32(txt1_Store.Text); } else { borders.Remove(1); }
            if (check2_Store.Checked) { borders[2] = Convert.ToInt32(txt2_Store.Text); } else { borders.Remove(2); }
            if (check3_Store.Checked) { borders[3] = Convert.ToInt32(txt3_Store.Text); } else { borders.Remove(3); }
            if (check4_Store.Checked) { borders[4] = Convert.ToInt32(txt4_Store.Text); } else { borders.Remove(4); }
            if (check5_Store.Checked) { borders[5] = Convert.ToInt32(txt5_Store.Text); } else { borders.Remove(5); }
            if (check6_Store.Checked) { borders[6] = Convert.ToInt32(txt6_Store.Text); } else { borders.Remove(6); }
            if (check7_Store.Checked) { borders[7] = Convert.ToInt32(txt7_Store.Text); } else { borders.Remove(7); }
            if (check8_Store.Checked) { borders[8] = Convert.ToInt32(txt8_Store.Text); } else { borders.Remove(8); }

            if (check1_Panel.Checked) { panels[495] = Convert.ToInt32(txt1_Panel.Text); panelsprior[495] = Convert.ToInt32(txt1_PanelPrior.Text); }
            else { panels.Remove(495); panelsprior.Remove(495); }
            if (check2_Panel.Checked) { panels[500] = Convert.ToInt32(txt2_Panel.Text); panelsprior[500] = Convert.ToInt32(txt2_PanelPrior.Text); }
            else { panels.Remove(500); panelsprior.Remove(500); }
            if (check3_Panel.Checked) { panels[518] = Convert.ToInt32(txt3_Panel.Text); panelsprior[518] = Convert.ToInt32(txt3_PanelPrior.Text); }
            else { panels.Remove(518); panelsprior.Remove(518); }
            if (check4_Panel.Checked) { panels[520] = Convert.ToInt32(txt4_Panel.Text); panelsprior[520] = Convert.ToInt32(txt4_PanelPrior.Text); }
            else { panels.Remove(520); panelsprior.Remove(520); }
            if (check5_Panel.Checked) { panels[524] = Convert.ToInt32(txt5_Panel.Text); panelsprior[524] = Convert.ToInt32(txt5_PanelPrior.Text); }
            else { panels.Remove(524); panelsprior.Remove(524); }
            if (check6_Panel.Checked) { panels[526] = Convert.ToInt32(txt6_Panel.Text); panelsprior[526] = Convert.ToInt32(txt6_PanelPrior.Text); }
            else { panels.Remove(526); panelsprior.Remove(526); }
            if (check7_Panel.Checked) { panels[555] = Convert.ToInt32(txt7_Panel.Text); panelsprior[555] = Convert.ToInt32(txt7_PanelPrior.Text); }
            else { panels.Remove(555); panelsprior.Remove(555); }
            if (check8_Panel.Checked) { panels[557] = Convert.ToInt32(txt8_Panel.Text); panelsprior[557] = Convert.ToInt32(txt8_PanelPrior.Text); }
            else { panels.Remove(557); panelsprior.Remove(557); }
            if (check9_Panel.Checked) { panels[589] = Convert.ToInt32(txt9_Panel.Text); panelsprior[589] = Convert.ToInt32(txt9_PanelPrior.Text); }
            else { panels.Remove(589); panelsprior.Remove(589); }
            if (check10_Panel.Checked) { panels[625] = Convert.ToInt32(txt10_Panel.Text); panelsprior[625] = Convert.ToInt32(txt10_PanelPrior.Text); }
            else { panels.Remove(625); panelsprior.Remove(625); }
            if (check11_Panel.Checked) { panels[691] = Convert.ToInt32(txt11_Panel.Text); panelsprior[691] = Convert.ToInt32(txt11_PanelPrior.Text); }
            else { panels.Remove(691); panelsprior.Remove(691); }
            if (check12_Panel.Checked) { panels[741] = Convert.ToInt32(txt12_Panel.Text); panelsprior[741] = Convert.ToInt32(txt12_PanelPrior.Text); }
            else { panels.Remove(741); panelsprior.Remove(741); }
        }

        private void List_Results(List<Solution> NumberOfsolutions)
        {
            this.dataGridView1.Visible = true;
            this.dataGridView1.RowCount = 1;

            int i = 0;
            foreach (Solution item in NumberOfsolutions.OrderBy(item => item.wolne_miejsce))
            {
                i++;

                this.dataGridView1.Rows.Add(i, "Rozwiązanie " + i, item.ryzy, item.wolne_miejsce);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                resView = new ResultView(NumberOfsolutions, e.RowIndex);
                data = resView.dataGridView1;
                resView.Show();

                det = new Details(NumberOfsolutions, panels, e.RowIndex);
                det.Show();
            }
        }

        #endregion

        #region Handlers

        void prg_DataAvailable(object sender, EventArgs e)
        {
            NumberOfsolutions = new List<Solution>();
            Progress prg1 = sender as Progress;
            if (prg != null)
            {
                if (prg1.Algorithm_Done)
                {
                    NumberOfsolutions = prg1.NumberOfsolutions;

                    List_Results(NumberOfsolutions);
                }
            }
        }

        #endregion

    }
}
