using UnityEngine;
using UnityEngine.UI;

public class GunShot : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public float maxammo;
    public float ammo;
    public float maxreload;
    public float reload;


    public Slider ammoSlider;
    public Slider reloadSlider;

    private void Start() 
    {
        ammo = maxammo;
        reload = maxreload;
    }
    void Update() 
    {
        if(Input.GetButtonDown("Shot") && ammo > 0f)
        {    
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
            ammo = ammo - 1;
        }
        //Rechargement
        if (Input.GetButtonDown("Reload") && reload > 0)
        {
            ammo = maxammo;
            reload = reload - 1;
        }  

        ammoSlider.value = ammo;
        reloadSlider.value = reload;
    }
}
