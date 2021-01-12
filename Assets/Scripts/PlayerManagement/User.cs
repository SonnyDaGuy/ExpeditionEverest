using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class User : MonoBehaviour
{
    public enum ControllerType
    {
        Keyboard,
        Xbox
    }

    private Rewired.Player _player;

    public float timeBetweenPresses { get; set; }

    private float _sensitivity;

    private Dictionary<string, float> _inputTimeLinks = new Dictionary<string, float>(){
        { "Horizontal", 0f },
        { "Vertical", 0f },
        { "Positive", 0f },
        { "Negative", 0f },
        { "RotateHorizontal", 0f },
        { "SwapCharacter", 0f },
        { "Restart", 0f },
    };

    public User(Player.ID playerID)
    {
        _player = Rewired.ReInput.players.GetPlayer((int)playerID);
        _sensitivity = 0.4f;
        timeBetweenPresses = 0.3f;
    }

    public ControllerType GetController()
    {
        if(_player.id == 0)
        {
            return ControllerType.Keyboard;
        }

        Rewired.Controller controller = _player.controllers.GetLastActiveController();

#if UNITY_EDITOR
        if (controller == null)
        {
            controller = _player.controllers.Controllers.First();
        }
#endif

        switch (controller.type)
        {
            case Rewired.ControllerType.Keyboard:
                return ControllerType.Keyboard;
            default:
                return ControllerType.Xbox;
        }
    }

    public bool GetRight() => GetAxisPress("Horizontal", true, true);
    public bool GetLeft() => GetAxisPress("Horizontal", false, true);
    public bool GetUp() => GetAxisPress("Vertical", true, true);
    public bool GetDown() => GetAxisPress("Vertical", false, true);

    public bool ButtonDownPositive() => GetButtonPress("Positive", true);

    public bool ButtonDownNegative() => GetButtonPress("Negative", true);
    public bool ButtonDownSwapCharacter() => GetButtonPress("SwapCharacter", true);
    public bool ButtonDownStart() => GetButtonPress("Start", true);
    public bool ButtonDownRestart() => GetButtonPress("Restart", true);

    public bool ButtonHeldPositive() => _player.GetButton("A");

    public bool GetButtonPress(string button, bool overwrite)
    {
        if (EnoughTimeElapsed(button) && _player.GetButton(button))
        {
            if (overwrite)
                _inputTimeLinks[button] = Time.time;
            return true;
        }
        return false;
    }

    public bool GetAxisPress(string axis, bool superior, bool overwrite)
    {
        if (EnoughTimeElapsed(axis) && (superior ? (_player.GetAxis(axis) > _sensitivity)
            : (_player.GetAxis(axis) < -_sensitivity)))
        {
            if (overwrite)
                _inputTimeLinks[axis] = Time.time;
            return true;
        }
        return false;
    }

    private bool EnoughTimeElapsed(string input)
    {
        float timeElapsed = Time.time - _inputTimeLinks[input];
        if (timeElapsed > timeBetweenPresses)
        {
            return true;
        }
        return false;
    }

    public float GetJoystickAngle(bool previousAngle) // start at 0 degrees at top and rotate clockcwise
    {
        Vector2 position;
        if (previousAngle)
        {
            position = _player.GetAxis2DPrev("Horizontal", "Vertical");
        }
        else
        {
            position = _player.GetAxis2D("Horizontal", "Vertical");
        }
        float angle = Mathf.Rad2Deg * Mathf.Atan2(position.y, position.x);
        if (position.x == 0 && position.y == 0)
        {
            return 0f;
        }
        if (position.y > 0)
        {
            if (position.x < 0)
            {
                angle = 360f - angle;
            }
            else
            {
                angle = 90f - angle;
            }
        }
        else
        {
            angle = 90f - angle;
        }
        return angle;
    }

    public float GetAngleChange()
    {
        float currentAngle = GetJoystickAngle(false);
        float previousAngle = GetJoystickAngle(true);
        float deltaAngle = currentAngle - previousAngle;
        return deltaAngle;
    }

    public Vector3 GetJoystick3D()
    {
        Vector3 joystick = Vector3.zero;
        if (GetController() == ControllerType.Xbox)
        {
            if (joystick.magnitude > _sensitivity)
            {
                joystick = new Vector3(_player.GetAxis("Horizontal"), 0, _player.GetAxis("Vertical"));
            }
        }
        else if (GetController() == ControllerType.Keyboard)
        {
            joystick = new Vector3(_player.GetAxisRaw("Horizontal"), 0, _player.GetAxisRaw("Vertical"));
        }
        joystick.Normalize();
        return joystick;
    }

    public float GetVertical()
    {
        return _player.GetAxis("Vertical");
    }
}
