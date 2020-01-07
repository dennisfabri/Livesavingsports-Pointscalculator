using System.Collections;
using Xamarin.Forms;

namespace de.df.points.View.Extensions
{
public class AlternateColorDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate EvenTemplate { get; set; }
    public DataTemplate UnevenTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        // TODO: Maybe some more error handling here
        return ((IList)((ListView)container).ItemsSource).IndexOf(item) % 2 == 0 ? EvenTemplate : UnevenTemplate;
    }
}}
