using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject awakeGroup;
    public GameObject sleepGroup;
    public GameObject detailsView;
    public GameObject historyContainer;
    public GameObject recordDisplayPrefab;

    public DetailViewController detailView;
    public DayMarker dayMarker;

    private int currentSize;

    private void Awake()
    {
        detailView.GetComponent<DetailViewController>().onClose = refreshList;
    }

    public void Start(){
        currentSize = -1;
    }

    public void Update()
    {
        enableActiveGroup();
        updateDurationIfActive();
        Records reversedHistory = RecordsManager.GetReverseHistorySortedByDay();
            if(currentSize == reversedHistory.records.Count){
            return;
        }
        refreshList();

    }

    public void onAwakeUp()
    {
        RecordManager.endRecording();
        sleepGroup.gameObject.SetActive(false);
        awakeGroup.gameObject.SetActive(true);
    }

    public void onSleeping()
    {
        RecordManager.startRecording();
        sleepGroup.gameObject.SetActive(true);
        awakeGroup.gameObject.SetActive(false);
    }

    public void onNew(){
        selectTimeRecord(Record.NewTimeRecord());
    }

    public void onResetHistoryClicked()
    {
        RecordsManager.resetHistory();
    }

    private void clearList()
    {
        foreach (Transform child in historyContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void updateDurationIfActive()
    {
        if (sleepGroup.activeSelf)
        {
            Transform durationTime = sleepGroup.transform.Find("Duration").Find("DurationTime");
            string duration = TimeRecordUtility.DurationAsString(RecordManager.getActiveTimeRecord());
            durationTime.GetComponent<Text>().text = duration;
        }
    }



    public void refreshList(){
        clearList();
        Records reversedHistory = RecordsManager.GetReverseHistorySortedByDay();
        dayMarker.resetDate();

        bool setWhite = true;
        foreach (Record timeRecord in reversedHistory.records)
        {
            dayMarker.addDayMarkerIfDayChanged(timeRecord);
            GameObject go = RecordDisplayFactory.create(recordDisplayPrefab, timeRecord, setWhite, historyContainer.transform, selectTimeRecord);
            setWhite = !setWhite;
        }
        currentSize = reversedHistory.records.Count;
    }
    public Record selectTimeRecord(Record timeRecord){
        detailView.setSelectedTimeRecord(timeRecord);
        return timeRecord;
    }
   
    private void enableActiveGroup()
    {
        Record timeRecord = RecordManager.getActiveTimeRecord();

        if (detailView.GetTimeRecord() != null)
        {
            detailsView.SetActive(true);
            awakeGroup.gameObject.SetActive(true);
            sleepGroup.gameObject.SetActive(false);
        }
        else if (timeRecord.startMil == null || timeRecord.startMil == "")
        {
            detailsView.SetActive(false);
            awakeGroup.gameObject.SetActive(true);
            sleepGroup.gameObject.SetActive(false);
        }
        else
        {
            detailsView.SetActive(false);
            awakeGroup.gameObject.SetActive(false);
            sleepGroup.gameObject.SetActive(true);
        }
    }
}
