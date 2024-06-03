using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PickRecipe picker;
    //public Recipe pickedRecipe;

    public enum GameStates
    {
        MainMenu,
        Pokedex,
        PokedexPick,
        FridgePick
    }
    public GameStates CurrentState = GameStates.MainMenu;

    public void Play()
    {
        CurrentState = GameStates.PokedexPick;
        picker.Pick();
    }
}
