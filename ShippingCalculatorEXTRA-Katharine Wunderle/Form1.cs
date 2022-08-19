using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShippingCalculatorEXTRA_Katharine_Wunderle
{
    //Author: Katharine Wunderle
    //ID: 623748
    //Date: 03/14/2021
    //Goal: Calculate shipping cost based on package weight and shipping zone
    public partial class shipCalc : Form
    {
        //Zone price constants
        const decimal ppp = 18m;
        public shipCalc()
        {
            InitializeComponent();
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            //Package weight variable
            decimal pkgWgt = 0;
            //Zone input variable
            decimal zonePrice = 0;
            bool tryParseResult;
            //Output variables
            decimal wgtCst = 0;
            decimal ttlCst = 0;

            //Clear calculation and capped labels with new calculation 
            wgtCstOtpt.Text = "";
            znCstOtpt.Text = "";
            ttlCstOtpt.Text = "";
            cpdLbl.Text = "";
            //INPUT
            //Get package weight and verify value from user
            tryParseResult = decimal.TryParse(pkgWgtIpt.Text, out pkgWgt);
            if (tryParseResult == false || pkgWgt <= 0)
            {
                MessageBox.Show("Error: Please enter a positive, numeric weight");
                    return; }
            //Get zone code from radio button
            if (nRad.Checked == true)
            { zonePrice = 27m; }
            else if (sRad.Checked == true)
            { zonePrice = 36m; }
            else if (eRad.Checked == true)
            { zonePrice = 45m; }
            else if (wRad.Checked == true)
            { zonePrice = 54m; }
            //Show error message is no button is selected
            else
            { MessageBox.Show("Error: Please Pick a Zone");
                return;
            }
            //CALCULATIONS
            //Calculate weight cost
            wgtCst = pkgWgt * ppp;
            //Calculate total cost
            ttlCst = wgtCst + zonePrice;

            //Cap shipping cost at $100
            if (ttlCst > 100)
            { ttlCst = 100;
                cpdLbl.Text = "CAPPED";
            }
            else
                { cpdLbl.Text = ""; }

            //OUTPUT
            //Display weight cost
            wgtCstOtpt.Text = wgtCst.ToString("c");
            //Display shipping zone cost
            znCstOtpt.Text = zonePrice.ToString("c");
            //Display total cost
            ttlCstOtpt.Text = ttlCst.ToString("c");
        }
    }
}
