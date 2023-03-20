using DataAccess;
using System;

public partial class PageToSync_artistDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var sql = new SQL();
        try
        {

            var data = sql.ExecuteStoredProcedureDT("GetArtistDetails");

            artistItems.DataSource = data;
            artistItems.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }
}