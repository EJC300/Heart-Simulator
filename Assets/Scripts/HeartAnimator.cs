using UnityEngine;

public class HeartAnimator : MonoBehaviour
{
    [SerializeField] private Animation heartAnimation;

    [SerializeField] private AnimationClip lubClip;
    [SerializeField] private AnimationClip dubClip;

    [SerializeField] private AnimationClip restClip;
    private void OnEnable()
    {
        HeartBeatManager.OnSANodeFire += PlayRestClip;
        HeartBeatManager.OnVentriclesContract += PlayLubClip;
        HeartBeatManager.OnValvesClosed += PlayDubClip;
    
    }

    private void OnDisable()
    {
        HeartBeatManager.OnSANodeFire -= PlayRestClip;
        HeartBeatManager.OnVentriclesContract -= PlayLubClip;
        HeartBeatManager.OnValvesClosed -= PlayDubClip;
    }
    private void PlayLubClip()
    {
       heartAnimation.clip = dubClip;
       heartAnimation.Play();
    }
    private void PlayDubClip()
    {
        heartAnimation.clip = lubClip;
        heartAnimation.Play();
    }
    private void PlayRestClip()
    {
        heartAnimation.clip = restClip;
        heartAnimation.Play();
    }
}
