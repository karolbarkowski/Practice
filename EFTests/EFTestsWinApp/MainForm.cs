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

        public MainForm()
        {
            InitializeComponent();

            //initialize context and custom query logger
            context = new EfTestsContext();

            //set custom db interceptor that will take care of logging internally
            CustomDbInterceptor dbInterceptor = new CustomDbInterceptor();
            dbInterceptor.EventLogged += DbInterceptor_EventLogged;
            DbInterception.Add(dbInterceptor);
        }

        private void DbInterceptor_EventLogged(object sender, LogEntry e)
        {
            GrowLabel label = new GrowLabel()
            {
                Text = e.CommandName,
                Width = panelLogPreview.Width - 10,
                Margin = new Padding(3, 0, 0, 10)
            };
            panelLogPreview.Controls.Add(label);
            panelLogPreview.Controls.SetChildIndex(label, 0);
        }

        private static void CheckInsert(EfTestsContext context)
        {
            context.ProductCategories.Add(new ProductCategory()
            {
                Name = "PC1"
            });

            context.SaveChanges();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            CheckInsert(context);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            context.Dispose();
        }
    }
}
