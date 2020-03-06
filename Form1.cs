using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace TypeOfPipeInsulatuion
{

    public partial class Form1 : System.Windows.Forms.Form
    {
        public List<TypeOfInsulation> FormCustomList { get; set; }


        public Autodesk.Revit.UI.UIDocument uiDoc { get; set; }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DiametersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TypesOfInsulationChekedBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void TypesOfInsulationCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DiametersGridView.Rows.Clear();

            if (TypesOfInsulationCheckedListBox.SelectedIndex < 0)
            {
                return;
            }

            var selectedType = FormCustomList[TypesOfInsulationCheckedListBox.SelectedIndex];

            foreach (var pair in selectedType.InstanceGroups)
            {
                DiametersGridView.Rows.Add(pair.Key, string.Empty);
            }

            for (int i = 0; i < selectedType.Diameters.Length; i++)
            {
                if (selectedType.Diameters[i] != 0)
                    DiametersGridView[1, i].Value = selectedType.Diameters[i];
            }
        }

        private void DiametersGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (FormCustomList == null)
            {
                return;
            }

            var customTypeOfInsulation = FormCustomList[TypesOfInsulationCheckedListBox.SelectedIndex]; 
            if((customTypeOfInsulation.Diameters[e.RowIndex] == 0))
                customTypeOfInsulation.Diameters[e.RowIndex] = int.Parse(DiametersGridView[e.ColumnIndex, e.RowIndex].Value.ToString());

        }



        private void DiametersGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(UserInsulationDiameter_KeyPress);
            if (DiametersGridView.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(UserInsulationDiameter_KeyPress);
                }
            }
        }
        private void UserInsulationDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml файлы (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XDocument xDoc = new XDocument();
                var allTypes = new XElement("AllTypes");

                foreach (int checkedIndex in TypesOfInsulationCheckedListBox.CheckedIndices)
                {
                    var selectedType = FormCustomList[checkedIndex];
                    var name = selectedType.RevitType.Name;
                    var index = checkedIndex.ToString();
                    var typeNode = new XElement("Type");
                    XAttribute typeName = new XAttribute("TypeName", name);
                    XAttribute typeIndex = new XAttribute("TypeIndex", index);
                    typeNode.Add(typeIndex);
                    typeNode.Add(typeName);
                   
                    for (int i = 0; i < selectedType.Diameters.Length; i++)
                    {
                        
                        var inputedDiameter = selectedType.Diameters[i].ToString();
                        var revitDiameter = selectedType.InstanceGroups.Keys.ToList()[i];
                        if (int.Parse(inputedDiameter) == 0)
                            continue;
                        XElement pairOfElements = new XElement("PairOfDiameters");
                        var j = i;
                        var input = new XElement("InputedDiameter");
                        input.Add(inputedDiameter);
                        var revit = new XElement("RevitDiameter");
                        revit.Add(revitDiameter);
                        XAttribute pairIndex = new XAttribute("PairIndex", j.ToString());
                        pairOfElements.Add(input);
                        pairOfElements.Add(revit);
                        pairOfElements.Add(pairIndex);
                        typeNode.Add(pairOfElements);
                    }
                    allTypes.Add(typeNode);
                }
                xDoc.Add(allTypes);
                xDoc.Save(saveFileDialog1.FileName);
            }
        }

        private void UpdateGridView(TypeOfInsulation selectedType)
        {
            DiametersGridView.Rows.Clear();
            foreach (var pair in selectedType.InstanceGroups)
            {                
                 DiametersGridView.Rows.Add(pair.Key, string.Empty);
            }

            for (int i = 0; i < selectedType.Diameters.Length; i++)
            {
                if (selectedType.Diameters[i] != 0)
                    DiametersGridView[1, i].Value = selectedType.Diameters[i];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "xml файлы (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    DiametersGridView.Rows.Clear();
                    XDocument xDoc = XDocument.Load(filePath); 
                    XElement allTypesNode = xDoc.Element("AllTypes");
                    
                    foreach (XElement typeNode in allTypesNode.Descendants("Type"))
                    {
                        var currentIndex = int.Parse(typeNode.Attribute("TypeIndex").Value);
                        if (FormCustomList[currentIndex].RevitType.Name == typeNode.Attribute("TypeName").Value)
                        {
                            foreach (XElement pairNode in typeNode.Descendants("PairOfDiameters"))
                            {

                                foreach (var pair in FormCustomList[currentIndex].InstanceGroups)
                                {
                                    var pairIndex = int.Parse(pairNode.Attribute("PairIndex").Value);
                                    if (pair.Key == int.Parse(pairNode.Element("RevitDiameter").Value))
                                    {
                                        FormCustomList[currentIndex].Diameters[pairIndex] = int.Parse(pairNode.Element("InputedDiameter").Value);

                                    }

                                }

                            }

                        }
                        UpdateGridView(FormCustomList[currentIndex]);
                    }
                    
                }
            }
        }
    }
}

    