using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsController : MonoBehaviour {
    private RecordDisplayController longestSleep;

    private void Awake()
    {
        longestSleep = transform.Find("longestSleep").GetComponent<RecordDisplayController>();
    }

    private void OnEnable()
    {
        longestSleep.setRecord(RecordManager.getLongestSleepRecord(),(Record record) => {});
    }
}
