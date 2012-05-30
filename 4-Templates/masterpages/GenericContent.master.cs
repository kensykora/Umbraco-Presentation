using System;
using System.Linq;
using System.Web.UI;

using uComponents.Core;
using uComponents.Core.uQueryExtensions;

public partial class masterpages_GenericContent : MasterPage
{
    #region Methods

    public string ImageUrl { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        var currentNode = uQuery.GetCurrentNode();
        ImageUrl = uQuery.GetMedia(currentNode.GetPropertyAsInt("mainImage")).GetImageUrl();
    }

    #endregion
}