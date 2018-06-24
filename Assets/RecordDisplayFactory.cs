using System;
using UnityEngine;
using UnityEngine.UI;

public class RecordDisplayFactory: MonoBehaviour {
    
    public static void configureHistoryDisplay( GameObject go, Record timeRecord, Func<Record, Record> selectTimeRecord){
        updateTextofChild(go, "Start", TimeRecordUtility.DateTimeToTimeString(timeRecord.getStartDateTime()));
        updateTextofChild(go, "End", TimeRecordUtility.DateTimeToTimeString(timeRecord.getEndDateTime()));
        updateTextofChild(go, "Duration", TimeRecordUtility.DurationAsString(timeRecord));
        // .GetComponentInChildren<Button>()
        go.GetComponent<RecordDisplayController>().timeRecord = timeRecord;
        go.GetComponent<RecordDisplayController>().selectTimeRecord = selectTimeRecord;
    }

    private static Record log(Record timeRecord){
        String logString = (timeRecord.getStartDateTime()) + " - " + TimeRecordUtility.DateTimeToString(timeRecord.getEndDateTime());
        Debug.Log(logString);
        return timeRecord;
    }

    private static  void enableDayMarkerIfDayChanged(GameObject go, Record timeRecord)
    {
        if (timeRecord.getStartDateTime().Date < timeRecord.getEndDateTime().Date)
        {
            go.transform.GetChild(0).gameObject.SetActive(true);
            go.transform.GetChild(0).GetComponentInChildren<Text>().text = TimeRecordUtility.DateTimeToDateString(timeRecord.getStartDateTime());
        }
    }

    private static void updateTextofChild(GameObject go, string name, string text)
    {
        go.transform.Find(name).GetComponent<Text>().text = text;
    }

    private static void setColor(GameObject go, bool setWhite)
    {
        if (setWhite) {
            go.GetComponent<Image>().color = Color.white;
        }
    }

    internal static GameObject create(GameObject prefab, Record timeRecord, bool setWhite, Transform parent, Func<Record, Record> selectTimeRecord)
    {
        GameObject go = Instantiate(prefab, parent);
        setColor(go, setWhite);
        enableDayMarkerIfDayChanged(go, timeRecord);
        configureHistoryDisplay(go, timeRecord, selectTimeRecord);
        return go;
    }
}
