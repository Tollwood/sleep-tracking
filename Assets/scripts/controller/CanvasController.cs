using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private DetailViewController detailView;
    private TrackingViewController trackingView;

    private void Awake()
    {
        detailView = transform.Find("DetailView").GetComponent<DetailViewController>();
        trackingView = transform.Find("TrackingView").GetComponent<TrackingViewController>();
    }

    private void Update()
    {
        bool isEditingRecord = detailView.GetTimeRecord() != null;
        detailView.gameObject.SetActive(isEditingRecord);
        trackingView.gameObject.SetActive(!isEditingRecord);
    }

    internal void editRecord(Record record)
    {
        detailView.setSelectedTimeRecord(record);
    }
}
