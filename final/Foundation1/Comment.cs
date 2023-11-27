using System;
using System.Collections.Generic;

public class Comment
{
    public string _commenterName { get; set;}
    public string _commenterTxt { get; set;}

    public Comment(string commenterName, string commenterTxt)
    {
        _commenterName = commenterName;
        _commenterTxt = commenterTxt;
    }

}