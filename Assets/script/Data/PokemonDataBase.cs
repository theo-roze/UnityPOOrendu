using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPokemonDatabase", menuName = "Database/Pokemon", order = 0)]

public class PokemonDataBase : ScriptableObject
{
    public List<PokemonData> datas = new();

    public void CreateData()
    {
        //PokemonData newPoke = new();
        //database
        //name : "Florizarre",
        //icon  : null,
        //size : 2,
        //weight : 100,
        //caption : "c'est un pokemon'");

        //  datas.Add(newPoke)

    }
}
