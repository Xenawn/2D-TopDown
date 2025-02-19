using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private static readonly int IsMoving = Animator.StringToHash("IsRun");

    protected Animator animator;
    void Start()
    {
       animator=  GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude>.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
