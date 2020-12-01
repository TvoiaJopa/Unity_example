using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLable;
    [SerializeField] private SettingsPopup settingsPopup;
    private int _score;

    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    void Start()
    {
        _score = 0;
        scoreLable.text = _score.ToString();

        settingsPopup.Close();
    }

    void Update()
    {
        //scoreLable.text = Time.realtimeSinceStartup.ToString();
    }

    private void OnEnemyHit()
    {
        _score += 1;
        scoreLable.text = _score.ToString();
    }

    public void OnOpenSettings()
    {
        settingsPopup.Open();
    }

    public void OnPointDown()
    {
        Debug.Log("pointer down");
    }




}
