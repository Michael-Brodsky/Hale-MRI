Imports LibDatabase.Contexts
Imports LibDatabase.Models
Public Class FrmManufacturers
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mFrmPropellers As FrmPropellers
#End Region
#Region "Public Interface"
    Public Overrides Property Database As HaleMRIContext
        Get
            Return MyBase.Database
        End Get
        Set(value As HaleMRIContext)
            MyBase.Database = value
            If value IsNot Nothing Then BindDataSources()
        End Set
    End Property
    Public Property Filter As String
        Set(value As String)
            'Navigator.Filter = value
        End Set
        Get
            Return Nothing
        End Get
    End Property
    Public Function Find(id As Integer) As Integer
        If Navigator.MasterSource.SupportsSearching Then
            Return Navigator.MasterSource.Find("Id", id)
        Else
            Dim index = Database.Manufacturers.Local.OrderBy(Function(c) c.ManufacturerName).ToList().FindIndex(Function(v) v.Id = id)
            If index <> kNoCurrentRecord Then Navigator.MasterSource.Position = index
            Return index
        End If
    End Function
#End Region
#Region "Private Interface"
    Private Sub BindDataSources()
        ManufacturersBindingSource.DataSource = Database.Manufacturers.Local.ToBindingList
        PropellersBindingSource.DataSource = Database.Propellers.Local.ToBindingList
        StatesBindingSource.DataSource = Database.StateCodes.Local.ToBindingList
        CountryCodesBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList
        BindMasterDetails(ManufacturersBindingSource, PropellersBindingSource, "Propellers")
        Navigator = RecordNavigationBar1
        Caption = "Manufacturers"
        DataSource = ManufacturersBindingSource
        'Navigator.MasterControl = DataGridManufacturers
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub DataGridPropeller_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridPropellers.CellMouseDoubleClick
        Try
            ShowForm(mFrmPropellers, Database)
            mFrmPropellers.Find(PropellersBindingSource.Current.Id)
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FrmManufacturers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region
End Class