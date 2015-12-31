using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDLMLab
{
    public partial class NoveMeranieWindow : Form
    {
        [Serializable]
        private class ValidateParametersException : Exception
        {
            public ValidateParametersException()
            {
            }

            public ValidateParametersException(string message) : base(message)
            {
            }

            public ValidateParametersException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected ValidateParametersException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        public NoveMeranieWindow()
        {
            InitializeComponent();

            //dynamicky nabindovane hodnoty a kluce pre dropdown list
            Dictionary<string, double> dict = new Dictionary<string, double>();
            dict.Add("1/8", 0.125);
            dict.Add("1/16", 0.0625);
            dict.Add("1/32", 0.03125);

            stepTimeFieldMs.DataSource = new BindingSource(dict, null);
            stepTimeFieldMs.DisplayMember = "Key";
            stepTimeFieldMs.ValueMember = "Value";

            stepTimeField2DMs.DataSource = new BindingSource(dict, null);
            stepTimeField2DMs.DisplayMember = "Key";
            stepTimeField2DMs.ValueMember = "Value";

            
        }
        public MeasurementParameters parametreMerania;

        
        private void runClick(object sender, EventArgs e)
        {
            try {
                nastavParametre();
                DialogResult = DialogResult.OK; //okno sa zatvori a parameter parametreMerania bude pripraveny na meranie
            }
            catch (ValidateParametersException ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Chyba",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            

        }

        /// <summary>
        /// tato metoda da do fieldu parametreMerania parametre merania konkretneho typu
        /// </summary>
        private void nastavParametre()
        {
            //zistit aky typ je vybraty
            if (typyMeraniaTaby.SelectedTab.Text.Equals("Energy Scan"))
            {
                try
                {
                    validateEnergyScanTab();
                    parametreMerania = new EnergyScanParameters(Convert.ToDouble(startPointFieldEs.Text), Convert.ToDouble(endPointFieldEs.Text), Convert.ToDouble(constantFieldEs.Text), Convert.ToDouble(stepTimeFieldEs.Text), Convert.ToInt32(pocetKrokovFieldEs.Text));
                    parametreMerania.setParameters(nameField
                        .Text, Convert.ToDouble(resolutionFieldEs.Text), Convert.ToInt32(pocetCyklovField.Value), noteField.Text);
                    
                    ulozParametreEnergyScan();
                }
                catch (ValidateParametersException e)
                {
                    throw e;
                }
                
                
            }
            else if (typyMeraniaTaby.SelectedTab.Text.Equals("Mass Scan"))
            {
                try
                {
                    validateMassScanTab();
                
                
                    parametreMerania = new MassScanParameters(Convert.ToDouble(startPointFieldMs.Text), Convert.ToDouble(endPointFieldMs.Text), Convert.ToDouble(constantFieldMs.Text), (double)stepTimeFieldMs.SelectedValue);
                    parametreMerania.setParameters(nameField
                        .Text, Convert.ToDouble(resolutionFieldMs.Text), Convert.ToInt32(pocetCyklovField.Value), noteField.Text);
                    ulozParametreMassScan();
                }
                catch (ValidateParametersException e)
                {
                    throw e;
                }
            }
            else if (typyMeraniaTaby.SelectedTab.Text.Equals("2D Scan"))
            {
                try
                {
                    validateMass2DScanTab();
                
                    EnergyScanParameters parametreMeraniaEnergy = new EnergyScanParameters(Convert.ToDouble(startPointField2DEs.Text), Convert.ToDouble(endPointField2DEs.Text), 0, (double)stepTimeFieldMs.SelectedValue, Convert.ToInt32(pocetKrokovField2DEs.Text));


                    MassScanParameters parametreMeraniaMass = new MassScanParameters(Convert.ToDouble(startPointField2DMs.Text), Convert.ToDouble(endPointField2DMs.Text), 0, Convert.ToDouble(stepTimeField2DMs.Text));

                    parametreMerania = new Scan2DParameters(parametreMeraniaEnergy, parametreMeraniaMass);

                    parametreMerania.setParameters(nameField
                        .Text, Convert.ToDouble(resolutionFieldMs.Text), Convert.ToInt32(pocetCyklovField.Value), noteField.Text);

                    ulozParametre2DScan();
                }
                catch (ValidateParametersException e)
                {
                    throw e;
                }
            }
        }

        private void ulozParametre2DScan()
        {
            throw new NotImplementedException();
        }

        private void ulozParametreMassScan()
        {
            throw new NotImplementedException();
        }

        private void ulozParametreEnergyScan()
        {
            throw new NotImplementedException();
        }

        private void validateMass2DScanTab()
        {
            //skontrolovat prislusne fieldy, pre kazdy jeho ocakavanu hodnotu.. ak nie su spravne vyhodit vynimku o chybe s konkretnou spravou, 
            throw new ValidateParametersException("sprava o konretnej zlej hodnote");
        }

        private void validateMassScanTab()
        {
            //...
            throw new ValidateParametersException("sprava o konretnej zlej hodnote");
        }

        private void validateEnergyScanTab()
        {
            //...
            throw new ValidateParametersException("sprava o konretnej zlej hodnote");
        }

      

        private void NoveMeranieWindow_Load(object sender, EventArgs e)
        {
            
            
            //pre vsetky 3 taby, vyplnit hodnoty predvolene userom zo settings file
            //v subore maju prefix "e" pre energyscan, "m" pre massscan, 
            //"e2D" pre energy cast 2dscanu, a "m2D" pre mass scan cast 2dscanu

            startPointFieldEs.Text = PosledneParametreMerania.Default.eStartPoint.ToString();
            //......



            

        }


        private void cancelbutton_click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
    
        
    }