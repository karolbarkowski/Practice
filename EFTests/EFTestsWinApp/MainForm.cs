using Context;
using Context.Log;
using EFTestsWinApp.UI;
using Models;
using System.Data.Entity.Infrastructure.Interception;
using System.Windows.Forms;

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

        private static void CheckInsert(EfTestsContext context)
        {
            context.ProductCategories.Add(new ProductCategory()
            {
                Name = "PC1"
            });

            context.SaveChanges();
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



        private void BtnRunAndLogQuery_Click(object sender, System.EventArgs e)
        {
            pnlControls.Enabled = false;
            DbInterception.Add(dbInterceptor);
            CheckInsert(context);
            DbInterception.Remove(dbInterceptor);
            pnlControls.Enabled = true;
        }

        private void DbInterceptor_EventLogged(object sender, LogEntry e)
        {
            AddLogLabel(e.CommandName);
        }


        private void BtnBenchmarkTime_Click(object sender, System.EventArgs e)
        {
            pnlControls.Enabled = false;
            int iterations = (int)numIterations.Value;

            double ms = Clock.BenchmarkTime(() => CheckInsert(context), iterations);

            AddLogLabel(string.Format("Time elapsed for {0} iterations: {1} ms.", iterations, ms));
            pnlControls.Enabled = true;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            context.Dispose();
        }
    }
}
