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
            CleanViewFields();
        }

        private void SaveActivity(object sender, EventArgs e)
        {
            var model = new ActivityModel();
            model.Id = Convert.ToInt32(view.ActivityId);
            model.Name = view.ActivityName;
            model.Description = view.ActivityDescription;
            model.Type = view.ActivityType;
            model.DescriptionURL = view.ActivityDescriptionURL;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit) //edit model
                {
                    repository.Edit(model);
                    view.Message = "Atividade editada com sucesso";
                } 
                else //add new model
                {
                    repository.Add(model);
                    view.Message = "Atividade adicionada com sucesso";
                }
                view.IsSuccessful = true;
                LoadAllActivityList();
                CleanViewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message= ex.Message;
            }
        }

        private void CleanViewFields()
        {
            view.ActivityId = "0";
            view.ActivityName = "";
            view.ActivityDescription = "";
            view.ActivityType = "";
            view.ActivityDescriptionURL = "";
        }

        private void DeleteSelectedActivity(object sender, EventArgs e)
        {
            try
            {
                var activity =  (ActivityModel)activitiesBindingSource.Current;
                repository.Delete(activity.Id);
                view.IsSuccessful = true;
                view.Message = "Atividade excluída sucedidamente";
                LoadAllActivityList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message= "Um erro ocorreu, a atividade não pode ser excluída.";
            }
        }

        private void LoadSelectedActivityToEdit(object sender, EventArgs e)
        {
            var activity = (ActivityModel)activitiesBindingSource.Current;
            view.ActivityId = activity.Id.ToString();
            view.ActivityName = activity.Name;
            view.ActivityDescription = activity.Description;
            view.ActivityType = activity.Type;
            view.ActivityDescriptionURL = activity.DescriptionURL;
            view.IsEdit = true;
        }

        private void AddNewActivity(object sender, EventArgs e)
        {
            view.IsEdit = false;
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
