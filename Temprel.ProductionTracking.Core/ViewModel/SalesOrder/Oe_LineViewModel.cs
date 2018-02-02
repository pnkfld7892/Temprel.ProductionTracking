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

        private bool BulkOps { get => !(SelectedStatusBulk == null); }

        public RelayCommand UpdateCommand { get; set; }
        public Oe_LineModel Oe_LineModel { get; set; }

        public ICollection<Data.Entities.oe_line> Lines { get => Oe_LineModel.Lines; }

        #region Contstructor
        public Oe_LineViewModel()
        {
            Statuses = IoC.Context.GetStatuses();
            Oe_LineModel = new Oe_LineModel();
            UpdateCommand = new RelayCommand(Update);
        }

        public Oe_LineViewModel(Oe_LineModel model)
        {
            Statuses = IoC.Context.GetStatuses();
            Oe_LineModel = model;
            UpdateCommand = new RelayCommand(Update);
        }
        #endregion

        #region events
        public void OnOrderHeaderLoaded(object source, OrderHeaderLoadedEventArgs e)
        {
            //TODO: Load data 

            Console.WriteLine("Yeah we got to OnOrderHeaderLoaded inside Oe_LineViewModel\nOrder No: {0}",e.OrderNo);
            Oe_LineModel = IoC.Context.GetOe_Line(e.OrderNo);
        }

        public EventHandler<EventArgs> OrderUpdated;
        public void OnOrderUpdated()
        {
            OrderUpdated?.Invoke(this, EventArgs.Empty);     
        }

        #endregion

        #region Commands
        protected void Update()
        {
            if(BulkOps)
            {
                foreach(var l in Lines)
                {
                    l.status = SelectedStatusBulk;
                }
                        
            }
            IoC.Context.UpdateOrder(this.Oe_LineModel);

            Clear();
            OrderUpdated(this,EventArgs.Empty);

        }

        private void Clear()
        {
            SelectedStatus = null;
            SelectedStatusBulk = null;
            SelectedLine = null;

            Oe_LineModel = new Oe_LineModel();
        }
        #endregion
    }
}
