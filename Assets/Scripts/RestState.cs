using UnityEngine;
using StateMachine;
public class RestState : State
{
    public float targetHeartRate;
    public HeartBeatController heartBeatController;
    float prevHeartRate = 0f;

    public Heart heart;


    public override void StartState()
    {
        
        prevHeartRate = heartBeatController.HeartRate;
        base.StartState();
    }

    public override void UpdateState()
    {
        
        var beatsPerMinute = heart.restingHeartRate;
        heartBeatController.HeartRate1 = beatsPerMinute;
        heartBeatController.TargetHeartRate = beatsPerMinute;
      

        base.UpdateState();
    }

    public override void ExitState()
    {
        heartBeatController.HeartRate1 = prevHeartRate;
        base.ExitState();
    }
}
