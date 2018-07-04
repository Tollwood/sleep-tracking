﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class DateTimeSelectorController : MonoBehaviour
{
    private Button dayUpButton;
    private InputField dayInput;
    private Button dayDownButton;
    private Button monthUpButton;
    private InputField monthInput;
    private Button monthDownButton;
    private Button yearUpButton;
    private InputField yearInput;
    private Button yearDownButton;
    private Button hourUpButton;
    private InputField hourInput;
    private Button hourDownButton;
    private Button minutesUpButton;
    private InputField minutesInput;
    private Button minutesDownButton;
    private DateTime dateTime;
    private DateTime renderedDatTime;

    protected void Awake()
    {
        dayUpButton = transform.Find("DayUp").GetComponent<Button>();
        dayInput = transform.Find("DayInput").GetComponent<InputField>();
        dayDownButton = transform.Find("DayDown").GetComponent<Button>();
        monthUpButton = transform.Find("MonthUp").GetComponent<Button>();
        monthInput = transform.Find("MonthInput").GetComponent<InputField>();    
        monthDownButton = transform.Find("MonthDown").GetComponent<Button>();
        yearUpButton = transform.Find("YearUp").GetComponent<Button>();
        yearInput = transform.Find("YearInput").GetComponent<InputField>();    
        yearDownButton = transform.Find("YearDown").GetComponent<Button>();
        hourUpButton = transform.Find("HoursUp").GetComponent<Button>();
        hourInput = transform.Find("HourInput").GetComponent<InputField>();   
        hourDownButton = transform.Find("HoursDown").GetComponent<Button>();
        minutesUpButton = transform.Find("MinutesUp").GetComponent<Button>();
        minutesInput = transform.Find("MinutesInput").GetComponent<InputField>();    
        minutesDownButton = transform.Find("MinutesDown").GetComponent<Button>();
    }

    private void Start()
    {
        dayUpButton.onClick.AddListener(onDayUp);
        dayDownButton.onClick.AddListener(onDayDown);
        monthUpButton.onClick.AddListener(onMonthUp);
        monthDownButton.onClick.AddListener(onMonthDown);
        yearUpButton.onClick.AddListener(onYearUp);
        yearDownButton.onClick.AddListener(onYearDown);
        hourUpButton.onClick.AddListener(onHoursUp);
        hourDownButton.onClick.AddListener(onHoursDown);
        minutesUpButton.onClick.AddListener(onMinutesUp);
        minutesDownButton.onClick.AddListener(onMinutesDown);
    }

    private void Update()
    {
        if(dateTime != renderedDatTime){
            renderDateTime();
            renderedDatTime = dateTime;
        }
    }
    private void OnEnable(){
        renderDateTime();
    }
    public void onMinutesUp()
    {
        dateTime = dateTime.AddMinutes(1);
        renderDateTime();
    }

    public void onMinutesDown()
    {
        dateTime = dateTime.AddMinutes(-1);
        renderDateTime();
    }

    public void onHoursUp()
    {
        dateTime = dateTime.AddHours(1);
        renderDateTime();
    }

    public void onHoursDown()
    {
        dateTime = dateTime.AddHours(-1);
        renderDateTime();
    }

    public void onDayUp()
    {
        dateTime = dateTime.AddDays(1);
        renderDateTime();
    }

    public void onDayDown()
    {
        dateTime = dateTime.AddDays(-1);
        renderDateTime();
    }

    public void onMonthUp()
    {
        dateTime = dateTime.AddMonths(1);
        renderDateTime();
    }

    public void onMonthDown()
    {
        dateTime = dateTime.AddMonths(-1);
        renderDateTime();
    }

    public void onYearUp()
    {
        dateTime = dateTime.AddYears(1);
        renderDateTime();
    }

    public void onYearDown()
    {
        dateTime = dateTime.AddYears(-1);
        renderDateTime();
    }

    private void renderDateTime(){
        transform.Find("DayInput").GetComponent<InputField>().text = dateTime.Day.ToString();
        transform.Find("MonthInput").GetComponent<InputField>().text = dateTime.Month.ToString();
        transform.Find("YearInput").GetComponent<InputField>().text = dateTime.Year.ToString();
        transform.Find("HourInput").GetComponent<InputField>().text = dateTime.Hour.ToString();
        transform.Find("MinutesInput").GetComponent<InputField>().text = dateTime.Minute.ToString();
    }

    public void SetDateTime(DateTime newDateTime){
        dateTime = newDateTime;
        renderDateTime();
    }

    public DateTime GetDateTime(){
        return dateTime;
    }
}
