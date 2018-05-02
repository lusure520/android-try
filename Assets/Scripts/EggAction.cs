using System.Collections;
using UnityEngine;

public class EggAction : MonoBehaviour {
    [SerializeField]
    private GameObject egg;
    private BoxCollider2D col;

    float x1, x2;
    // Use this for initialization
    void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }
    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnEgg(1f));
    }
	
	// Update is called once per frame
	IEnumerator SpawnEgg(float time)
    {
        yield return new WaitForSecondsRealtime(time);// control the second egg spawn

        x1 = transform.position.x - col.bounds.size.x / 2f;
        x2 = transform.position.x + col.bounds.size.x / 2f;

        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2);// get random x position to falling egg down
        Instantiate(egg, temp, Quaternion.identity);
        StartCoroutine(SpawnEgg(Random.Range(1f, 2f))); 
    }
}
