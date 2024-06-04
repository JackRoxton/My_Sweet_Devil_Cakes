using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    public List<Transform> spots = new List<Transform>();
    public GameObject IngredientPrefab;
    List<GameObject> IngredientsList = new List<GameObject>();

    public void Clear()
    {
        foreach (GameObject go in IngredientsList)
        {
            Destroy(go);
        }
        IngredientsList.Clear();
    }

    public void Spawn()
    {
        Clear();
        int i = 0;
        foreach (Transform t in spots)
        {
            GameObject go = Instantiate(IngredientPrefab, t.position, Quaternion.identity);
            go.GetComponent<DragnDrop>().ingredient = RecipeManager.Instance.ingredients[i];
            IngredientsList.Add(go);
            i++;
        }
    }
}
