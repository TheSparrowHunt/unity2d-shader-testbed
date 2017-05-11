using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTriangles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectsWithTag("Triangle") != null) {
			GameObject[] tris = GameObject.FindGameObjectsWithTag ("Triangle");
			foreach (GameObject tri in tris) {
				Destroy(tri);
			}
		}
		for (int i = 0; i < 100; i++) {
			for (int j = 0; j < 100; j++) {
				GameObject current = (GameObject)Instantiate(Resources.Load ("Triangle"));
				float xoffset = i * 0.66f;
				//translation
				current.transform.Translate(-50.0f+xoffset, -50.0f+(float)j, 0.0f);

				//rotation flipping for tesselation
				switch (i % 2) {
				case 0:
					current.transform.Rotate (0.0f, 0.0f, 180.0f);
					break;
					default:

					break;
				}

				//colours
				switch ((((j*2)%4)+i) % 4) {
					case 0:
						current.GetComponent<MeshRenderer>().material = (Material)Resources.Load ("MatColour0");
					break;
					case 1:
						current.GetComponent<MeshRenderer>().material = (Material)Resources.Load ("MatColour1");
					break;
					case 2:
						current.GetComponent<MeshRenderer>().material = (Material)Resources.Load ("MatColour2");
					break;
					case 3:
						current.GetComponent<MeshRenderer>().material = (Material)Resources.Load ("MatColour4");
					break;

				}


			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
