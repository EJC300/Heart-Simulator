using System.Data;
using UnityEngine;

public class Heart
{
    public float oxygenLevel { get; set; }

    public float cardiacEfficiency {  get; set; }

    public float energyDrainRate { get; set; }

    public float recoveryRate { get; set; }

    public float heartWorkLoad { get; set; }

    public float maxHeartRate { get; set; }

    public float restingHeartRate { get; set; }

    public void CalculateMaxHeartRate(Body body)
    {
        maxHeartRate = 100 + body.fitnessLevel - body.age;
        
    }

    public void CalculateRestingHeartRate(Body body)
    {
        this.restingHeartRate = (maxHeartRate - body.fitnessLevel);
    }

    public void CalculateEnergyDrainRate(Body body,float heartRate)
    {
  
        recoveryRate = (body.fitnessLevel / body.age) * cardiacEfficiency;
        energyDrainRate =  ( body.age/ body.fitnessLevel);
  
 
       
    
    }

    public void CalculateHeartWorkLoad(float heartRate,Body body)
    {
        var baseHeartWorkLoad = heartRate;

        heartWorkLoad = baseHeartWorkLoad + (heartRate / maxHeartRate);
        
        

    }

    public void CalculateOxygenDrain(float heartRate,Body body,HeartBeatController heartBeatController)
    {
        float oxygenDrain = energyDrainRate * heartWorkLoad;

        oxygenLevel -= oxygenDrain * Time.deltaTime * 5;
           
       
        
        oxygenLevel = Mathf.Max(oxygenLevel, 0);
        oxygenLevel = Mathf.Min(oxygenLevel, 100);

        cardiacEfficiency = oxygenLevel / 100;

        heartRate = heartRate * cardiacEfficiency;
    
      
        if(oxygenLevel < 20)
        {
            cardiacEfficiency -= Mathf.Abs(60/ (body.fitnessLevel - heartRate)) * Time.deltaTime;
            heartRate -= (heartRate - cardiacEfficiency);
        }
        else if(oxygenLevel < 85)
        {
            heartRate += (heartRate - cardiacEfficiency);
        }
       

        heartBeatController.HeartRate1 = heartRate;
        heartBeatController.UpdateHeartRate(heartRate);
    }

    public void RecoverOxygen()
    {
        oxygenLevel += recoveryRate;
      
        oxygenLevel = Mathf.Min(oxygenLevel, 100);
       
    }

    public Heart()
    {
        oxygenLevel = 100;

        UnityEngine.Physics.gravity = Vector3.down * 0.1f;
        
    }
}
