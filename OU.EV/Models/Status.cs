namespace OU.EV.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum Status
    {
        [Display(Name = "Waiting Near By")]
        WaitingNear = 10,
        [Display(Name = "Waiting In Bay")]
        Waiting = 20,
        [Display(Name = "On Charge")]
        OnCharge = 30,
        [Display(Name = "Completed")]
        Completed = 40,
        [Display(Name = "No Charge Taken")]
        NoCharge = 50
    }
}