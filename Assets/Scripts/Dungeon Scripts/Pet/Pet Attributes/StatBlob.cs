using System;
using System.Collections.Generic;

class StatBlob
{
    List<Stat> _myStats = new List<Stat>();

    void Init()
    {
        //Gather up all the stats for use in other activities, or perhaps they've always lived here
    }

    Stat GetStat(string type)
    {
        //Return the requested stat's value for whatever
        return _myStats[0];
    }
}

