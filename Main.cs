using BepInEx;
using GorillaNetworking;
using Photon.Pun;

namespace skibidi
{
    [Description("HauntedModMenu")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Main
    {
        static readonly bool rp = ControllerInputPoller.instance.rightControllerPrimaryButton;
        static readonly bool rs = ControllerInputPoller.instance.rightControllerSecondaryButton;
        static readonly bool rt = ControllerInputPoller.TriggerFloat(UnityEngine.XR.XRNode.RightHand) > 0.5f;
        static readonly bool rg = ControllerInputPoller.GripFloat(UnityEngine.XR.XRNode.RightHand) > 0.5f;

        static readonly bool lp = ControllerInputPoller.instance.leftControllerPrimaryButton;
        static readonly bool ls = ControllerInputPoller.instance.leftControllerSecondaryButton;
        static readonly bool lt = ControllerInputPoller.TriggerFloat(UnityEngine.XR.XRNode.LeftHand) > 0.5f;
        static readonly bool lg = ControllerInputPoller.GripFloat(UnityEngine.XR.XRNode.LeftHand) > 0.5f;

        static readonly bool buttonsPressed = rp && rs && rt && rg && lp && ls && lt && lg;

        static readonly string SKIBIDI = "SKIBIDI";

        static bool isEnabled = true;

        public static void Update()
        {
            if (isEnabled)
            {
                if (buttonsPressed)
                {
                    PhotonNetwork.Disconnect();

                    PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(SKIBIDI, JoinType.Solo);
                }
            }
        }

        public static void OnEnable()
        {
            isEnabled = true;
        }

        public static void OnDisable()
        {
            isEnabled = false;
        }
    }

    public class PluginInfo
    {
        public const string GUID = "com.linnea.bpgt.skibidi";
        public const string Name = "skibidi";
        public const string Version = "1.0.0";
    }
}
