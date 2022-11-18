using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControl : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void holdingAnimation()
    {
        _anim.SetBool("isHold", true);
    }

    public void notHoldingAnimation()
    {
        _anim.SetBool("isHold", false);
    }
}
