using System.ComponentModel.DataAnnotations;

namespace OU.EV.Models
{
    public enum Status
    {
        [Display(Name = "Waiting Near By")]
        WaitingNear = 10,
        [Display(Name = "Waiting")]
        Waiting = 20,
        [Display(Name = "On Charge")]
        OnCharge = 30,
        [Display(Name = "Completed")]
        Completed = 40
    }
}