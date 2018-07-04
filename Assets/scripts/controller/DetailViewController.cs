using UnityEngine;
using UnityEngine.UI;
public class DetailViewController : MonoBehaviour {
    
    private Record record;
    private Text title;
    private Button deletButton;
    private InputField hintInput;
    private DateTimeSelectorController startDateTimeSelector;
    private DateTimeSelectorController endDateTimeSelector;

    public void setSelectedTimeRecord(Record tr){
        if(tr == null){
            return;
        }
        record = tr;

        transform.Find("Title").GetComponent<Text>().text = "Bearbeiten";

        if (record.isNewRecord())
        {
            transform.Find("Title").GetComponent<Text>().text = "Neuer Eintrag";
        }

        transform.Find("DeleteButton").GetComponent<Button>().gameObject.SetActive(!record.isNewRecord());
        transform.Find("HintInput").GetComponent<InputField>().text = record.hint;
        transform.Find("StartDateTimeSelector").GetComponent<DateTimeSelectorController>().SetDateTime(record.getStartDateTime());
        transform.Find("EndDateTimeSelector").GetComponent<DateTimeSelectorController>().SetDateTime(record.getEndDateTime());}

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
        record.SetStartDate(startDateTimeSelector.GetDateTime());
        record.SetEndDate(endDateTimeSelector.GetDateTime());
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

}
