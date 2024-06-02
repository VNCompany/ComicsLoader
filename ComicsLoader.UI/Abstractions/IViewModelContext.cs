﻿namespace ComicsLoader.UI.Abstractions;

public interface IViewModelContext : IDisposable
{
    bool? ShowDialog();
    void Show();
    void Hide();
    void Close();
}