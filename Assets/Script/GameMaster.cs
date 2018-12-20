using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class GameMaster : SingletonMonoBehaviour<GameMaster>
{
    public GameObject Player;
    [System.NonSerialized]
    public int MaxEnemy;


    [System.NonSerialized]
    public int EnemyCounts = 0;

    public int MaxLife = 5;
    public int Life;

    public int Score = 0;
    public int AddScoreRange = 100;

    public float NonAtackedTime = 3.0f;

    public bool CanAtack = true;

    [SerializeField] Text LifeText, ScoreText;


    // Use this for initialization
    void Start()
    {
        Life = MaxLife;
        LifeText.text = "Life " + Life.ToString();
        ScoreText.text = "Score " + Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NonAtackCoroutine()

    {
        if (CanAtack)
        {
            CanAtack = false;
            Observable.Timer(TimeSpan.FromSeconds(NonAtackedTime)).Subscribe(_ =>
            {
                CanAtack = true;
                // NonAtacktime秒の間アタックできない
            }).AddTo(this);
        }
    }

    public void Damage()

    {
        Life--;
        LifeText.text = Life.ToString();
    }
    public void AddScore()
    {
        Score += AddScoreRange;
        ScoreText.text = Score.ToString();
    }


}