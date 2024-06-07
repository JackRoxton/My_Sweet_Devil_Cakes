using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : Singleton<CraftingManager>
{
    public List<Transform> craftSpots;
    List<GameObject> craftObjects = new List<GameObject>();
    public GameObject anim;
    public CraftingResult result;


    public void InstantiateCraft(List<DragnDrop> list)
    {
        int i = 0;
        foreach (DragnDrop x in list) 
        {
            GameObject go = Instantiate(x.gameObject, craftSpots[i].position, Quaternion.identity);
            //go.GetComponent<DragnDrop>().ingredient = x;
            craftObjects.Add(go);
            i++;
        }
    }

    void Clear()
    {
        foreach (GameObject go in craftObjects)
        {
            Destroy(go);
        }
        craftObjects.Clear();
    }

    public void CraftButton()
    {
        if (result.CraftCheck())
        {
            StartCoroutine(_CraftButton());
        }
    }

    IEnumerator _CraftButton()
    {
        Anim();
        List<DragnDrop> list = result.StartCraft();
        result.Clear();
        yield return new WaitForSeconds(1);
        GameManager.Instance.SetFinalIngredients(list);
        AnimClear();
        Clear();
    }

    public void Anim()
    {
        int i = 0;
        SpriteRenderer[] list = anim.GetComponentsInChildren<SpriteRenderer>();
        List<DragnDrop> list2 = result.StartCraft();
        foreach(DragnDrop go in list2)
        {
            if(!go.bad)
                list[i].sprite = go.ingredient.Sprite;
            else
                list[i].sprite = go.ingredient.badSprite;
            i++;
        }
        anim.GetComponent<Animator>().Play("Craft", 0);
    }

    public void AnimClear()
    {
        SpriteRenderer[] list = anim.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer go in list)
        {
            go.sprite = null;
        }
    }


}
