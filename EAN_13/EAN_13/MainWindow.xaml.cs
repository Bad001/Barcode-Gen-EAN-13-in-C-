using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;

namespace EAN_13
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker backgroundWorker1 = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.WorkerReportsProgress = true;
        }

        public void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public string Controllo(string codice)
        {
            char[] Array;
            Array = codice.ToCharArray();
            int posizione_dispari = 0;
            int risultato = 0;
            double decina_superiore;
            int[] Array_int = new int[Array.Length + 1];
            for (int i = 0; i < Array.Length; i++)
            {
                Array_int[i] = Convert.ToInt32(Array[i].ToString());
            }

            for (int i = Array_int.Length - 2; i >= 0; i--)
            {
                if (i % 2 == 1)
                {
                    posizione_dispari = Array_int[i] * 3;
                    risultato += posizione_dispari;
                }
                else
                {
                    risultato += Array_int[i];
                }
            }
            decina_superiore = Convert.ToDouble(risultato) / 10;
            decina_superiore = Math.Ceiling(decina_superiore);
            decina_superiore = decina_superiore * 10;
            risultato = Convert.ToInt32(decina_superiore) - risultato;
            Array_int[Array_int.Length - 1] = risultato;
            Lista.Items.Add(codice + risultato);
            return codice;
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            if (StartControlli())
            {
                string codice = this.boxCodiceIniziale.Text.ToString();
                string limite = this.boxLimite.Text.ToString();
                try
                {
                    long c = Convert.ToInt64(codice);
                    Convert.ToInt64(limite);
                }
                catch (System.FormatException)

                {
                    MessageBox.Show(" Non possono essere immesse delle lettere!", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int i = 1;
                while (i <= Convert.ToInt64(limite))
                {
                    // Creo il barcode
                    Controllo(codice);
                    // Incremento il codice
                    codice = (Convert.ToInt64(codice) + 1).ToString();
                    i++;
                }
            }
            else
                MessageBox.Show("Inserire i dati mancanti per eseguire l'elaborazione.", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private bool StartControlli()
        {
            if (boxCodiceIniziale.Text == "")
                return false;

            if (boxLimite.Text == string.Empty)
                return false;

            return true;
        }

        private void Salva_Button_Click(object sender, RoutedEventArgs e)
        {
            Pulisci_Button.IsEnabled = false;
            Start_Button.IsEnabled = false;
            Salva_Button.IsEnabled = false;
            Ferma.IsEnabled = true;
            Barra.Maximum = Lista.Items.Count;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var path = @"C:\Users\Bad\Desktop\Barcode EAN-13.txt";
            if (Lista.Items.Count > 0)
            {
                for (int i = 0; i < Lista.Items.Count; i++)
                {
                    File.AppendAllText(path, Lista.Items[i].ToString() + Environment.NewLine);
                    backgroundWorker1.ReportProgress(i+1);
                }
                MessageBox.Show(" Informazioni salvate correttamente!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(" Errore, dati inesistenti!", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Pulisci_Button.IsEnabled = true;
            Start_Button.IsEnabled = true;
            Salva_Button.IsEnabled = true;
            Ferma.IsEnabled = false;
        }

        private void Pulisci_Button_Click(object sender, RoutedEventArgs e)
        {
            boxCodiceIniziale.Clear();
            boxLimite.Clear();
            Lista.Items.Clear();
            Barra.Value = 0;
            percentuale.Text = "0%";
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Barra.Value = e.ProgressPercentage;
            double calcolo_percentuale = (Convert.ToDouble(e.ProgressPercentage) / Convert.ToDouble(Lista.Items.Count)) * Convert.ToDouble(100);
            if(calcolo_percentuale < Int32.MaxValue)
            {
                percentuale.Text = Convert.ToString(Convert.ToInt32(calcolo_percentuale)) + "%";
            }
        }

        private void Ferma_Button_Click(object sender, RoutedEventArgs e)
        {
            Lista.Items.Clear();
        }
    }
}