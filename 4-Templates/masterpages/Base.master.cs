using System;
using System.Linq;
using System.Web.UI;

using uComponents.Core;
using uComponents.Core.uQueryExtensions;

using umbraco.presentation.nodeFactory;

public partial class masterpages_Base : MasterPage
{
    #region Methods

    private Node CurrentNode { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        CurrentNode = uQuery.GetCurrentNode();
        Page.Title = CurrentNode.Name;
    }


    protected string CheckActive(string name)
    {
        return this.CurrentNode.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase) ? "active" : string.Empty;
    }

    #endregion
}