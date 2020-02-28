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
    public class TypeOfInsulation 
    {
        public Dictionary<int, List<PipeInsulation>> InstanceGroups { get; private set; }
        public int[] Diameters { get; private set; }
        public PipeInsulationType RevitType { get; }

        public TypeOfInsulation(PipeInsulationType revitType)
        {
            InstanceGroups = new Dictionary<int, List<PipeInsulation>>();
            RevitType = revitType;
        }
        public Dictionary<int, List<PipeInsulation>> GroupInstanceByHostDiameter(FilteredElementCollector allInsulations)
        {
            List<PipeInsulation> list = new List<PipeInsulation>();
            foreach( PipeInsulation insulation in allInsulations)
            {
                if (insulation.GetTypeId() == RevitType.Id)
                {
                    if (!(RevitType.Document.GetElement(insulation.HostElementId) is Pipe))                      
                        continue;                       
                    list.Add(insulation);                    
                }
            }
           
            Dictionary<int, List<PipeInsulation>> instanceGroups = new Dictionary<int, List<PipeInsulation>>();
            instanceGroups = list.GroupBy(x =>
            {
                Pipe hostPipe = RevitType.Document.GetElement(x.HostElementId) as Pipe;
                var diameterInFeet = hostPipe.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER).AsDouble();
                var diameterInMM = diameterInFeet * 304.8;
                int diameter = (int)Math.Round(diameterInMM);
                return diameter;
            }
            ).ToDictionary(x => x.Key, y => y.ToList());

            InstanceGroups = instanceGroups;

            Diameters = new int[InstanceGroups.Count];

            return InstanceGroups;
        }
       
    }
        

        
}

