using UnityEngine;

public class DayDetailViewController : AbstracListController<SleepElement>{
    private DayElement dayElement;
    private Transform dayElemetUi;

    private void Awake()
    {
        dayElemetUi = transform.Find("DayElement");
        container = transform.Find("SleepElementList/SleepElementContainer");
    }
    public void configure(DayElement dayElement){
        this.dayElement = dayElement;
        dayElemetUi.GetComponent<DayElementController>().configure(dayElement, this.gameObject, false);
        elements = dayElement.GetSleepElements();
    }

    protected override void addElement(SleepElement element)
    {
        ObjectFactory.createSleepElement(dayElement, element, this.gameObject, container);
    }
}
