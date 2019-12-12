// GENERATED AUTOMATICALLY FROM 'Assets/Runtime/Scripts/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""player"",
            ""id"": ""904ef2be-cb55-452e-9e5e-b6559a8db5eb"",
            ""actions"": [
                {
                    ""name"": ""aim"",
                    ""type"": ""Value"",
                    ""id"": ""cde288ec-b541-491d-a615-c45de621ba87"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""shoot"",
                    ""type"": ""Button"",
                    ""id"": ""1acadfdf-4604-4218-a920-b14d505f3ee9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8067e8db-0964-4444-98ff-457a9fc72473"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddd7bc4d-2707-43d2-aa15-00486e9519d9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // player
        m_player = asset.FindActionMap("player", throwIfNotFound: true);
        m_player_aim = m_player.FindAction("aim", throwIfNotFound: true);
        m_player_shoot = m_player.FindAction("shoot", throwIfNotFound: true);
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

    // player
    private readonly InputActionMap m_player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_player_aim;
    private readonly InputAction m_player_shoot;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @aim => m_Wrapper.m_player_aim;
        public InputAction @shoot => m_Wrapper.m_player_shoot;
        public InputActionMap Get() { return m_Wrapper.m_player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @aim.started += instance.OnAim;
                @aim.performed += instance.OnAim;
                @aim.canceled += instance.OnAim;
                @shoot.started += instance.OnShoot;
                @shoot.performed += instance.OnShoot;
                @shoot.canceled += instance.OnShoot;
            }
        }
    }
    public PlayerActions @player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
