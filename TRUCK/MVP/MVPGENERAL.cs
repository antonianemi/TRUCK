using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRUCK.MVP
{
    public class MVPGeneral
    {
        public interface IRequiredViewOpc
        {
            void ShowEscenaInicial();
            void ShowEscenaAccessDenied();
            void ShowEscenaAccess();
            void ClearControls();
            void BindDataToView(ENT_CONFIGURATION obj);
            void sendDataFromView();
            ENT_CONFIGURATION getDataFromView();
        }


        public interface IPresenterOpc
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            void saveConfiguration(ENT_CONFIGURATION obj);
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            void loadConfiguration();
            /// <summary>
            /// Clean all controls in the form.
            /// </summary>
            void clear();
            /// <summary>
            /// Allows edit the form.
            /// </summary>
            void Edit();
            /// <summary>
            /// Allows 
            /// </summary>
            void Close();
        }


        public interface IRequiredPresenterOpc
        {
            void Error();
            void DataSavedSucess();
            /// <summary>
            /// 
            /// </summary>
            string MessageError { get; }
        }



        public interface IModelOpc
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="obj"></param>
            void saveConfiguration(ENT_CONFIGURATION obj);
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            ENT_CONFIGURATION getConfiguration();

        }
    }
}
