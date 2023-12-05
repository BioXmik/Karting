using Google.Protobuf.WellKnownTypes;
using UnityEngine;

namespace KartGame.KartSystems {

    public class KeyboardInput : BaseInput
    {
        //public string TurnInputName = "Horizontal";
        //public string AccelerateButtonName = "Accelerate";
        //public string BrakeButtonName = "Brake";
        public Transform Camera;
        public bool accelerate;
        public bool breake;
        public float turn;

        public override InputData GenerateInput() {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.localEulerAngles.x, Camera.localEulerAngles.y, transform.localEulerAngles.z), Time.deltaTime * 4);
            return new InputData
            {
                //Accelerate = Input.GetButton(AccelerateButtonName),
                //Brake = Input.GetButton(BrakeButtonName),
                //TurnInput = Input.GetAxis("Horizontal")
                Accelerate = accelerate,
                Brake = breake,
                TurnInput = turn
            };
        }

        public void SetAccelerate(bool value)
        {
            accelerate = value;
        }

        public void SetBrake(bool value)
        {
            breake = value;
        }
    }
}
