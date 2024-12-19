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
    [XmlElement("Date")]public DateTime _date;


    public SaveInstance(string playerName, int score,int level,DateTime date)
    {
        _playerName = playerName;
        _score = score;
        _level = level;
        _date = date;
    }
    public SaveInstance()
    {
    }
    
}