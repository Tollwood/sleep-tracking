using UnityEngine;
using System.Collections;
using System;

public class ObjectFactory : MonoBehaviour
{
    private static GameObject currentView;
    
    internal static GameObject createDayView(DayElement dayElement){
        Destroy(currentView);
        GameObject go = Instantiate(Resources.Load("DayView", typeof(GameObject)), GameObject.Find("Canvas").transform) as GameObject;
        go.GetComponent<DayDetailViewController>().configure(dayElement);
        currentView = go;
        return currentView;
    }

    internal static void createDayElement(DayElement element, GameObject parent, Transform container)
    {
        GameObject go = Instantiate(Resources.Load("DayElement", typeof(GameObject)), container) as GameObject;
        go.GetComponent<DayElementController>().configure(element, parent, true);
    }

    internal static GameObject createDetailView(Record record){
        Destroy(currentView);
        GameObject go = Instantiate(Resources.Load("DetailView", typeof(GameObject)), GameObject.Find("Canvas").transform) as GameObject;
        go.GetComponent<DetailViewController>().configure(record);
        currentView = go;
        return currentView;
    }

    internal static GameObject createDayList()
    {
        Destroy(currentView);
        GameObject go =  Instantiate(Resources.Load("DayList", typeof(GameObject)), GameObject.Find("Canvas").transform) as GameObject;
        currentView = go;
        return currentView;
    }

    internal static GameObject createSleepView(DayElement dayElement, SleepElement sleepElement){
        Destroy(currentView);
        GameObject go = Instantiate(Resources.Load("SleepView", typeof(GameObject)), GameObject.Find("Canvas").transform) as GameObject;
        go.GetComponent<SleepDetailViewController>().configure(dayElement, sleepElement);
        currentView = go;
        return currentView;
    }

    internal static GameObject createStatisticsView()
    {
        Destroy(currentView);
        GameObject go = Instantiate(Resources.Load("StatisticsView", typeof(GameObject)), GameObject.Find("Canvas").transform) as GameObject;
        currentView = go;
        return currentView;
    }

    internal static GameObject createSleepElement(DayElement dayElement, SleepElement sleepElement, GameObject prevView, Transform container)
    {
        GameObject go = Instantiate(Resources.Load("SleepElement", typeof(GameObject)), container) as GameObject;
        go.GetComponent<SleepElementController>().configure(dayElement, sleepElement, prevView, true);
        return go;
    }

    internal static GameObject createRecord(Record record, Transform parent){
        GameObject go = Instantiate(Resources.Load("Record", typeof(GameObject)), parent) as GameObject;
        go.GetComponent<RecordController>().configure(record, true);
        return go;
    }

}
