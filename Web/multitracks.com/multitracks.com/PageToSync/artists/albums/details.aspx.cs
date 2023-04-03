using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PageToSync_artists_albums_details : System.Web.UI.Page
{
    private readonly SQL _sql;

    public PageToSync_artists_albums_details()
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
                    var rptAlbums = e.Item.FindControl("rptAlbums") as Repeater;
                    rptAlbums.DataSource = GetArtistAlbum(_artistID);
                    rptAlbums.DataBind();
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    private DataTable GetArtistAlbum(int artistID)
    {
        _sql.Parameters.Clear();
        _sql.Parameters.Add("@artistID", artistID);
        return _sql.ExecuteStoredProcedureDT("[GetArtistAlbum]");
    }
}