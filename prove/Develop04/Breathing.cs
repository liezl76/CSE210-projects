using System;
using System.Reflection.Metadata;

// public class BreathingActivty : Activity
// {
//     private string _breathInMessage;
//     private string _breathOutMessage;
    
//     public BreathingActivty(string _activityName, string _description, int _duration, string breathInMessage, string breatOutMessage) : base(activityname, description, duration)
//     {
//         this._breathInMessage = breathInMessage;
//         this._breathOutMessage = breatOutMessage;
//     }
//     protected override void PerformActivity()
//     {
//         for (int i=0; i < _duration; i++)
//         {
//             Console.WriteLine(_breathInMessage);
//             Pause(2); 

//             Console.WriteLine(breathOutMessage);
//             Pause(2);
//         }
//     }
// }