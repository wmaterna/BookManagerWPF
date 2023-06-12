using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Xml;

namespace BookManager.Core
{
    public class BookManagerPageModel : BaseViewModel
    {
        public ObservableCollection<BookItemViewModel> BooksList { get; set; } = new ObservableCollection<BookItemViewModel>();
        public string NewBookTitle { get; set; }

        public string NewBookAuthor { get; set; }

        public ICommand AddNewBookCommand { get; set; }

        public ICommand RemoveBookCommand { get; set; }



        public BookManagerPageModel()
        {
            AddNewBookCommand = new RelayCommand(AddNewBookToCollection);
            RemoveBookCommand = new RelayCommand(RemoveBookFromCollection);
        }
        private void AddNewBookToCollection()
        {
            var newBook = new BookItemViewModel
            {
                Title = NewBookTitle,
                Author = NewBookAuthor,
            };
            BooksList.Add(newBook);
            NewBookTitle = string.Empty;
            NewBookAuthor = string.Empty;

            OnPropetyChanged(nameof(NewBookAuthor));
            OnPropetyChanged(nameof(NewBookTitle));

        }

        private void RemoveBookFromCollection()
        {
            var selectedBooks = BooksList.Where(x => x.IsSelected).ToList();
            
            foreach(var book in selectedBooks)
            {
                BooksList.Remove(book);
            }
        }

    }
}
