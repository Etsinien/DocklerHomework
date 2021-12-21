using Adapter;
using Caliburn.Micro;
using DataProvider.Command;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataProvider
{
    public class AWEmpireDataProvider : IBaseDataProvider
    {
        #region Fields and properties
        private readonly IRestApiAdapter m_restApiAdapter;
        private static UriBuilder m_uriBuilder;
        public BindableCollection<AWEmpireViewData> Videos { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Page number used to track which is the current page
        /// </summary>
        private int page = 1;
        public int Page
        {
            get { return page; }
            set
            {
                page = value;
                OnPropertyChanged();
            }
        }
        #endregion

        /// <summary>
        /// ctor
        /// </summary>
        public AWEmpireDataProvider()
        {
            Videos = new BindableCollection<AWEmpireViewData>();
            m_restApiAdapter = new AWEmpireAdapter();
            m_uriBuilder = new UriBuilder();
        }


        /// <summary>
        /// Async data collector for the View layer
        /// Its role is to request an update from the adapter layer and
        /// fill the dependency view model: AWEmpireDataElement
        /// </summary>
        /// <returns></returns>
        public async Task FetchDataAsync()
        {
            await m_restApiAdapter.GetNewDataAsync("https://pt.ptawe.com/api/video-promotion/v1/list?category=girl&clientIp=192.168.0.1&limit=25&pageIndex=" + Page + "&psid=TestUser00&accessKey=4edbad345fce30901f1757f17f0bcc35&primaryColor=FFEEEE&labelColor=EEFFEE");
            //TEST
            if (m_restApiAdapter.HasNewData)
            {
                Videos.Clear();

                var data = m_restApiAdapter.GetData() as AWEmpireDataRepository;
                Page = data.data.pagination.currentPage;

                foreach (var video in data.data.videos)
                {
                    ConvertToValidURI(video);

                    var viewData = new AWEmpireViewData
                    {
                        Title = video.title,
                        PreviewImage = m_uriBuilder.Uri,
                        Quality = video.quality,
                        Duration = video.duration.ToString()
                    };

                    Videos.Add(viewData);
                }
            }  
        }

        private static void ConvertToValidURI(AWEmpireDataRepository.Video video)
        {
            // URI to resource starts with '//' must append the https//
            // To avoid 'https////' issues, must trim the first two '//'
            m_uriBuilder.Host = video.previewImages.First().TrimStart(new char[] { '/', '/' });
            m_uriBuilder.Scheme = "https";
        }

        private ICommand LoadNextPageCommand;
        /// <summary>
        /// Command handler for Lodaing next page
        /// </summary>
        public ICommand LoadNextBtnCommand {
            get
            {
                if (LoadNextPageCommand == null)
                {
                    LoadNextPageCommand = new RelayCommand(
                        p => true,
                        p => LoadNextPage());
                }
                return LoadNextPageCommand;
            }
        }

        /// <summary>
        /// Loading next page by fetching new data to the repository and updating the specific View Data
        /// </summary>
        private async void LoadNextPage()
        {
            if(Page < 1)
                Page = 1;

            ++Page;
            await FetchDataAsync();
        }

        private ICommand LoadPreviousPageCommand;
        /// <summary>
        /// Command handler for loading previous page
        /// </summary>
        public ICommand LoadPreviousBtnCommand
        {
            get
            {
                if (LoadPreviousPageCommand == null)
                {
                    LoadPreviousPageCommand = new RelayCommand(
                        p => true,
                        p => LoadPreviousPage());
                }
                return LoadPreviousPageCommand;
            }
        }
        /// <summary>
        /// Loading previous page by fetching new data to the repository and updating the specific View Data
        /// </summary>
        private async void LoadPreviousPage()
        {
            if(Page > 1)
            {
                --Page;
                await FetchDataAsync();
            }   
        }

        private ICommand LoadSpecificPageCommand;
        /// <summary>
        /// Command handler for loading previous page
        /// </summary>
        public ICommand LoadSpecificPageBtnCommand
        {
            get
            {
                if (LoadSpecificPageCommand == null)
                {
                    LoadSpecificPageCommand = new RelayCommand(
                        p => true,
                        p => LoadSpecificPage());
                }
                return LoadSpecificPageCommand;
            }
        }
        /// <summary>
        /// Loading previous page by fetching new data to the repository and updating the specific View Data
        /// </summary>
        private async void LoadSpecificPage()
        {
            if (Page > 0)
            {
                await FetchDataAsync();
            }
            else
            {
                Page = 1;
            }
        }

        /// <summary>
        /// To be called when property changes, to fire property changed event
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
