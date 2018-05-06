using RecGabrielHMobi.Classes;
using System.Windows.Input;
using Xamarin.Forms;

namespace RecGabrielHMobi.ViewsModels
{
    public class DetalheViewModel : BaseViewModel
    {
        /// <summary>
        /// Detalhes das Noticias com Respectivos Campos da Model (Noticias)
        /// </summary>
     public Noticias Noticias { get; set; }
        public string Texto
        {
            get { return string.Format("{0}", Noticias.Text); }

        }

        public string Titulo
        {
            get { return string.Format("{0}", Noticias.Title); }

        }
        public string Data
        {
            get { return string.Format("{0}", Noticias.PostDate); }

        }
        public string PhotoFullPath
        {
            get{ return string.Format("{0}", Noticias.NewsId);}
        }
    
        public DetalheViewModel(Noticias noticias)
        {

            Noticias = noticias;

            ProximoCommand = new Command(() =>
            {
                MessagingCenter.Send(noticias, "Proximo");
            });

        }
        public ICommand ProximoCommand { get; set; }

    }

}
