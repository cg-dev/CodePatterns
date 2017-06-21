using Newtonsoft.Json;

namespace OU.EV.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Vehicle
    {
        [JsonProperty(PropertyName = "id")]
        [MaxLength(5, ErrorMessage = "Only enter the first 5 characters of your registration. e.g. 'AB 12'")]
        public string Registration { get; set; }

        [JsonProperty(PropertyName = "make")]
        public string Make { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "colour")]
        public string Colour { get; set; }

        [JsonProperty(PropertyName = "forename")]
        public string Forename { get; set; }

        [JsonProperty(PropertyName = "surname")]
        [MaxLength(1, ErrorMessage = "Only enter the first letter of your surname")]
        [DisplayName("Surname Initial")]
        public string Surname { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonIgnore]
        public string FullName
        {
            get { return $"{this.Forename} {this.Surname}"; }
        }
    }
}