<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="BaseContent" runat="server">
    
    <script src="https://maps.googleapis.com/maps/api/js"></script>
    <script>
        var initialize = function () {
            var startPos; var lat; var lng; var LatLng;
            var geoOptions = {
                maximumAge: 5 * 60 * 1000,
                timeout: 10 * 1000
            }

            var geoSuccess = function (position) {
                startPos = position;
                lat = startPos.coords.latitude;
                lng = startPos.coords.longitude;
                lat_lng = { lat: lat, lng: lng };

                var mapCanvas = document.getElementById('map');
                var mapOptions = {
                    center: new google.maps.LatLng(lat, lng),
                    zoom: 8,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                }
                var map = new google.maps.Map(mapCanvas, mapOptions);
                var marker = new google.maps.Marker({
                    position: lat_lng,
                    map: map,
                    title: 'Hello World!',
                    lable: 'A'
                });
            };
            var geoError = function (position) {
                console.log('Error occurred. Error code: ' + error.code);
                // error.code can be:
                //   0: unknown error
                //   1: permission denied
                //   2: position unavailable (error response from location provider)
                //   3: timed out
            };

            navigator.geolocation.getCurrentPosition(geoSuccess, geoError, geoOptions);
        };

        google.maps.event.addDomListener(window, 'load', initialize);
    </script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    
    <div id="map" class="jumbotron"></div>
    <div id="map_error"></div>
    <div id="startLat"></div>
    <div id="startLon"></div>


</asp:Content>
