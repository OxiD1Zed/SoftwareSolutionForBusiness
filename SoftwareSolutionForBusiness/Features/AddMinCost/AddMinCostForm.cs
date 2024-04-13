using System;
using System.Windows.Forms;

namespace SoftwareSolutionForBusiness.Features.AddMinCost
{
    public partial class AddMinCostForm : Form
    {
        private readonly Action<decimal> _addMinCostEvent; 

        public AddMinCostForm(decimal startValue, Action<decimal> addMinCostEvent)
        {
            InitializeComponent();
            numericMinCost.Maximum = decimal.MaxValue;
            numericMinCost.Value = startValue;
            _addMinCostEvent = addMinCostEvent;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if(_addMinCostEvent != null)
            {
                _addMinCostEvent(numericMinCost.Value);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
