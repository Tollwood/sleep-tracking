using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SleepElementController : MonoBehaviour, IPointerClickHandler
{
    private SleepElement sleepElement;
    private DayElement dayElement;
    private GameObject prevView;
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
        Destroy(prevView);
        ObjectFactory.createSleepView(dayElement, sleepElement);

    }

    public void configure(DayElement dayElement, SleepElement sleepElement, GameObject prevView, bool interactable){
        this.dayElement = dayElement;
        this.sleepElement = sleepElement;
        this.prevView = prevView;
        this.interactable = interactable;

        this.sleepUnits.text = sleepElement.GetRecords().Count+"";
        this.duration.text = TimeRecordUtility.MiliSecToDuration(sleepElement.GetTotalSleepTime());

        Record[] array = sleepElement.GetRecords().ToArray();
        String startDateTime = TimeRecordUtility.DateTimeToTimeString(array[0].getStartDateTime());
        this.fromTo.text = startDateTime + " - " + TimeRecordUtility.DateTimeToTimeString(array[array.Length - 1].getEndDateTime());

    }
}
