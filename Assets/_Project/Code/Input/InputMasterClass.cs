// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputMasterClass : IInputActionCollection
{
    private InputActionAsset asset;
    public InputMasterClass()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""PinballMachine"",
            ""id"": ""bdd026dd-8c27-412c-87bf-67021f9908e8"",
            ""actions"": [
                {
                    ""name"": ""CompressSpring"",
                    ""id"": ""959425a3-bc96-4c31-9eaa-89d543318996"",
                    ""expectedControlLayout"": """",
                    ""continuous"": false,
                    ""passThrough"": false,
                    ""initialStateCheck"": false,
                    ""processors"": """",
                    ""interactions"": """",
                    ""bindings"": []
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""15283569-0fb0-40e3-9306-b098254fac66"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard & Mouse"",
                    ""action"": ""CompressSpring"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                },
                {
                    ""name"": """",
                    ""id"": ""dadd66b7-c69c-4489-9b19-19db51ecfbdd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard & Mouse"",
                    ""action"": ""CompressSpring"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false,
                    ""modifiers"": """"
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""basedOn"": """",
            ""bindingGroup"": ""Keyboard & Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mobile"",
            ""basedOn"": """",
            ""bindingGroup"": ""Mobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PinballMachine
        m_PinballMachine = asset.GetActionMap("PinballMachine");
        m_PinballMachine_CompressSpring = m_PinballMachine.GetAction("CompressSpring");
    }

    ~InputMasterClass()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes
    {
        get => asset.controlSchemes;
    }

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PinballMachine
    private InputActionMap m_PinballMachine;
    private IPinballMachineActions m_PinballMachineActionsCallbackInterface;
    private InputAction m_PinballMachine_CompressSpring;
    public struct PinballMachineActions
    {
        private InputMasterClass m_Wrapper;
        public PinballMachineActions(InputMasterClass wrapper) { m_Wrapper = wrapper; }
        public InputAction @CompressSpring { get { return m_Wrapper.m_PinballMachine_CompressSpring; } }
        public InputActionMap Get() { return m_Wrapper.m_PinballMachine; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PinballMachineActions set) { return set.Get(); }
        public void SetCallbacks(IPinballMachineActions instance)
        {
            if (m_Wrapper.m_PinballMachineActionsCallbackInterface != null)
            {
                CompressSpring.started -= m_Wrapper.m_PinballMachineActionsCallbackInterface.OnCompressSpring;
                CompressSpring.performed -= m_Wrapper.m_PinballMachineActionsCallbackInterface.OnCompressSpring;
                CompressSpring.canceled -= m_Wrapper.m_PinballMachineActionsCallbackInterface.OnCompressSpring;
            }
            m_Wrapper.m_PinballMachineActionsCallbackInterface = instance;
            if (instance != null)
            {
                CompressSpring.started += instance.OnCompressSpring;
                CompressSpring.performed += instance.OnCompressSpring;
                CompressSpring.canceled += instance.OnCompressSpring;
            }
        }
    }
    public PinballMachineActions @PinballMachine
    {
        get
        {
            return new PinballMachineActions(this);
        }
    }
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.GetControlSchemeIndex("Keyboard & Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.GetControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    public interface IPinballMachineActions
    {
        void OnCompressSpring(InputAction.CallbackContext context);
    }
}
