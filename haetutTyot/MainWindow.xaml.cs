﻿using System;
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
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace haetutTyot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        APPLICATION application = new APPLICATION();
        CONNECT connection = new CONNECT();

        //Strings to alter easily and quickly if needed for the "About" section on the application
        string applicationVersion = "1.0.0";
        string applicationCreator = "Joel Mantere";
        string applicationYear = "2023";
        public MainWindow()
        {
            InitializeComponent();
            CreateIdRandom(); //Create a random ID for the application when opened
            appDate.SelectedDate = DateTime.Today; //Set the current date automatically as the selected date when opened
        }

        public partial class App : Application
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataTable.DataContext = application.GetApplications(); //When the window loads, call the getApplications function, which shows current contents of database on the DataGrid.


        }

        private void ClearValues() //Clear values for all fields, uncheck all checkboxes, set calendar date to the current date and create a new random ID.
        {
            employerName.Text = "Työnantaja";
            roleName.Text = "Työnimike";
            workAddress.Text = "Työpaikan osoite";
            contactInfo.Text = "Yhteystiedot";
            postLink.Text = "Linkki";
            appDate.DisplayDate = DateTime.UtcNow;
            gotReply.IsChecked = false;
            gotInterview.IsChecked = false;
            gotWork.IsChecked = false;
            appDate.SelectedDate = DateTime.Today;
            CreateIdRandom();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e) //Clear all inputs and places the default values into the fields.
        {
            ClearValues();
        }

        private void RemoveDefaultOnFocus(object sender, RoutedEventArgs e) //Clear default values from fields once user focuses on the given textbox
        {
            TextBox textField = sender as TextBox;
            string textFieldText = textField.Text;

            switch (textFieldText)
            {
                case "Työnantaja":
                    textField.Text = "";
                    break;

                case "Työnimike":
                    textField.Text = "";
                    break;

                case "Työpaikan osoite":
                    textField.Text = "";
                    break;

                case "Yhteystiedot":
                    textField.Text = "";
                    break;

                case "Linkki":
                    textField.Text = "";
                    break;
            }
         
        }

        private void DefaultLostFocus(object sender, RoutedEventArgs e) //When losing focus on a certain textbox and it being an empty string, fill it back with the default string. 
        {
            if (sender == employerName && employerName.Text == "")
            {
                employerName.Text = "Työnantaja";
            }
            if (sender == roleName && roleName.Text == "")
            {
                roleName.Text = "Työnimike";
            }
            if (sender == workAddress && workAddress.Text == "")
            {
                workAddress.Text = "Työpaikan osoite";
            }
            if (sender == contactInfo && contactInfo.Text == "")
            {
                contactInfo.Text = "Yhteystiedot";
            }
            if (sender == postLink && postLink.Text == "")
            {
                postLink.Text = "Linkki";
            }
        }


        private void AddApplication(object sender, RoutedEventArgs e)
        {
            //Assign the input within the TextBoxes as the values of the items to be entered into the database.
            string emplName = employerName.Text;
            string jobTitle = roleName.Text;
            string jobAddress = workAddress.Text;
            if (emplName == "Työnantaja" || jobTitle == "Työnimike" || jobAddress == "Työpaikan osoite") //Check that the default values aren't used for the mandatory textboxes
            { 
                MessageBox.Show("Et voi syöttää oletusarvoja, yritä uudelleen.", "Virhe", MessageBoxButton.OK); 
            }
            else
            {
                int ID = Convert.ToInt32(appId.Text);
                string contInfo = contactInfo.Text;
                string ptLink = postLink.Text;
                DateTime? aDate = appDate.SelectedDate;
                string gReply;
                //The values of the checkboxes is dependent on if they're checked or not. 
                if (gotReply.IsChecked == true)
                {
                    gReply = "KYLLÄ";
                }
                else
                {
                    gReply = "EI";
                }
                string gInt;
                if (gotInterview.IsChecked == true)
                {
                    gInt = "KYLLÄ";
                }
                else
                {
                    gInt = "EI";
                }
                string gJob;
                if (gotWork.IsChecked == true)
                {
                    gJob = "KYLLÄ";
                }
                else
                {
                    gJob = "EI";
                }
                    //If adding the application is succesful, show message and if not, show message as well
                try
                {
                    Boolean addApp = application.AddApplication(ID, emplName, jobTitle, jobAddress, contInfo, ptLink, aDate, gReply, gInt, gJob);

                    if (addApp)
                    {
                        MessageBox.Show("Jeee");
                        dataTable.DataContext = application.GetApplications();
                        CreateIdRandom();
                    }
                    else
                    MessageBox.Show("EIIII");
                }     
                catch
                {
                    MessageBox.Show("Et voi lisätä työhakemusta, jolla on jo olemassa oleva ID. Yritä uudelleen.", "Virhe", MessageBoxButton.OK);
                }


            }   
        }

        private void CreateIdRandom() 
        //Function that creates a random number using 1 through 9 (and 0) to be used as the id.
        //This function is called both when the app is opened and when the fields are cleared.
        {
            char[] numbers = "1234567890".ToCharArray();
            Random random = new Random();
            string randomId = "";
            for (int i = 0; i < 6; i++)
            {
                randomId += numbers[random.Next(0, 9)].ToString();
            }
            appId.Text = randomId;
            appId.IsReadOnly = true;
        }

        private void EditApplication(object sender, RoutedEventArgs e)
        {
            {
                //Assign the input within the TextBoxes as the values of the items to be entered into the database.
                int ID = Convert.ToInt32(appId.Text);
                string emplName = employerName.Text;
                string jobTitle = roleName.Text;
                string jobAddress = workAddress.Text;
                string contInfo = contactInfo.Text;
                string ptLink = postLink.Text;
                DateTime? aDate = appDate.SelectedDate;
                string gReply;
                //The values of the checkboxes is dependent on if they're checked or not. 
                if (gotReply.IsChecked == true)
                {
                    gReply = "KYLLÄ";
                }
                else
                {
                    gReply = "EI";
                }
                string gInt;
                if (gotInterview.IsChecked == true)
                {
                    gInt = "KYLLÄ";
                }
                else
                {
                    gInt = "EI";
                }
                string gJob;
                if (gotWork.IsChecked == true)
                {
                    gJob = "KYLLÄ";
                }
                else
                {
                    gJob = "EI";
                }
                //If adding the application is succesful, show message and if not, show message as well
                Boolean editApp = application.EditApplication(ID, emplName, jobTitle, jobAddress, contInfo, ptLink, aDate, gReply, gInt, gJob);
                if (editApp)
                {
                    MessageBox.Show("Hakemustasi muokattiin onnistuneesti.");
                    dataTable.DataContext = application.GetApplications();
                }
                else
                    MessageBox.Show("Jokin meni vikaan, yritä uudelleen.", "Virhe", MessageBoxButton.OK);
            }
        }

        private void DeleteApplication(object sender, RoutedEventArgs e) //Delete application, ask the user if they are sure they want to and if the user clicks "Yes", the deletion proceeds normally.
        { 
            MessageBoxResult warningResult = MessageBox.Show("Oletka varma, että tahdot poistaa valitun työhakemuksen?", "Varoitus", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (warningResult == MessageBoxResult.Yes)
            {
                int ID = Convert.ToInt32(appId.Text);
                Boolean deleteApp = application.DeleteApplication(ID);
                if (deleteApp)
                {
                    dataTable.DataContext = application.GetApplications();
                    ClearValues();
                    CreateIdRandom();
                }
                else
                MessageBox.Show("Valitse poistettava hakemus ja yritä uudelleen.", "Virhe", MessageBoxButton.OK);
            }
 
        }

        private void dataTable_SelectionChanged(object sender, SelectionChangedEventArgs e) //When selecting a job application in the datagrid, its values are assigned to the textfields, calendar and checkboxes.
        {
            DataGrid dg = sender as DataGrid;
            DataRowView rowSelected = dg.SelectedItem as DataRowView;
            if(rowSelected != null)
            {
                appId.Text = rowSelected["ID"].ToString();
                employerName.Text = rowSelected["employerName"].ToString();
                roleName.Text = rowSelected["roleName"].ToString();
                workAddress.Text = rowSelected["workAddress"].ToString();
                contactInfo.Text = rowSelected["contactInfo"].ToString();
                postLink.Text = rowSelected["ilmLink"].ToString();
                appDate.SelectedDate = DateTime.Parse(rowSelected["appDate"].ToString());
                if (rowSelected["gotReply"].ToString() == "KYLLÄ")
                {
                    gotReply.IsChecked = true;
                }

                if (rowSelected["gotInterview"].ToString() == "KYLLÄ")
                {
                    gotInterview.IsChecked = true;
                }

                if (rowSelected["saatuTyo"].ToString() == "KYLLÄ")
                {
                    gotWork.IsChecked = true;
                }
            }
        }

        private void OnClick(object sender, RoutedEventArgs e) //Function that checks which item fired it off and reacts accordingly
        {
            if(sender == aboutButton)
            {
                contextMenuFile.IsOpen = true;
            }

            if(sender == aboutFile)
            {
                MessageBox.Show($"Versio: {applicationVersion}\nLuotu: {applicationYear}\nTekijä: {applicationCreator}", "Ohjelmistosta", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if(sender == languageOfFile)
            {
                contextMenuLanguage.IsOpen = true;
            }

            if(sender == finnishLanguage)
            {
                MessageBox.Show("Olet jo valinnut suomen kielen, yritä uudelleen.", "Virhe", MessageBoxButton.OK);
            }
            else if(sender == englishLanguage)
            {
                this.Close();
                MainWindowEnglish englishWindow = new MainWindowEnglish();
                englishWindow.Show();
            }

            if(sender == exitFile)
            {
                Environment.Exit(0);
            }
        }
    }
}

