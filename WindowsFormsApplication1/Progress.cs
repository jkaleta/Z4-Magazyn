using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Progress : Form
    {
        #region Members

        public int Max;
        public int Tolerance;
        public int Step;
        public int NofTry;
        public int NofSolution;
        public int Interspace;
        public Dictionary<int, int> borders;
        public Dictionary<int, int> panels;
        public Dictionary<int, int> panelsprior;
        Random rand;
        public List<Solution> NumberOfsolutions;
        private Solution solution;
        public bool Algorithm_Done;

        BackgroundWorker m_oWorker;

        #endregion

        #region Event
        // event
        public event EventHandler DataAvailable;

        protected virtual void OnDataAvailable(EventArgs e)
        {
            EventHandler eh = DataAvailable;
            if (eh != null)
            {
                eh(this, e);
            }
        }
        #endregion

        #region Construction

        public Progress(int Max, int Tolerance, int Step, int NofTry, int NofSolution, Dictionary<int, int> borders, Dictionary<int, int> panels, Dictionary<int, int> panelsprior, int Interspace, Random rand)
        {
            InitializeComponent();


            this.Max = Max;
            this.Tolerance = Tolerance;
            this.Step = Step;
            this.NofTry = NofTry;
            this.NofSolution = NofSolution;
            this.Interspace = Interspace;
            this.borders = borders;
            this.panels = panels;
            this.panelsprior = panelsprior;
            this.rand = rand;
            NumberOfsolutions = new List<Solution>();
            
            m_oWorker = new BackgroundWorker();
            m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
            m_oWorker.ProgressChanged += new ProgressChangedEventHandler
                    (m_oWorker_ProgressChanged);
            m_oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (m_oWorker_RunWorkerCompleted);
            m_oWorker.WorkerReportsProgress = true;
            m_oWorker.WorkerSupportsCancellation = true;

            OKbtn.Enabled = false;
            Cncbtn.Enabled = true;

            m_oWorker.RunWorkerAsync();
        }

        #endregion

        #region BackgroundWorker_methods

        private void m_oWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                lblStatus.Text = "Zadanie zostało anulowane";
            }

            else if (e.Error != null)
            {
                lblStatus.Text = "Wysątpił błąd podczas wykonywania zadania";
            }
            else
            {
                lblStatus.Text = "Zadanie zostało zakończone pomyślnie";
            }

            OKbtn.Enabled = true;
            Cncbtn.Enabled = false;

        }

        void m_oWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblStatus.Text = "Trwa wykonywanie zadania..." + progressBar1.Value.ToString() + "%";
        }

        #endregion

        #region DOWORK

        void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            List<int> panelspriorNumber = new List<int>();

            foreach (var item in panelsprior)
            {
                for (int i = 0; i < item.Value; i++)
                    panelspriorNumber.Add(item.Key);
            }
            
            List<int> panelsNumber = new List<int>();

            foreach (var item in panels)
            {
                for (int i = 0; i < item.Value - panelsprior[item.Key]; i++)
                    panelsNumber.Add(item.Key);
            }

            Dictionary<int, List<int>> list = new Dictionary<int, List<int>>();

            for (int i = 0; i < NofSolution; i++)
            {

                list = Algorithm.runAlgorithm(Max, Tolerance, Step, NofTry, borders, panelsNumber, panelspriorNumber, Interspace, rand);      // Wywołanie metody tworzącej populacje

                solution = new Solution(list, Algorithm.ryzy, Algorithm.wolne_miejsce);                   // Utworzenie obiektu typu Population

                NumberOfsolutions.Add(solution);

                m_oWorker.ReportProgress((int)Math.Round((((double)i/(double)NofSolution)*100)));

                if (m_oWorker.CancellationPending)
                {
                    e.Cancel = true;
                    m_oWorker.ReportProgress(0);
                    return;
                }
            }


            m_oWorker.ReportProgress(100);
            Algorithm_Done = true;
        }

        #endregion

        #region BackgroundWorker_buttons

        private void Cncbtn_Click(object sender, EventArgs e)
        {
            if (m_oWorker.IsBusy)
            {
                m_oWorker.CancelAsync();
                Algorithm_Done = false;
            }
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            OnDataAvailable(null);
            this.Close();
        }

        #endregion

    }
}
