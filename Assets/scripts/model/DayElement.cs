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
            date = setCurrentDate(record);
            return;
        }
        SleepElement[] sleeps = sleepElements.ToArray();
        SleepElement lastElement = sleeps[sleeps.Length - 1];
        Record[] records = lastElement.GetRecords().ToArray();
        Record lastRecord = records[records.Length - 1];

        if(lastRecord.getStartDateTime().AddHours(-2) < record.getEndDateTime()){
            lastElement.addRecord(record);
            return;
        }
        SleepElement element = new SleepElement();
        element.addRecord(record);
        sleepElements.Add(element);
    }

    private DateTime setCurrentDate(Record record)
    {
        if(record.getStartDateTime().Hour > 18){
            DateTime newDate = record.getStartDateTime().AddDays(1);
            return newDate;
        }
        return record.getStartDateTime();
    }

    internal bool isSameDay(Record record)
    {
        if(date.Year == 1){
            return true;
        }
        DateTime startDate = date.Date.AddHours(-6);
        DateTime endDate = date.Date.AddHours(18);
        //today 18 - to yesterday
        if(  startDate < record.getStartDateTime() && endDate > record.getStartDateTime()){
            return true;
        }

        return false;
    }
}