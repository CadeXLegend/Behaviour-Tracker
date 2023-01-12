using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[CreateAssetMenu(fileName = "New Category Object", menuName = "Data/Categories Object", order = 0)]
public class CategoriesObject : ScriptableObject
{
    private const string SaveDataName = "CategoriesData";
    [SerializeField]
    private CategoriesContainer container;
    public CategoriesContainer Container { get => container; }

    #region Insert Data Into CategoriesObject
    public void Insert(Category category)
    {
        if (container == null) return;
        if (container.Categories == null) return;
        if (category == null) return;
        if (container.Categories.Contains(category)) return;

        container.Categories.Add(category);
    }

    public void Insert(Activity activity, Category parentCategory)
    {
        if (parentCategory == null) return;
        if (activity == null) return;
        if (parentCategory.Activities.Contains(activity)) return;

        parentCategory.Activities.Add(activity);
    }

    public void Insert(Metric metric, Activity parentActivity)
    {
        if (parentActivity == null) return;
        if (metric == null) return;
        if (parentActivity.Metrics.Contains(metric)) return;

        parentActivity.Metrics.Add(metric);
    }

    public void Insert(DataSkeleton skeleton, Metric parentMetric)
    {
        if (parentMetric == null) return;
        if (skeleton == null) return;
        if (parentMetric.CollectedData.Data.Contains(skeleton)) return;

        parentMetric.CollectedData.Data.Add(skeleton);
    }
    #endregion

    #region Remove Data From CategoriesObject
    public void Remove(Category category)
    {
        if (container == null) return;
        if (container.Categories == null) return;
        if (category == null) return;
        if (!container.Categories.Contains(category)) return;

        container.Categories.Remove(category);
    }

    public void Remove(Activity activity, Category parentCategory)
    {
        if (parentCategory == null) return;
        if (activity == null) return;
        if (!parentCategory.Activities.Contains(activity)) return;

        parentCategory.Activities.Remove(activity);
    }

    public void Remove(Metric metric, Activity parentActivity)
    {
        if (parentActivity == null) return;
        if (metric == null) return;
        if (!parentActivity.Metrics.Contains(metric)) return;

        parentActivity.Metrics.Remove(metric);
    }

    public void Remove(DataSkeleton skeleton, Metric parentMetric)
    {
        if (parentMetric == null) return;
        if (skeleton == null) return;
        if (!parentMetric.CollectedData.Data.Contains(skeleton)) return;

        parentMetric.CollectedData.Data.Remove(skeleton);
    }
    #endregion

    [ContextMenu("Save To JSON")]
    public void SaveToJSON()
    {
        string json = JsonConvert.SerializeObject(container);
        Debug.Log(json);
        PlayerPrefs.SetString(SaveDataName, json);
        PlayerPrefs.Save();
    }
    [ContextMenu("Load From JSON")]
    public void LoadFromJSON()
    {
        string json = PlayerPrefs.GetString(SaveDataName);
        CategoriesContainer savedContainer = JsonConvert.DeserializeObject<CategoriesContainer>(json);
        container = savedContainer;
    }

    [ContextMenu("Debug Loading From JSON")]
    public void DebugLoadingFromJSON()
    {
        string json = PlayerPrefs.GetString(SaveDataName);
        Debug.Log(json);
        CategoriesContainer savedContainer = JsonConvert.DeserializeObject<CategoriesContainer>(json);
    }
}
