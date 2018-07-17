using UnityEngine;

public class StatisticsController : MonoBehaviour {
    private RecordController longestSleep;

    private void Awake()
    {
        longestSleep = transform.Find("longestSleep").GetComponent<RecordController>();
    }

    private void OnEnable()
    {
        longestSleep.configure(RecordManager.getLongestSleepRecord(),false);
    }

    public void onBack(){
        Destroy(this.gameObject);
    }
}
