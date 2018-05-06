using RecGabrielHMobi.Classes;
using RecGabrielHMobi.ViewsModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecGabrielHMobi.Views
{
    /// <summary>
    /// Listagem de Todas as Noticias
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListagemView : ContentPage
    {
       public ListagemViewModel ViewModel { get; set; }
        public ListagemView ()
		{
			InitializeComponent ();
            this.ViewModel = new ListagemViewModel();
            this.BindingContext = ViewModel;
        }
        /// <summary>
        /// Quando Aparecer TELA Ordena em Get passando com MessasingCenter para ListView na View
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            await ViewModel.GetNoticias();

            MessagingCenter.Subscribe<Noticias>(this, "NoticiasSelecionado",
                (msg) =>
                {
                    Navigation.PushAsync(new DetalheView(msg));

                }

                );
            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem",
                (msg) =>
                {
                    DisplayAlert(
                        "Erro",
                        msg.Message,
                        "Ok"
                            );
                }

                );
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Noticias>(this, "NoticiasSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
            
        }

    }
}
