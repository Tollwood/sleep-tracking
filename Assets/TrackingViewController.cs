using System;
using UnityEngine;
using UnityEngine.UI;

public class TrackingViewController : MonoBehaviour {
    
    private Transform list;
    private Transform statistics;
    private Transform awakeGroup;
    private Transform sleepGroup;

    private void Awake()
    {
        awakeGroup = transform.Find("AwakeGroup");
        sleepGroup = transform.Find("SleepGroup");
        statistics = transform.Find("Statistics");
        list = transform.Find("List");
    }

    public void Update()
    {
        updateActiveState();
    }

    private void updateActiveState()
    {
        Record timeRecord = RecordManager.getActiveTimeRecord();
        awakeGroup.gameObject.SetActive(!timeRecord.isTracking());
        sleepGroup.gameObject.SetActive(timeRecord.isTracking());
    }

    public void onAwakeUp()
    {
        RecordManager.endRecording();
        updateActiveState();
    }

    public void onSleeping()
    {
        RecordManager.startRecording();
        updateActiveState();
    }

    public void onShowStatistics()
    {
        bool visibility = list.gameObject.gameObject.activeSelf;
        awakeGroup.gameObject.SetActive(!visibility);
        list.gameObject.SetActive(!visibility);
        statistics.gameObject.SetActive(visibility);
    }
    public void onResetHistoryClicked()
    {
        RecordsManager.resetHistory();
    }
 
    public void onNew()
    {
        editRecord(Record.NewTimeRecord());
    }

    public void editRecord(Record record){
        transform.GetComponentInParent<CanvasController>().editRecord(record);
    }
   
}
