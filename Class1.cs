using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Plumbing;

namespace TypeOfPipeInsulatuion
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]

   
    public class Class1 : IExternalCommand 
         
    {
        public Result Execute(
        ExternalCommandData commandData,
        ref string message,
        ElementSet elements)
        {
            
            UIApplication uiApp = commandData.Application;
            UIDocument uiDoc = uiApp.ActiveUIDocument;
            Document doc = uiApp.ActiveUIDocument.Document;
            Form1 ui = new Form1();
            ui.uiDoc = uiDoc;
            ui.Show();
           

            FilteredElementCollector pipeInsulations = new FilteredElementCollector(doc).OfClass(typeof(PipeInsulation));
           
            FilteredElementCollector typesOfInsulations = new FilteredElementCollector(doc).OfClass(typeof(PipeInsulationType));
            List<TypeOfInsulation> customList = new List<TypeOfInsulation>();

            
        List<int> diametres = new List<int>();
            foreach (PipeInsulationType type in typesOfInsulations)
            {
                TypeOfInsulation customType = new TypeOfInsulation(type);                
                var dict = customType.GroupInstanceByHostDiameter(pipeInsulations);
                string msg = string.Join(" ", dict.Keys.ToArray());
                System.Windows.Forms.MessageBox.Show(type.Name + "\n" + msg);
                System.Windows.Forms.MessageBox.Show(customType.Diameters.Count().ToString());
                customList.Add(customType);               
            }

            ui.TypesOfInsulationChekedBox.Items.AddRange(customList.ConvertAll(x=>x.RevitType.Name).ToArray());
            

            return Result.Succeeded;
        }
    }
}
