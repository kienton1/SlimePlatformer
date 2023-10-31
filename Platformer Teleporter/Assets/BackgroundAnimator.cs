using UnityEngine;

public class BackgroundAnimator : MonoBehaviour
{
    public Animation backgroundAnimation;

    void Start()
    {
        backgroundAnimation.Play("Back Ground Castle");
    }
}
