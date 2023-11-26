using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ExperimentInfo {
        public int MovementId;
        public string Text;
        public string ImageId;
        public int ExperimentNumber;

        public ExperimentInfo(int pMovementId, int pExperimentNumber, string pTextInfo = null, string pImageId = null) {
            this.Text = pTextInfo;
            this.ImageId = pImageId;
            this.ExperimentNumber = pExperimentNumber;
            this.MovementId = pMovementId;

            if (this.Text == null) {
                this.Text = $"This is Movement Number # {this.MovementId}.\n To complete this movement, move your arms as shown in\n the picture attaached. You can also look at the VR model.";
            }

            if (this.ImageId == null) {
                this.ImageId = "" + this.MovementId;
            }
        }
    }
