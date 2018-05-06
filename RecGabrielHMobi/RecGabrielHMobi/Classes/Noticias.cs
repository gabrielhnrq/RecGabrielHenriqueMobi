using System;
using System.Collections.Generic;
using System.Text;

namespace RecGabrielHMobi.Classes
{/// <summary>
/// Modelos dos Campos de Noticias
/// </summary>
    public class Noticias
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string PostDate { get; set; }
        public string Photo { get; set; }
        public string LogoFile { get; set; }
        public string PhotoFullPath
        {
            get
            {
                if (!string.IsNullOrEmpty(Photo))
                {
                    return string.Format("http://gabrielh.somee.com/Photos/{0}.png", NewsId.ToString());
                }

                return string.Empty;
            }
        }
        public string Capa { get; set; }
        public string CapaFile { get; set; }
        public string Text { get; set; }
        public string ResumeText { get; set; }
        public string Author { get; set; }

    }
}
