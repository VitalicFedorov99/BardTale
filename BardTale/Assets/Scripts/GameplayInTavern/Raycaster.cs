using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Raycaster : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private TMP_Text nameText;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out IInteraction objInteraction))
            {
                obj = hit.collider.gameObject;
                nameText.text = objInteraction.GetName();
            }
            else 
            {
                nameText.text = "";
            }
        }
    }
}
