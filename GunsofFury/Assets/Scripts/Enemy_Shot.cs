using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shot : MonoBehaviour
{
    public GameObject pickupPrefab;
    private GameObject pickup;
    public int enemyHealth = 60;

    public void GotShot()
    {
        enemyHealth -= 20;
        if (enemyHealth <= 0)
        {
            EnemyRMovement behavior = GetComponent<EnemyRMovement>();
            if (behavior != null)
            {
                behavior.SetAlive(false);
            }

            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
        pickup = Instantiate(pickupPrefab) as GameObject;
        pickup.transform.position = transform.position;
    }

}