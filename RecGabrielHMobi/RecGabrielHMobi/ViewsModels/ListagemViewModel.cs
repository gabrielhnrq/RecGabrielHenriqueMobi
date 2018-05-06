using Newtonsoft.Json;
using RecGabrielHMobi.Classes;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecGabrielHMobi.ViewsModels
{
    public class ListagemViewModel : BaseViewModel
    {
        /// <summary>
        /// Entrada de Dados via HTTP URL JSON
        /// </summary>
        public ObservableCollection<Noticias> Noticias { get; set; }
        const string URL_GET_NOTICIAS = "http://gabrielh.somee.com/api/News";



        bool _aguarde;
        Noticias _noticiasSelecionando;
        /// <summary>
        /// Ordenar Noticias quando Solicitado
        /// </summary>
        public Noticias NoticiasSelecionado
        {
            get
            {
                return _noticiasSelecionando;
            }
            set
            {
                _noticiasSelecionando = value;
                if (value != null)
                    MessagingCenter.Send(_noticiasSelecionando, "NoticiasSelecionado");
            }
        }
        /// <summary>
        /// Obtendo Dados da Noticias na URL
        /// </summary>
        /// <returns></returns>
        public async Task GetNoticias()
        {
            Aguarde = true;
            try
            {
                HttpClient cliente = new HttpClient();
                var resultado = await cliente.GetStringAsync(URL_GET_NOTICIAS);
                var restaurantesJson = JsonConvert.DeserializeObject<NoticiasJson[]>(resultado);
                
                Noticias.Clear();
                //LOOOP
                foreach (var restaurantes in restaurantesJson)
                {
                    Noticias.Add(new Noticias
                    {
                        NewsId = restaurantes.newsid,
                        Title = restaurantes.title,
                        Author = restaurantes.author,
                        ResumeText = restaurantes.resumetext,
                        PostDate = restaurantes.postdate,
                        Photo = restaurantes.photo.ToString(),
                        Text = restaurantes.text
                    });
                }
            }
            catch (Exception ex)
            {
                MessagingCenter.Send<Exception>(ex, "FalhaListagem");
            }
            Aguarde = false;

        }

        public bool Aguarde
        {
            get { return _aguarde; }
            set
            {
                _aguarde = value;
                OnPropertyChanged();
            }
        }
        public ListagemViewModel()
        {
            Noticias = new ObservableCollection<Noticias>();
        }

    }
    /// <summary>
    /// Passando Dados para Variaveis (Strings)
    /// </summary>
    public class NoticiasJson
    {
        public string author { get; set; }
        public string resumetext { get; set; }
        public string postdate { get; set; }
        public string photo { get; set; }
        public string text { get; set; }
        public string title { get; set; }
        public int newsid { get; set; }
    }

}
