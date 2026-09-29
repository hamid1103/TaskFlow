using System.ComponentModel;

namespace TaskFlowBackend.Models;

public enum RecurringType
{
    [Description("Do not recur")]
    None=1,
    [Description("Recur Daily")]
    Daily=2,
    [Description("Recur Weekly")]
    Weekly=3,
    [Description("Recur Bi-weekly")]
    BiWeekly=4,
    [Description("Recur Monthly")]
    Monthly=5,
}