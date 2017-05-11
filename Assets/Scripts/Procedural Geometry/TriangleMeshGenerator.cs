using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TriangleMeshGenerator : MonoBehaviour {

	public Vector3[] newVertices;
	public Vector2[] newUV;
	public int[] newTriangles;

	public Vector3 start;
	void Start() {
		newVertices = new Vector3[3];
		newUV = new Vector2[3];

		//bottom left
		newVertices[0] = new Vector3(-0.66f, -0.5f, 0.0f);
		newUV[0] = new Vector2(1.0f, 1.0f);
		//top
		newVertices[1] = new Vector3(0.0f, 0.5f, 0.0f);
		newUV[1] = new Vector2(1.0f, 1.0f);
		//bottom left
		newVertices[2] = new Vector3(0.66f, -0.5f, 0.0f);
		newUV[2] = new Vector2(1.0f, 1.0f);


		//Triangles to connect them together
		newTriangles = new int[] { 0, 1, 2 };

		Mesh mesh = new Mesh();

		//add a Mesh Filter if there isn't one already
		if (!gameObject.GetComponent<MeshFilter>()){
			gameObject.AddComponent<MeshFilter>();
		}

		//add a Mesh Renderer if there isn't one already
		if (!gameObject.GetComponent<MeshRenderer>()){
			gameObject.AddComponent<MeshRenderer>();
			gameObject.GetComponent<MeshRenderer>().material = (Material)Resources.Load ("MatColour0");
		}

		GetComponent<MeshFilter>().mesh = mesh;
		mesh.vertices = newVertices;
		mesh.uv = newUV;
		mesh.triangles = newTriangles;

		start = gameObject.GetComponent<Transform>().position;

	}

	void Update () {
		Vector3 change = new Vector3(0.01f*Mathf.Sin(Time.time), 0.0f, 0.0f);
		gameObject.GetComponent<Transform>().position += change;
	}
}
