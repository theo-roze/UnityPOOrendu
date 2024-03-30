using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokemonInfoCrontroller : MonoBehaviour
{

    [SerializeField] private Image imgIcon;
    [SerializeField] private Text txtName;
    [SerializeField] private Text txtType;
    [SerializeField] private Text txtSize;
    [SerializeField] private Text txtWeight;
    [SerializeField] private Text txtCaption;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previewButton;

    private DatabaseManager databaseManager;
    private int currentIndex = 0;

    private void Awake()
    {


        databaseManager = FindObjectOfType<DatabaseManager>();
        nextButton.onClick.AddListener(nextButton_Click);
        previewButton.onClick.AddListener(previewButton_Click);
    }

    void nextButton_Click()
    {
        currentIndex = (currentIndex + 1) % databaseManager.database.datas.Count;
        updatePokemon();
    }

    void previewButton_Click()
    {
        currentIndex = (databaseManager.database.datas.Count + currentIndex - 1) % databaseManager.database.datas.Count;
        updatePokemon();
    }
    private void updatePokemon()
    {
        PokemonData pokeData = databaseManager.database.datas[currentIndex];

        imgIcon.sprite = pokeData.icon;
        txtName.text = pokeData.Name;
        txtType.text = $"{pokeData.pokemonType.ToString()}";
        txtSize.text = $"{pokeData.size.ToString("f1")}m";
        txtWeight.text = $"{pokeData.weight.ToString("f1")}kg";
        txtCaption.text = $"{pokeData.caption}";
    }

    private void Start()
    {
        updatePokemon();
    }
}