using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordMigrator: MonoBehaviour {

    public Text oldJson;
    public Text newJson;

    private void Start()
    {
        migrateData();     
    }

    public  void migrateData(){
        string jsonString = PlayerPrefs.GetString("history", "{}");
        PlayerPrefs.SetString("historyBackup2", jsonString);
        oldJson.text = jsonString;
        HistoryOld oldData = JsonUtility.FromJson<HistoryOld>(jsonString);
        Records history = new Records();
        //history.records = oldData.records.ConvertAll<Record>((input) => new Record(RecordsManager.GetNextId(), input.startDateMil, input.endTimeMil, ""));
        string backup = PlayerPrefs.GetString("historyBackup", "{}");
        newJson.text = JsonUtility.ToJson(backup);
        //RecordsManager.updateHistory(history);

    }

}

[Serializable]
class HistoryOld {

    public List<TimeRecordOld> records;

    public HistoryOld()
    {
        records = new List<TimeRecordOld>();
    }

}
    

[Serializable]
public class TimeRecordOld : IComparable<Record>
{
    public string startDateMil;
    public string endTimeMil;

    public int CompareTo(Record obj)
    {
        double start = Double.Parse(this.startDateMil);
        double startObj = Double.Parse(obj.endMil);
        if (start > startObj)
        {
            return -1;
        }
        else if (start < startObj)
        {
            return 1;
        }
        return 0;
    }
}