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
    //Prends une chaine de caractères, deux entiers et une date, ajoute une sauvegarde à la liste saves
    public void addSave(string playerName, int score,int level,DateTime date)
    {
        saves.Add(new SaveInstance(playerName, score,level,date));
    }

}