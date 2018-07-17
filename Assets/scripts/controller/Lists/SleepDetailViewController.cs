using System.Collections.Generic;
using UnityEngine;

public class SleepDetailViewController : AbstracListController<Record>{
    private DayElement dayElement;
    private SleepElement sleepElement;
    private Transform prevView;
    private Transform dayElemetUi;
    private Transform sleepElementUi;

    private void Awake()
    {
        dayElemetUi = transform.Find("DayElement");
        sleepElementUi = transform.Find("SleepElement");
        container = transform.Find("RecordList/RecordContainer");
    }

    public void configure(DayElement dayElement, SleepElement sleepElement){
        this.dayElement = dayElement;
        this.sleepElement = sleepElement;
        dayElemetUi.GetComponent<DayElementController>().configure(dayElement, ()=> { ObjectFactory.createDayView(dayElement); });
        sleepElementUi.GetComponent<SleepElementController>().configure(dayElement, sleepElement, false);
        elements = sleepElement.GetRecords(); 
    }

    protected override void addElement(Record element)
    {
        ObjectFactory.createRecord(element, container);
    }
}
