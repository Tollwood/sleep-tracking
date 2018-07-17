using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SleepElementController : MonoBehaviour, IPointerClickHandler
{
    private SleepElement sleepElement;
    private DayElement dayElement;
    private bool interactable;

    private Text fromTo;
    private Text sleepUnits;
    private Text duration;

    private void Awake()
    {
        fromTo = transform.Find("FromTo").GetComponent<Text>();
        sleepUnits = transform.Find("Sleep Units").GetComponent<Text>();
        duration = transform.Find("Duration").GetComponent<Text>();
  
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(!interactable){
            return;
        }
        ObjectFactory.createSleepView(dayElement, sleepElement);

    }

    public void configure(DayElement dayElement, SleepElement sleepElement, bool interactable){
        this.dayElement = dayElement;
        this.sleepElement = sleepElement;
        this.interactable = interactable;

        String count = "";
        if(sleepElement.GetRecords().Count > 1){
            count = (sleepElement.GetRecords().Count - 1) + "";
        }
        this.sleepUnits.text = count;
        this.duration.text = TimeRecordUtility.MiliSecToDuration(sleepElement.GetTotalSleepTime());

        Record[] array = sleepElement.GetRecords().ToArray();
        String startDateTime = TimeRecordUtility.DateTimeToTimeString(array[array.Length-1].getStartDateTime());
        String endDateTime = TimeRecordUtility.DateTimeToTimeString(array[0].getEndDateTime());
        this.fromTo.text = startDateTime + " - " + endDateTime;

    }
}
