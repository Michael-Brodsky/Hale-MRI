Imports LibDatabase.Models
Imports LibDatabase.Contexts
Imports Microsoft.EntityFrameworkCore
Public Module StoredProcedures
    Public Function QryCustomerVessels(ByVal db As HaleMRIContext, Optional ByVal customerID As Integer = 0) As List(Of Customer)
        ' This query retrieves customers and includes their associated vessels.
        If customerID > 0 Then
            ' If a specific customer ID is provided, filter by that ID.
            Return db.Customers.Include(Function(c) c.Vessels).Where(Function(c) c.Id = customerID).ToList()
        Else
            ' If no specific customer ID is provided, retrieve all customers with their vessels.
            Return db.Customers.Include(Function(c) c.Vessels).ToList()
        End If
    End Function
    Public Function QryVesselJobs(ByVal db As HaleMRIContext, Optional ByVal vesselID As Integer = 0) As List(Of Vessel)
        ' This query retrieves vessels and includes their associated jobs.
        If vesselID > 0 Then
            ' If a specific vessel ID is provided, filter by that ID.
            Return db.Vessels.Include(Function(v) v.Jobs).Where(Function(v) v.Id = vesselID).ToList()
        Else
            ' If no specific vessel ID is provided, retrieve all vessels with their jobs.
            Return db.Vessels.Include(Function(v) v.Jobs).ToList()
        End If
    End Function
    Public Function QryJobJobDetails(ByVal db As HaleMRIContext, Optional ByVal jobID As Integer = 0) As List(Of Job)
        ' This query retrieves jobs and includes their associated job details.
        If jobID > 0 Then
            ' If a specific job ID is provided, filter by that ID.
            Return db.Jobs.Include(Function(j) j.JobDetails).Where(Function(j) j.Id = jobID).ToList()
        Else
            Return db.Jobs.Include(Function(j) j.JobDetails).ToList()
        End If
    End Function
    Public Function QryJobDetailMeasurements(ByVal db As HaleMRIContext, Optional ByVal jobdetailID As Integer = 0) As List(Of JobDetail)
        ' This query retrieves job details and includes their associated measurements.
        If jobdetailID > 0 Then
            ' If a specific job detail ID is provided, filter by that ID.
            Return db.JobDetails.Where(Function(jd) jd.Id = jobdetailID) _
                .Include(Function(jd) jd.CellMeasurements) _
                .Include(Function(jd) jd.RadiusMeasurements) _
                .Include(Function(jd) jd.ExtremeMeasurements).ToList()
        Else
            ' If no specific job detail ID is provided, retrieve all job details with their measurements.
            Return db.JobDetails _
                .Include(Function(jd) jd.CellMeasurements) _
                .Include(Function(jd) jd.RadiusMeasurements) _
                .Include(Function(jd) jd.ExtremeMeasurements).ToList()
        End If
    End Function
    Public Function QryWorkstationCalibration(ByVal db As HaleMRIContext, ByVal hostName As String) As Workstation
        ' This query retrieves the named workstation's calibration data.
        Return QryWorkstations(db).Find(Function(ws) ws.Hostname = hostName)
    End Function
    Public Function QryWorkstations(ByVal db As HaleMRIContext) As List(Of Workstation)
        ' This query retrieves all workstations.
        Return db.Workstations.ToList()
    End Function
End Module
