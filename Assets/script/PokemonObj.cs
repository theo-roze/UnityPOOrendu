using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonObj : MonoBehaviour
{
    private void Awake()
    {
        InitCurrentLife(ref pokemonData);
        InitStatsPoints(ref pokemonData);
    }
    private void Start()
    {
        StartCoroutine(DelayAttack());
    }
    public enum PokemonType
    {
        Normal, Fire, Water, Electric, Grass, Ice, Fighting, Poison, Ground, Flying, Psychic, Bug, Rock, Ghost, Dragon, Dark, Steel, Fairy
    }

    public PokemonData pokemonData;
    [SerializeField] private PokemonObj PokemonOpponent;

    private void InitCurrentLife(ref PokemonData pokemonData)
    {
        pokemonData.currentHealth = pokemonData.StartingHealth;
    }

    private void InitStatsPoints(ref PokemonData pokemonData)
    {
        pokemonData.stats = pokemonData.StartingHealth + pokemonData.Attack + pokemonData.Defense;
    }


    public bool IsPokemonAlive()
    {
        if (this.pokemonData.currentHealth <= 0)
        {
            Debug.Log("Pokemon " + pokemonData.Name + " is fainted.");
            return false;
        }
        else
        {
            Debug.Log("Pokemon " + pokemonData.Name + " is still alive.");
            return true;
        }
    }



    public void TakeDamage(PokemonObj pokemonObj)
    {
        int damage = pokemonObj.pokemonData.Attack;
        PokemonType enemyType = pokemonObj.pokemonData.pokemonType;

        if (damage <= 0)
        {
            return;
        }
        float damageMultiplier = 1.0f;

        foreach (PokemonType weakness in this.pokemonData.WeaknessesList)
        {
            if (weakness == enemyType)
            {
                damageMultiplier *= 2.0f;
                break;
            }
        }

        foreach (PokemonType resistance in this.pokemonData.ResistancesList)
        {
            if (resistance == enemyType)
            {
                damageMultiplier *= 0.5f;
                break;
            }
        }

        this.pokemonData.currentHealth -= (int)actualDamage(damage, damageMultiplier);

        this.pokemonData.currentHealth = Mathf.Max(this.pokemonData.currentHealth, 0);

        Debug.Log("Pokemon " + pokemonData.Name + " is current health after attack: " + this.pokemonData.currentHealth);
    }

    public void AttackOpponent()
    {
        if (!IsPokemonAlive())
        {
            Debug.Log("This pokemon " + pokemonData.Name + " is dead he can't attack");
        }
        if (IsPokemonAlive() && PokemonOpponent.IsPokemonAlive())
        {
            PokemonOpponent.TakeDamage(this);
        }
    }

    IEnumerator DelayAttack()
    {
        while (IsPokemonAlive() && PokemonOpponent.IsPokemonAlive())
        {
            AttackOpponent();
            float waitTime = Random.Range(1.25f, 3.1f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private float actualDamage(int damage, float damageMultiplier)
    {
        return damage * damageMultiplier;
    }

}
