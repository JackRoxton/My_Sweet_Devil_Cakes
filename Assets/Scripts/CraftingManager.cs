using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : Singleton<CraftingManager>
{
    public List<Transform> craftSpots;
    List<GameObject> craftObjects = new List<GameObject>();
    //public GameObject prefab;
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
        if(result.CraftCheck())
        {
            GameManager.Instance.SetFinalIngredients(result.StartCraft());
            result.Clear();
            Clear();
        }
    }
}
