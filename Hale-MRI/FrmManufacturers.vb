Imports System.ComponentModel
Imports LibDatabase.Contexts
Imports LibDatabase.Models

''' <summary>
''' This form provides a user inteface for editing 
''' Manufacturer records and accessing related 
''' Propeller records.
''' </summary>

Public Class FrmManufacturers
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mFilter As Object = Nothing                 ' The current form filter object, if any.
    Private mFilterOn As Boolean = False                ' Flag indicating whether the current form filter is active.
    Private mMasterSource As BindingSource = Nothing    ' The current "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing ' Derived forms' RecordNavigationBar.
    ' Define all forms this form can open.
    ' Do not create new instances of forms directly;
    ' use the FormInstances.ShowForm/CloseForm methods.
    Private mFrmPropellers As FrmPropellers
#End Region
#Region "Public Interface"
    Public ReadOnly Property Current
        Get
            Return BindingSourceCurrent(mMasterSource)
        End Get
    End Property

    Public Overrides Property Database As HaleMRIContext

    Public Property Filter As Object
        Get
            Return mFilter
        End Get
        Set(value As Object)
            mFilter = value
            If mNavigator IsNot Nothing Then mNavigator.Filter = mFilter
            FilterOn = mFilter IsNot Nothing
        End Set
    End Property

    Public Property FilterOn As Boolean
        Get
            Return mFilterOn
        End Get
        Set(value As Boolean)
            mFilterOn = value
            If mNavigator IsNot Nothing Then mNavigator.FilterOn = mFilterOn
        End Set
    End Property

    Public Function Find(item As Manufacturer) As Manufacturer
        Dim result As Manufacturer = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            MasterSource.Position = pos
            result = MasterSource.Current
        End If
        Return result
    End Function
#End Region
#Region "Private Interface"
    Protected Overrides Sub BindDataSources()
        ' These DataSources use LocalViews, which are loaded on application
        ' startup, and not expected to change.
        StatesBindingSource.DataSource = Database.StateCodes.Local.ToBindingList
        CountryCodesBindingSource.DataSource = Database.CountryCodes.Local.ToBindingList
        ' These DataSources query the database, as they may change while
        ' the application is open.
        ManufacturersBindingSource.DataSource = New BindingList(Of Manufacturer)(Database.Manufacturers.OrderBy(Function(e) e.ManufacturerName).ToList())
        BindMasterDetails(ManufacturersBindingSource, PropellersBindingSource, "Propellers")
        ' Configure the RecordNavigator.
        Navigator = RecordNavigationBar1
        MasterSource = ManufacturersBindingSource
    End Sub

    Private Property MasterSource As BindingSource
        Get
            Return mMasterSource
        End Get
        Set(value As BindingSource)
            mMasterSource = value
            If Navigator IsNot Nothing Then Navigator.MasterSource = mMasterSource
        End Set
    End Property

    Private Property Navigator As RecordNavigationBar
        Get
            Return mNavigator
        End Get
        Set(value As RecordNavigationBar)
            mNavigator = value
            If mNavigator IsNot Nothing Then mNavigator.Database = Database
        End Set
    End Property

#End Region
#Region "Event Handlers"
    Private Sub DataGridPropeller_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridPropellers.CellMouseDoubleClick
        Try
            ShowForm(mFrmPropellers, Database, User)
            mFrmPropellers.Find(PropellersBindingSource.Current.Id)
        Catch ex As Exception
            MessageBox.Show("Error opening vessel details: " & ex.Message, STR_TITLE_APPLICATION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FrmManufacturers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region
End Class