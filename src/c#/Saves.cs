using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SpacePeace;

[XmlRoot("Saves", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/Saves")]
[Serializable]

public class Saves
{
    [XmlElement("SaveInstance")] public List<SaveInstance> saves;

    public Saves()
    {
        saves = new List<SaveInstance>();
    }
    
    public void addSave(string playerName, int score,int level,DateTime date)
    {
        saves.Add(new SaveInstance(playerName, score,level,date));
    }

}