using DontLeMeExpire.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DontLeMeExpire.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IProduktService _produktService;

        private int _AnzahlProdukte;
        private int _AnzahlBaldAbgelaufenenProdukten;
        private int _AnzahlHeuteAbgelaufenenProdukten;
        private int _AnzahlAbgelaufenenProdukten;



        public MainViewModel(IProduktService produktService)
        {
            _produktService = produktService;
        }

        public int AnzahlProdukte
        {
            get => _AnzahlProdukte;
            set => SetProperty(ref _AnzahlProdukte, value);
        }

        public int AnzahlBaldAbgelaufenenProdukten
        {
            get => _AnzahlBaldAbgelaufenenProdukten;
            set => SetProperty(ref _AnzahlBaldAbgelaufenenProdukten, value);
        }
        public int AnzahlHeuteAbgelaufenenProdukten
        {
            get => _AnzahlHeuteAbgelaufenenProdukten;
            set => SetProperty(ref _AnzahlHeuteAbgelaufenenProdukten, value);
        }
        public int AnzahlAbgelaufenenProdukten
        {
            get => _AnzahlAbgelaufenenProdukten;
            set => SetProperty(ref _AnzahlAbgelaufenenProdukten, value);
        }


        public async Task LadeProduktStatistiken()
        {
            AnzahlProdukte = (await _produktService.LadeProduktliste()).Count();

            AnzahlBaldAbgelaufenenProdukten =(await _produktService.LadeProdukteBaldAblaufen()).Count();

            AnzahlHeuteAbgelaufenenProdukten = (await _produktService.LadeProdukteHeuteAblaufen()).Count();

            AnzahlAbgelaufenenProdukten = (await _produktService.LadeAbgelaufeneProdukte()).Count();
        }



    }
}
