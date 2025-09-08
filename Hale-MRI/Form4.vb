Imports System.ComponentModel
Imports LibDatabase.Models
Imports Microsoft.EntityFrameworkCore
Imports LibDatabase.ModelExtensions
Public Class Form4
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mJob As Job
    Private mJobDetail As JobDetail
#End Region
#Region "Public Interface"
    Public Property Hardware As WorkstationEncoders

    Public Property Job As Job
        Get
            Return mJob
        End Get
        Set(value As Job)
            mJob = value
            If mJob IsNot Nothing Then
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail)(Database.JobDetails _
                .Where(Function(id) id.JobId = mJob.Id) _
                .Include(Function(cm) cm.CellMeasurements) _
                .Include(Function(em) em.ExtremeMeasurements) _
                .Include(Function(rm) rm.RadiusMeasurements) _
                .OrderBy(Function(sd) sd.StartDate).ToList())
                BindMeasurements()
            Else
                JobsBindingSource.DataSource = Nothing
                JobDetailsBindingSource.DataSource = Nothing
            End If
            ShowJobInfo()
        End Set
    End Property

    Public Property JobDetail As JobDetail
        Get
            Return mJobDetail
        End Get
        Set(value As JobDetail)
            mJobDetail = value
            If mJobDetail IsNot Nothing Then
                Database.Entry(mJobDetail).Collection(Function(cm) cm.CellMeasurements).Load()
                Database.Entry(mJobDetail).Collection(Function(em) em.ExtremeMeasurements).Load()
                Database.Entry(mJobDetail).Collection(Function(rm) rm.RadiusMeasurements).Load()
                JobDetailsBindingSource.DataSource = New BindingList(Of JobDetail) From {mJobDetail}.ToList()
                BindMeasurements()
            Else
                JobsBindingSource.DataSource = Nothing
                JobDetailsBindingSource.DataSource = Nothing
            End If
            mJob = mJobDetail?.Job
            ShowJobInfo()
        End Set
    End Property
#End Region
#Region "Private Interface"
    Private Sub BindMeasurements()
        BindMasterDetails(JobDetailsBindingSource, CellMeasurementsBindingSource, "CellMeasurements")
        BindMasterDetails(JobDetailsBindingSource, ExtremeMeasurementsBindingSource, "ExtremeMeasurements")
        BindMasterDetails(JobDetailsBindingSource, RadiusMeasurementBindingSource, "RadiusMeasurements")
    End Sub

    Private Sub ShowJobInfo()
        If mJob IsNot Nothing Then
            JobsBindingSource.DataSource = New BindingList(Of Job) From {mJob}.ToList()
            Dim validBlades As New BindingList(Of Integer)
            For i As Short = 1 To If(CType(BindingSourceCurrent(JobsBindingSource), Job)?.PropellerBlades, 0)
                validBlades.Add(i)
            Next
            ComboSelectedBlade.DataSource = validBlades
        End If
        ComboSelectedBlade.SelectedItem = Nothing
    End Sub
#End Region
#Region "Event Handlers"
    Private Sub JobDetailsBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles JobDetailsBindingSource.CurrentChanged
        mJobDetail = BindingSourceCurrent(JobDetailsBindingSource)
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Const kMeasurementStrings As String = "Angle,Depth,Radius"
        Dim measurementNames As String() = kMeasurementStrings.Split(","c)
        ComboMeasurementType.DataSource = New BindingList(Of String)(measurementNames)
        ComboMeasurementType.SelectedItem = Nothing
    End Sub
#End Region
End Class