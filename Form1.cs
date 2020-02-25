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
            
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
