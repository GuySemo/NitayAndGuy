using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMother : MonoBehaviour
{
    [SerializeField] public float speed = 5;

    [SerializeField] GameObject[] lilChicks;
    // Start is called before the first frame update
    void Start()
    {
        speed = GetComponent<NnormalEnemy>().speed;
        for (int i = 0; i < lilChicks.Length; i++)
        {
            if (lilChicks[i] != null)
            {
                lilChicks[i].GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                if (speed > 0)
                {
                    lilChicks[i].transform.position = transform.position + new Vector3(-2.2f * i, -2.75f, 0);
                }
                else
                {
                    lilChicks[i].transform.position = transform.position + new Vector3(2.2f * i, -2.75f, 0);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChickenDie()
    {
        for (int i = 0; i < lilChicks.Length; i++)
         {
            if (lilChicks[i] != null)
            {
                int rnd = Mathf.RoundToInt(Random.Range(0, 2));
                if (rnd == 0)
                {
                    lilChicks[i].GetComponent<Rigidbody2D>().velocity = new Vector2(speed * -2, 0);
                    lilChicks[i].GetComponent<NnormalEnemy>().speed = speed * -2;

                }
                else
                {
                    lilChicks[i].GetComponent<Rigidbody2D>().velocity = new Vector2((speed * 2), 0);
                    lilChicks[i].GetComponent<NnormalEnemy>().speed = speed * 2;
                }
            }
        }
        Destroy(gameObject);
    }
}
