using System;
using System.Collections.Generic;

public class Comment
{
    public string _commenterName { get; set; }
    public string _commentertext { get; set; }

    public Comment(string commenterName, string commentertext)
    {
        _commenterName = commenterName;
        _commentertext = commentertext;
    }
}