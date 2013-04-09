using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoccerRankingLib;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace WpfFrenchChampionship.ViewModel
{
    public class MatchListViewModel : ViewModel
    {
        private ObservableCollection<Match> match = new ObservableCollection<Match>();
        private Ranking _ranking;

        public struct RankedMatch
        {
            public Club Home { get; set; }
            public Club Away { get; set; }
            public int HomeGoals { get; set; }
            public int AwayGoals { get; set; }
        } 

        public MatchListViewModel(Ranking ranking)
        {
            this._ranking = ranking;
            this._ranking.NewMatchRegistered += new EventHandler<Ranking.MatchRegistrationEventArgs>(_ranking_NewMatchRegistered);
            match.CollectionChanged += new NotifyCollectionChangedEventHandler(match_CollectionChanged);
        }

        void _ranking_NewMatchRegistered(object sender, Ranking.MatchRegistrationEventArgs e)
        {
            match.Add(e.NewMatch);
        }

        void match_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged("Matches");
        }

        public INotifyCollectionChanged Matches
        {
            get
            {
                return match;
            }
        }

        private void ranking_NewMatchRegistered(object sender, Ranking.MatchRegistrationEventArgs e)
        {
            match.Add(e.NewMatch);

        }
    }
}
