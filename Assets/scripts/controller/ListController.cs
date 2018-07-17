using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListController : MonoBehaviour
{

  /*  public GameObject dayMarkerPrefab;
    public GameObject elementPrefab;


    private DateTime? dayMarkerDateTime = null;
    private Transform recordContainer;
    private int currentSize = -1;

    private void Awake(){
        recordContainer = transform.Find("RecordContainer");
    }
    private void OnEnable(){
        refreshList();
    }
    public void Update(){
        Records reversedHistory = RecordsManager.GetReverseHistorySortedByDay();
        if (currentSize == reversedHistory.records.Count)
        {
            return;
        }
        refreshList();
    }

    public void refreshList(){
        clearList();
        Records reversedHistory = RecordsManager.GetReverseHistorySortedByDay();
        dayMarkerDateTime = null;

        bool setWhite = true;
        foreach (Record timeRecord in reversedHistory.records)
        {
            addDayMarkerIfDayChanged(timeRecord);
            addElement(timeRecord, setWhite);
            setWhite = !setWhite;
        }
        currentSize = reversedHistory.records.Count;
    }


    private void clearList()
    {
  //      foreach (Transform child in recordContainer)
        //      {
        //  Destroy(child.gameObject);
        //}
    }

    public void addDayMarkerIfDayChanged(Record timeRecord)
    {
        if (dayMarkerDateTime == null)
        {
            dayMarkerDateTime = DateTime.Now;
            addDayMarker(dayMarkerDateTime.Value);
        }

        DateTime endDate = timeRecord.getEndDateTime();
        bool startEndsOnSameDay = timeRecord.getStartDateTime().Day == timeRecord.getEndDateTime().Day;
        bool isOnPrevDay = endDate.Date < dayMarkerDateTime.GetValueOrDefault(DateTime.Now).Date;
        dayMarkerDateTime = timeRecord.getStartDateTime();
        if (isOnPrevDay && startEndsOnSameDay)
        {
            addDayMarker(endDate);

        }
    }

    public void addDayMarker(DateTime dateToSet)
    {
        GameObject dayMarkerGo = Instantiate(dayMarkerPrefab, recordContainer);
        dayMarkerGo.GetComponentInChildren<Text>().text = TimeRecordUtility.DateTimeToDateString(dateToSet);

    }

    public void editRecord(Record record)
    {
        GetComponentInParent<TrackingViewController>().editRecord(record);
    }


    public GameObject addElement( Record timeRecord, bool setWhite)
    {
        GameObject go = Instantiate(elementPrefab, recordContainer);
        if (setWhite)
        {
            go.GetComponent<Image>().color = Color.white;
        }
        go.GetComponent<RecordController>().setRecord(timeRecord, editRecord);
        return go;
    }
*/
}
