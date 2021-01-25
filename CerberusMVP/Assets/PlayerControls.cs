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
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""9d11371d-f636-4d97-bafd-9e8385fc0252"",
                    ""expectedControlType"": ""Stick"",
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
                    ""name"": ""Switch Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""be15ff93-53f9-41ab-9c7a-eeae1e343428"",
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
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7127d396-3d14-4ff4-9ec0-039383db456c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ccc9c78e-c193-49f1-8895-89f88c8de448"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0f9031c-9e50-4e43-9f74-b39cc14083cb"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00bed613-fe5e-40d9-b048-4a7ef6ca079d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Primary Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""116cce1e-54af-4065-8957-d8c321eff036"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Alternate Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""680846af-6e99-4783-86bf-6f521f5e42d2"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8db46a0e-b95e-43d1-a027-518b6e23691d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe76af01-55b0-4faf-b993-4be9306b7bee"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24ebe497-ca90-4b57-a218-ba053601fd03"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18aaaeff-0199-43ac-ad91-398660904bc8"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Health Pack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ed22efa-67ab-4aab-84c5-44581344d8e3"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moxie Battery"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a9bf7c9-b4f3-4455-a37e-7a46994dd562"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
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
        m_Gameplay_SwitchWeapon = m_Gameplay.FindAction("Switch Weapon", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_HealthPack = m_Gameplay.FindAction("Health Pack", throwIfNotFound: true);
        m_Gameplay_MoxieBattery = m_Gameplay.FindAction("Moxie Battery", throwIfNotFound: true);
        m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_SwitchWeapon;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_HealthPack;
    private readonly InputAction m_Gameplay_MoxieBattery;
    private readonly InputAction m_Gameplay_Pause;
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
        public InputAction @SwitchWeapon => m_Wrapper.m_Gameplay_SwitchWeapon;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @HealthPack => m_Wrapper.m_Gameplay_HealthPack;
        public InputAction @MoxieBattery => m_Wrapper.m_Gameplay_MoxieBattery;
        public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
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
                @SwitchWeapon.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchWeapon;
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
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
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
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnPrimaryFire(InputAction.CallbackContext context);
        void OnAlternateFire(InputAction.CallbackContext context);
        void OnGrit(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnHealthPack(InputAction.CallbackContext context);
        void OnMoxieBattery(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
