#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

#endregion

namespace WPFCourse
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Step 1: put any code needed for the form here

            // Step 2: Open form
            MyForm currentForm = new MyForm()
            {
                Width = 500,
                Height = 450,
                WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
                Topmost = true,
            };

            currentForm.ShowDialog();

            // Step 4: get form data and do something

            if(currentForm.DialogResult == false) 
            {
                //do something
                return Result.Cancelled;
            }
            
            //assumed clicked ok so code continues

            //string textboxresult = currentForm.tbx.Text;
            string textboxresult = currentForm.getTextboxValue();            

            bool checkbox1value = currentForm.getcheckbox1();

            string radiobuttonvalue = currentForm.GetGroup1();

            TaskDialog.Show("Test", "textbox result is " + textboxresult);

            if(checkbox1value==true)
            {
                TaskDialog.Show("Test", "checkbox1 was selected");
            }

            TaskDialog.Show("test", radiobuttonvalue);

            return Result.Succeeded;
        }

        public static String GetMethod()
        {
            var method = MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            return method;
        }
    }
}
