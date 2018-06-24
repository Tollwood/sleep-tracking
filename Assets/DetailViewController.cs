using System;
using UnityEngine;
using UnityEngine.UI;
public class DetailViewController : MonoBehaviour {
    
    private Record timeRecord;
    private Text title;
    private Button deletButton;
    private InputField hintInput;
    private DateTimeSelectorController startDateTimeSelector;
    private DateTimeSelectorController endDateTimeSelector;
    internal Action onClose;

    public void setSelectedTimeRecord(Record tr){timeRecord = tr;}

    public Record GetTimeRecord(){return timeRecord;}

    private void onDelete()
    {
        RecordsManager.delete(timeRecord);
        timeRecord = null;
    }

    private void onBack(){ timeRecord = null;}

    private void onSave()
    {
        timeRecord.hint = hintInput.text;
        timeRecord.SetStartDate(startDateTimeSelector.dateTime);
        timeRecord.SetEndDate(endDateTimeSelector.dateTime);
        if(timeRecord.id == 0){
            RecordsManager.save(timeRecord);
        }
        RecordManager.update(timeRecord);
        timeRecord = null;
        onClose();
    }

    private void Awake()
    {
        title = transform.Find("Title").GetComponent<Text>();
        deletButton = transform.Find("DeleteButton").GetComponent<Button>();
        hintInput = transform.Find("HintInput").GetComponent<InputField>();
        startDateTimeSelector = transform.Find("StartDateTimeSelector").GetComponent<DateTimeSelectorController>();
        endDateTimeSelector = transform.Find("EndDateTimeSelector").GetComponent<DateTimeSelectorController>();
    }

    private void OnEnable(){
        title.text = "Bearbeiten";

        if(timeRecord.isNewRecord()){
            title.text = "Neuer Eintrag";
        }

        deletButton.gameObject.SetActive(!timeRecord.isNewRecord());
        hintInput.text = timeRecord.hint;
        startDateTimeSelector.dateTime = timeRecord.getStartDateTime();
        endDateTimeSelector.dateTime = timeRecord.getEndDateTime();
    }

}
