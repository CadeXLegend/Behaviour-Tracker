using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class CategoriesContainer
{
    [SerializeField]
    private List<Category> categories = new List<Category>();
    public List<Category> Categories { get => categories; }

    public CategoriesContainer(List<Category> Categories)
    {
        categories = Categories;
    }
}
