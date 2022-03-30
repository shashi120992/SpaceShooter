using Assets.Scripts;
using UnityEngine;



public class PlayerShooting : MonoBehaviour {

    public GameObject player;
    public GameObject projectile;
    public GameObject projctileClone;
    
    
    [HideInInspector] public CanvasManager canvasManager;
    [HideInInspector] public PlayerHealth playerHealth;
   

    
    private void Update()
    {
        fireProjectile();
    }
    private void fireProjectile()
    {
        if(Input.GetKeyDown(KeyCode.Space)/* && projectile == null*/)
        {
            //projctileClone = Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y + 0.8f, 0), player.transform.rotation) as GameObject;

            Vector3 pos = new Vector3(player.transform.position.x, player.transform.position.y + 0.8f, 0);
            GameObject lasor = ObjectPooler.Instance.getPooledObject();
            if(lasor != null)
            {
                lasor.transform.position = pos;
                lasor.SetActive(true);
            }
        }
    }

    
    
}
