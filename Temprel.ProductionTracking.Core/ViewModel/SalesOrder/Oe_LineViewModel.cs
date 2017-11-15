using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temprel.ProductionTracking.Data;
using Temprel.ProductionTracking.Data.Entities;

namespace Temprel.ProductionTracking.Core
{
    /// <summary>
    /// A viewmodel for the Oe_line control
    /// </summary>
    public class Oe_LineViewModel: BaseViewModel
    {
        public ICollection<status> Statuses
        {
            get;
        }

        public status SelectedStatus { get; set; }
        public status SelectedStatusBulk { get; set; }
        public oe_line SelectedLine { get; set;}

        public Oe_LineModel Oe_LineModel { get; set; }

        #region Contstructor
        public Oe_LineViewModel()
        {
            Statuses = IoC.Context.GetStatuses();
            Oe_LineModel = new Oe_LineModel();
        }

        public Oe_LineViewModel(Oe_LineModel model)
        {
            Statuses = IoC.Context.GetStatuses();
            Oe_LineModel = model;
        }
        #endregion

        #region events
        public void OnOrderHeaderLoaded(object source, EventArgs e)
        {
            //TODO: Load data 

            Console.WriteLine("Yeah we got to OnOrderHeaderLoaded inside Oe_LineViewModel");
        }
        #endregion
    }
}
