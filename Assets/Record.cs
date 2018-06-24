using System;

[Serializable]
public class Record : IComparable<Record>{
    public int id;
    public string startMil;
    public string endMil;
    public string hint;

    public static Record NewTimeRecord(){
        Record timeRecord = new Record();
        timeRecord.SetStartDate(DateTime.Now);
        timeRecord.SetEndDate(DateTime.Now);
        return timeRecord;
    }

    public Record(){}

    public Record(int id, string startMil, string endMil, string hint)
    {
        this.id = id;
        this.startMil = startMil;
        this.endMil = endMil;
        this.hint = hint;
    }

    public DateTime getStartDateTime(){
        return toDateTime(startMil);
    }

    public DateTime getEndDateTime(){
        return toDateTime(endMil);
    }

    private DateTime toDateTime(string miliSec){
        return (new DateTime(1, 1, 1)).AddMilliseconds(double.Parse(miliSec));
    }

    private string toDateTimeMil(DateTime dateTime){
        return (dateTime - DateTime.MinValue).TotalMilliseconds.ToString();
    }

    internal void SetStartDate(DateTime dateTime)
    {
        startMil = toDateTimeMil(dateTime);
    }

    internal void SetEndDate(DateTime dateTime)
    {
        endMil = toDateTimeMil(dateTime);
    }

    public int CompareTo(Record obj)
    {
        double start = Double.Parse(this.startMil);
        double startObj = Double.Parse(obj.startMil);
        if( start> startObj){
            return -1;
        }
        else if (start < startObj)
        {
            return 1;
        }
        return 0;
    }

    internal bool isNewRecord()
    {
        return id == 0;
    }
}
