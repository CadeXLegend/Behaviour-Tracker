using UnityEngine;

public class GoEnablerFromUIState : MonoBehaviour
{
    [SerializeField]
    private GameObject[] categoryStateObjects;
    [SerializeField]
    private GameObject[] activityStateObjects;
    [SerializeField]
    private GameObject[] metricStateObjects;

    [SerializeField]
    private UIViewsObject uiViewsObject;

    private void Start()
    {
        uiViewsObject.OnViewStateChanged += () =>
        {
            switch (uiViewsObject.View.ViewState)
            {
                case UIView.State.Category:
                    foreach (GameObject go in categoryStateObjects)
                        go.SetActive(true);
                    foreach (GameObject go in activityStateObjects)
                        go.SetActive(false);
                    foreach (GameObject go in metricStateObjects)
                        go.SetActive(false);
                    break;
                case UIView.State.Activity:
                    foreach (GameObject go in categoryStateObjects)
                        go.SetActive(false);
                    foreach (GameObject go in activityStateObjects)
                        go.SetActive(true);
                    foreach (GameObject go in metricStateObjects)
                        go.SetActive(false);
                    break;
                case UIView.State.Metric:
                    foreach (GameObject go in categoryStateObjects)
                        go.SetActive(false);
                    foreach (GameObject go in activityStateObjects)
                        go.SetActive(false);
                    foreach (GameObject go in metricStateObjects)
                        go.SetActive(true);
                    break;
            }
        };
    }
}
