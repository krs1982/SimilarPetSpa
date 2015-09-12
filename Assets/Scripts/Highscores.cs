using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.UI;

public class Highscores : MonoBehaviour
{
    private List<Score> highscores = new List<Score>();
    private List<Score> sortedList = new List<Score>();

    FileInfo txtFile = null;
    StreamReader reader = null;

    public Text[] names, scores;

	void Start ()
    {
        txtFile = new FileInfo(Application.dataPath + "/Resources/scores.txt");

        if (txtFile != null && txtFile.Exists)
            reader = txtFile.OpenText();

        if (reader == null)
        {
            Debug.Log("scores.txt not found or not readable");
        }
        else
        {
            string txt = null;
            while((txt = reader.ReadLine()) != null)
            {
                string[] values = txt.Split(',');
                highscores.Add(new Score(values[0], Int32.Parse(values[1])));
            }

            highscores.Sort((s1, s2) => s1.score.CompareTo(s2.score));

            foreach (Score score in highscores)
            {
                sortedList.Insert(0, score);
            }

            highscores.Clear();
            highscores = sortedList;

            Score[] scoresArray = highscores.ToArray();

            if(highscores.Count < 10)
            {
                for(int i=0; i< highscores.Count; i++)
                {
                    names[i].text = scoresArray[i].name;
                    scores[i].text = scoresArray[i].score.ToString();
                }
            }
            else if(highscores.Count >= 10)
            {
                for (int i = 0; i < 10; i++)
                {
                    names[i].text = scoresArray[i].name;
                    scores[i].text = scoresArray[i].score.ToString();
                }
            }

            reader.Close();
        }
	}
	
    //void OnApplicationQuit()
    //{
    //    reader.Close();
    //}
}

