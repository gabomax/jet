using UnityEngine;
using UnityEngine.UI;

public class MobCounter : MonoBehaviour
{
    public GameObject[] enemies;

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("mob");
    }
}
