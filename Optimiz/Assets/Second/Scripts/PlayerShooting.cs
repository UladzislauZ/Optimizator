using Unity.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public bool spreadShot = false;

	[Header("General")]
	public Transform gunBarrel;
	public ParticleSystem shotVFX;
	public AudioSource shotAudio;
	public float fireRate = .1f;
	public int spreadAmount = 20;

	[Header("Bullets")] 
	public Pool pool;

	float timer;

	void Update()
	{
		timer += Time.deltaTime;

		if (Input.GetButton("Fire1") && timer >= fireRate)
		{
			Vector3 rotation = gunBarrel.rotation.eulerAngles;
			rotation.x = 0f;

			if (spreadShot)
				SpawnBulletSpread(rotation);
			else
				SpawnBullet(rotation);
			

			timer = 0f;

			if (shotVFX)
				shotVFX.Play();

			if (shotAudio)
				shotAudio.Play();
		}
	}

	void SpawnBullet(Vector3 rotation)
	{
		InitBullet(rotation);
	}

	void SpawnBulletSpread(Vector3 rotation)
	{
		int max = spreadAmount / 2;
		int min = -max;

		Vector3 tempRot = rotation;
		for (int x = min; x < max; x++)
		{
			tempRot.x = (rotation.x + 3 * x) % 360;

			for (int y = min; y < max; y++)
			{
				tempRot.y = (rotation.y + 3 * y) % 360;
				InitBullet(tempRot);
			}
		}
	}

	void InitBullet(Vector3 tempRot)
	{
		var bullet = pool.GetObject();
		bullet.SetActive(true);
		bullet.GetComponent<ProjectileBehaviour>().Off += OffBullet;
		bullet.transform.position = gunBarrel.position;
		bullet.transform.rotation = Quaternion.Euler(tempRot);
	}

	void OffBullet(GameObject obj)
	{
		obj.SetActive(false);
		pool.Return(obj);
	}
}

