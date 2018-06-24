using System;
using UnityEngine;
using UnityEngine.UI;

public class DayMarker : MonoBehaviour{
    public GameObject dayMarkerPrefab;
    public GameObject historyContainer;

    private DateTime? dayMarkerDateTime = null;

    public void addDayMarkerIfDayChanged( Record timeRecord)
    {
        if(dayMarkerDateTime == null) {
            dayMarkerDateTime = DateTime.Now;
            addDayMarker(dayMarkerDateTime.Value);
        }

        DateTime endDate = timeRecord.getEndDateTime();
        bool startEndsOnSameDay = timeRecord.getStartDateTime().Day == timeRecord.getEndDateTime().Day;
        bool isOnPrevDay = endDate.Date < dayMarkerDateTime.GetValueOrDefault(DateTime.Now).Date;
        dayMarkerDateTime = timeRecord.getStartDateTime();
        if (isOnPrevDay && startEndsOnSameDay)
        {
            addDayMarker(endDate);

        }
    }

    public void addDayMarker(DateTime dateToSet)
    {
        GameObject dayMarkerGo = Instantiate(dayMarkerPrefab, historyContainer.transform);
        dayMarkerGo.GetComponentInChildren<Text>().text = TimeRecordUtility.DateTimeToDateString(dateToSet);

    }

    internal void resetDate()
    {
        dayMarkerDateTime = null;
    }
}
