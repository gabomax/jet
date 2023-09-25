using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject Gun;

    public float bulletSpeed = 60.0f;

    public Vector3 target;

    void Update() 
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target-Gun.transform.position;
        float rotationz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Gun.transform.rotation = Quaternion.Euler(180f, 180f, rotationz);
    }
}