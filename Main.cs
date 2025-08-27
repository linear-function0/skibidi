using BepInEx;
using GorillaNetworking;

namespace Skibidi
{
    [BepInPlugin("com.linnea.bpgt.skibidi", "Skibidi", "1.0.0")]
    public class Main
    {
        internal bool IsEnabled { get; set; }

        internal bool ButtonsPressed =>
            ControllerInputPoller.instance.rightControllerPrimaryButton &&
            ControllerInputPoller.instance.rightControllerSecondaryButton &&
            ControllerInputPoller.instance.rightControllerTriggerButton &&
            ControllerInputPoller.instance.rightGrab &&
            ControllerInputPoller.instance.leftControllerPrimaryButton &&
            ControllerInputPoller.instance.leftControllerSecondaryButton &&
            ControllerInputPoller.instance.leftControllerTriggerButton &&
            ControllerInputPoller.instance.leftGrab;

        void Update()
        {
            if (IsEnabled && ButtonsPressed)
            {
                NetworkSystem.Instance.ReturnToSinglePlayer();
                PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("SKIBIDI", JoinType.Solo);
            }
        }

        void OnEnable() => IsEnabled = true;
        void OnDisable() => IsEnabled = false;
    }
}
