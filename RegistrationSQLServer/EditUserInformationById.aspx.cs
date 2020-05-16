using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationSQLServer
{
    public partial class EditUserInformationById : System.Web.UI.Page
    {

        private int Id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if id is provided in request.
            if (String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //Show error in case id is missing
                Response.Write("Id is null.");
            }

            //Store Request 'Id'.
            this.Id = Convert.ToInt32(Request.QueryString["id"]);


        }
    }
}