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

    public void Empty()
    {
        foreach (GameObject go in IngredientsList)
        {
            go.transform.position = new Vector2(20, 20);
        }
    }

    public void Spawn()
    {
        Clear();
        int i = 0;
        foreach (Transform t in spots)
        {
            GameObject go = Instantiate(IngredientPrefab, spots[i].position, Quaternion.identity);
            go.GetComponent<DragnDrop>().ingredient = RecipeManager.Instance.ingredients[i].ingredient;
            if(Random.Range(0,4) == 0 && go.GetComponent<DragnDrop>().ingredient.canbebad == true)
            {
                go.GetComponent<DragnDrop>().GoBad();
            }
            else
            {
                go.GetComponent<DragnDrop>().Normal();
            }
            IngredientsList.Add(go.gameObject);
            i++;
        }
    }

    public void SpawnClean(GameObject go)
    {
        int i = 0;
        foreach(GameObject game in IngredientsList)
        {
            if(game == go)
            {
                IngredientsList.RemoveAt(i);
                GameObject g = Instantiate(IngredientPrefab, spots[i].position, Quaternion.identity);
                g.GetComponent<DragnDrop>().ingredient = RecipeManager.Instance.ingredients[i].ingredient;
                g.GetComponent<DragnDrop>().Normal();
                IngredientsList.Insert(i, g.gameObject);
                Destroy(go);
                return;
            }
            i++;
        }
    }
}
