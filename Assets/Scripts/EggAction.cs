using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggAction : MonoBehaviour {
    [SerializeField]
    private GameObject egg;
    private BoxCollider2D col;

    float x1, x2;
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
        yield return new WaitForSecondsRealtime(time);

        x1 = transform.position.x - col.bounds.size.x / 2f;
        x2 = transform.position.x + col.bounds.size.x / 2f;

        Vector3 temp = transform.position;
        temp.x = Random.Range(x1, x2);
        Instantiate(egg, temp, Quaternion.identity);
        StartCoroutine(SpawnEgg(Random.Range(1f, 2f))); 
    }
}
