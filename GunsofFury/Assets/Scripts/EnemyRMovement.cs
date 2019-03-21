using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float enemyRange = 10.0f;

    public GameObject bulletPrefab;
    private GameObject _bullet;

    private int destroytime = 5;

    public GameObject player;
    private Vector3 targetPoint;
    private Quaternion targetRotation;
    private bool seenPlayer = false;

    private bool _alive;

    public Vector3 addHeight = new Vector3(0, 4, 0);

    float timer;
    int waitingTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        _alive = true;
        // Add + 1 to player's last known position so bullet appears to float above ground.
        //ector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        // Aim bullet in player's direction.
        //transform.rotation = Quaternion.LookRotation(playerPos);
    }

    void Update()
    {

        //transform.LookAt(player.transform.position);
        if (_alive) transform.Translate(0, 0, Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < enemyRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }

        //timer += Time.deltaTime;
        /*if (timer > waitingTime)
        {
            StartCoroutine(Shoot());
            timer = 0;
        }
        Destroy(_bullet, destroytime);*/
    }


    public void Strafe()
    {
        
    }

    IEnumerator Shoot()
    {
        for (int i = 0; i <= 3; i++)
        {
            _bullet = Instantiate(bulletPrefab) as GameObject;
            _bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 1.8f, transform.position.z);
           // _bullet.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
            yield return new WaitForSeconds(0.3f);
        }
        yield return null;
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
