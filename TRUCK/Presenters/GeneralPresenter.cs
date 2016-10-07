using System;
using TRUCK.MVP;

namespace TRUCK
{
    public class GeneralPresenter : MVPGeneral.IPresenterOpc, MVPGeneral.IRequiredPresenterOpc
    {

        MVPGeneral.IModelOpc _model;
        MVPGeneral.IRequiredViewOpc _view;

        public GeneralPresenter(MVPGeneral.IRequiredViewOpc view)
        {
            _model = new ModelGeneral(this);
            _view = view;
        }

        public string MessageError
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        /// <summary>
        /// Clean the view.
        /// </summary>
        public void clear()
        {
            _view.ClearControls();
        }
        /// <summary>
        /// Close the view.
        /// </summary>
        public void Close()
        {
            
        }

        public void DataSavedSucess()
        {
           //Notify that the dats was saved sucessfully
        }

        public void Edit()
        {
           
        }

        public void Error()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Load data from database
        /// </summary>
        public void loadConfiguration()
        {
            _view.BindDataToView(_model.getConfiguration());
        }

        public void saveConfiguration(ENT_CONFIGURATION obj)
        {
            _model.saveConfiguration(obj);
        }
    }
}
