using System;
using UnityEngine;
using UnityEngine.UI;

public class DateTimeSelectorController : MonoBehaviour
{
    private InputField dayInput;
    private InputField monthInput;
    private InputField yearInput;
    private InputField hourInput;
    private InputField minutesInput;

    public DateTime dateTime;

    private void Awake()
    {
        dayInput = transform.Find("DayInput").GetComponent<InputField>();
        monthInput = transform.Find("MonthInput").GetComponent<InputField>();    
        yearInput = transform.Find("YearInput").GetComponent<InputField>();    
        hourInput = transform.Find("HourInput").GetComponent<InputField>();    
        minutesInput = transform.Find("MinutesInput").GetComponent<InputField>();    
    }

    private void OnEnable()
    {
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
        dayInput.text = dateTime.Day.ToString();
        monthInput.text = dateTime.Month.ToString();
        yearInput.text = dateTime.Year.ToString();
        hourInput.text = dateTime.Hour.ToString();
        minutesInput.text = dateTime.Minute.ToString();
    }
}
