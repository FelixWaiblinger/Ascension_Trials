using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameControlsActions, GameInput.IUIControlsActions
{
	public static UnityAction<Vector2> moveEvent;
	public static UnityAction dashEvent;
	public static UnityAction attackEvent;
	public static UnityAction specialEvent;
	public static UnityAction ultimateEvent;
	public static UnityAction healEvent;
	public static UnityAction reviveEvent;
	public static UnityAction menuEvent;

	private GameInput gameInput;

    public void InitGameInput()
	{
		if (gameInput == null)
		{
			gameInput = new GameInput();
			gameInput.GameControls.SetCallbacks(this);
			gameInput.UIControls.SetCallbacks(this);
		}

		EnablePlayerInputs();
		EnableUIControls();
    }

	#region SUBSCRIBERS

	public void ClearAllSubscribers()
	{
		ClearSubscribers(moveEvent);
		ClearSubscribers(dashEvent);
		ClearSubscribers(attackEvent);
		ClearSubscribers(specialEvent);
		ClearSubscribers(ultimateEvent);
		ClearSubscribers(healEvent);
		ClearSubscribers(reviveEvent);
		ClearSubscribers(menuEvent);
	}

	void ClearSubscribers<T>(UnityAction<T> a) { a = null; }

	void ClearSubscribers(UnityAction a) { a = null; }

	#endregion

	#region CALLBACKS

	// move player (lstick)
	public void OnMove(InputAction.CallbackContext context)
	{
		moveEvent?.Invoke(context.ReadValue<Vector2>());
	}

	// quickly move a short distance (south)
	public void OnDash(InputAction.CallbackContext context)
	{
        if (context.phase == InputActionPhase.Performed) dashEvent?.Invoke();
	}

	// attack (west)
	public void OnAttack(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed) attackEvent?.Invoke();
	}

	// special (north)
	public void OnSpecial(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed) specialEvent?.Invoke();
	}

    // ultimate (east)
	public void OnUltimate(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed) ultimateEvent?.Invoke();
	}

	// use a health potion (right shoulder)
	public void OnHeal(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Started) healEvent?.Invoke();
	}

    // revive fallen teammate (left&right trigger)
    public void OnRevive(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) menuEvent?.Invoke();
    }

    // open ingame menu (start)
    public void OnMenu(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started) menuEvent?.Invoke();
    }

    #endregion

    #region SWITCH INPUT

    public void EnablePlayerInputs() { gameInput.GameControls.Enable(); }
    
	public void DisablePlayerInputs() { gameInput.GameControls.Disable(); }

	public void EnableUIControls() { gameInput.UIControls.Enable(); }

    public void DisableUIInputs() { gameInput.UIControls.Disable(); }

	#endregion
}