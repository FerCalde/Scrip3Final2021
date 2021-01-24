using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : MonoBehaviour
{
	StateMachine ST;
	public GameObject molotov;
	public Transform shPoint;
	public Transform playerPos;
	public GameObject player;
	public GameObject newBullet;
	public float speed = 10f;
	// Start is called before the first frame update
	private void Awake()
	{
		ST = GetComponent<StateMachine>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void Start()
    {
		newBullet = GameObject.Instantiate(molotov, shPoint.position, transform.rotation);
		ST = GetComponent<StateMachine>();
		player = GameObject.FindGameObjectWithTag("Player");
		//molotov.transform.position = player.transform.position;
		ST.ChangeState("Shooting");
	}

    // Update is called once per frame
    void Update()
    {
		//molotov.transform.position = player.transform.position;
		newBullet.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}
}
