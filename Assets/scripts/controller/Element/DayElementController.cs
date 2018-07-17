using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DayElementController : MonoBehaviour, IPointerClickHandler
{
    private DayElement dayElement;
    private GameObject previousView;
    private bool interactable;

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
        if(!interactable){
            return; 
        }
        Destroy(previousView);
        ObjectFactory.createDayView(dayElement);
    }


    public void configure(DayElement dayElement, GameObject previousView, bool interactable){
        this.dayElement = dayElement;
        this.sleepUnits.text = dayElement.GetSleepCount()+"";
        this.date.text = dayElement.GetDate();
        this.duration.text = TimeRecordUtility.MiliSecToDuration(dayElement.GetTotalSleepTime());
        this.previousView = previousView;
        this.interactable = interactable;
    }

}
