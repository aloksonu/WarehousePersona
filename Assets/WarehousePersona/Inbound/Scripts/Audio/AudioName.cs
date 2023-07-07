namespace WarehousePersona.Inbound.Scripts.Audio
{
    public enum AudioName
    {

        NotSet=-1,
        GameBG = 0,
        ButtonClick = 1,
        Correct = 2,
        Wrong = 3,

        // Inbound
        Transport = 4,
        AssignLane = 5,
        Verification1 = 6,
        Unload = 7,
        Checking = 8,
        Receiving = 9,
        PutAway = 10,

        // Outbound
        OrderReceiving = 11,
        Picking = 12,
        Sorting = 13,
        Lebelling = 14,
        Loading = 15,
        Verification2 = 16,
        Shipping = 17,
    }
}