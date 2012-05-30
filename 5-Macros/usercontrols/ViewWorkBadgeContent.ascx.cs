using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using uComponents.Core;
using uComponents.Core.uQueryExtensions;

public partial class usercontrols_ViewWorkBadgeContent : BaseWidget
{
    protected string LinkUrl { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        EscapeUserContentBlock = false;
        WysiwygContent.Text = Node.GetPropertyAsString("mainContent");
        LinkUrl = uQuery.GetNode(Node.GetPropertyAsInt("linkURL")).Url;
    }

}