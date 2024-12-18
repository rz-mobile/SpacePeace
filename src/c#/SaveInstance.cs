using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SpacePeace;
[XmlRoot("SaveInstance", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/Saves")]
[Serializable]
public class SaveInstance
{
    [XmlElement("PlayerName")]public string _playerName;
    [XmlElement("Score")]public int _score;
    [XmlElement("Niveau")]public int _level;


    public SaveInstance(string playerName, int score,int level)
    {
        _playerName = playerName;
        _score = score;
        _level = level;
    }
    public SaveInstance()
    {
    }
    
}