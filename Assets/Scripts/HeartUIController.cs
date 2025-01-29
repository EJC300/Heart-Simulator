using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HeartUIController : MonoBehaviour
{
    [SerializeField] private Slider heartSlider;
    [SerializeField] private HeartBeatController heartBeatController;

    [SerializeField] private TextMeshProUGUI heartRateText;
    
    public void OnExit()
    {
        Application.Quit();
    }
    
    public void OnStressButton()
    {
        heartBeatController.Stressed();
    }

    public void OnChangeHR()
    {
        heartBeatController.ChangeHRUsingSlider(heartSlider);
    }

    public void OnRest()
    {
        heartBeatController.Resting();
    }
    private void Update()
    {
        heartRateText.text = "Heart Rate:" + (heartBeatController.currentHeartRate).ToString("F0") + "Target Heart Rate " + ( heartBeatController.TargetHeartRate).ToString("F0");
       

    }
}
