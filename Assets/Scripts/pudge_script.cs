using UnityEngine;

public class pudgeController : MonoBehaviour
{
    public GameObject pudge; 
    private Animator pudgeAnimator;

    private void Start()
    {
        pudgeAnimator = pudge.GetComponent<Animator>();
    }
    
    public void PlayPudgeAnimation()
    {
        if (pudgeAnimator != null)
        {
            pudgeAnimator.Play("Ultumate"); // Запуск анимации у Pudge
        }
    }
}
