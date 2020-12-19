using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using System.IO;
using Events;

public class CameraBehaviour : MonoBehaviour {

	public Transform target;
	public GameObject canvas;
	public GameObject missilePrefab;
	public GameObject[] cloudPrefab;
	public float speed = 5f;
	public bool gameOver;
	Vector3 offSet;

	/*Log variables*/
	private static int counter = 0;
	private int missiles = 0;
	private static string c1 = "EVENT";
	private static string c2 = "VALUE";
	private static string c3 = "TIME";
	private static string currentTime;
	Log Log = new Log();

	// Use this for initialization
	void Start () {
		counter++;
		Log.Write(c1, c2, c3);

		offSet = target.position - transform.position;
		StartCoroutine(startAnimation());
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(!gameOver) transform.position = Vector3.Lerp(transform.position, target.position - offSet, speed * Time.deltaTime);
	}

	IEnumerator missileSpawner(){

		while(!gameOver){

			/* AQUI */
			currentTime = Time.time.ToString("f5");
			missiles++;
			c1 = "NM";
			c2 = missiles.ToString();
			c3 = currentTime;

			Log.Write(c1,c2,c3);
			/* AQUI */

			int j = 0;   
			int i = 0;
			if(target.rotation.z < 180) {
				i = 10;
				j = 8;
			}
			else {
				i = -10;   
				j = -8;
			}
			Vector3 spawnPosition = target.position + new Vector3(Random.Range(j,i),Random.Range(j,i),0f);
			GameObject missileTemp = Instantiate(missilePrefab, spawnPosition, missilePrefab.transform.rotation);
			missileTemp.GetComponent<MissileBehaviour>().target = target;
			yield return new WaitForSeconds(Random.Range(3f,5f));
		}

	}

	void makeClouds(){
		for(int i=-40; i < 40; i+= (int) Random.Range(5,8)){
			for(int j = -40; j < 40; j+= (int) Random.Range(5,8)){
				Instantiate(cloudPrefab[Random.Range(0,cloudPrefab.Length)], new Vector3(i,j,0f), Quaternion.identity);
			}
		}
	}

	IEnumerator startAnimation(){
		makeClouds(); 
		yield return new WaitForSeconds(2f);
		canvas.SetActive(false);
		StartCoroutine(missileSpawner());
	}

	public void restart(){

		/*AQUI*/
		currentTime = Time.time.ToString("f5");

		c1 = "restart";
		c2 = counter.ToString();
		c3 = currentTime;
		/*AQUI*/

		SceneManager.LoadScene("Main");
	}
}
