using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

	public GameObject obstaclePrefab;
	public Canvas canvas;
	private float currentTime1;
	private float currentTime2;
	private Vector2 speed;
	private float height;
	private float delay;
	private List<GameObject> obstacles;

	// Start is called before the first frame update
	void Start()
	{
		speed = new Vector2(-5, 0);
		delay = 1.75f;
		obstacles = new List<GameObject>();
	}

	// Update is called once per frame
	void Update()
	{
		if (currentTime1 < Time.timeSinceLevelLoad)
		{
			currentTime1 = Time.timeSinceLevelLoad + delay;
			delay = Random.Range(1f, 3f);

			height = Random.Range(100, 201);
			obstacles.Add(Instantiate(obstaclePrefab));
			obstacles[obstacles.Count - 1].transform.localScale = new Vector2(obstaclePrefab.transform.localScale.x, height);
			obstacles[obstacles.Count - 1].GetComponent<Rigidbody2D>().velocity = speed;
		}

		if(currentTime2 < Time.timeSinceLevelLoad)
		{
			currentTime2 = Time.timeSinceLevelLoad + delay;
			delay = Random.Range(1f, 2f);
			height = Random.Range(100, 201);
			obstacles.Add(Instantiate(obstaclePrefab));
			obstacles[obstacles.Count - 1].transform.position = new Vector2(obstaclePrefab.transform.position.x + 5, -3.5f);
			obstacles[obstacles.Count - 1].transform.localScale = new Vector2(obstaclePrefab.transform.localScale.x, height);
			obstacles[obstacles.Count - 1].GetComponent<Rigidbody2D>().velocity = speed;
		}

		if(obstacles.Count > 0 && obstacles[0].transform.position.x < -10)
		{
			Destroy(obstacles[0]);
			obstacles.RemoveAt(0);
		}
	}

	public void Restart()
	{
		foreach(GameObject obj in obstacles)
		{
			Destroy(obj);
		}

		obstacles.Clear();
		delay = 1.75f;
		Time.timeScale = 1;
		canvas.enabled = false;
	}

	public void Quit()
	{
		Application.Quit();
	}
}
