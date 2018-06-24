using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecordDisplayController : MonoBehaviour, IPointerClickHandler
{
    public Record timeRecord;
    public Func<Record,Record> selectTimeRecord;

    public void OnPointerClick(PointerEventData eventData)
    {
        selectTimeRecord(timeRecord);
    }

}
