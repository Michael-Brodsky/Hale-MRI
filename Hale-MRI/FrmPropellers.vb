Imports LibDatabase.Contexts
Imports LibDatabase.Models
Public Class FrmPropellers
    Inherits FrmDatabaseForm
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
            Dim index = Database.Propellers.Local.OrderBy(Function(m) m.ManufacturerId).ToList().FindIndex(Function(v) v.Id = id)
            If index <> kNoCurrentRecord Then Navigator.MasterSource.Position = index
            Return index
        End If
    End Function
    Private Sub BindDataSources()
        ' Load the Propellers and related data into the BindingSources.
        PropellerBindingSource.DataSource = Database.Propellers.Local.ToBindingList()
        ManufacturersBindingSource.DataSource = Database.Manufacturers.Local.ToBindingList()
        BladesBindingSource.DataSource = Database.Blades.Local.ToBindingList()
        StylesBindingSource.DataSource = Database.Styles.Local.ToBindingList()
        MaterialsBindingSource.DataSource = Database.Materials.Local.ToBindingList()
        RotationsBindingSource.DataSource = Database.Rotations.Local.ToBindingList()
        ' Configure the RecordNavigator.
        Navigator = RecordNavigationBar1
        Caption = "Propellers"
        DataSource = PropellerBindingSource
        'Navigator.MasterControl = DataGridPropellers
    End Sub
End Class