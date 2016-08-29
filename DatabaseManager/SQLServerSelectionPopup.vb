Imports System.ComponentModel

Friend Class SQLServerSelectionPopup

    Private _sqlServerCredential As SQLServerCredential
    Private _dtAvailableSQLDataSource As DataTable
    Private WithEvents _bgWorker As New ComponentModel.BackgroundWorker

    Friend Sub New(ByRef sqlServerCredential As SQLServerCredential)
        InitializeComponent()
        _sqlServerCredential = sqlServerCredential
    End Sub

    Private Sub SQLServerSelectionPopup_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        btnRefresh.PerformClick()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        _bgWorker.RunWorkerAsync()
    End Sub

    Private Sub _bgWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles _bgWorker.DoWork
        _dtAvailableSQLDataSource = Sql.SqlDataSourceEnumerator.Instance.GetDataSources
    End Sub

    Private Sub _bgWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles _bgWorker.RunWorkerCompleted
        DataGridView1.DataSource = _dtAvailableSQLDataSource
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        _sqlServerCredential.ServerURL = CType(DataGridView1.CurrentRow.DataBoundItem, DataRowView).Row("ServerName").ToString
        _sqlServerCredential.Save()
        DialogResult = Windows.Forms.DialogResult.OK
        Close()
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Close()
    End Sub

End Class