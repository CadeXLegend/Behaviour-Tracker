using UnityEngine;

[System.Serializable]
public class DataSkeleton
{
    [SerializeField]
    private int wholeNumber = 0;
    public int WholeNumber { get => wholeNumber; }
    [SerializeField]
    private double digit = 0.0;
    public double Digit { get => digit; }
    [SerializeField]
    private int seconds = 0;
    public int Seconds { get => seconds; }
    [SerializeField]
    private string date = "";
    public string Date { get => date; }
    [SerializeField]
    private float percentage = 0f;
    public float Percentage { get => percentage; }

    [SerializeField]
    private bool completed = false;
    public bool Completed { get => completed; }

    public DataSkeleton(int WholeNumber, double Digit, int Seconds, string Date, float Percentage, bool Completed)
    {
        this.wholeNumber = WholeNumber;
        this.digit = Digit;
        this.seconds = Seconds;
        this.date = Date;
        this.percentage = Percentage;
        this.completed = Completed;
    }
}
