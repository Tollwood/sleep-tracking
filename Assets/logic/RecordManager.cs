using System;
using System.Collections.Generic;
using UnityEngine;

public static class RecordManager {
    
    public static Record getActiveTimeRecord(){
        return JsonUtility.FromJson<Record>(PlayerPrefs.GetString("activeRecord", "{}"));
    }

    public static void resetActiveTimeRecord()
    {
        PlayerPrefs.SetString("activeRecord", "{}");
    }
    public static Record getById(int id){
        return RecordsManager.GetHistory().records.Find((obj) => obj.id == id);
    }
    public static void update(Record timeRecord) {
        Records history = RecordsManager.GetHistory();
        List<Record> records = history.records.ConvertAll((Record input) =>
        {
            int id = input.id;
            if(id == timeRecord.id){
                return timeRecord;
            }
            return input;
        });
        history.records = records;
        RecordsManager.updateHistory(history);
    }

    internal static void startRecording()
    {
        Record activeRecord = getActiveTimeRecord();
        activeRecord.startMil = CurrentDateTimeToMilSecs();
        PlayerPrefs.SetString("activeRecord", JsonUtility.ToJson(activeRecord));
    }


    internal static void endRecording()
    {
        Record activeRecord = getActiveTimeRecord();
        if (activeRecord.startMil == null)
        {
            return;
        }
        activeRecord.endMil = CurrentDateTimeToMilSecs();
        RecordsManager.save(activeRecord);
        PlayerPrefs.SetString("activeRecord", JsonUtility.ToJson(new Record()));
    }


    private static string CurrentDateTimeToMilSecs()
    {
        return (DateTime.Now - DateTime.MinValue).TotalMilliseconds.ToString();
    }

}
