using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TypeOfPipeInsulatuion
{

    public partial class Form1 : System.Windows.Forms.Form
    {
        public List<TypeOfInsulation> customList { get; set; }
        
    
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
        }

        private void TypesOfInsulationChekedBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (TypesOfInsulationChekedBox.SelectedIndex == 0)
            {
                DiametersGridView.Rows.Add(customList[0].Diameters.Count());
                for (int i = 0; i <=customList[0].Diameters.Count(); i++)
                    DiametersGridView[0,customList[0].Diameters.Count()].Value = customList[0].Diameters[i];
            }
            if (TypesOfInsulationChekedBox.SelectedIndex == 1)
            {
                DiametersGridView.Rows.Add(customList[1].Diameters.Count());
                for (int i = 0; i <= customList[1].Diameters.Count(); i++)
                    DiametersGridView[0, customList[1].Diameters.Count()].Value = customList[1].Diameters[i];
            }
            if (TypesOfInsulationChekedBox.SelectedIndex == 2)
            {
                DiametersGridView.Rows.Add(customList[2].Diameters.Count());
                for (int i = 0; i <= customList[2].Diameters.Count(); i++)
                    DiametersGridView[0, customList[2].Diameters.Count()].Value = customList[2].Diameters[i];
            }

        }

        private void DiametersGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((DiametersGridView.CurrentCell.GetType() != typeof(int)) || ((int)DiametersGridView.CurrentCell.Value <= 0))
                MessageBox.Show("Вводимое значение должно быть положительным числом");
        }
    }
    
}
