using System;
using System.Linq;
using System.Web.UI;

using uComponents.Core;
using uComponents.Core.uQueryExtensions;

using umbraco.presentation.nodeFactory;

public partial class masterpages_ProjectLanding : MasterPage
{
    #region Methods

    protected Node CurrentNode { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        CurrentNode = uQuery.GetCurrentNode();
        this.Projects.DataSource =
            CurrentNode.GetChildNodes().Select(
                x =>
                new { x.Id, ImageUrl = uQuery.GetMedia(x.GetPropertyAsInt("mainImage")).GetImageUrl(), x.Name, x.Url });
        this.Projects.DataBind();
    }

    #endregion
}