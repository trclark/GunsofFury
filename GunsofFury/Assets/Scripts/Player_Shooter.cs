using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Shooter : MonoBehaviour
{
    private Camera playerCam;
    private int switchWeapons;

    //different Ammunition counts
    private int pistolMag = 10;
    private int autoMag = 30;
    private int pistolAmmoCount;
    private int autoAmmoCount;

    //use these to output current Magazine and Ammuntion to the screen
    public Text currentGunMagText;
    public Text currentPistolAmmoText;
    public Text currentAutoAmmoText;

    void Start()
    {
        playerCam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pistolAmmoCount = pistolMag;
        SetPistolCurrAmmo();
        autoAmmoCount = autoMag;
        SetAutoCurrAmmo();

        switchWeapons = 0;
        //GameObject.Find("MachineGun").SetActive(false);
        GameObject.Find("CurrentAutoAmmoCount").SetActive(false);
        //GameObject.Find("S & W 357").SetActive(true);
        GameObject.Find("CurrentPistolAmmoCount").SetActive(true);
    }

    void Update()
    {
        //If T is pressed then switch weapons
        if (Input.GetKeyDown(KeyCode.T) && switchWeapons == 1)
        {
            // pistol active
            switchWeapons = 0;
            currentPistolAmmoText.gameObject.SetActive(true);
            currentAutoAmmoText.gameObject.SetActive(false);
        } else if (Input.GetKeyDown(KeyCode.T) && switchWeapons == 0)
        {
            // machine gun active
            switchWeapons = 1;
            currentAutoAmmoText.gameObject.SetActive(true);
            currentPistolAmmoText.gameObject.SetActive(false);
        }

        if (switchWeapons == 0)
        {
            currentGunMagText.text = pistolMag.ToString();
            if (Input.GetMouseButtonDown(0)) //Fire Pistol
            {
                fireGun();
                pistolAmmoCount--;
                SetPistolCurrAmmo();
                if (pistolAmmoCount <= 0)
                {
                    pistolAmmoCount = pistolMag;
                }
            }

        }
        else
        {
            currentGunMagText.text = autoMag.ToString();
            if (Input.GetMouseButton(0)) //Fire Machine Gun
            {
                fireGun();
                autoAmmoCount--;
                SetAutoCurrAmmo();
                if (autoAmmoCount <= 0)
                {
                    autoAmmoCount = autoMag;
                }
            }
        }
    }

    private void SetPistolCurrAmmo()
    {
        currentPistolAmmoText.text = pistolAmmoCount.ToString();
    }

    private void SetAutoCurrAmmo()
    {
        currentAutoAmmoText.text = autoAmmoCount.ToString();
    }

    public void fireGun()
    {
        Vector3 point = new Vector3(playerCam.pixelWidth / 2, playerCam.pixelHeight / 2, 0);
        Ray ray = playerCam.ScreenPointToRay(point);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            Enemy_Shot target = hitObject.GetComponent<Enemy_Shot>();

            if (target != null)
            {
                target.GotShot();
            }
            else
            {
                StartCoroutine(ShotGen(hit.point)); //Launch a coroutine in response to a hit!
            }

        }
    }

    private IEnumerator ShotGen(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }

    void OnGUI()
    {
        int size = 12;
        float posX = playerCam.pixelWidth / 2 - size / 4;
        float posY = playerCam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
}
