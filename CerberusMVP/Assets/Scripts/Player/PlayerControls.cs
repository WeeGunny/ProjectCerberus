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
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6156da92-c940-4421-92d5-a7c1fb3b7da5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""9d11371d-f636-4d97-bafd-9e8385fc0252"",
                    ""expectedControlType"": ""Vector2"",
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
                },
                {
                    ""name"": ""Switch Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""30494cd3-60e2-4858-83e0-483ef0a37be0"",
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
                    ""id"": ""10964810-3f5b-482e-b404-39c160af91e7"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Camera"",
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
                    ""id"": ""50150c0e-35e9-4143-a801-375bd1b287d5"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a67d1990-c37e-46ff-bfac-aa4d791662a6"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB and Mouse"",
                    ""action"": ""Switch Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85bf6763-5c17-4e92-b869-198d832e78ef"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Switch Weapon"",
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
                    ""id"": ""ffa3cc45-352d-44aa-9ff8-309d89e0aa43"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad Controls"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""e29f69f2-91bb-47da-abf7-420b7f225f94"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""c3a86516-2ddb-4a55-810c-6e2b13db80f0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""0fbe1900-68a4-4f3a-a42b-e19bbeaffc89"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""21fe6d1b-8a87-4a0d-a50a-bba73b187376"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""64853913-8b47-46ff-ab4a-094d3990dd23"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d053755c-8071-4f68-be41-2c21974a279d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3a9e076e-6f7d-41a7-9580-958f15475c7e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2e223cce-b51b-415a-b93f-5b55e329f8f1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5368f443-c255-437c-a125-54f93258e106"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""bfe85939-79fb-4e70-a77c-d643f377f1f2"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""58b4ae95-aafb-4234-bcc0-8c094ffa9b5f"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""7c17cd9c-f399-4d28-a90b-c6ee01081aff"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""803a37e1-f488-4e8e-b8aa-5eab624b4542"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e57bb68d-b526-49b8-958a-d2d440788481"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0d7558fb-fdaa-4340-be70-2218751471b2"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c6d7a5dd-3460-4fc2-a82a-09236dbd82fb"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9c1cf801-95bc-4861-a556-7d579f05252a"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4f96b873-e1c7-421a-b3bf-24c1a3832104"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a67734b0-4e67-4a99-a6f7-8b6ea1d1f923"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1a10716a-eb72-4cfb-8776-217d7b6d9c5f"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""654b03bd-26dd-4d67-9aa2-994e0ed7d31a"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""54e2a869-d073-40aa-8e9c-92f12ee82d53"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c6e3d5fc-65e3-4ed0-a09e-9ce6730df96a"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""50d037fb-48d6-4347-846f-c0d4d8e5f890"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3e7c0913-16e3-4829-9ecc-72d7cf1f2b4a"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cf966e30-11dc-4d0d-80fc-5c890eda9399"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""3072edbd-c284-498b-b203-460128086923"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""94d42d3f-d349-4fdc-9526-458c78f81f70"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""87144782-b4f0-4e04-8e0d-ebe395c869b1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""737fc8e4-5aa4-4909-b504-aa2c72a48308"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6e35e570-174c-4fec-beac-efd3b8c630fa"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1f6bbffe-1f3e-409f-8aed-1b84899bced4"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""484851bc-703c-4eac-adee-77b8d78560e8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""955dca0b-2b26-4914-ac8f-a9b4eb7ce681"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""837f2976-6d42-47a6-8216-8547cc2b18a8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3eb550b7-c675-401b-b275-15500d5639c5"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fab7f6b9-b50c-43be-bf08-77fa7ccc5c5f"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""250faa93-17e2-45dd-82af-5407906212f6"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e75a57f1-787f-4656-986f-fed0427ace41"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db57114b-f259-4b96-bb6b-e79a7ed1095c"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f6966e9-acd1-4a30-b8ef-ea210e0511c2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5f7bda4-63fa-45b2-9617-d835813d38a6"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4caf4b58-3b53-4cf0-b96d-8024112b14bf"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95d1a668-5b48-4fab-ac0b-a777391b017b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ebf4d03-4845-4305-b754-efce51e326ea"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45ff3000-bf7d-4c22-850f-ea67b4da5b8c"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""effc9d2d-547e-474d-a9bc-0f46380da90c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0f89386-7850-4d0e-b41d-2c6aaee49aba"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3a818699-8332-45da-b955-010b8e70a916"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
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
        m_Gameplay_SwitchWeapon = m_Gameplay.FindAction("Switch Weapon", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
        m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_SwitchWeapon;
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
        public InputAction @SwitchWeapon => m_Wrapper.m_Gameplay_SwitchWeapon;
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
                @SwitchWeapon.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitchWeapon;
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
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_Navigate;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_ScrollWheel;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_RightClick;
    private readonly InputAction m_UI_TrackedDevicePosition;
    private readonly InputAction m_UI_TrackedDeviceOrientation;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
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
        void OnSwitchWeapon(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnNavigate(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
    }
}