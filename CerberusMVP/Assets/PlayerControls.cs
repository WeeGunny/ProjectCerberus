// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""aa5b4a04-9348-438f-b08d-56891ea9b265"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""43af8e80-dc73-42c5-9df0-4fb808fab2cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6156da92-c940-4421-92d5-a7c1fb3b7da5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""9d11371d-f636-4d97-bafd-9e8385fc0252"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Primary Fire"",
                    ""type"": ""Button"",
                    ""id"": ""8711c5f1-7492-41c2-8c1a-d80f5cb5a47b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Alternate Fire"",
                    ""type"": ""Button"",
                    ""id"": ""b20c79f7-b61d-4a10-8bb6-6582f4e01fe8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grit"",
                    ""type"": ""Button"",
                    ""id"": ""574fd01b-2e2a-4d3b-9796-26bf5fd8580c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""6d69e77d-1a9c-4fb4-9b52-157423553bcf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""91c9e1ef-38fc-49d8-b0b2-6a5dfb880e70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Health Pack"",
                    ""type"": ""Button"",
                    ""id"": ""9f94202f-383f-47d4-9aae-85dd8a9d9717"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Moxie Battery"",
                    ""type"": ""Button"",
                    ""id"": ""9f22113d-5d64-4729-a753-7d4be86e402a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""b1d73529-e691-4894-a258-b77925413ebd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""5f2870db-9747-470d-a6c9-1cb5cc4497f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ae61f9ea-8992-44c1-9855-b0aebe72fa20"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49d1d840-4164-4d6e-83df-0cec9d5ae88c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e3afce3b-7d86-4a69-a54c-8c068587109a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""268d48e7-a747-4f01-a5cb-060d5304b8da"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f0410a69-70aa-4656-b6ac-fbab2643c9e4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bc09123a-95e8-43d5-9738-245ea013b75e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""732fe426-ea50-4e3e-834d-7ef8eb0abb93"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a6f03efe-2b46-4f03-99e9-5f4f47b67016"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a3283b4-f73f-4c01-a3fe-584af5240c5d"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Health Pack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b775d16c-ca84-4ae4-9ff3-80f3d906f899"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Health Pack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eab93d33-f9c5-44ac-89c8-3401c8d9b3fd"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Moxie Battery"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""86313e02-9d65-429f-820e-bfc67f6e70fb"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Moxie Battery"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c9094c32-2de3-428e-9555-68e4f43940cb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40b61f5e-ee73-48fd-b227-7eed5eda4c4a"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a662624d-a96d-49f8-bcee-2d8ff2104c56"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffa3cc45-352d-44aa-9ff8-309d89e0aa43"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""942e5c21-76a2-45b6-a14d-ce1b23ef24e3"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10964810-3f5b-482e-b404-39c160af91e7"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3ca6530-16ce-4ad1-8fba-3c15aac18be7"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Primary Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b97acfaa-40aa-4118-bec5-641421374cf0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Primary Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e34c1dd-cad5-4d52-9097-0562ab68dffc"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Alternate Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f498214-d37a-4ae9-a051-a124c84dd683"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Alternate Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""486894ad-4da1-4b6f-b597-10b4e29f1a47"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Grit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d092d26-6da3-41b9-88b0-0ae8f5757e52"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Grit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f9a8acd-c5a9-4b22-8e5f-d64500f50344"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9dcfa04f-4ecd-41ea-9493-2bb114d7bf35"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d93cf52c-707a-4a36-9739-60593d7a171c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50150c0e-35e9-4143-a801-375bd1b287d5"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""0a81255f-deb8-4928-8eda-3c889573975d"",
            ""actions"": [
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""46e1b7be-61c5-4210-8fd5-92cbc6e4d615"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""ed137946-369c-4661-b90b-2ca5074a7a3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""1d736bf2-aa33-4f70-8e41-48cbc7dadf6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""6fbe177b-bf2d-4a57-a110-19951a648c0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""74a4838c-0cc4-440b-bed0-99c42721e25c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""715e5ee2-d7fe-412c-9aef-5b420d0c79ef"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b22ddf56-6aea-42ee-9394-f781dc2278ba"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""277d5ceb-ff4d-45ae-b5ef-43436ad47fba"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""GamePad Controls"",
            ""bindingGroup"": ""GamePad Controls"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""KB and Mouse"",
            ""bindingGroup"": ""KB and Mouse"",
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
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Camera = m_Gameplay.FindAction("Camera", throwIfNotFound: true);
        m_Gameplay_PrimaryFire = m_Gameplay.FindAction("Primary Fire", throwIfNotFound: true);
        m_Gameplay_AlternateFire = m_Gameplay.FindAction("Alternate Fire", throwIfNotFound: true);
        m_Gameplay_Grit = m_Gameplay.FindAction("Grit", throwIfNotFound: true);
        m_Gameplay_Reload = m_Gameplay.FindAction("Reload", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_HealthPack = m_Gameplay.FindAction("Health Pack", throwIfNotFound: true);
        m_Gameplay_MoxieBattery = m_Gameplay.FindAction("Moxie Battery", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
        m_Gameplay_Sprint = m_Gameplay.FindAction("Sprint", throwIfNotFound: true);
    }

    public void Dispose()
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

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Camera;
    private readonly InputAction m_Gameplay_PrimaryFire;
    private readonly InputAction m_Gameplay_AlternateFire;
    private readonly InputAction m_Gameplay_Grit;
    private readonly InputAction m_Gameplay_Reload;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_HealthPack;
    private readonly InputAction m_Gameplay_MoxieBattery;
    private readonly InputAction m_Gameplay_Pause;
    private readonly InputAction m_Gameplay_Sprint;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Camera => m_Wrapper.m_Gameplay_Camera;
        public InputAction @PrimaryFire => m_Wrapper.m_Gameplay_PrimaryFire;
        public InputAction @AlternateFire => m_Wrapper.m_Gameplay_AlternateFire;
        public InputAction @Grit => m_Wrapper.m_Gameplay_Grit;
        public InputAction @Reload => m_Wrapper.m_Gameplay_Reload;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @HealthPack => m_Wrapper.m_Gameplay_HealthPack;
        public InputAction @MoxieBattery => m_Wrapper.m_Gameplay_MoxieBattery;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
        public InputAction @Sprint => m_Wrapper.m_Gameplay_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Camera.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamera;
                @PrimaryFire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryFire;
                @PrimaryFire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryFire;
                @PrimaryFire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrimaryFire;
                @AlternateFire.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAlternateFire;
                @AlternateFire.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAlternateFire;
                @AlternateFire.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAlternateFire;
                @Grit.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrit;
                @Grit.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrit;
                @Grit.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrit;
                @Reload.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @HealthPack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHealthPack;
                @HealthPack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHealthPack;
                @HealthPack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHealthPack;
                @MoxieBattery.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoxieBattery;
                @MoxieBattery.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoxieBattery;
                @MoxieBattery.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMoxieBattery;
                @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                @Sprint.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @PrimaryFire.started += instance.OnPrimaryFire;
                @PrimaryFire.performed += instance.OnPrimaryFire;
                @PrimaryFire.canceled += instance.OnPrimaryFire;
                @AlternateFire.started += instance.OnAlternateFire;
                @AlternateFire.performed += instance.OnAlternateFire;
                @AlternateFire.canceled += instance.OnAlternateFire;
                @Grit.started += instance.OnGrit;
                @Grit.performed += instance.OnGrit;
                @Grit.canceled += instance.OnGrit;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @HealthPack.started += instance.OnHealthPack;
                @HealthPack.performed += instance.OnHealthPack;
                @HealthPack.canceled += instance.OnHealthPack;
                @MoxieBattery.started += instance.OnMoxieBattery;
                @MoxieBattery.performed += instance.OnMoxieBattery;
                @MoxieBattery.canceled += instance.OnMoxieBattery;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_GamePadControlsSchemeIndex = -1;
    public InputControlScheme GamePadControlsScheme
    {
        get
        {
            if (m_GamePadControlsSchemeIndex == -1) m_GamePadControlsSchemeIndex = asset.FindControlSchemeIndex("GamePad Controls");
            return asset.controlSchemes[m_GamePadControlsSchemeIndex];
        }
    }
    private int m_KBandMouseSchemeIndex = -1;
    public InputControlScheme KBandMouseScheme
    {
        get
        {
            if (m_KBandMouseSchemeIndex == -1) m_KBandMouseSchemeIndex = asset.FindControlSchemeIndex("KB and Mouse");
            return asset.controlSchemes[m_KBandMouseSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnPrimaryFire(InputAction.CallbackContext context);
        void OnAlternateFire(InputAction.CallbackContext context);
        void OnGrit(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnHealthPack(InputAction.CallbackContext context);
        void OnMoxieBattery(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnConfirm(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
}
