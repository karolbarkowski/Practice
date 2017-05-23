using Context;
using Context.Log;
using EFTestsWinApp.UI;
using System.Data.Entity.Infrastructure.Interception;
using System.Windows.Forms;
using System.Linq;
using System.Data.Entity;

namespace EFTestsWinApp
{
    public partial class MainForm : Form
    {
        EfTestsContext context;
        CustomDbInterceptor dbInterceptor;

        public MainForm()
        {
            InitializeComponent();

            //initialize context and custom query logger
            context = new EfTestsContext();

            //set custom db interceptor that will take care of logging internally
            dbInterceptor = new CustomDbInterceptor();
            dbInterceptor.EventLogged += DbInterceptor_EventLogged;
        }





        private void BtnRunAndLogQuery_Click(object sender, System.EventArgs e)
        {
            pnlControls.Enabled = false;
            DbInterception.Add(dbInterceptor);

            var products = context.Products.ToList();

            DbInterception.Remove(dbInterceptor);
            pnlControls.Enabled = true;
        }

        private void DbInterceptor_EventLogged(object sender, LogEntry e)
        {
            AddLogLabel(e.CommandName);
        }


        private void BtnBenchmarkTime_Click(object sender, System.EventArgs e)
        {

        }

        private void btnSelectFromView_Click(object sender, System.EventArgs e)
        {

        }

        private void btnSelectByRelation_Click(object sender, System.EventArgs e)
        {
            pnlControls.Enabled = false;

            int iterations = (int)numIterations.Value;
            int index = 0;
            DbInterception.Add(dbInterceptor);

            double ms = Clock.BenchmarkTime(() =>
            {
                var products = context.Products.Include(p => p.Categories).ToList();

                if (index == 0)
                {
                    DbInterception.Remove(dbInterceptor);
                }
                index++;
            }, iterations);

            AddLogLabel("Generated query:");
            AddLogLabel(string.Format("Time elapsed for {0} iterations: {1} ms.", iterations, ms));
            AddLogLabel("Selected by relation results:");

            pnlControls.Enabled = true;
        }


        private void AddLogLabel(string text)
        {
            GrowLabel label = new GrowLabel()
            {
                Text = text,
                Width = panelLogPreview.Width - 50,
                Margin = new Padding(3, 0, 0, 10)
            };
            panelLogPreview.Controls.Add(label);
            panelLogPreview.Controls.SetChildIndex(label, 0);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            context.Dispose();
        }
    }
}
