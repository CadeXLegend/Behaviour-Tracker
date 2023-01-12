using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Category", menuName = "Data/Category", order = 1)]
[System.Serializable]
public class Category
{
    [SerializeField]
    private Sprite icon = null;
    [SerializeField]
    private string categoryName = "";
    public string CategoryName { get => categoryName; }
    [SerializeField]
    private List<Activity> activities = new List<Activity>();
    public List<Activity> Activities { get => activities; }

    public Category(Sprite icon, string CategoryName, List<Activity> Activities)
    {
        this.icon = icon;
        this.categoryName = CategoryName;
        this.activities = Activities;
    }
}
