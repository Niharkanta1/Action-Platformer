using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*=============================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       30-04-2022 20:19:12
================================================*/
namespace DWG.AI {

    public class AIDataBoard : MonoBehaviour {

        public List<AIDataTypes> dataTypes;
        Dictionary<AIDataTypes, bool> aiBoard = new Dictionary<AIDataTypes, bool>();

        private void Start() {
            HashSet<AIDataTypes> noDuplicates = new HashSet<AIDataTypes>(dataTypes);
            foreach(var item in noDuplicates) {
                aiBoard.Add(item, false);
            }
        }

        public bool CheckBoard(AIDataTypes aiDataType) {
            if(CheckParameters(aiDataType) == false) {
                throw new System.Exception("No " + aiDataType.ToString() + " in the AI board for " + gameObject.name);            
            }
            return aiBoard[aiDataType];
        }

        public void SetBoard(AIDataTypes aiDataType, bool value) {
            if(CheckParameters(aiDataType) == false) {
                throw new System.Exception("No " + aiDataType.ToString() + " in the AI board for " + gameObject.name);
            }
            aiBoard[aiDataType] = value;
        }

        public bool CheckParameters(AIDataTypes aiDataType) => aiBoard.ContainsKey(aiDataType);
    }

    public enum AIDataTypes {
        Waiting,
        PlayerDetected,
        Arrived,
        InMeleeRange,
        PathBlocked
    }
}