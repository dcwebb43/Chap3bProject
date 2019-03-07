using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chap3bProject
{
    public partial class frmRoomCharge : Form
    {

        //Declare fields here...
        private decimal fDecGrandTotal;

        public frmRoomCharge()
        {
            InitializeComponent();
        }

        private void frmRoomCharge_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();         
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // declare variables and constants...
                int intNights;
                decimal decNightlyCharge, decRoomService, decPhone, decMisc,
                    decRoomCharges, decAddCharges, decSubtotal, decTax, decTotal;
                const decimal decTaxRate=.09m;
                // convert textbox values into numeric...
                intNights = int.Parse(txtNights.Text);
                decNightlyCharge = decimal.Parse(txtNightlyCharge.Text);
                decRoomService = decimal.Parse(txtRoomService.Text);
                decPhone = decimal.Parse(txtTelephone.Text);
                decMisc = decimal.Parse(txtMisc.Text);
                // perform calculations
                decRoomCharges = intNights * decNightlyCharge;
                decAddCharges = decRoomService + decPhone + decMisc;
                decSubtotal = decRoomCharges + decAddCharges;
                decTax = decSubtotal * decTaxRate;
                decTotal = decSubtotal + decTax;
                // increment summary field variable for grand total
                //fDecGrandTotal = fDecGrandTotal + decTotal;
                fDecGrandTotal += decTotal;
                // display output...
                lblRoomCharges.Text = decRoomCharges.ToString("n");
                lblAdditionalCharges.Text = decAddCharges.ToString("n");
                lblSubtotal.Text = decSubtotal.ToString("n");
                lblTax.Text = decTax.ToString("n");
                lblTotal.Text = decTotal.ToString("c");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem during calculations." + "\n" + ex.Message);
            }
        }

        private void btnShowGrandTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Grand Total Charges = " + fDecGrandTotal.ToString("c"));
        }
    }
}
