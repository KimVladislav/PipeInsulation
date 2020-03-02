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
using System.Xml;
using System.Windows.Forms;

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

            FilteredElementCollector pipeInsulations = new FilteredElementCollector(doc).OfClass(typeof(PipeInsulation));         
            FilteredElementCollector typesOfInsulations = new FilteredElementCollector(doc).OfClass(typeof(PipeInsulationType));
            FilteredElementCollector pipes = new FilteredElementCollector(doc).OfClass(typeof(Pipe));
            if (pipes.Count() == 0)
            {
                System.Windows.Forms.MessageBox.Show("В данном проекте нет труб");
                return Result.Cancelled;
            }
            Pipe pipe = pipes.FirstOrDefault() as Pipe;
            Parameter param = (pipe as Element).LookupParameter("Изоляция_Диаметр");
            ////if (null == param)
            //{
            //   // System.Windows.Forms.MessageBox.Show("В данном проекте нет параметра \"Изоляция_Диаметр\"");
            //   // return Result.Cancelled;
            //}
            List<TypeOfInsulation> customList = new List<TypeOfInsulation>();
            
            foreach (PipeInsulationType type in typesOfInsulations)
            {
                 TypeOfInsulation customType = new TypeOfInsulation(type);
                 var dict = customType.GroupInstanceByHostDiameter(pipeInsulations);
                 customList.Add(customType);
            }

            ui.FormCustomList = customList;            
            ui.TypesOfInsulationCheckedListBox.Items.AddRange(customList.ConvertAll(x => x.RevitType.Name).ToArray());
            var uiResult = ui.ShowDialog();

            if (uiResult != System.Windows.Forms.DialogResult.OK)
                return Result.Cancelled;
            Transaction tr = new Transaction(doc, "Диаметр изоляции");
            tr.Start();
            foreach (int checkedIndex in ui.TypesOfInsulationCheckedListBox.CheckedIndices)
            {
                TypeOfInsulation type = customList[checkedIndex];
                
                foreach(int diameter in type.Diameters)               
                {                                      
                    if (diameter != 0)
                    {
                        foreach (var pipeInslationList in type.InstanceGroups.Values)
                        {
                            foreach ( var pipeInsulation in pipeInslationList)
                            {
                                Pipe p = customList[checkedIndex].RevitType.Document.GetElement(pipeInsulation.HostElementId) as Pipe;
                                p.LookupParameter("Изоляция_Диаметр").Set(diameter.ToString());
                            }
                        }
                    }                    
                }
            }
            tr.Commit();
            return Result.Succeeded;
        }
    }
}
