using System;
using System.Collections.Generic;

public class DayElement {
    private DateTime date;
    private List<SleepElement> sleepElements = new List<SleepElement>();

    public DayElement(){ 
    }
    public DayElement(DateTime date){
        this.date = date;
    }
    public String GetDate()
    {
        return TimeRecordUtility.DateTimeToDateString(date);
    }

    public int GetSleepCount(){
        return sleepElements.Count;
    }

    public double GetTotalSleepTime(){
        double totalSleepTime = 0;
        foreach(SleepElement sleepElement in sleepElements){
            totalSleepTime += sleepElement.GetTotalSleepTime();
        }
        return totalSleepTime;
    }

    public List<SleepElement> GetSleepElements(){
        return this.sleepElements;
    }

    internal void addRecord(Record record)
    {
        if(sleepElements.Count == 0){
            SleepElement newSleepElement = new SleepElement();
            newSleepElement.addRecord(record);
            sleepElements.Add(newSleepElement);
            date = record.getStartDateTime();
            return;
        }
        // just add it 
        sleepElements.ToArray()[0].addRecord(record);
    }

    internal bool isSameDay(Record record)
    {
        if( date.Date.Equals(record.getStartDateTime().Date)){
            return true;
        }

        return false;
    }
}