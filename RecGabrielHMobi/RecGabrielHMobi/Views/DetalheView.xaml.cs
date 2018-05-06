using RecGabrielHMobi.Classes;
using RecGabrielHMobi.ViewsModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecGabrielHMobi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheView : ContentPage
    {
        /// <summary>
        /// Classe Vinculo de Notícias
        /// </summary>
        public Noticias Noticias { get; set; }
        public DetalheViewModel ViewModel { get; set; }
        public DetalheView(Noticias noticias)
        {
            InitializeComponent();
            Noticias = noticias;
            this.ViewModel = new DetalheViewModel(noticias);
            this.BindingContext = ViewModel;
        }

        
        /// <summary>
        /// Buscando Foto
        /// </summary>
        protected override void OnAppearing()
        {
            //base.OnAppearing();
            //MessagingCenter.Subscribe<Restaurante>(this, "Proximo",
            //(msg) =>
            //{
            //    Navigation.PushAsync(new AgendamentoView(msg));
            //});
            
            base.OnAppearing();
            photoImage.Source = Noticias.PhotoFullPath;
            photoImage.HeightRequest = 200f;
            photoImage.WidthRequest = 200f;
        }

    }
}