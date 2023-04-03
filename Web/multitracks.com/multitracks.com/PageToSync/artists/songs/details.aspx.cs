using DataAccess;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class PageToSync_artists_songs_details : System.Web.UI.Page
{
    private readonly SQL _sql;

    public PageToSync_artists_songs_details()
    {
        _sql = new SQL();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var _artistID = Convert.ToInt32(Request.QueryString["id"]);
            _sql.Parameters.Add("@artistID", _artistID);
            var data = _sql.ExecuteStoredProcedureDT("[GetArtist]");
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
                    var _artistID = Convert.ToInt32(Request.QueryString["id"]);
                    var rptSongs = e.Item.FindControl("rptSongs") as Repeater;
                    rptSongs.DataSource = GetArtistSongs(_artistID);
                    rptSongs.DataBind();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    private DataTable GetArtistSongs(int artistID)
    {
        _sql.Parameters.Clear();
        _sql.Parameters.Add("@artistID", artistID);
        return _sql.ExecuteStoredProcedureDT("[GetArtistSong]");
    }
}