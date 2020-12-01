using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    public const float baseSpeed = 3.0f;
    public float speed = 3.0f;

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    // Update is called once per frame
    void Update()
    {

        if(_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(0, 0, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
            WanderingAI wanAi = _enemy.GetComponent<WanderingAI>();
            wanAi.speed = speed;
        }
    }


    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }
}
