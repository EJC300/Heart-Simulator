using UnityEngine;

public class EKG : MonoBehaviour
{
   
    public LineRenderer lineRenderer;

    public int points;
    public int width;
    public float amplitude;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
     
    }
    //
    public void DrawEKG()
    {
        float Tau = 2* Mathf.PI ;
        float finish = Tau;
        lineRenderer.positionCount = points;
        for (int i = 0; i < points; i++)
        {
            float progress = (float)i/ (points - 1);

            float offset = Time.timeSinceLevelLoad * Time.deltaTime;
            
            float newPosX = offset + Mathf.Lerp(0,finish , progress);
            float newPosY = -0.5f* Mathf.Pow( Mathf.Sin((offset + 0.3f * newPosX * Tau -3) ), 10) + 0.8f * Mathf.Pow(Mathf.Sin((0.3f * newPosX) + 5.5f), 22) +.7f * Mathf.Pow(Mathf.Sin( 0.3f * newPosX), 300);

            
            
            lineRenderer.SetPosition(i, transform.position + new Vector3(newPosX, newPosY));
        }
    }
    private void Update()
    {
        DrawEKG();
    }
}
