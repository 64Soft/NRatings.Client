﻿namespace NRatings.Client.ApiClient.DTO
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
