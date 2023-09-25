using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public MobCounter mobCounter;

    public GameObject winMenu;
    public GameObject player;

    void Update()
    {
        if (mobCounter.enemies.Length == 0)
        {
            winMenu.SetActive(true);
            Cursor.visible = true;
            player.SetActive(false);
        }
    }
}
