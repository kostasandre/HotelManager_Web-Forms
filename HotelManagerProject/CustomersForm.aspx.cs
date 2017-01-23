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

    using DevExpress.Web;

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
        /// The customers list grid view_ on custom button callback.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void customersListGridView_OnCustomButtonCallback(
            object sender,
            ASPxGridViewCustomButtonCallbackEventArgs e)
        {
            this.customerController = new CustomerController();
            var gridviewIndex = e.VisibleIndex;
            var row = this.customersListGridView.GetRow(gridviewIndex) as Customer;
            var customer = this.customerController.GetEntity(row.Id);
            this.customersListGridView.JSProperties["cp_text"] = customer.Name;
            this.customersListGridView.JSProperties["cp_text1"] = customer.Surname;
            this.customersListGridView.JSProperties["cp_text2"] = customer.TaxId;
            this.customersListGridView.JSProperties["cp_text3"] = customer.IdNumber;
            this.customersListGridView.JSProperties["cp_text4"] = customer.Email;
            this.customersListGridView.JSProperties["cp_text5"] = customer.Address;
            this.customersListGridView.JSProperties["cp_text6"] = customer.Created.ToString();
            this.customersListGridView.JSProperties["cp_text7"] = customer.CreatedBy;
            this.customersListGridView.JSProperties["cp_text8"] = customer.Id.ToString();
            this.customersListGridView.JSProperties["cp_text9"] = customer.Phone;
        }

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
                    this.customersListGridView.GetSelectedFieldValues(this.customersListGridView.KeyFieldName, "Id");
                if ((selectedRowKeys == null) || (selectedRowKeys.Count == 0))
                {
                    errorlabel.Text = @"Please select a billing first to delete";
                    return;
                }

                foreach (object[] row in selectedRowKeys)
                {
                    var id = Convert.ToInt32(row[0]);
                    var myCustomer = new Customer() { Id = id };
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

                        errorlabel.Text += $@"'{myCustomer.Id}', ";
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
        /// The page_ init.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            this.customerController = new CustomerController();
            var customerList = this.customerController.RefreshEntities();
            this.customersListGridView.DataSource = customerList;
            this.customersListGridView.DataBind();
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
            var customerId = this.iDtextBox.Text;
            this.customer.Id = customerId == string.Empty ? 0 : Convert.ToInt32(customerId);
            this.customer.Name = this.nameTextBox.Text;
            this.customer.Surname = this.surNameTextBox.Text;
            this.customer.IdNumber = this.idNumberTextBox.Text;
            this.customer.TaxId = this.taxIdTextBox.Text;
            this.customer.Email = this.emailTextBox.Text;
            this.customer.Address = this.addressTextBox.Text;
            this.customer.Phone = this.phoneTextBox.Text;

            try
            {
                this.customerController.CreateOrUpdateEntity(this.customer);
                this.Page.Response.Redirect(this.Page.Request.Url.ToString(), true);
            }
            catch (Exception ex)
            {
            }
        }
    }
}