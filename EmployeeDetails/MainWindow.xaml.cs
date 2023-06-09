﻿using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BusinessLayer;
using Entities.EmployeeEntities;
using DataAccessLayer.DataAccessService;
using CommonLayer;

namespace EmployeeDetails
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Object Call
        ButtonEvents objBevent = new ButtonEvents(new CallMethods());
        #endregion

        #region Variables declaration
        int searchId;
        string empDetails;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            InitiateComboBoxValues();
            btnCreate.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Hidden;
        }


        #region Button Load All the Employees in Grid
        protected async void btnLoadEmpDetails_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                dgrdEmp.ItemsSource = await objBevent.SelectAllDetails();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        #endregion

        #region Button Create Employee
        protected void btnCreate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ValidateTextValues();

                // text obj call.
                var emp = new Employee()

                {
                    //Id = Convert.ToInt32(txtEmpId.Text),
                    Name = textName.Text,
                    Email = textMail.Text,
                    Gender = comboBoxGender.SelectedValue.ToString(),
                    Status = comboBoxStatus.SelectedValue.ToString()
                };

                objBevent.SaveDetails(emp);

                textEmpId.Text = "";
                textName.Text = "";
                textMail.Text = "";
                comboBoxGender.SelectedValue = "";
                comboBoxStatus.SelectedValue = "";
            }

            catch (Exception ex)
            {
                throw (ex);
            }


        }

        #endregion

        #region Button Edit details
        protected void btnEdit(object sender, RoutedEventArgs e)
        {
            Employee emp = ((FrameworkElement)sender).DataContext as Employee;

            textEmpId.Text = emp.Id.ToString();
            textName.Text = emp.Name;
            textMail.Text = emp.Email;
            comboBoxGender.SelectedValue = emp.Gender;
            comboBoxStatus.SelectedValue = emp.Status;
        }
        #endregion

        #region Button onclick delete
        protected async void btnDeleteEmp(object sender, RoutedEventArgs e)
        {
            Employee emp = ((FrameworkElement)sender).DataContext as Employee;

            try
            {
                if (emp.Id.ToString() == null || emp.Id.ToString() == "" || emp.Id == 0)
                {
                    MessageBox.Show("Please Select Emlpoyee to delete the Request");
                }

                else
                {
                    empDetails = emp.Id.ToString();
                    objBevent.DeleteDetails(emp.Id);
                    MessageBox.Show("Employee with ID " + empDetails + " has been deleted.", "Response Window.");
                }
               
                dgrdEmp.ItemsSource = await objBevent.SelectAllDetails();
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }

        #endregion

        #region Export the employee list to csv
        protected void btnExport_Click(object sender, RoutedEventArgs e)
        {

            dgrdEmp.SelectAllCells();
            dgrdEmp.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dgrdEmp);
            dgrdEmp.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            File.AppendAllText("D:\\EmployeeDetails.csv", result, UnicodeEncoding.UTF8);
        }
        #endregion

        #region Buttton onclick Update
        protected void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValidateTextValues();

                Employee emp = new Employee()

                {
                    Id = Convert.ToInt32(textEmpId.Text),
                    Name = textName.Text,
                    Email = textMail.Text,
                    Gender = comboBoxGender.SelectedValue.ToString(),
                    Status = comboBoxStatus.SelectedValue.ToString()
                };

                objBevent.UpdateDetails(emp);

                textEmpId.Text = "";
                textName.Text = "";
                textMail.Text = "";
                comboBoxGender.SelectedValue = "";
                comboBoxStatus.SelectedValue = "";
            }

            catch (Exception ex)
            {
                throw (ex);
            }

        }
        #endregion

        #region Button Search Single Details
        public async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (textEmpId.Text.ToString() == "" || textEmpId.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter Employee Id to search");
                }
                else
                {
                    searchId = Convert.ToInt32(textEmpId.Text);
                }


                dgrdEmp.ItemsSource = await objBevent.GetById(searchId);
            }

            catch (Exception ex)
            {
                throw (ex);

            }
        }
        #endregion

        #region Validate the control values
        public void ValidateTextValues()
        {
            if (textName.Text.Length == 0)
            {
                MessageBox.Show("Please enter the Employee Name");
                textName.Focus();
            }

            if (textMail.Text.Length == 0)
            {
                MessageBox.Show("Please enter the Email");
                textMail.Focus();
            }

            if (comboBoxGender.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please enter the Gender");

                comboBoxGender.Focus();
            }
            if (comboBoxStatus.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please enter the Status");
                comboBoxStatus.Focus();
            }
        }
        #endregion

        #region Initiate the Combox values at load event
        public void InitiateComboBoxValues()
        {
            DataContext = new ComboBoxvalues();
        }
        #endregion
    }
}

