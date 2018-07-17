using System.Collections.Generic;
using UnityEngine;

public class DayOverviewController : AbstracListController<DayElement>
{

    private void Awake()
    {
        container = transform.Find("DayContainer");
    }

    private void OnEnable()
    {
        elements = RecordsManager.GetDayElements();
    }

    protected override void addElement(DayElement element)
    {
        ObjectFactory.createDayElement(element,this.gameObject, container);
    }
}
