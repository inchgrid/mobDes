using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {

    public GameObject gameObject1;          // Reference to the first GameObject
    public GameObject gameObject2;          // Reference to the second GameObject
    public int lineindex;

    private LineRenderer line;  						 // Line Renderer
    public DistanceJoint2D[] djs;
   // public DistanceJoint2D dj2;
    private Vector2 pos0;
	// Use this for initialization
	void Start () {
        // Add a Line Renderer to the GameObject
        line = this.gameObject.AddComponent<LineRenderer>();
        djs = gameObject1.GetComponents<DistanceJoint2D>();
        // Set the width of the Line Renderer
        line.startWidth = 1.5f;
        line.endWidth = 1.5f;
        // Set the number of vertex fo the Line Renderer
        line.positionCount = 2;
        line.startColor = Color.cyan;
        line.endColor = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () {
        // Check if the GameObjects are not null
        if (gameObject1 != null && gameObject2 != null)
        {
            // Update position of the two vertex of the Line Renderer
            //pos0 = new Vector2(gameObject2.transform.position.x, gameObject1.transform.position.y);
            pos0 = djs[lineindex].anchor;
            Debug.Log("ball " + lineindex + " anchor " + pos0);
            line.SetPosition(0, pos0);
            //line.SetPosition(0, gameObject1.transform.position);
            line.SetPosition(1, gameObject2.transform.position);
        }
	}
}
