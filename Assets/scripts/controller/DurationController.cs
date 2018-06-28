using UnityEngine;
using UnityEngine.UI;

public class DurationController : MonoBehaviour
{

    private void Update()
    {
        GetComponent<Text>().text = TimeRecordUtility.DurationAsString(RecordManager.getActiveTimeRecord());
    }


}
