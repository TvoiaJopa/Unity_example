using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    public const float baseSpeed = 3.0f;
    public float speed = 3.0f;
    public float obstscleRange = 5.0f;
    public float gravity = -9.8f;
    private bool _alive;


    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    void Start()
    {
        _alive = true;
    }


    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0 ,speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<CharacterController>())
                {
                    if(_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position =
                            transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if(hit.distance < obstscleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
