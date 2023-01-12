using UnityEngine;

//[CreateAssetMenu(fileName = "New Metric", menuName = "Data/Metric", order = 3)]
[System.Serializable]
public class Metric
{
    [System.Flags]
    public enum Type
    {
        Nothing     = 0,
        WholeNumber = 1,
        Digit       = 2,
        Seconds     = 4,
        Date        = 8,
        Percentage  = 16,
        Completed   = 32,
    }

    [SerializeField]
    private Type typeOfMetric = Type.Nothing;
    public Type TypeOfMetric { get => typeOfMetric; }

    [SerializeField]
    private DataContainer collectedData;
    public DataContainer CollectedData { get => collectedData; }

    public Metric(Type TypeOfMetric, DataContainer CollectedData)
    {
        this.typeOfMetric = TypeOfMetric;
        this.collectedData = CollectedData;
    }
}
