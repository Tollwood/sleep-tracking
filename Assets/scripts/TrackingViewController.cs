using UnityEngine;

public class TrackingViewController : MonoBehaviour {
    
    private Transform awakeGroup;
    private Transform sleepGroup;

    private void Awake()
    {
        awakeGroup = transform.Find("AwakeGroup");
        sleepGroup = transform.Find("SleepGroup");
    }

    private void Start()
    {
        ObjectFactory.createDayList();

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
        ObjectFactory.createStatisticsView();
    }

    public void onShowDayOverview()
    {
        ObjectFactory.createDayList();
    }

    public void onResetHistoryClicked()
    {
        RecordsManager.resetHistory();
    }
 
    public void onNew()
    {
        ObjectFactory.createDetailView(Record.NewTimeRecord());
    }
}
