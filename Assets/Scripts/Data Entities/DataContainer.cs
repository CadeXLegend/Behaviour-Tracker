using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataContainer
{
    [SerializeField]
    private List<DataSkeleton> data = new List<DataSkeleton>();
    public List<DataSkeleton> Data { get => data; }

    public DataContainer(List<DataSkeleton> Data)
    {
        this.data = Data;
    }
}
