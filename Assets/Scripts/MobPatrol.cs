using UnityEngine;

public class MobPatrol : MonoBehaviour
{
    public float speed;
    public float FollowReach;

    public GameObject mainUI;

    Transform target;

    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        target = Player.transform;
        if (Vector3.Distance(transform.position, target.position) < FollowReach)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            mainUI.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }
}