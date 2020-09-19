namespace ClassesScheduleSetup
{
    public enum ClassActivityWeight
    {
        Normal = 0,

        StartsIn9AM = Normal,
        EndsIn5PM = 2,
        EndsIn6PM = 12,
        StartsIn8AM = 65,
        EndsIn7PM = 350,
        EndsIn8PM = 1800,

        Thursday_EndsIn1PM = Normal,
        Thursday_EndsIn2PM = Normal,
        Thursday_EndsIn3PM = Normal,
        Thursday_EndsIn4PM = Normal,
        Thursday_EndsIn5PM = EndsIn5PM,
        Thursday_EndsIn6PM = EndsIn6PM,
        Thursday_EndsIn7PM = EndsIn7PM,
        Thursday_EndsIn8PM = EndsIn8PM,
    }
}
