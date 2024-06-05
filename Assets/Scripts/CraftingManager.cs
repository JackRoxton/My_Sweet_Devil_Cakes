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
        yield return new WaitForSeconds(1);
        GameManager.Instance.SetFinalIngredients(result.StartCraft());
        result.Clear();
        Clear();
    }

    public void Anim()
    {
        int i = 0;
        SpriteRenderer[] list = anim.GetComponentsInChildren<SpriteRenderer>();
        List<DragnDrop> list2 = result.StartCraft();
        foreach(DragnDrop go in list2)
        {
            list[i].sprite = go.ingredient.Sprite;
            i++;
        }
        anim.GetComponent<Animator>().Play("Craft", 0);
    }
}
