using DataAccess;
using System;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;

public partial class PageToSync_artistDetails : System.Web.UI.Page
{
    private readonly SQL sql = new SQL();

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            var data = sql.ExecuteStoredProcedureDT("[GetArtistDetails]");
            rptArtist.DataSource = data;
            rptArtist.DataBind();
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void rptArtist_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var row = e.Item.DataItem as DataRowView;
                if (row != null)
                {
                    int artistID = Convert.ToInt32(row["artistID"]);
                    var rptAlbums = e.Item.FindControl("rptAlbums") as Repeater;
                    rptAlbums.DataSource = GetArtistAlbum(artistID);
                    rptAlbums.DataBind();


                    var rptTopSongs = e.Item.FindControl("rptTopSongs") as Repeater;
                    rptTopSongs.DataSource = GetTopSongs(artistID);
                    rptTopSongs.DataBind();


                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    private DataTable GetTopSongs(int artistID)
    {
        sql.Parameters.Clear();
        sql.Parameters.Add("@artistID", artistID);
        return sql.ExecuteStoredProcedureDT("GetArtistTopSongs");
    }
    private DataTable GetArtistAlbum(int artistID)
    {
        sql.Parameters.Clear();
        sql.Parameters.Add("@artistID", artistID);
        return sql.ExecuteStoredProcedureDT("GetArtistAlbum");
    }
}