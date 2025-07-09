Imports LibDatabase.Contexts
Imports LibDatabase.Models

Public Class FrmManufacturers
    Inherits FrmDatabaseForm
    Public Property CurrentManufacturer As Manufacturer
        ' Gets/sets the form's current Manufacturer record.
        Set(value As Manufacturer)
            If value IsNot Nothing Then CurrentId = value.Id
        End Set
        Get
            If ManufacturersBindingSource.Current IsNot Nothing Then
                Return CType(ManufacturersBindingSource.Current, Manufacturer)
            Else
                Return Nothing
            End If
        End Get
    End Property
    Public Property CurrentId As Integer
        ' Gets/sets the form's current ManufacturerId.
        Set(value As Integer)
            If ManufacturersBindingSource.SupportsSearching Then
                ManufacturersBindingSource.Find("Id", value)
            Else
                Dim index = Database.Manufacturers.Local.ToList().FindIndex(Function(v) v.Id = value)
                If index <> kNoCurrentRecord Then ManufacturersBindingSource.Position = index
            End If
        End Set
        Get
            If ManufacturersBindingSource.Current IsNot Nothing Then
                Return ManufacturersBindingSource.Current.Id
            Else
                Return kNoCurrentRecord
            End If
        End Get
    End Property
    Public Overrides Property Database As HaleMRIContext
        Get
            Return MyBase.Database
        End Get
        Set(value As HaleMRIContext)
            MyBase.Database = value
            If value IsNot Nothing Then BindDataSources()
        End Set
    End Property
    Private Sub BindDataSources()
        ManufacturersBindingSource.DataSource = Database.Manufacturers.Local.ToBindingList
        StatesBindingSource.DataSource = Database.StateCodes.Local.ToBindingList
        CountryCodesBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList
    End Sub
End Class