using UnityEngine;

public class Body
{
    public float fitnessLevel = 50;

    public float age = 31;

   
   

    
    
   
   public float CalculateStressHR()
    {
      
        return Random.Range(110f, 130f) - (fitnessLevel);
        
    }
 
}
