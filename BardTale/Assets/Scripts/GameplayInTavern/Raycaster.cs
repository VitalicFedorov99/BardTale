using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class Raycaster : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text nameActionText;
    // Update is called once per frame
    void Update()
    {
        if (ObjLocator.instance.GetStateMachineGame().GetState() == StateInMainGame.Game)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out IInteraction objInteraction))
                {
                    obj = hit.collider.gameObject;
                    nameText.text = objInteraction.GetName();
                    nameActionText.text = objInteraction.GetNameAction();
                }
                else
                {
                    nameText.text = "";
                    nameActionText.text = "";
                }
            }
        }
        else
        {
            nameText.text = "";
            nameActionText.text = "";
        }
    }

    public void OnFire()
    {
        
        if (ObjLocator.instance.GetStateMachineGame().GetState() == StateInMainGame.Game)
        {
            if (obj.TryGetComponent(out IInteraction interaction))
                interaction.Interaction();
        }
        
    }
}
