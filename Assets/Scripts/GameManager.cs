using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        MainMenu,
        Pokedex,
        PokedexPick,
        FridgePick
    }
    public GameStates CurrentState;
}
