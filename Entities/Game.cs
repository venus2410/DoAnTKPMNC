using System;
using System.Collections.Generic;

namespace DoAnTKPMNC.Entities
{
    public partial class Game
    {
        public Game()
        {
            CampaignGames = new HashSet<CampaignGame>();
        }

        public int GameId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CampaignGame> CampaignGames { get; set; }
    }
}
