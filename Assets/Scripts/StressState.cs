using UnityEngine;
using StateMachine;
public class StressState : State
{
    public float targetHeartRate;
    public HeartBeatController heartBeatController;
    float prevHeartRate = 0f;

    Body body;


    public override void StartState()
    {
        body = heartBeatController.Body;
        prevHeartRate = heartBeatController.HeartRate;
        base.StartState();
    }

    public override void UpdateState()
    {
        var beatsPerMinute = body.CalculateStressHR();
        heartBeatController.TargetHeartRate = beatsPerMinute;
        Debug.Log(beatsPerMinute);
        heartBeatController. UpdateHeartRate(beatsPerMinute);

        base.UpdateState();
    }

    public override void ExitState()
    {
        heartBeatController.HeartRate1 = prevHeartRate;
        base.ExitState();
    }
}
