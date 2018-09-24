using PostApp.Data;
using PostApp.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentListPage : ContentPage
    {
        public ObservableCollection<Comment> CommentsList { get; }

        DataRetriever _dr;

        public CommentListPage()
        {

            BindingContext = this;
            IsBusy = true;

            InitializeComponent();

            Title = "Comments";
            CommentsList = new ObservableCollection<Comment>();
            CommentsListView.ItemsSource = CommentsList;

            CommentsListView.ItemSelected += CommentsListView_ItemSelected;

            _dr = new DataRetriever();
            ViewDidLoad();

        }

        private void CommentsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                string address = GetCommentorMail(e.SelectedItem as Comment);
                Device.OpenUri(new Uri($"mailto:{address}"));
            }

            // Clear selection
            CommentsListView.SelectedItem = null;
        }

        private string GetCommentorMail(Comment comment)
        {
            return comment.Email;
        }

        private async void ViewDidLoad()
        {
            await Task.Delay(2000);
            IsBusy = false;
        }

        public CommentListPage(Post post) : this()
        {
            AddToolbarItem(post);

            List<Comment> comments = _dr.GetComments(post.Id);

            foreach (Comment c in comments)
            {
                CommentsList.Add(c);
            }
        }

        private void AddToolbarItem(Post post)
        {
            ToolbarItem toolbarItem = new ToolbarItem("User", "user.png", () =>
            {
                UserProfilePage userProfile = new UserProfilePage(post.UserId);
                Navigation.PushAsync(userProfile);
            }, 0, 0);
            ToolbarItems.Add(toolbarItem);
        }
    }
}