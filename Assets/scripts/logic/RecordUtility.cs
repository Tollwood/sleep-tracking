using UnityEngine;
using System;


public class TimeRecordUtility {
    
    public static void logTimeRecord(Record timeRecord)
    {
        Debug.Log(DurationAsString(timeRecord));
        Debug.Log(DateTimeToString(timeRecord.getStartDateTime()));
        Debug.Log(DateTimeToString(timeRecord.getEndDateTime()));
        Debug.Log(JsonUtility.ToJson(timeRecord));
    }

    internal static string DurationAsString(Record timeRecord)
    {
        DateTime endTime = (timeRecord.endMil == null || timeRecord.endMil == "") ? DateTime.Now : timeRecord.getEndDateTime();
        TimeSpan duration = (endTime - timeRecord.getStartDateTime());
        return String.Format("{0}h {1}min {2}sec", duration.Hours.ToString().PadLeft(2, '0'), duration.Minutes.ToString().PadLeft(2,'0'), duration.Seconds.ToString().PadLeft(2, '0'));
    }

    internal static string MiliSecToDuration(double totalSleepTime)
    {
        int seconds = (int)(totalSleepTime / 1000) % 60;
        int minutes = (int)((totalSleepTime / (1000 * 60)) % 60);
        int hours = (int)((totalSleepTime / (1000 * 60 * 60)) % 24);
        return String.Format("{0}:{1}:{2}", hours.ToString().PadLeft(2, '0'), minutes.ToString().PadLeft(2, '0'), seconds.ToString().PadLeft(2, '0'));

    }

    internal static double DurationInMiliSec(Record timeRecord)
    {
        DateTime endTime = (timeRecord.endMil == null || timeRecord.endMil == "") ? DateTime.Now : timeRecord.getEndDateTime();
        TimeSpan duration = (endTime - timeRecord.getStartDateTime());
        return duration.TotalMilliseconds;
    }

    internal static string DateTimeToString(DateTime dateTime){
        return String.Format("{0}.{1}.{2} {3}:{4}", dateTime.Day.ToString().PadLeft(2,'0'), dateTime.Month.ToString().PadLeft(2,'0'), dateTime.Year, dateTime.Hour.ToString().PadLeft(2,'0'), dateTime.Minute.ToString().PadLeft(2, '0'));
    }

    internal static string DateTimeToDateString(DateTime dateTime)
    {
        return String.Format("{0}.{1}.{2}", dateTime.Day.ToString().PadLeft(2, '0'), dateTime.Month.ToString().PadLeft(2, '0'), dateTime.Year);
    }

    internal static string DateTimeToTimeString(DateTime dateTime)
    {
        return String.Format("{0}:{1}", dateTime.Hour.ToString().PadLeft(2, '0'), dateTime.Minute.ToString().PadLeft(2, '0'));
    }
}
