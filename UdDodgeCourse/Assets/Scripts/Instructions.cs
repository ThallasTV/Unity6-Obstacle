using Unity.Multiplayer.Center.Common;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class Instructions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI instructionText;
    [SerializeField] InputAction escapeAction;
    [SerializeField] InputAction nextAction;

    private void OnEnable()
    {
        escapeAction.Enable();
        nextAction.Enable();
    }

    private void OnDisable()
    {
        escapeAction.Disable();
        nextAction.Disable();
    }
    void Start()
    {
        //instructionText.text = GameObject.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text;
        instructionText.text = "Use WASD or Arrow keys to move the object.\n";
            
    }

    // Update is called once per frame
    void Update()
    {
        if(nextAction.triggered)
        {
            instructionText.text = "Don't collide with objects!";
        }

        if (escapeAction.triggered)
        {
            instructionText.text = "";
        }
        
    }
}
