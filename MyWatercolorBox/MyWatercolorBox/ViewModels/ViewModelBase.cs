using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyWatercolorBox.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.OnPropertyChanged(propertyName);

            return true;
        }

        protected virtual T SetProperty<T>(T value, [CallerMemberName] string propertyName = null)
        {
            this.OnPropertyChanged(propertyName);

            return value;
        }


        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //var eventHandler = this.PropertyChanged;
            //if (eventHandler != null)
            //{
            //    eventHandler(this, new PropertyChangedEventArgs(propertyName));
            //}
        }

        //protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        //{
        //    var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
        //    this.OnPropertyChanged(propertyName);
        //}


    }
}
