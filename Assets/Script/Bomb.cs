using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class Bomb : MonoBehaviour
{
    [Tooltip("爆発するまでの時間")]
    [SerializeField] float StartTime = 3f;
    [Tooltip("爆発後消えるまでの時間")]
    [SerializeField] float EndTime = 1f;
    [SerializeField] GameObject BombColider;
    // Use this for initialization
    void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(StartTime)).Subscribe(_ =>
        {
            // StartTime 後　発火
            Instantiate(BombColider, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        ).AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
