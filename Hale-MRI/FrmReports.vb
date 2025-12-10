Imports System.ComponentModel
Imports LibDatabase.Contexts
Imports LibDatabase.Models

''' <summary>
''' This form provides a user interface for viewing Job
''' related reports.
''' </summary>
Public Class FrmReports
    Inherits FrmDatabaseForm

    Private mJobDetails As JobDetail                            ' The current JobDetail record
    Private mJob As Job                                         ' The Job the current JobDetail record belongs to.
    Private mMasterSource As BindingSource = Nothing            ' The form's "master" BindingSource.

    ''' <summary>
    ''' Returns the currently selected JobDetail,
    ''' or Nothing if there is no selected record.
    ''' </summary>
    Public ReadOnly Property Current As JobDetail
        Get
            Return BindingSourceCurrent(JobDetailsBindingSource)
        End Get
    End Property

    Public Overrides Property Database As HaleMRIContext
    ''' <summary>
    ''' Loads all JobDetails and their Cell, Extreme and RadiusMeasurements
    ''' for the given Job.
    ''' </summary>
    ''' <returns></returns>
    Public Property Job As Job
        Get
            Return mJob
        End Get
        Set(value As Job)
            mJob = value
            If mJob IsNot Nothing Then
                JobDetailsBindingSource.DataSource = GetMeasurementData(Current)
                ShowJobInfo(mJob)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Loads only the given JobDetail and its Cell, Extreme and RadiusMeasurements.
    ''' </summary>
    ''' <returns></returns>
    Public Property JobDetails As JobDetail
        Get
            Return mJobDetails
        End Get
        Set(value As JobDetail)
            mJobDetails = value
            mJob = mJobDetails?.Job
            If mJobDetails IsNot Nothing Then
                JobDetailsBindingSource.DataSource = GetMeasurementData(mJobDetails)
                ShowJobInfo(mJob)
            End If
        End Set
    End Property

    Protected Overrides Property MasterSource As BindingSource

    Private Function GetMeasurementData(ByVal jd As JobDetail) As BindingList(Of JobDetail)
        Dim data As BindingList(Of JobDetail) = Nothing

        Return data
    End Function

    Private Sub ShowJobInfo(ByVal j As Job)
        TxtJobNumber.Text = Job?.JobNumber.ToString()
        TxtStartDate.Text = If(JobDetails?.StartDate, "")?.ToString()
        TxtMeasurement.Text = If(JobDetails?.MeasurementType, "")?.ToString()
        TxtClass.Text = If(JobDetails?.ToleranceClass, "")?.ToString()
        TxtEmployee.Text = Database.Employees.Local.FirstOrDefault(Function(emp) emp.Id = JobDetails?.PerformedBy)?.EmployeeName
        TxtDescription.Text = If(JobDetails?.Description, "")?.ToString()
        TxtCustomer.Text = Job?.Vessel?.Customer?.CustomerName
        TxtVessel.Text = Job?.Vessel?.VesselName
        TxtManufacturer.Text = Database.Manufacturers.Local.FirstOrDefault(Function(mfr) mfr.Id = Job?.PropellerManufacturerId)?.ManufacturerName
        TxtStyle.Text = If(Job?.PropellerStyle, "")?.ToString()
        TxtMaterial.Text = If(Job?.PropellerMaterial, "")?.ToString()
        TxtRotation.Text = If(Job?.PropellerRotation, "")?.ToString()
        TxtBlades.Text = If(Job?.PropellerBlades, "")?.ToString()
        TxtDiameter.Text = If(Job?.PropellerDiameter, "").ToString()
        TxtBore.Text = If(Job?.PropellerBore, "").ToString()
    End Sub
End Class