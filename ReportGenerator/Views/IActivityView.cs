using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportGenerator.Views
{
    public interface IActivityView
    {
        // Properties - Fields
        string ActivityId { get; set; }
        string ActivityName { get; set; }
        string ActivityDescription { get; set; }
        string ActivityType { get; set; }
        string ActivityDescriptionURL { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        //Methods
        void SetActivityBindingSource(BindingSource activityList);
        void Show(); //Optional
    }
}
