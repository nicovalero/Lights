using System.Collections.Generic;
using System.Collections.ObjectModel;
using UI.Models.Interfaces;

namespace UI.Models.Structs
{
    internal struct LightListConfig_ViewModel
    {
        private ObservableCollection<IConfigListViewModel> _collection;

        public ObservableCollection<IConfigListViewModel> Collection { get { return _collection; } set { _collection = value; } }

        public LightListConfig_ViewModel(ObservableCollection<IConfigListViewModel> collection)
        {
            _collection = collection;
        }
    }
}
