
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Game objects to generate
    public GameObject[] Potions ;
     // Time controller
    float time;
    // Interval between every generation on seconds
    public float interval;
    // Range of dispersion between object on units
    public float range;
    // Items random to create
    public float creationRange = 1;
    // GameObject to avoid
    public string playerObjectName = "Doctor";
    // Game objects position into game
    float doctorX;
    float doctorY;
    float camHeight;
    float camWidth;

    void Start () {
        // Doctor sprite reference position
        GameObject doctor = GameObject.Find(playerObjectName);
        Collider2D doctorCollider = doctor.GetComponent<Collider2D>();
        doctorX = doctorCollider.bounds.extents.x;
        doctorY = doctorCollider.bounds.extents.y;

        // Camera reference position
        Camera camera = Camera.main;
        camHeight = camera.orthographicSize / 2f;
        camWidth = camera.aspect * camHeight;
    }

    void Update()
    {
        time += Time.deltaTime;

        if(time >= interval) {
            for(int i = 0; i < Random.Range(1, creationRange); i++) {
                generate();
            }
            time = 0;
        }
        
    }

    // Define inntial position
    Vector3 getRandomPosition(){
        float randomX = Random.Range(-range, range);
        float randomY = Random.Range(-range/2, range/2);

        Vector3 position = this.transform.position;
        position.x = position.x + randomX;
        position.y = position.y + randomY;

        return position;
    }

    // Method to generate random object arround father position 
    void generate() {
        Vector3 position = getRandomPosition();

        // Recursive validator with cam limits and doctor script position
        if((position.x <= doctorX && position.x >= -doctorX) && (position.y <= doctorY && position.y >= -doctorY)){
            generate();
            return;
        }
        if(position.x >= camWidth || position.y >= camHeight ){
            generate();
            return;
        }

        // Type of potion handler
        GameObject potion = Potions[Random.Range(0, Potions.Length)];

        Instantiate(potion, position, Quaternion.identity);

    }
}
