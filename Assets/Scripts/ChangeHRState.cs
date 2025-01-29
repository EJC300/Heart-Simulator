using StateMachine;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHRState : State
{
    public Slider heartSlider;
    public float targetHeartRate;
    public HeartBeatController heartBeatController;
    public override void StartState()
    {
      
    }

    public override void UpdateState()
    {
        var beatsPerMinute = heartSlider.value;
        heartBeatController.HeartRate1 = beatsPerMinute;
        heartBeatController.TargetHeartRate = beatsPerMinute;
        
       
        
    }

    public override void ExitState()
    {
       
    }
}
