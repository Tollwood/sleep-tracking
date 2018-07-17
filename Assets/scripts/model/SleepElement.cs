using System;
using System.Collections.Generic;

public class SleepElement
{
    private DateTime start;
    private DateTime end;
    private List<Record> records;

    public SleepElement()
    {
        records = new List<Record>();
    }

    public int GetSleepPhaseCount(){
        return records.Count;
    }

    public List<Record> GetRecords(){
        return records;
    }

    internal void addRecord(Record record)
    {
        records.Add(record);
    }

    public double GetTotalSleepTime()
    {
        double totalSleepTime = 0;
        foreach (Record record in records)
        {
            totalSleepTime += TimeRecordUtility.DurationInMiliSec(record);
        }
        return totalSleepTime;
    }
}
