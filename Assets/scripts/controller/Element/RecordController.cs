﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RecordController : MonoBehaviour, IPointerClickHandler
{
    private Record record;
    private Text startText;
    private Text endText;
    private Text durationText;
    private GameObject dayMarker;
    private bool interactable;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!interactable)
        {
            return;
        }
        ObjectFactory.createDetailView(record);
    }

    public void configure(Record record, bool interactable){
        this.record = record;
        this.interactable = interactable;
        transform.Find("Start").GetComponent<Text>().text =  TimeRecordUtility.DateTimeToTimeString(record.getStartDateTime());
        transform.Find("End").GetComponent<Text>().text = TimeRecordUtility.DateTimeToTimeString(record.getEndDateTime());
        transform.Find("Duration").GetComponent<Text>().text =  TimeRecordUtility.DurationAsString(record);
        if (record.getStartDateTime().Date < record.getEndDateTime().Date){
            dayMarker = transform.Find("DayMarker").gameObject;
            dayMarker.SetActive(true);
            dayMarker.GetComponentInChildren<Text>().text = TimeRecordUtility.DateTimeToDateString(record.getStartDateTime());
        }

    }
}
