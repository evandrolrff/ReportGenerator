using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportGenerator.Views
{
    public partial class ActivityView : Form, IActivityView
    {
        //Fields
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        // Constructor
        public ActivityView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl.TabPages.Remove(tabPage2);
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtBoxSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            //Others
        }

        //Properties
        public string ActivityId 
        { 
            get { return txtBoxID.Text; } 
            set { txtBoxID.Text = value; } 
        }
        public string ActivityName 
        { 
            get { return txtBoxName.Text; } 
            set { txtBoxName.Text = value; } 
        }
        public string ActivityDescription 
        { 
            get { return txtBoxDescription.Text; } 
            set { txtBoxDescription.Text = value; } 
        }
        public string ActivityType 
        { 
            get { return txtBoxTipo.Text; } 
            set { txtBoxTipo.Text = value; } 
        }
        public string ActivityDescriptionURL 
        { 
            get { return txtBoxDescriptionURL.Text; } 
            set { txtBoxDescriptionURL.Text = value; } 
        }
        public string SearchValue 
        {
            get { return txtBoxSearch.Text; }
            set { txtBoxSearch.Text = value;  }
        }
        public bool IsEdit 
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        public bool IsSuccessful 
        {
            get { return isSuccessful; } 
            set { isSuccessful = value; }
        }
        public string Message 
        { 
            get { return message; }  
            set { message = value; } 
        }

        // Events
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        // Methods
        public void SetActivityBindingSource(BindingSource activityList)
        {
            dataGridView1.DataSource = activityList;
        }
    }
}
