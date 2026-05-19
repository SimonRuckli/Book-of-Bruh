namespace BookOfBruh.Core.GameData
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Custom event args for property changes in Core project (UI-agnostic)
    /// </summary>
    public class PropertyChangedEventArgs : EventArgs
    {
        public PropertyChangedEventArgs(string? propertyName)
        {
            PropertyName = propertyName;
        }

        public string? PropertyName { get; }
    }

    /// <summary>
    /// Base class for entities that notify about property changes without UI framework dependencies
    /// </summary>
    public class NotifyPropertyChangedBase
    {
        public event EventHandler<PropertyChangedEventArgs>? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}