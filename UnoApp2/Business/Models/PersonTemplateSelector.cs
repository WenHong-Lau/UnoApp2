namespace UnoApp2.Business.Models;
public class PersonTemplateSelector : DataTemplateSelector
{
    public DataTemplate VipTemplate { get; set; }
    public DataTemplate NonVipTemplate { get; set; }

    /// <summary>
    /// Selects the template for the specified item. This is called by SelectTemplate to determine where to select the template based on the control's type
    /// </summary>
    /// <param name="item">The item to select the template for</param>
    /// <returns>The template that should be used to render the specified item or null if none is found in the data</returns>
    protected override DataTemplate SelectTemplateCore(object item)
    {
        var p = item as Person;
        /// Select template for the control type
        if(p?.IsVIP == true)
        {
            return VipTemplate;
        }
        else
        {
            return NonVipTemplate;
        }
    }
}
