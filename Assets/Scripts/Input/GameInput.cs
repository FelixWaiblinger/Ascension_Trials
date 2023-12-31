//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/Input/GameInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInput"",
    ""maps"": [
        {
            ""name"": ""GameControls"",
            ""id"": ""3fcbc835-c5b7-440d-83f4-f652db109822"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""677813b8-921f-4326-ab3c-ee20e64fd379"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""49649be1-8f08-4846-bab3-05d432b84aff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""bff7961e-72a7-49d4-891e-a0505f5f9644"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""0958c95c-9e1d-4fac-b0a2-5435981d702a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ultimate"",
                    ""type"": ""Button"",
                    ""id"": ""348566c0-b7c8-4bdb-acd0-bd440cce9455"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Heal"",
                    ""type"": ""Button"",
                    ""id"": ""76b1d7b9-0cda-4e64-b97c-965783e7de9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Revive"",
                    ""type"": ""Button"",
                    ""id"": ""3013d26a-92a6-4db8-b573-98c466485878"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""LStick"",
                    ""id"": ""669ec5ff-a22a-4d50-a248-79f1a450b5ce"",
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
                    ""id"": ""db0e56d1-ad88-4882-abb3-db1a31ebf2db"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""59cb0aa6-0054-4fdb-bb71-5b0c723fd32b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""48b7638d-97ee-4377-ba66-6295f3941890"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""eaff4549-ef73-490d-8c93-e1e2d71f40bf"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""062b26f0-61c7-42e3-ad54-3b6eaed0a8e4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d553c80-eafe-46cc-9695-d5394ef188a4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12caaf16-d1f6-4a9d-90ea-2572a2d2f883"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b151cce-ee33-45fc-a742-8a1d0f69376c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Ultimate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3965cc7d-ebff-4eb0-b871-2e0fdd5cc234"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Revive"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""482627d8-7232-465b-bfd8-382632001312"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UIControls"",
            ""id"": ""645c5385-2b1b-4f69-a2e8-46835ddc110e"",
            ""actions"": [
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""800bee6f-f48d-4d30-bc11-b8cebc039306"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""78187ba8-d51d-4d2a-bbe9-9d5a3adab370"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GameControls
        m_GameControls = asset.FindActionMap("GameControls", throwIfNotFound: true);
        m_GameControls_Move = m_GameControls.FindAction("Move", throwIfNotFound: true);
        m_GameControls_Dash = m_GameControls.FindAction("Dash", throwIfNotFound: true);
        m_GameControls_Attack = m_GameControls.FindAction("Attack", throwIfNotFound: true);
        m_GameControls_Special = m_GameControls.FindAction("Special", throwIfNotFound: true);
        m_GameControls_Ultimate = m_GameControls.FindAction("Ultimate", throwIfNotFound: true);
        m_GameControls_Heal = m_GameControls.FindAction("Heal", throwIfNotFound: true);
        m_GameControls_Revive = m_GameControls.FindAction("Revive", throwIfNotFound: true);
        // UIControls
        m_UIControls = asset.FindActionMap("UIControls", throwIfNotFound: true);
        m_UIControls_Menu = m_UIControls.FindAction("Menu", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GameControls
    private readonly InputActionMap m_GameControls;
    private List<IGameControlsActions> m_GameControlsActionsCallbackInterfaces = new List<IGameControlsActions>();
    private readonly InputAction m_GameControls_Move;
    private readonly InputAction m_GameControls_Dash;
    private readonly InputAction m_GameControls_Attack;
    private readonly InputAction m_GameControls_Special;
    private readonly InputAction m_GameControls_Ultimate;
    private readonly InputAction m_GameControls_Heal;
    private readonly InputAction m_GameControls_Revive;
    public struct GameControlsActions
    {
        private @GameInput m_Wrapper;
        public GameControlsActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GameControls_Move;
        public InputAction @Dash => m_Wrapper.m_GameControls_Dash;
        public InputAction @Attack => m_Wrapper.m_GameControls_Attack;
        public InputAction @Special => m_Wrapper.m_GameControls_Special;
        public InputAction @Ultimate => m_Wrapper.m_GameControls_Ultimate;
        public InputAction @Heal => m_Wrapper.m_GameControls_Heal;
        public InputAction @Revive => m_Wrapper.m_GameControls_Revive;
        public InputActionMap Get() { return m_Wrapper.m_GameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControlsActions set) { return set.Get(); }
        public void AddCallbacks(IGameControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_GameControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameControlsActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Special.started += instance.OnSpecial;
            @Special.performed += instance.OnSpecial;
            @Special.canceled += instance.OnSpecial;
            @Ultimate.started += instance.OnUltimate;
            @Ultimate.performed += instance.OnUltimate;
            @Ultimate.canceled += instance.OnUltimate;
            @Heal.started += instance.OnHeal;
            @Heal.performed += instance.OnHeal;
            @Heal.canceled += instance.OnHeal;
            @Revive.started += instance.OnRevive;
            @Revive.performed += instance.OnRevive;
            @Revive.canceled += instance.OnRevive;
        }

        private void UnregisterCallbacks(IGameControlsActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Special.started -= instance.OnSpecial;
            @Special.performed -= instance.OnSpecial;
            @Special.canceled -= instance.OnSpecial;
            @Ultimate.started -= instance.OnUltimate;
            @Ultimate.performed -= instance.OnUltimate;
            @Ultimate.canceled -= instance.OnUltimate;
            @Heal.started -= instance.OnHeal;
            @Heal.performed -= instance.OnHeal;
            @Heal.canceled -= instance.OnHeal;
            @Revive.started -= instance.OnRevive;
            @Revive.performed -= instance.OnRevive;
            @Revive.canceled -= instance.OnRevive;
        }

        public void RemoveCallbacks(IGameControlsActions instance)
        {
            if (m_Wrapper.m_GameControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_GameControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameControlsActions @GameControls => new GameControlsActions(this);

    // UIControls
    private readonly InputActionMap m_UIControls;
    private List<IUIControlsActions> m_UIControlsActionsCallbackInterfaces = new List<IUIControlsActions>();
    private readonly InputAction m_UIControls_Menu;
    public struct UIControlsActions
    {
        private @GameInput m_Wrapper;
        public UIControlsActions(@GameInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Menu => m_Wrapper.m_UIControls_Menu;
        public InputActionMap Get() { return m_Wrapper.m_UIControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIControlsActions set) { return set.Get(); }
        public void AddCallbacks(IUIControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_UIControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIControlsActionsCallbackInterfaces.Add(instance);
            @Menu.started += instance.OnMenu;
            @Menu.performed += instance.OnMenu;
            @Menu.canceled += instance.OnMenu;
        }

        private void UnregisterCallbacks(IUIControlsActions instance)
        {
            @Menu.started -= instance.OnMenu;
            @Menu.performed -= instance.OnMenu;
            @Menu.canceled -= instance.OnMenu;
        }

        public void RemoveCallbacks(IUIControlsActions instance)
        {
            if (m_Wrapper.m_UIControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_UIControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIControlsActions @UIControls => new UIControlsActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSpecial(InputAction.CallbackContext context);
        void OnUltimate(InputAction.CallbackContext context);
        void OnHeal(InputAction.CallbackContext context);
        void OnRevive(InputAction.CallbackContext context);
    }
    public interface IUIControlsActions
    {
        void OnMenu(InputAction.CallbackContext context);
    }
}
