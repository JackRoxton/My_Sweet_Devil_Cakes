using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragnDrop : MonoBehaviour
{
    public bool isDragged = false;
    public bool Draggable = true;
    public Ingredient ingredient;
    public GameObject ps;
    public bool bad;
    bool flag = false;
    bool soundFlag = false;

    void Update()
    {

        if (!Input.GetMouseButton(0))
        {
            isDragged = false;
            soundFlag = false;
        }

        if ((ingredient.name == "Fraise" || ingredient.name == "Sucre") && !flag)
        {
            StartCoroutine(Anim());
        }

    }

    public void OnMouseDrag()
    {
        if(!Draggable) return;
        if(!soundFlag)
        {
            SoundManager.Instance.Play("Panic");
            soundFlag = true;
        }
        isDragged = true;
        this.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        this.GetComponent<Animator>().Play("Wriggle",0);
    }

    public void GoBad()
    {
        bad = true;
        ps.SetActive(true);
        this.GetComponent<SpriteRenderer>().sprite = ingredient.badSprite;
    }

    public void Normal()
    {
        bad = false;
        ps.SetActive(false);
        this.GetComponent<SpriteRenderer>().sprite = ingredient.Sprite;
    }

    public IEnumerator Anim()
    {
        flag = true;
        this.GetComponent<SpriteRenderer>().sprite = ingredient.badSprite;
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<SpriteRenderer>().sprite = ingredient.Sprite;
        yield return new WaitForSeconds(0.2f);
        flag = false;
    }


}
