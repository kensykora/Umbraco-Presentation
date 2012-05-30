using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using uComponents.Core;
using uComponents.Core.uQueryExtensions;
using umbraco.presentation.nodeFactory;

/// <summary>
/// Summary description for BaseWidget
/// </summary>
public class BaseWidget : UserControl
{
    private Node _node;

    /// <summary>
    /// Set to false if for some reason you don't want to escape the user content block
    /// </summary>
    protected bool EscapeUserContentBlock = true;

    /// <summary>
    /// Set to false if for some reason you don't want to escape the user content block
    /// </summary>
    protected bool RenderInMacroDiv = true;

    public int? NodeId
    {
        get
        {
            int result;
            if (int.TryParse(NodeIdString, out result))
            {
                return result;
            }
            return null;
        }
        set { NodeIdString = value.HasValue ? value.Value.ToString() : null; }
    }

    public Node Node
    {
        get
        {
            if (_node == null && NodeId.HasValue || (_node != null && NodeId.HasValue && _node.Id != NodeId.Value))
            {
                _node = uQuery.GetNode(NodeId.Value);
            }
            return _node;
        }
        set { 
            _node = value;
            NodeId = _node == null ? null : (int?)_node.Id;
        }
    }

    public string NodeIdString { get; set; }

    protected override void Render(HtmlTextWriter writer)
    {

        //Ugly hack time.. 
        //Placeholder will be the parent control when the user is in wysiwyg mode
        //We don't want to close any divs if we're being rendered within the umbraco content editor.
        if (!(Parent.TemplateSourceDirectory.EndsWith("umbraco")) && EscapeUserContentBlock)
        {
            writer.WriteLine("</div>");
        }

        //Render in Macro div
        if (RenderInMacroDiv) {
            //Declare this a macro tag
            writer.AddAttribute("class", "macro");
            writer.RenderBeginTag("div");
        }

        base.Render(writer);

        if (RenderInMacroDiv) {
            writer.RenderEndTag();
        }

        if (!(Parent.TemplateSourceDirectory.EndsWith("umbraco")) && EscapeUserContentBlock)
        {
            //Re-open the macro
            writer.WriteLine("<div class='user-content'>");
        }
    }
}