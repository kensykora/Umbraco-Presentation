using System;
using System.Linq;
using System.Web.UI;

using uComponents.Core;
using uComponents.Core.uQueryExtensions;

public partial class masterpages_Project : MasterPage
{
    #region Methods

    protected void Page_Load(object sender, EventArgs e)
    {
        var currentNode = uQuery.GetCurrentNode();
        this.Images.DataSource =
            uQuery.GetMedia(currentNode.GetPropertyAsInt("projectImageFolder")).GetChildMedia().Select(
                x => new { ImageUrl = x.GetImageUrl(), AltText = x.Text });
        this.Images.DataBind();
    }

    #endregion
}