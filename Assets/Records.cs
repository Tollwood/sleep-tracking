using System;
using System.Collections.Generic;

[Serializable]
public class Records {

    public Records(){
        records = new List<Record>();
    }
    public List<Record> records;
}
