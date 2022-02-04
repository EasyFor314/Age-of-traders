using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AlteroGames.AgeOfTraders.InputManager
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler _instance;
        private RaycastHit hit;
        private Vector3 mousePos;


        GameObject shipObject;

        void Start()
        {
            _instance = this;
        }

        public void HandleUnitMovement()
        {
            if (Input.GetMouseButtonDown(0))
            {
                
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D targetObject = Physics2D.OverlapPoint(mousePos);

                if (targetObject)
                {
                    GameObject selectedObject = targetObject.transform.gameObject;
                    if (selectedObject.layer == 6)
                    {
                        mousePos.z = -1;
                        shipObject.transform.position = mousePos;
                        Debug.Log("Map click");
                    }
                    else if (selectedObject.layer == 8)
                    {
                        shipObject = selectedObject;
                        Debug.Log("Ship click");
                    }
                    else if (selectedObject.layer == 7)
                        Debug.Log("City click");
                    else
                        Debug.Log("click");

                }
                else
                    Debug.LogError("Target Object nor found");



            }
        }
    }
}