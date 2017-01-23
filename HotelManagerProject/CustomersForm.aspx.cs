// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomersForm.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The customers form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HotelManagerProject
{
    #region

    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using HotelManagerLib.Controllers;
    using HotelManagerLib.Models.Persistant;

    #endregion

    /// <summary>
    /// The customers form.
    /// </summary>
    public partial class CustomersForm : Page
    {
        /// <summary>
        /// The customer.
        /// </summary>
        private Customer customer;

        /// <summary>
        /// The customer controller.
        /// </summary>
        private CustomerController customerController;

        /// <summary>
        /// The delete customer button.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        protected void deleteCustomerButton(object sender, EventArgs e)
        {
            this.customerController = new CustomerController();

            var errorlabel = this.Master?.FindControl("form1").FindControl("divErrorMessage") as Label;
            if (errorlabel != null)
            {
                errorlabel.Text = string.Empty;
                if (this.customersListGridView.VisibleRowCount == 0)
                {
                    errorlabel.Text = @"There are no companies to delete";
                }

                var firstRun = true;
                this.Session["errorMessage"] = string.Empty;

                var selectedRowKeys =
                    this.customersListGridView.GetSelectedFieldValues(this.customersListGridView.KeyFieldName, "Name", "Surname");
                if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
                {
                    errorlabel.Text = @"Please select a billing first to delete";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    var customerName = row[1].ToString();
                    var customerSurname = row[2].ToString();
                    var myCustomer = new Customer() { Id = id, Name = customerName, Surname = customerSurname};
                    try
                    {
                        this.customerController.DeleteEntity(myCustomer);
                    }
                    catch (ArgumentNullException)
                    {
                        if (firstRun)
                        {
                            errorlabel.Text = @"You can't delete ";
                            firstRun = false;
                        }

                        errorlabel.Text += $@"'{myCustomer.Name} {myCustomer.Surname}', ";
                        this.customersListGridView.Selection.UnselectRowByKey(id);
                    }
                    catch (SqlException ex)
                    {
                        return;
                    }
                }

                errorlabel.Text = errorlabel.Text.TrimEnd(' ', ',');
                this.Session["errorMessage"] = errorlabel.Text;
                this.customersListGridView.DataSource = this.customerController.RefreshEntities();
                this.customersListGridView.DataBind();
            }
        }

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.customerController = new CustomerController();
                var customerList = this.customerController.RefreshEntities();
                this.customersListGridView.DataSource = customerList;
                this.customersListGridView.DataBind();
            }
        }

        /// <summary>
        /// The save button_ on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void saveButton_OnClick(object sender, EventArgs e)
        {
            this.customer = new Customer();
            this.customerController = new CustomerController();
            this.customer.Name = this.nameTextBox.Text;
            this.customer.Surname = this.surNameTextBox.Text;
            this.customer.IdNumber = this.idNumberTextBox.Text;
            this.customer.TaxId = this.taxIdTextBox.Text;
            this.customer.Email = this.emailTextBox.Text;
            this.customer.Address = this.addressTextBox.Text;
            this.customer.Phone = this.phoneTextBox.Text;

            this.customerController.CreateOrUpdateEntity(this.customer);
            this.Page.Response.Redirect(this.Page.Request.Url.ToString(), true);
        }
    }
}