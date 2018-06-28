using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecordDisplayController : MonoBehaviour, IPointerClickHandler
{
    private Record record;
    public Action<Record> onSelect;
    private Text startText;
    private Text endText;
    private Text durationText;
    private GameObject dayMarker;

    private void Awake()
    {
        startText = transform.Find("Start").GetComponent<Text>();
        endText = transform.Find("End").GetComponent<Text>();
        durationText = transform.Find("Duration").GetComponent<Text>();
        dayMarker = transform.Find("DayMarker").gameObject;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        onSelect(record);
    }


    public void setRecord(Record record, Action<Record> onSelect){
        this.record = record; 

        startText.text =  TimeRecordUtility.DateTimeToTimeString(record.getStartDateTime());
        endText.text = TimeRecordUtility.DateTimeToTimeString(record.getEndDateTime());
        durationText.text =  TimeRecordUtility.DurationAsString(record);
        if (record.getStartDateTime().Date < record.getEndDateTime().Date){
            dayMarker.SetActive(true);
            dayMarker.GetComponentInChildren<Text>().text = TimeRecordUtility.DateTimeToDateString(record.getStartDateTime());
        }
        this.onSelect = onSelect;
    }
}
