using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] private float delay = 0.5f;
	[SerializeField] private GameObject bullet;
	GameObject ammo;
	private float lastTime;


	private void Update()
	{
		if (Time.time - lastTime > delay)
		{
			if(Input.GetKey(KeyCode.Space))
				SpawnBombFromPool();
		}
		if(ammo != null)
			ammo.GetComponent<Rigidbody>().velocity = transform.forward * 20;
	}

    private void SpawnBomb()
    {
        lastTime = Time.time;
        Vector3 position = transform.position;
        var ammo = Instantiate(bullet, position, Quaternion.identity);
    }

    private void SpawnBombFromPool()
	{
		lastTime = Time.time;
		Vector3 position = transform.position;
		ammo = BasicPool.Instance.getRandomPool();
		ammo.transform.position = position;
	}
}