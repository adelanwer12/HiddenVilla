using System;
using System.Collections.Generic;

namespace HiddenVillaServer.Models
{
    public class BlazorRoom
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public List<BlazorRoomProp> RoomProps { get; set; }
    }
}