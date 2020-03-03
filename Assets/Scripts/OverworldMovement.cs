using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMovement : MonoBehaviour
{
    Rigidbody rigidbody;
    public float speed = 10;
    private void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rigidbody.MovePosition(rigidbody.position + new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime));
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fight"){
            Debug.Log("Fight");
            GameManager.trainer = other.GetComponent<TrainerHolder>().trainer;
            GameManager.ChangeGameState(GameManager.GameState.Battle);
        }
    }

}
