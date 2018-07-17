using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DayElementController : MonoBehaviour, IPointerClickHandler
{
    private DayElement dayElement;
    private Action onClick = null;
    private Text sleepUnits;
    private Text date;
    private Text duration; 

    private void Awake()
    {
        sleepUnits = transform.Find("Sleep Units").GetComponent<Text>();
        date = transform.Find("DayLabel").GetComponent<Text>();
        duration = transform.Find("SleepDuration").GetComponent<Text>();
  
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        onClick();
    }


    public void configure(DayElement dayElement, Action onClickAction) {
        this.dayElement = dayElement;
        this.sleepUnits.text = dayElement.GetSleepCount() + "";
        this.date.text = dayElement.GetDate();
        this.onClick = onClickAction;
        this.duration.text = TimeRecordUtility.MiliSecToDuration(dayElement.GetTotalSleepTime());
    }

}
