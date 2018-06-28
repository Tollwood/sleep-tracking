using UnityEngine;
using UnityEngine.UI;
public class DetailViewController : MonoBehaviour {
    
    private Record record;
    private Text title;
    private Button deletButton;
    private InputField hintInput;
    private DateTimeSelectorController startDateTimeSelector;
    private DateTimeSelectorController endDateTimeSelector;

    public void setSelectedTimeRecord(Record tr){record = tr;}

    public Record GetTimeRecord(){return record;}

    public void onDelete()
    {
        RecordsManager.delete(record);
        record = null;
    }

    public void onBack(){ record = null;}

    public void onSave()
    {
        record.hint = hintInput.text;
        record.SetStartDate(startDateTimeSelector.dateTime);
        record.SetEndDate(endDateTimeSelector.dateTime);
        if(record.id == 0){
            RecordsManager.save(record);
        }
        RecordManager.update(record);
        record = null;
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

        if(record.isNewRecord()){
            title.text = "Neuer Eintrag";
        }

        deletButton.gameObject.SetActive(!record.isNewRecord());
        hintInput.text = record.hint;
        startDateTimeSelector.dateTime = record.getStartDateTime();
        endDateTimeSelector.dateTime = record.getEndDateTime();
    }

}
