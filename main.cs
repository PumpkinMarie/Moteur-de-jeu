 using UnityEngine;
 using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class main : MonoBehaviour {

	 public Vector3 jump;
	 public float jumpForce = 1.3f;
 	 public float slideForce = 0.2f;
	 public int semLeft=1;
	 public int semRight=1;
     private Vector3 deplacement = Vector3.zero;
     public float ray = 0.2f;
     public RaycastHit hit;

	 Rigidbody rb;
	 void Start(){
		 rb = GetComponent<Rigidbody>();
	 }
	 
	bool isGrounded() {
		Vector3 down = transform.TransformDirection(Vector3.down) * ray * ray;
        return Physics.Raycast(transform.position, down, out hit, 0.1f * 0.5f);
	}

	 void FixedUpdate(){
		 if(Input.GetKeyDown(KeyCode.Space) && isGrounded()){
			 rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
 		 }
		 if(Input.GetKeyDown(KeyCode.RightArrow) && semRight>0){
			deplacement = Vector3.left;
			semRight--;
			semLeft++;
 		 }
		 if(Input.GetKeyDown(KeyCode.LeftArrow) && semLeft>0){
			deplacement = Vector3.right;
			semLeft--;semRight++;
 		 }
	 }
 }
