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
            try
            {
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
            else if (typyMeraniaTaby.SelectedTab.Text.Equals("2D scan"))
            {
                try
                {
                    validateMass2DScanTab();

                    EnergyScanParameters parametreMeraniaEnergy = new EnergyScanParameters(Convert.ToDouble(startPointField2DEs.Text), Convert.ToDouble(endPointField2DEs.Text),0.0,Convert.ToDouble(steptimeField2DEs.Text), Convert.ToInt32(pocetKrokovField2DEs.Text));


                    MassScanParameters parametreMeraniaMass = new MassScanParameters(Convert.ToDouble(startPointField2DMs.Text), Convert.ToDouble(endPointField2DMs.Text), 0, (double)stepTimeField2DMs.SelectedValue);

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
        }

        /// <summary>
        /// metoda na ulozanie akutalne zadanych parametrov pre 2dscan do settign filu PosledneParametreMerania. nic nevaliduje. vola sa az po validacii, takze fieldy sa mozu bezpecne ulozit
        /// </summary>
        private void ulozParametre2DScan()
        {
            PosledneParametreMerania.Default.m2DStartPoint = int.Parse(startPointField2DMs.Text);
            ///atd...

        }

        private void ulozParametreMassScan()
        {
            
        }

        private void ulozParametreEnergyScan()
        {
            
        }

        private void validateMass2DScanTab()
        {
            Double startpoint;
            Double endpoint;
            Double resolution;
            int step;
            int krok;
            if (nameField.Text.Length < 3)
            {
                throw new ValidateParametersException("Zadajte správny nazov merania");
            }

             if (!Double.TryParse(startPointField2DMs.Text, out startpoint)) throw new ValidateParametersException("Neplatná hodnota pre startpoint" );
             if (!Double.TryParse(endPointField2DMs.Text, out endpoint)) throw new ValidateParametersException("Neplatná hodnota pre endpoint " );
             if (!Double.TryParse(resolutionField2D.Text, out resolution)) throw new ValidateParametersException("Neplatná hodnota pre resolution");
             //if (!int.TryParse(stepTimeField2DMs.SelectedText, out step)) throw new ValidateParametersException("Neplatná hodnota steptimefield" + stepTimeFieldMs.Text); //ani toto tu nema co robit
             if (!int.TryParse(pocetKrokovField2DEs.Text, out krok)) throw new ValidateParametersException("Neplatná hodnota pre pocet cyklov");

        }

        private void validateMassScanTab()
        {
            Double startpoint;
            Double endpoint;
            Double resolution;
            int step;
            int krok;
            
            //preco by nazov nemohol byt kratsi ako 3 ??? 
            if (nameField.Text.Length < 3)
            {
                throw new ValidateParametersException("Zadajte správny nazov merania");
            }

            ///ani jedna z tychto testov nedovloluje zadat double hodnotu.... opravit !!!
            /// okrem toho volanie parametru .Text je nanic, kedze z toho neviem ktory field mam opravit.. zadat rucne nazov ktory field je zly!!!
            /// podobne pre validate energy scan a validate 2dscan....!!!
            if (!Double.TryParse(startPointFieldMs.Text, out startpoint)) throw new ValidateParametersException("Neplatná hodnota pre startpoint");
            if (!Double.TryParse(endPointFieldMs.Text, out endpoint)) throw new ValidateParametersException("Neplatná hodnota pre end point" );
            if (!Double.TryParse(resolutionFieldMs.Text, out resolution)) throw new ValidateParametersException("Neplatná hodnota pre resolution");
            if (!Double.TryParse(constantFieldMs.Text, out resolution)) throw new ValidateParametersException("Neplatná hodnota pre constant" );

//            if (!int.TryParse(stepTimeFieldMs.Text, out step)) throw new ValidateParametersException("Neplatná hodnota pre steptime");//tuto hodnotu netreba kontrolovat kedze sa vybera zo select listu !!!

            

        }

        private void validateEnergyScanTab()
        {
            Double startpoint;
            Double endpoint;
            Double resolution;
            int step;
            int krok;
            if (nameField.Text.Length < 3)
            {
                throw new ValidateParametersException("Zadajte správny nazov merania");
            }

            if (!Double.TryParse(startPointFieldEs.Text, out startpoint)) throw new ValidateParametersException("Neplatná hodnota pre startpoint");
            if (!Double.TryParse(endPointFieldEs.Text, out endpoint)) throw new ValidateParametersException("Neplatná hodnota pre endpoint");
            if (!Double.TryParse(resolutionFieldEs.Text, out resolution)) throw new ValidateParametersException("Neplatná hodnota pre resolution" );
            if (!Double.TryParse(constantFieldEs.Text, out resolution)) throw new ValidateParametersException("Neplatná hodnota pre constant");
            if (!int.TryParse(stepTimeFieldEs.Text, out step)) throw new ValidateParametersException("Neplatná hodnota pre steptime");
            if (!int.TryParse(pocetKrokovFieldEs.Text, out step)) throw new ValidateParametersException("Neplatná hodnota pre pocetkrokov" );

            
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
    }


}
