# RegistrationSQLServer
Created for the Registration WebForm app and SQL Server project

Add a new WebForm page EditUserInformationById.aspx.

When a Request is made for this page there is an id value passed with the request (ex: http://localhost:52330/EditUserInformationById.aspx?id=1) – the variable id = 1 is passed in the Request.QueryString (?id=1 represents the QueryString of the current Request).

On the Page_Load event handler you should get this id variable value, find the specific record in the database identified by this id and display that specific UserInformation record in the page (use the controls already created for Registration page).

In the Edit page you can modify the existing data and click on Update button to Update the record in the database. Check if the record is updated by verifying the database table.

Create a link on the current Registration page that will redirect you from Registration to Edit page (with the QueryString value set to the id value of the newly created record).
The link should be displayed/visible ONLY if the Registration is successful!!!!

Also on the Edit page you should implement a link to go back to Registration page to create a new UserInformation record in the database. So in this way you will have a navigation between Registration and EditUserInformationById pages.

Good luck!