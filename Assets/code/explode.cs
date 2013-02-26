using UnityEngine;
using System.Collections;

public class explode : MonoBehaviour {
	
	bool exploding = false;
	public NetworkManagerScript netScript;
	
	private SphereCollider sCol;
	
	
	// Use this for initialization
	void Start () {
		netScript = (NetworkManagerScript) GameObject.Find("NetworkManager").GetComponent("NetworkManagerScript");
		sCol = GetComponent<SphereCollider>();
		sCol.enabled = false;
	}
	
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Ground"){
			Debug.Log("ground collide");
			exploding = true;
			sCol.enabled = true;
			
		}
	}
	
	void OnTriggerEnter(Collider victim){
		if(victim.gameObject.tag == "AI"){
			SphereScript aiScript = (SphereScript) victim.GetComponent("SphereScript");
			int aiID = aiScript.aiID;
			aiScript.localInfect();
			netScript.infected(networkView.viewID, aiID);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(exploding){
			sCol.radius = sCol.radius + 0.1f;
			if(sCol.radius > 10.0f){
				Destroy(this.gameObject);
			}
		}
	}
}
