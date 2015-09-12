using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public Text NameField;

    public void Next()
    {
        FileStream fileStream = File.Open(Application.dataPath + "/Resources/scores.txt", FileMode.Append, FileAccess.Write);

        StreamWriter fileWriter = new StreamWriter(fileStream);

        fileWriter.WriteLine(NameField.text + "," + PersistentData.scoreToSave.ToString());
        fileWriter.Flush();
        fileWriter.Close();

        Application.LoadLevel("HighscoresScene");
    }
}

