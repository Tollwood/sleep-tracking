using UnityEngine;

public static class RecordsManager {

    public static Records GetHistory(){
        return JsonUtility.FromJson<Records>(PlayerPrefs.GetString("history", JsonUtility.ToJson(new Records())));
    }
    public static Records GetReverseHistory(){
        Records history = GetHistory();
        history.records.Reverse();
        return history;
    }

    public static void resetHistory()
    {
        PlayerPrefs.SetString("history", JsonUtility.ToJson(new Records()));
    }

    private static void updateHistory(Record record){
        Records history = GetHistory();
        history.records.Add(record);
        PlayerPrefs.SetString("history", JsonUtility.ToJson(history));
    }


    public static void updateHistory(Records history)
    {
        PlayerPrefs.SetString("history", JsonUtility.ToJson(history));
    }


    public static void save(Record record)
    {
        if(record.id == 0){
            record.id = GetNextId();
        }
        Records history = RecordsManager.GetHistory();
        history.records.Add(record);
        PlayerPrefs.SetString("history", JsonUtility.ToJson(history));
    }

    internal static Records GetReverseHistorySortedByDay()
    {
        Records history = RecordsManager.GetHistory();
        history.records.Sort();
        return history;
    }

    public static int GetNextId()
    {
        int nextId = PlayerPrefs.GetInt("UniqueId", 1);
        PlayerPrefs.SetInt("UniqueId", nextId + 1);
        return nextId;
    }

    public static void delete(Record record)
    {
        Records history = RecordsManager.GetHistory();
        history.records = history.records.FindAll((obj) => obj.id != record.id);
        PlayerPrefs.SetString("history", JsonUtility.ToJson(history));
    }
}
