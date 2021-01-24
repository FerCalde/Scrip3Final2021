using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovBullet : MonoBehaviour
{
	public GameObject player;
	public float speed = 4f;
	public Vector3 destino;
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		destino = player.transform.position;
	
	}

    // Update is called once per frame
    void Update()
    {
		if (this.transform.position == destino)
		{

		}

		this.transform.position = Vector3.MoveTowards(transform.position, destino, speed * Time.deltaTime);
	}
}
