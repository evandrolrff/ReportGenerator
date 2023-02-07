using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReportGenerator.Models;
using ReportGenerator.Views;

namespace ReportGenerator.Presenters
{
    public class ActivityPresenter
    {
        //Fields
        private IActivityView view;
        private IActivityRepository repository;
        private BindingSource activitiesBindingSource;
        private IEnumerable<ActivityModel> activitiesList;

        //Constructor
        public ActivityPresenter(IActivityView view, IActivityRepository repository)
        {
            this.activitiesBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchActivity;
            this.view.AddNewEvent += AddNewActivity;
            this.view.EditEvent += LoadSelectedActivityToEdit;
            this.view.DeleteEvent += DeleteSelectedActivity;
            this.view.SaveEvent += SaveActivity;
            this.view.CancelEvent += CancelAction;

            //Set activity binding source
            this.view.SetActivityBindingSource(this.activitiesBindingSource);

            //Load activity list view
            LoadAllActivityList();

            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllActivityList()
        {
            activitiesList = repository.GetAll();
            activitiesBindingSource.DataSource = activitiesList; //Set data source
        }

        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveActivity(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteSelectedActivity(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadSelectedActivityToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddNewActivity(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SearchActivity(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrEmpty(this.view.SearchValue);

            if (emptyValue)
            {
                activitiesList = repository.GetAll();
            }
            else
            {
                activitiesList = repository.GetByValue(this.view.SearchValue);
            }

            activitiesBindingSource.DataSource = activitiesList;
        }
    }
}
