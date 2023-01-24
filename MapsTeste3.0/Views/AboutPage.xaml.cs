﻿using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace MapsTeste3._0.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private readonly Geocoder _geocoder = new Geocoder();

        async void Pesquisaendereco_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await Geocoding.GetLocationsAsync(entry.Text);

                var positions = await _geocoder.GetPositionsForAddressAsync(entry.Text);


                if (result.Any())
                   resultLocation.Text = $"lat: {result.FirstOrDefault()?.Latitude}, long: {result.FirstOrDefault()?.Longitude}";

                myMap.MoveToRegion(MapSpan.FromCenterAndRadius(positions.First(), Distance.FromMeters(1)));

                Pin pin = new Pin
                {
                    Label = "entry.Text",
                    Address = "entry.Text",
                    Type = PinType.Place,
                    Position = new Position(result.FirstOrDefault().Latitude, result.FirstOrDefault().Longitude)
                };
                myMap.Pins.Add(pin);

            }
            catch (Exception ex)
            {
                // TODO: Do something useful
            }

            //var positions = await _geocoder.GetPositionsForAddressAsync(result);
        }
    }
}