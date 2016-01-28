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

            public ValidateParametersException(string message)
                : base(message)
            {
            }

            public ValidateParametersException(string message, Exception innerException)
                : base(message, innerException)
            {
            }

            protected ValidateParametersException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        bool testRun;
        public NoveMeranieWindow()
        {
            InitializeComponent();

            //dynamicky nabindovane hodnoty a kluce pre dropdown list
            Dictionary<string, int> dict = new Dictionary<string, int>();
            if (Properties.Devices.Default.QmsType == 2048)
            {
                dict.Add("8", 8);
            }
                dict.Add("16", 16);
                dict.Add("32", 32);
            if (Properties.Devices.Default.QmsType == 1024 || Properties.Devices.Default.QmsType == 512)
            {
                dict.Add("64", 64);
            }

                DensOfMeasFieldMs.DataSource = new BindingSource(dict, null);
            DensOfMeasFieldMs.DisplayMember = "Key";
            DensOfMeasFieldMs.ValueMember = "Value";

            DensOfMeasField2DMS.DataSource = new BindingSource(dict, null);
            DensOfMeasField2DMS.DisplayMember = "Key";
            DensOfMeasField2DMS.ValueMember = "Value";

            Dictionary<string, int> dictTime = new Dictionary<string, int>();
            dictTime.Add("10 s", 10000);
            dictTime.Add("5 s", 5000);
            dictTime.Add("2 s", 2000);
            dictTime.Add("1 s", 1000);
            dictTime.Add("500 ms", 500);
            dictTime.Add("200 ms", 200);
            dictTime.Add("100 ms", 100);
            dictTime.Add("50 ms", 50);
            dictTime.Add("20 ms", 20);



            timePerAmuFieldMs.DataSource = new BindingSource(dictTime, null);
            timePerAmuFieldMs.DisplayMember = "Key";
            timePerAmuFieldMs.ValueMember = "Value";

            timePerAmuField2DMs.DataSource = new BindingSource(dictTime, null);
            timePerAmuField2DMs.DisplayMember = "Key";
            timePerAmuField2DMs.ValueMember = "Value";

            startPointField2DMs.Text = PosledneParametreMerania.Default.m2DStartPoint.ToString();
            endPointField2DMs.Text = PosledneParametreMerania.Default.m2DEndPoint.ToString();
            resolutionField2D.Text = PosledneParametreMerania.Default.m2DResolution.ToString();
            DensOfMeasField2DMS.Text = PosledneParametreMerania.Default.m2DDensOfMeas.ToString();
            timePerAmuField2DMs.Text = PosledneParametreMerania.Default.m2DTimePerAmu.ToString();
            steptimeField2DEs.Text = PosledneParametreMerania.Default.e2DStepTime.ToString();
            startPointField2DEs.Text = PosledneParametreMerania.Default.e2DStartPoint.ToString();
            endPointField2DEs.Text = PosledneParametreMerania.Default.e2DEndPoint.ToString();
            pocetKrokovField2DEs.Text = PosledneParametreMerania.Default.e2DPocetKrokov.ToString();

            startPointFieldMs.Text = PosledneParametreMerania.Default.mStart.ToString();
            endPointFieldMs.Text = PosledneParametreMerania.Default.mEnd.ToString();
            resolutionFieldMs.Text = PosledneParametreMerania.Default.mResolution.ToString();
            DensOfMeasFieldMs.Text = PosledneParametreMerania.Default.mDensOfMeas.ToString();
            constantFieldMs.Text = PosledneParametreMerania.Default.mKonstanta.ToString();
            MessageBox.Show(timePerAmuFieldMs.Text);
            timePerAmuFieldMs.SelectedValue = PosledneParametreMerania.Default.mTimePerAmu.ToString();

        }

        public MeasurementParameters parametreMerania;


        private void runClick(object sender, EventArgs e)
        {
            try
            {
                testRun = false;
                nastavParametre();
                DialogResult = DialogResult.OK; //okno sa zatvori a parameter parametreMerania bude pripraveny na meranie
            }
            catch (ValidateParametersException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /// <summary>
        /// tato metoda da do fieldu parametreMerania parametre merania konkretneho typu
        /// </summary>
        private void nastavParametre()
        {
            //zistit aky typ je vybraty
            
            if (typyMeraniaTaby.SelectedTab.Text.Equals("Energy scan"))
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
            else if (typyMeraniaTaby.SelectedTab.Text.Equals("Mass scan"))
            {
                try
                {
                    validateMassScanTab();


                    parametreMerania = new MassScanParameters(Convert.ToInt32(startPointFieldMs.Text), Convert.ToInt32(endPointFieldMs.Text), Convert.ToDouble(constantFieldMs.Text), (int)DensOfMeasFieldMs.SelectedValue);
                    parametreMerania.setParameters(nameField
                        .Text, Convert.ToDouble(resolutionFieldMs.Text), Convert.ToInt32(pocetCyklovField.Value), noteField.Text);
                    ulozParametreMassScan();
                }
                catch (ValidateParametersException e)
                {
                    throw e;
                }
            }
            else if (typyMeraniaTaby.SelectedTab.Text.Equals("2D scan"))
            {
                try
                {
                    validateMass2DScanTab();

                    EnergyScanParameters parametreMeraniaEnergy = new EnergyScanParameters(Convert.ToDouble(startPointField2DEs.Text), Convert.ToDouble(endPointField2DEs.Text),0.0,Convert.ToDouble(steptimeField2DEs.Text), Convert.ToInt32(pocetKrokovField2DEs.Text));

                    MassScanParameters parametreMeraniaMass = new MassScanParameters(Convert.ToInt32(startPointField2DMs.Text), Convert.ToInt32(endPointField2DMs.Text), 0, (double)DensOfMeasField2DMS.SelectedValue);

                    parametreMerania = new Scan2DParameters(parametreMeraniaEnergy, parametreMeraniaMass);
                    parametreMerania.setParameters(nameField
                        .Text, Convert.ToDouble(resolutionField2D.Text), Convert.ToInt32(pocetCyklovField.Value), noteField.Text);

                    ulozParametre2DScan();
                }
                catch (ValidateParametersException e)
                {
                    throw e;
                }
            }
            parametreMerania.testRun = testRun;
        }

        /// <summary>
        /// metoda na ulozanie akutalne zadanych parametrov pre 2dscan do settign filu PosledneParametreMerania. 
        /// nic nevaliduje. vola sa az po validacii, takze fieldy sa mozu bezpecne ulozit
        /// </summary>
        private void ulozParametre2DScan()
        {
            PosledneParametreMerania.Default.m2DStartPoint = int.Parse(startPointField2DMs.Text);
            PosledneParametreMerania.Default.m2DEndPoint = int.Parse(endPointField2DEs.Text);
            PosledneParametreMerania.Default.m2DResolution = double.Parse(resolutionField2D.Text);
            PosledneParametreMerania.Default.m2DDensOfMeas = int.Parse(DensOfMeasField2DMS.SelectedValue.ToString());
            PosledneParametreMerania.Default.m2DTimePerAmu = int.Parse(timePerAmuField2DMs.SelectedValue.ToString());
            PosledneParametreMerania.Default.e2DStepTime = double.Parse(steptimeField2DEs.Text);
            PosledneParametreMerania.Default.e2DStartPoint = double.Parse(startPointField2DEs.Text);
            PosledneParametreMerania.Default.e2DEndPoint = double.Parse(endPointField2DEs.Text);
            PosledneParametreMerania.Default.e2DPocetKrokov = int.Parse(pocetKrokovField2DEs.Text);
            PosledneParametreMerania.Default.Save();

        }

        private void ulozParametreMassScan()
        {
            PosledneParametreMerania.Default.mStart= int.Parse(startPointFieldMs.Text);
            PosledneParametreMerania.Default.mEnd = int.Parse(endPointFieldMs.Text);
            PosledneParametreMerania.Default.mResolution = double.Parse(resolutionFieldMs.Text);
            PosledneParametreMerania.Default.mDensOfMeas = int.Parse(DensOfMeasFieldMs.SelectedValue.ToString());
            PosledneParametreMerania.Default.mKonstanta= double.Parse(constantFieldMs.Text);
            PosledneParametreMerania.Default.mTimePerAmu = int.Parse(timePerAmuFieldMs.SelectedValue.ToString());
            //MessageBox.Show(timePerAmuFieldMs.SelectedValue.ToString());
            PosledneParametreMerania.Default.Save();

        }

        private void ulozParametreEnergyScan()
        {
            PosledneParametreMerania.Default.eStartPoint = double.Parse(startPointFieldEs.Text);
            PosledneParametreMerania.Default.eEndPoint = double.Parse(endPointFieldEs.Text);
            PosledneParametreMerania.Default.eResolution = double.Parse(resolutionFieldEs.Text);
            PosledneParametreMerania.Default.eStepTime = double.Parse(stepTimeFieldEs.Text);
            PosledneParametreMerania.Default.eKonstanta = int.Parse(constantFieldEs.Text);
            PosledneParametreMerania.Default.ePocetKrokov = int.Parse(pocetKrokovFieldEs.Text);
            PosledneParametreMerania.Default.Save();
        }

        private void validateMass2DScanTab()//treba upravit ak neni yadane vsetko tak by to padlo
        {
            Double startpointqms;
            Double endpointqms;
            Double startpointtem;
            Double endpointtem;
            Double resolution;
            string nazov;
            Double step;
            int krok;
            if (nameField.Text.Length <= 0 && !testRun)
            {

                throw new ValidateParametersException("nazov merania musi mat aspon jeden znak");
            }
           
			if (!Double.TryParse(startPointField2DEs.Text, out startpointqms)) throw new ValidateParametersException("Neplatná hodnota pre startpointtem");
            
            if (!Double.TryParse(endPointField2DEs.Text, out endpointqms)) throw new ValidateParametersException("Neplatná hodnota pre endpointtem");
          
            if (!int.TryParse(pocetKrokovField2DEs.Text, out krok)) throw new ValidateParametersException("Neplatná hodnota pre pocetkrokoqtem");
            
            if (!Double.TryParse(steptimeField2DEs.Text, out step)) throw new ValidateParametersException("Neplatná hodnota pre pocetkrokoqtem");

            if (!Double.TryParse(startPointField2DMs.Text, out startpointtem)) throw new ValidateParametersException("Neplatná hodnota pre startpointqms");
            
            if (!Double.TryParse(endPointField2DMs.Text, out endpointtem)) throw new ValidateParametersException("Neplatná hodnota pre endpointqms");
            
           if (!Double.TryParse(resolutionField2D.Text, out resolution)) throw new ValidateParametersException("Neplatná hodnota pre resolutionqms");
            
            
            
            if (!int.TryParse(pocetKrokovField2DEs.Text, out krok)) throw new ValidateParametersException("Neplatná hodnota pre pocetkrokoqms");
            
            if (startpointtem >= endpointtem) throw new ValidateParametersException("Neplatná hodnota endpoint musi byt vacsi ako startpointqms");
            
            if (startpointqms >= endpointqms) throw new ValidateParametersException("Neplatná hodnota endpoint musi byt vacsi ako startpointqms");
            
        }

     private void validateMassScanTab()
        {
            Double startpoint;
            Double endpoint;
            Double resolution;
            string nazov;
            Double step;
            int krok;
            double constant;
            if (nameField.Text.Length <= 0 && !testRun)
            {
               throw new ValidateParametersException("nazov merania musi mat aspon jeden znak");
            }
            

            if (!Double.TryParse(startPointFieldMs.Text, out startpoint)) throw new ValidateParametersException("Neplatná hodnota pre startpoint");
           
            if (!Double.TryParse(endPointFieldMs.Text, out endpoint)) throw new ValidateParametersException("Neplatná hodnota pre endpoint");
          
            if (!Double.TryParse(resolutionFieldMs.Text, out resolution)) throw new ValidateParametersException("Neplatná hodnota pre resolution");
       	    
            if (!Double.TryParse(constantFieldMs.Text, out constant)) throw new ValidateParametersException("Neplatná hodnota pre constant");
          
            if (!Double.TryParse(DensOfMeasFieldMs.Text, out step)) throw new ValidateParametersException("Neplatná hodnota pre steptime");
            
            if (startpoint >= endpoint) throw new ValidateParametersException("Neplatná hodnota endpoint musi byt vacsi ako startpoint");
            if (resolution == 0) throw new ValidateParametersException("Neplatná hodnota resulution nemoze byt 0");

        }

        private void validateEnergyScanTab()//uprava validate e scan a mass scan
        {
            Double startpoint;
            Double endpoint;
            Double resolution;
            string nazov;
            Double step;
            int krok;
            if (nameField.Text.Length <= 0 && !testRun)
            {
               throw new ValidateParametersException("nazov merania musi mat aspon jeden znak");
            }
           
            double constant;
            if (!Double.TryParse(startPointFieldEs.Text, out startpoint)) throw new ValidateParametersException("Neplatná hodnota pre startpoint");
            
            if (!Double.TryParse(endPointFieldEs.Text, out endpoint)) throw new ValidateParametersException("Neplatná hodnota pre endpoint");
           
            if (!Double.TryParse(resolutionFieldEs.Text, out resolution)) throw new ValidateParametersException("Neplatná hodnota pre resolution");
           
            if (!Double.TryParse(constantFieldEs.Text, out constant)) throw new ValidateParametersException("Neplatná hodnota pre constant");
            
            if (!Double.TryParse(stepTimeFieldEs.Text, out step)) throw new ValidateParametersException("Neplatná hodnota pre steptime");
            
            if (!int.TryParse(pocetKrokovFieldEs.Text, out krok)) throw new ValidateParametersException("Neplatná hodnota pre pocetkrokov");
            
            if (startpoint >= endpoint) throw new ValidateParametersException("Neplatná hodnota endpoint musi byt vacsi ako startpoint");
            if (resolution == 0) throw new ValidateParametersException("Neplatná hodnota resulution nemoze byt 0");
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

        private void pocetCyklovFieldLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                testRun = true;
                nastavParametre();
                DialogResult = DialogResult.OK; //okno sa zatvori a parameter parametreMerania bude pripraveny na meranie
            }
            catch (ValidateParametersException ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Trieda NoveMeranieWindow (pripadne aj measurementcontrol): 
            //vymysliet ako spravit aby pri stlaceni buttonu test run, nekontroloval vyplneny nazov, a aby potom trieda measurement control 
            //vedela ze nema namerane veci posielat do db. pozri si ako je spraveny normalny run a co robi a ako sa dostane az do triedy mesarurementcontrol...
        }

        private void nameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void stepTimeFieldMs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        private void vypocitajStepPreEs()
        {
            try {
                double start = int.Parse(startPointFieldEs.Text);
                double end = int.Parse(endPointFieldEs.Text);
                int pocetkrokov = int.Parse(pocetKrokovFieldEs.Text);
                StepValueEsLabel.Text = (((end - start) / pocetkrokov) ).ToString();
                StepValueEsLabel.Visible = true;
                label28.Visible = true;
            }
            
            catch(Exception e)
            {
                StepValueEsLabel.Visible = false;
                label28.Visible = false;
            }
}
        private void vypocitajStepPre2DEs()
        {
            try {
                double start = int.Parse(startPointField2DEs.Text);
                double end = int.Parse(endPointField2DEs.Text);
                int pocetkrokov = int.Parse(pocetKrokovField2DEs.Text);
                StepValue2DEsLabel.Text = (((end - start) / pocetkrokov)).ToString();
                StepValue2DEsLabel.Visible = true;
                label35.Visible = true;
            }
            
            catch(Exception e)
            {
                StepValue2DEsLabel.Visible = false;
                label35.Visible = false;
            }
}
        private void vypocitajStepPre2DMs()
        {
            try { 

                double start = int.Parse(startPointField2DMs.Text);
                double end = int.Parse(endPointField2DMs.Text);
                double casnakrok = double.Parse(DensOfMeasField2DMS.SelectedValue.ToString());
                StepValue2DMsLabel.Text = (((end - start) * casnakrok)).ToString();
                StepValue2DMsLabel.Visible = true;
                label36.Visible = true;
            }

            catch(Exception e)
            {
                StepValue2DMsLabel.Visible = false;
                label36.Visible = false;
            }
}
        private void vypocitajStepPreMs()
        {
            try {
                double start = int.Parse(startPointFieldMs.Text);
                double end = int.Parse(endPointFieldMs.Text);
                
                double casnakrok = double.Parse(DensOfMeasFieldMs.SelectedValue.ToString());
                StepValueMsLabel.Text = (((end - start) * casnakrok)).ToString();
                StepValueMsLabel.Visible = true;
                label37.Visible = true;
            }
            catch(Exception e)
            {
                StepValueMsLabel.Visible = false;
                label37.Visible = false;
            }
          
        }
        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void startPointFieldEs_KeyUp(object sender, KeyEventArgs e)
        {
            vypocitajStepPreEs();

        }

        private void endPointFieldEs_KeyUp(object sender, KeyEventArgs e)
        {
            vypocitajStepPreEs();
        }

        private void pocetKrokovFieldEs_TextChanged(object sender, EventArgs e)
        {

        }

        private void pocetKrokovFieldEs_KeyUp(object sender, KeyEventArgs e)
        {
            vypocitajStepPreEs();
        }

        private void startPointFieldMs_KeyUp(object sender, KeyEventArgs e)
        {
            vypocitajStepPreMs();
        }

        private void endPointFieldMs_KeyUp(object sender, KeyEventArgs e)
        {
            vypocitajStepPreMs();
        }

        private void stepTimeFieldMs_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void stepTimeFieldMs_TextChanged(object sender, EventArgs e)
        {
            vypocitajStepPreMs();
        }

        private void stepTimeFieldMs_ValueMemberChanged(object sender, EventArgs e)
        {
            vypocitajStepPreMs();
        }

        private void stepTimeField2DMs_ValueMemberChanged(object sender, EventArgs e)
        {
            vypocitajStepPre2DMs();
        }

        private void startPointField2DMs_KeyUp(object sender, KeyEventArgs e)
        {
            vypocitajStepPre2DMs();
        }

        private void endPointField2DMs_KeyUp(object sender, KeyEventArgs e)
        {
            vypocitajStepPre2DMs();
        }

        private void startPointField2DEs_KeyUp(object sender, KeyEventArgs e)
        {
            vypocitajStepPre2DEs();
        }

        private void endPointField2DEs_KeyUp(object sender, KeyEventArgs e)
        {
            vypocitajStepPre2DEs();
        }

        private void pocetKrokovField2DEs_TextChanged(object sender, EventArgs e)
        {

        }

        private void pocetKrokovField2DEs_KeyUp(object sender, KeyEventArgs e)
        {
            vypocitajStepPre2DEs();
        }

        private void NoveMeranieWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) ;
            {
                //DialogResult = DialogResult.Cancel;
            }
        }

        private void DensOfMeasFieldMs_SelectedValueChanged(object sender, EventArgs e)
        {
            vypocitajStepPreMs();
        }

        private void DensOfMeasField2DMS_SelectedValueChanged(object sender, EventArgs e)
        {
            vypocitajStepPre2DMs();
        }
    }


}
