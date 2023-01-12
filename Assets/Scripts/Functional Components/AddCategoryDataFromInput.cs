using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class AddCategoryDataFromInput : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;
    [SerializeField]
    private CategoriesObject categoriesObject;
    [SerializeField]
    private UIViewsObject viewsObject;
    [SerializeField]
    private ButtonGenerator bGenerator;

    public void Add()
    {
        if (string.IsNullOrEmpty(inputField.text)) return;
        if (viewsObject.View.CParent == null)
        {
            bGenerator.GenerateButton(
                ButtonGenerator.ButtonType.Category,
           inputField.text,
    null, InsertNewCategory());
        }
        if (viewsObject.View.CParent != null && viewsObject.View.AParent == null)
        {
            bGenerator.GenerateButton(
            ButtonGenerator.ButtonType.Activity,
       inputField.text,
null, viewsObject.View.CParent, InsertNewActivity());
        }
        if (viewsObject.View.AParent != null && viewsObject.View.MParent == null)
        {
            InsertNewMetric();
        }

        categoriesObject.SaveToJSON();
    }

    private Category InsertNewCategory()
    {
        Category c = new Category(null, inputField.text, new List<Activity>());
        categoriesObject.Insert(c);
        return c;
    }

    private Activity InsertNewActivity()
    {
        Activity a = new Activity(null, inputField.text, new List<Metric>());
        categoriesObject.Insert(a, viewsObject.View.CParent);
        return a;
    }

    private Metric InsertNewMetric()
    {
        Metric m = new Metric(TypeOfMetric: Metric.Type.Nothing, new DataContainer(new List<DataSkeleton>()));
        categoriesObject.Insert(m, viewsObject.View.AParent);
        return m;
    }
}
