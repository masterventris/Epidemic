using UnityEngine;
using System.Collections;

public class Civilian : MonoBehaviour {
	CivilianAIEntity aiControl;
	int changed ; //REMOVE FROM RELEASE, THIS IS A HACK
	
	

	// Use this for initialization
	void Start () {
		changed= 0;
		aiControl = new CivilianAIEntity(new Vector(100,100)); //This position won't really work, and it will need to convert easily to / from Vector3
		aiControl.setDestinationWaypoint(new Vector(0,0));
		Debug.Log ("lol");
		Debug.Log("npc class " + EntityManager.globalInstance().numberOfEntities());
	}
	
	// Update is called once per frame
	void Update () {
		double dt = Time.deltaTime;
		aiControl.update(dt);
		//transform.Translate(0.1f,0,0); //This moves it 0.1x and 0y
		if(changed == 0){
			Vector3 pos;
			pos.x = (float)aiControl.getDestinationWaypoint().x();
			pos.z = (float)aiControl.getDestinationWaypoint().y();
			pos.y = 1f;
			transform.position = Vector3.Lerp(transform.position, pos, 0.002f);
			pos = transform.position;
			aiControl.setPosition(new Vector(pos.x,pos.z));
			changed = 1;
		}else {
			Vector3 pos = transform.position;
			aiControl.setPosition(new Vector(pos.x,pos.z));
			if (aiControl.getPosition().equals(aiControl.getDestinationWaypoint())) changed = 0;
		}

	}
}