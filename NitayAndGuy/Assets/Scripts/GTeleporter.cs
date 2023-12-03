using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTeleporter : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = Player2.transform.position;
    }
}
