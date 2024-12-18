using SportPlus.DAL.Enums;
namespace SportPlus.PLL.Models
{
    public class teamInput
    {
        public FavouriteTeam? Team { get; set; }
        public int? Season { get; set; }
        public  SportPlus.DAL.Enums.League? League{ get; set; }
    }
}
