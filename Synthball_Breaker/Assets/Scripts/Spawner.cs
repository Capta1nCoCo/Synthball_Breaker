using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] powerModifiers;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerModifiers[Random.Range(0, powerModifiers.Length)], transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
