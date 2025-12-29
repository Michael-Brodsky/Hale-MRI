Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Hale_MRI.EncoderStatusStrip
Imports Hale_MRI.RecordNavigationBar
Imports LibDatabase.Contexts
Imports LibDatabase.Models
Imports LibDatabase.StoredProcedures
Imports LibEncoder
'Imports LibEncoder.IEncoderHardware
Imports Microsoft.EntityFrameworkCore
Public Class FrmComparison
    Inherits FrmDatabaseForm
#Region "Private Members"
    Private mJobDetails As JobDetail                            ' The current JobDetail record
    Private mJob As Job                                         ' The Job the current JobDetail record belongs to.
    Private mMasterSource As BindingSource = Nothing            ' The form's "master" BindingSource.
    Private mNavigator As RecordNavigationBar = Nothing         ' The form's RecordNavigationBar.
#End Region
#Region "Public Interface"
    ''' <summary>
    ''' Returns the currently selected JobDetail,
    ''' or Nothing if there is no selected record.
    ''' </summary>
    Public ReadOnly Property Current As JobDetail
        Get
            'Return BindingSourceCurrent(JobDetailsBindingSource)
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the current database context used 
    ''' to access data. Overrides MyBase.Database.
    ''' </summary>
    Public Overrides Property Database As HaleMRIContext

    ''' <summary>
    ''' Finds the given JobDetail and, if found, makes it the current record.
    ''' </summary>
    ''' <param name="item">The JobDetail to find.</param>
    ''' <returns>The found JobDetail, or Nothing if not found.</returns>
    Public Function Find(item As JobDetail) As JobDetail
        Dim result As JobDetail = Nothing
        Dim pos As Integer = BindingSourceFind(MasterSource, item)
        If pos <> kNoCurrentRecord Then
            MasterSource.Position = pos
            result = Current
        End If
        Return result
    End Function
    Public Property JobDetails As JobDetail
        Get
            Return mJobDetails
        End Get
        Set(value As JobDetail)
            mJobDetails = value
            mJob = mJobDetails?.Job
            If mJobDetails IsNot Nothing Then
                'JobDetailsBindingSource.DataSource = GetMeasurementData(mJobDetails)
            End If
        End Set
    End Property
    Public Property Job As Job
        Get
            Return mJob
        End Get
        Set(value As Job)
            mJob = value
            If mJob IsNot Nothing Then
                'JobDetailsBindingSource.DataSource = GetMeasurementData(mJob)
            End If
        End Set
    End Property
#End Region
#Region "Private Interface"
    Private Sub OrientCharts(chartnum As Integer)
        Dim x As Integer
        For x = 0 To chartnum - 1
            ChartComparison.ChartAreas.ElementAt(x).Position.Auto = False
            ChartComparison.ChartAreas.ElementAt(x).Position.Height = 100 / chartnum
            ChartComparison.ChartAreas.ElementAt(x).Position.Width = 100
            ChartComparison.ChartAreas.ElementAt(x).AxisX.Minimum = -5
            ChartComparison.ChartAreas.ElementAt(x).AxisX.Maximum = 105
            ChartComparison.ChartAreas.ElementAt(x).AxisY.Minimum = 1 ' need to add control for managing y Axis Scaling
            ChartComparison.ChartAreas.ElementAt(x).AxisY.Maximum = 10
            ChartComparison.ChartAreas.ElementAt(x).Position.Y = x * (100 / chartnum)

        Next
        ChartComparison.Height = chartnum * 250
    End Sub
    Private Sub CreateChartAreas(radorBlade As Boolean)
        'radorBlade true = all radii False = one rad on all blades
        If radorBlade Then
            For Each RM As RadiusMeasurement In mJobDetails?.RadiusMeasurements.Where(Function(r) r.BladeId = ComboRadiusorBlade.SelectedItem)
                ChartComparison.ChartAreas.Add("Rad" + Math.Round(RM.Radius.Value).ToString())
                ChartComparison.ChartAreas("Rad" + Math.Round(RM.Radius.Value).ToString()).AxisY.Title = "Bld " + ComboRadiusorBlade.SelectedItem.ToString() + "Radius " + RM.Radius.Value.ToString()
            Next
        Else
            Dim x As Integer
            For x = 1 To Job.PropellerBlades
                ChartComparison.ChartAreas.Add("Blade" + x.ToString())
                ChartComparison.ChartAreas("Blade" + x.ToString()).AxisY.Title = "Bld " + x.ToString() + " " + ComboRadiusorBlade.SelectedItem.ToString()
            Next
        End If
    End Sub
    Private Sub ShowCompChart()
        ChartComparison.Series.Clear()
        ChartComparison.ChartAreas.Clear()
        Dim x As Integer
        'ChartComparison.ChartAreas.
        ' going to have to handle all modifications and plotting of charts here fully programmatically
    End Sub
#End Region
#Region "Event Handlers"

#End Region
End Class