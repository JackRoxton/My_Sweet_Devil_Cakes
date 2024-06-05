using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Granny : MonoBehaviour
{
    public List<Sprite> sprites;
    public Animator controller;

    void Start()
    {
        controller = this.gameObject.GetComponent<Animator>();
    }

    public void Speak()
    {

    }

    public void Angry()
    {
        controller.Play("Angry",0);
    }

    public void Happy()
    {
        controller.Play("Happy",0);
    }
}
