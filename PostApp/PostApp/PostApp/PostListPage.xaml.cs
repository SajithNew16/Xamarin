using PostApp.Data;
using PostApp.Net;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PostApp
{
    public partial class PostListPage : ContentPage
    {
        public ObservableCollection<Post> PostsList { get; }

        DataRetriever _dr;

        public PostListPage()
        {
            BindingContext = this;
            IsBusy = true;

            InitializeComponent();

            Title = "Posts";
            PostsList = new ObservableCollection<Post>();
            PostsListView.ItemsSource = PostsList;

            PostsListView.ItemSelected += PostsListView_ItemSelected;

            _dr = new DataRetriever();

            ViewDidLoad();
        }



        private void PostsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CommentListPage comments = new CommentListPage(e.SelectedItem as Post);
                Navigation.PushAsync(comments);
            }

            // Clear selection
            PostsListView.SelectedItem = null;
        }

        private async void ViewDidLoad()
        {
            await Task.Delay(2000);
            IsBusy = false;
            LoadData();
        }

        private void LoadData()
        {
            PostsList.Clear();

            List<Post> posts = _dr.GetPosts();
            foreach (Post p in posts)
            {
                p.Body = Regex.Replace(p.Body, @"\n|\r", " ");
                PostsList.Add(p);
            }
        }
    }
}
