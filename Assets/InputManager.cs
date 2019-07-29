using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public float pauseTime = 1.5f;
    public GameObject pauseCanvas;

    private Keyboard keyboard;
    private float _bothPressedTime = 0;
    private float BothPressedTime
    {
        get
        {
            return _bothPressedTime;
        }
        set
        {
            _bothPressedTime = Mathf.Clamp(value, 0, pauseTime);
        }
    }
    private bool plus = true;

    // Start is called before the first frame update
    void Start()
    {
        keyboard = InputSystem.GetDevice<Keyboard>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboard.escapeKey.isPressed)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif      
        }

        bool flipper0 = keyboard.leftArrowKey.isPressed;
        bool flipper1 = keyboard.rightArrowKey.isPressed;

        foreach (var touch in Input.touches)
        {
            if (touch.position.y <= Screen.height * 0.2f)
            {
                if (touch.position.x <= Screen.width * 0.35f)
                {
                    flipper0 = true;
                }
                else if (touch.position.x >= Screen.width * 0.65f)
                {
                    flipper1 = true;
                }
            }
        }

        if (plus)
        {
            if (flipper0 && flipper1)
            {
                BothPressedTime += Time.fixedDeltaTime;

                if (BothPressedTime >= pauseTime)
                {
                    World.Active.QuitUpdate = true;
                    pauseCanvas.SetActive(true);
                }
            }
            else if (BothPressedTime >= pauseTime)
            {
                plus = false;
            }
            else
            {
                BothPressedTime -= Time.fixedDeltaTime;
            }
        }
        else
        {
            if (flipper0 && flipper1)
            {
                BothPressedTime -= Time.fixedDeltaTime;

                if (BothPressedTime <= 0)
                {
                    World.Active.QuitUpdate = false;
                    pauseCanvas.SetActive(false);
                }
            }
            else if (BothPressedTime <= 0)
            {
                plus = true;
            }
            else
            {
                BothPressedTime += Time.fixedDeltaTime;
            }
        }

        //    if (flipper0 && flipper1)
        //{
        //    bothPressedTime += Time.fixedDeltaTime;

        //    World.Active.QuitUpdate = (bothPressedTime >= pauseTime);
        //}
        //else
        //{
        //    bothPressedTime = 0;
        //}
    }
}
