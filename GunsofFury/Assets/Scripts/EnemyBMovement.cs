using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float enemyRange = 5.0f;

    public GameObject bulletPrefab;
    private GameObject _bullet;

    private int destroytime = 5;

    private bool _alive;
    // Start is called before the first frame update
    void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive) transform.Translate(0, 0, Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerController>())
            {
                if (_bullet == null)
                {
                    _bullet = Instantiate(bulletPrefab) as GameObject;
                    _bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _bullet.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < enemyRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
        Destroy(_bullet, destroytime);
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}