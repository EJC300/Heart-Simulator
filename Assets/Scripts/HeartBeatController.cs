using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using StateMachine;

public class HeartBeatController : MonoBehaviour
{
    private Heart heart;
    private float Oxygen;
    private RestState restState;
    private ChangeHRState sliderChangeHRState;
    private StressState stressed;
    private FiniteStateMachine heartStateMachine;
    private Body body;
    private float heartRate = 60;
    private float heartBeatInterval;
    private float nextBeat;
    private float recoverRate;
    private float targetBPM;
    private float targetHeartRate;
    private float energyFromOxygen;
    private float cameraDistortionValue;
    public float HeartRate { get { return HeartRate1; } }
    public RawImage fadeImage;
    public float currentHeartRate { get; set; }

    public float TargetHeartRate { get => targetHeartRate; set => targetHeartRate = value; }
    public float HeartRate1 { get => heartRate; set => heartRate = value; }
    public Body Body { get => body; set => body = value; }
    public FiniteStateMachine HeartStateMachine { get => heartStateMachine; set => heartStateMachine = value; }
    public float HeartBeatInterval { get => heartBeatInterval; set => heartBeatInterval = value; }

    
    public  void UpdateHeartRate(float bpm)
    {
       
        targetBPM = 60 / (bpm);
   
        heartBeatInterval = Mathf.MoveTowards(heartBeatInterval, targetBPM,heart.recoveryRate * Time.deltaTime * 0.1f);
        currentHeartRate = (60 /heartBeatInterval );

    }
    public void Resting()
    {

        restState.heart = heart;
        heartStateMachine.FlushState(restState);

       
    }
    public void Stressed()
    {
      stressed.heartBeatController = this;
      
      heartStateMachine.FlushState(stressed);
    }
    public void ChangeHRUsingSlider(Slider heartSlider)
    {
        sliderChangeHRState.heartBeatController = this;
        sliderChangeHRState.heartSlider = heartSlider;
        heartStateMachine.FlushState(sliderChangeHRState);
    }
    private void Start()
    {
        restState = new RestState();
        restState.heartBeatController = this;
        heartStateMachine = new FiniteStateMachine();
        stressed = new StressState();
        sliderChangeHRState = new ChangeHRState();
        heartStateMachine = new FiniteStateMachine();
        Body = new Body();
        heart = new Heart();
       
        heartRate = heart.restingHeartRate;
        Resting();
        UpdateHeartRate(HeartRate);
    }
    private void Update()
    {

       
        nextBeat += Time.deltaTime;
        heart.CalculateRestingHeartRate(body);
        heart.CalculateMaxHeartRate(body);

    
        
       
        UpdateHeartRate(HeartRate);

        heart.CalculateEnergyDrainRate(body, HeartRate);
        recoverRate = heart.recoveryRate;
        Debug.Log(recoverRate);
        heart.CalculateHeartWorkLoad(HeartRate, body);
     
        if (nextBeat > HeartBeatInterval && heart.oxygenLevel > 0)
        {

           
            TriggerHeartBeat();
            nextBeat = 0;
        }
        heartStateMachine.RunState();
        Debug.Log(HeartRate);

        
   
        Debug.Log($"{ heart.cardiacEfficiency} + cardiac efficiency + {heart.oxygenLevel} + heart oxygen levels");
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, cameraDistortionValue, Time.deltaTime);
        Color fadeColor = fadeImage.color;
        var fadeOpacity = cameraDistortionValue/100;
        fadeColor.a = fadeOpacity;
        fadeImage.color = fadeColor;
    }
    
    private void TriggerHeartBeat()
    {
        HeartBeatManager.OnSANodeFire?.Invoke();
        cameraDistortionValue =50;
        heart.CalculateOxygenDrain(HeartRate, body, this);
        Invoke(nameof(TriggerAVNode), 0.1f);
    }
    private void TriggerAVNode()
    {
        HeartBeatManager.OnAVNodeFire?.Invoke();
        Invoke(nameof(TriggerVentriclesContracted), 0.4f);
    }
    private void TriggerVentriclesContracted()
    {
        cameraDistortionValue = 55;
        HeartBeatManager.OnVentriclesContract?.Invoke();
        heart.RecoverOxygen();
        Invoke(nameof(TriggerOnValvesClosed), 0.30f * heart.cardiacEfficiency);
    }
    
    private void TriggerOnValvesClosed()
    {
        cameraDistortionValue = 60;
        HeartBeatManager.OnValvesClosed?.Invoke();
    }
}

