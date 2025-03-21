﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiWindowForm
{
    public partial class NewCustomerForm : Form
    {
        private MainForm _mainForm;
        private int CustomerCount;
        private bool IsEditing;
        private int CurrentSelectionId;

        public NewCustomerForm(MainForm form)
        {
            InitializeComponent();
            _mainForm = form;
            CustomerCount = 1;
            IsEditing = false;
            CurrentSelectionId = -1;
        }

        public void ToggleEdit(bool newState)
        {
            IsEditing = newState;
        }

        private void CreateCustomer()
        {
            // validation
            if (!CheckValidity())
            {
                // show an error
                // return and try again
            }

            // create a customer and load it with the data from the form
            Customer customer = new Customer
            {
                CustomerId = CustomerCount,
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
            };

            // send that data to the AddCustomer function on the parent form
            _mainForm.AddCustomer(customer);
            CustomerCount++;
        }

        private bool CheckValidity()
        {
            // some logic here to validate the various inputs

            
            bool somevalue = true; // set this to the validity of the form
            return somevalue;
        }

        private void EditCustomer()
        {
            // validators here, exit early if invalid


            MessageBox.Show("Form is being edited.");

            // tell the main form what our customer looks like
            _mainForm.EditCustomer(CurrentSelectionId, new Customer
            {
                CustomerId = CurrentSelectionId,
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
            });

            CurrentSelectionId = -1;
            ToggleEdit(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEditing)
            {
                // edit the item in place
                EditCustomer();
            } 
            else
            {
                // create a new customer
                CreateCustomer();
            }



            // clear the new customer form
            ClearForm();

            // close the form if we want to
            Hide();
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
        }

        public void LoadCustomer(Customer customer)
        {
            CurrentSelectionId = customer.CustomerId;
            txtName.Text = customer.Name;
            txtEmail.Text = customer.Email;
            txtPhoneNumber.Text = customer.PhoneNumber;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
