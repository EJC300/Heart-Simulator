using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore.Text;
using TMPro;

//TODO Use a finite state machine to manage states between exercise, stress,rest , and slider
/*
 * Plan:
 * 
 * Heart Attack Simulator with basic digestive simulation 
 * 
 * Create An extensible state machine for the heart states - Done
 * 
 * Create the simple digestive system using a time of day routine thing
 * 
 * Create food types
 * 
 * Create artery health system
 * 
 * Progrss to more advanced simulation model
 * 
 * Refactor as needed
 * 
 */

/*
 * I need to refactor this before I add any of the planned features use an seperate event system and seperate heart controller
 * 
 * Heart Controller - This controls and manages the heartbeat system
 * HeartBeat Manager - Manages the delagates(Events) of the heart sim's heartbeat
 * HeartSound
 * Heart Animator
 * Heart Sim UI - Handles UI such as the slider and buttons among other things
 * Heart State Machine - Controls the states but also registers the state to the Heart Sim UI
 * After refactoring follow the same design for the new systems
 


public class HeartManager : MonoBehaviour
{
    ChangeHRState changeHRState = new ChangeHRState();
    StressState stressState = new StressState();
    public static event Action OnSANodeFire;
    public static event Action OnVentriclesContract;
    public static event Action OnAVNodeFire;
    public static event Action OnValvesClosed;
    public FiniteStateMachine states = new FiniteStateMachine();
    public static event Action StartExercise;

    [SerializeField] private Slider heartSlider;

    [SerializeField] private TextMeshProUGUI heartRateText;
    private static TextMeshProUGUI heartRateTextValue;
    private static float heartRate;
    public static float GetHR { get { return heartRate; } }
    public static float SetHR { set { heartRate = value; } }
    private static float heartBeatInterval;
    private static float nextBeat;
    private static float recoverRate;
    private static Body body;
    private static float targetBPM;
    public static Body GetBody { get { return body; } }
    public void OnSliderValueChanged()
    {

        changeHRState.heartSlider = heartSlider;

        states.FlushState(changeHRState);



    }

    public void OnStress()
    {



        states.FlushState(stressState);

    }



    private void Start()
    {
        body = new Body();

    }
    private void Update()
    {
        states.RunState();
        nextBeat += Time.deltaTime;


        body.CalculateRecoveryRateHR();
        UpdateHeartRate(heartRate);

        if (nextBeat > heartBeatInterval)
        {

            TriggerHeartBeat();
            nextBeat = 0;
        }

        heartRateText.text = "Heart Rate:" + (heartRate).ToString("F0") + "Target Heart Rate " + (60 / targetBPM).ToString("F0");
    }


    public static void UpdateHeartRate(float bpm)
    {
        targetBPM = 60 / bpm;
        recoverRate = body.CalculateRecoveryRateHR();
        heartBeatInterval = Mathf.MoveTowards(heartBeatInterval, targetBPM, 0.1f);


    }
    private void TriggerHeartBeat()
    {
        OnSANodeFire?.Invoke();
        
        Invoke(nameof(TriggerAVNode), 0.1f);
    }
    private void TriggerAVNode()
    {
        OnAVNodeFire?.Invoke();

        Invoke(nameof(TriggerVentriclesContracted), 0.5f);
    }
    private void TriggerVentriclesContracted()
    {
        OnVentriclesContract?.Invoke();

        Invoke(nameof(TriggerOnValvesClosed), 0.30f);
    }

    private void TriggerOnValvesClosed()
    {
        OnValvesClosed?.Invoke();
    }


}
*/