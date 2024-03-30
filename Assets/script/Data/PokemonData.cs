using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public struct PokemonData
{
    public Sprite icon;
    public float size;
    public string caption;

    public string Name;
    public int StartingHealth;
    public int Attack;
    public int Defense;
    public float weight;
    public int stats;
    public int currentHealth;
    public PokemonObj.PokemonType pokemonType;
    public PokemonObj.PokemonType[] WeaknessesList;
    public PokemonObj.PokemonType[] ResistancesList;

    /*
      public PokemonData()
      {
          stats = 0;
          Name = "Pikachu";
          StartingHealth = 35;
          Attack = 55;
          Defense = 40;
          weight = 5.9f;
  }
    */
    //public PokemonData(string name, Sprite icon, float size, float weight, string caption) : this(name)
    //{
    //    this.name = name;
    //    this.icon = icon;
    //    this.size = size;
    //    this.weight = weight;
    //    this.caption = caption;
    //}
}