using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using Sirenix.OdinInspector;
using System.IO;
using UnityEditor;

namespace Polombia
{
    public class ReadData : MonoBehaviour
    {
        public TextAsset json;
        //const string path = "Assets/_Project/Level/SO/CardSo";

        [Button]
        public List<Card> LoadData()
        {
            List<Card> cards = new List<Card>();
            var N = JSON.Parse(json.text);
            int i = 0;
            while (N[i] != null)
            {
                var character = N[i]["Character"].Value;
                Debug.Log(character);
                var question = N[i]["Question"].Value;
                Debug.Log(question);
                var decisionText1 = N[i]["Decision1"].Value.ToString();
                Debug.Log(question);
                float budget1 = N[i]["Budget1"].AsFloat;
                float approval1 = N[i]["Aproval1"].AsFloat;
                float support1 = N[i]["Support1"].AsFloat;
                Consequence consequence1 = new Consequence(budget1, approval1, support1);
                Decision decision1 = new Decision();
                decision1.decisionString = decisionText1;
                decision1.consequence = consequence1;

                var decisionText2 = N[i]["Decision2"].Value.ToString();
                float budget2 = N[i]["Budget2"].AsFloat;
                float approval2 = N[i]["Aproval2"].AsFloat;
                float support2 = N[i]["Support2"].AsFloat;
                Consequence consequence2 = new Consequence(budget2, approval2, support2);
                Decision decision2 = new Decision();
                decision2.decisionString = decisionText2;
                decision2.consequence = consequence2;

                Card newCard = new Card();
                newCard.CharacterName = character;
                newCard.decisions = new List<Decision>();
                newCard.questionString = question;
                newCard.decisions.Add(decision1);
                newCard.decisions.Add(decision2);

                cards.Add(newCard);
                i++;
                Debug.Log(i);


                //    if (!Directory.Exists($"{path}"))
                //    {
                //        //if it doesn't, create it
                //        Directory.CreateDirectory($"{path}");
                //    }

                //    AssetDatabase.CreateAsset(newCard, $"{path}\\{pathName}.asset");

                //    Debug.Log("Character: " + character + " " +
                //        "Question: " + question + " " +
                //        "Budget: " + budget1 + " " +
                //        "Decision2: " + decision2 + " "
                //        );


                }

                return cards;
        }
    }
}
