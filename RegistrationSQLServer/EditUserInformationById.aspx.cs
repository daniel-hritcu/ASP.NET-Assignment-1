using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using RegistrationSQLServer.DBLayer;
using RegistrationSQLServer.BusinessLayer;
using System.Web.DynamicData;

namespace RegistrationSQLServer
{
    public partial class EditUserInformationById : System.Web.UI.Page
    {

        private int UserId { get; set; }
        private UserInformation UserInfo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            //Check if id is provided in request.
            if (String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //Show error in case id is missing
                lblResultMessage.Text = "Id is null.";
                return;
            }

            //Store Request 'Id'.
            UserId = Convert.ToInt32(Request.QueryString["id"]);

            //Store UserInformation found by Id
            UserInfo = DBUtilities.SelectUserInformationById(UserId);

            //Check if user is found by id
            if (UserInfo == null)
            {
                lblResultMessage.Text = "No user exists with the provided id.";
            }

            //If not postback
            if (!IsPostBack)
            {
                //Fill form fields with UserInformation
                firstNameTextBox.Text = UserInfo.FirstName;
                lastNameTextBox.Text = UserInfo.LastName;
                addressTextBox.Text = UserInfo.Address;
                cityTextBox.Text = UserInfo.City;
                stateOrProvinceTextBox.Text = UserInfo.Province;
                zipCodeTextBox.Text = UserInfo.PostalCode;
                countryTextBox.Text = UserInfo.Country;
            }
        }

        protected void UpdateInfoButton_OnClick(object sender, EventArgs e)
        {

            UserInfo.FirstName = firstNameTextBox.Text;
            UserInfo.LastName = lastNameTextBox.Text;
            UserInfo.Address = addressTextBox.Text;
            UserInfo.City = cityTextBox.Text;
            UserInfo.Province = stateOrProvinceTextBox.Text;
            UserInfo.PostalCode = zipCodeTextBox.Text;
            UserInfo.Country = countryTextBox.Text;



            //If Update was successfull
            if (DBUtilities.UpdateUserInformationById(UserId, UserInfo) == 1)
            {
                //Check if the record is updated by verifying the database table. *Could use the Comparer
                
                var dbUserInfo = DBUtilities.SelectUserInformationById(UserId);
                if (
                    dbUserInfo.Id == UserInfo.Id &&
                    dbUserInfo.FirstName == UserInfo.FirstName &&
                    dbUserInfo.LastName == UserInfo.LastName &&
                    dbUserInfo.Address == UserInfo.Address &&
                    dbUserInfo.City == UserInfo.City &&
                    dbUserInfo.Province == UserInfo.Province &&
                    dbUserInfo.PostalCode == UserInfo.PostalCode &&
                    dbUserInfo.Country == UserInfo.Country
                   )
                {
                    lblResultMessage.Text = "The User Information was successfully updated into db table";
                }
                else
                {
                    lblResultMessage.Text = "The updated user information does not match the one in the DB!";
                }
            }
            else
            {
                lblResultMessage.Text = "There was an error updating the user information!";
            }
        }
    }

}