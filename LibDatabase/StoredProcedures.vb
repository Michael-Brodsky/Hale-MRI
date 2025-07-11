Imports LibDatabase.Models
Imports LibDatabase.Contexts
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.ChangeTracking
Imports System.Linq.Expressions
Imports Microsoft.EntityFrameworkCore.Query.Internal
Imports System.Reflection
Imports System.ComponentModel

Public Module StoredProcedures
#Region "Miscellaneous Functions"
    Public Function FormatString(ByVal str As String) As FormattableString
        'Returns a FormattableString from the given string that can be
        'used in LINQ queries taking string variables as parameters.
        'Plain string variables cannot be used in LINQ queries because
        'they get mangled by the SQL translator and compiler and will
        'not work as expected or throw an exception. Ostensibly, this
        'is to prevent SQL injection attacks, but it also prevents 
        'the use of plain string variables in LINQ queries.
        Return $"{str}"
    End Function
    Public Sub Rollback(ByRef db As HaleMRIContext)
        ' Undoes all changes made to the database context since the last SaveChanges().
        Dim changedEntries = db.ChangeTracker.Entries().Where(Function(e) e.State <> EntityState.Unchanged).ToList()
        RollbackImpl(changedEntries)
    End Sub

    Public Sub Rollback(Of T As Class)(ByRef db As HaleMRIContext)
        ' Undoes all changes made to the specified DbSet since the last SaveChanges().
        ' Example usage: Rollback(Of Customer)(db)
        Dim changedEntries = db.ChangeTracker.Entries(Of T)().Where(Function(e) e.State <> EntityState.Unchanged).ToList()
        RollbackImpl(changedEntries)
    End Sub
    Public Sub Rollback(Of T As Class)(ByRef db As HaleMRIContext, bs As BindingList(Of T))
        ' Undoes all changes made to the specified BindingList since the last SaveChanges().
        ' Example usage: Rollback(db, customerBindingList), where customerBindingList is a BindingList(Of Customer).
        If bs IsNot Nothing AndAlso db IsNot Nothing Then
            Dim changedEntries = db.ChangeTracker.Entries(Of T)().Where(Function(e) e.State <> EntityState.Unchanged).ToList()
            RollbackImpl(changedEntries)
        End If
    End Sub
    Public Sub Rollback(Of T As Class)(ByRef db As HaleMRIContext, bs As IEnumerable(Of T))
        If bs IsNot Nothing AndAlso db IsNot Nothing Then
            Dim changedEntries = db.ChangeTracker.Entries(Of T)().Where(Function(e) e.State <> EntityState.Unchanged).ToList()
            RollbackImpl(changedEntries)
        End If
    End Sub
    Private Sub RollbackImpl(entries As IEnumerable(Of EntityEntry))
        ' This subroutine undoes all changes made to the specified entries.
        ' It is used internally by the Rollback methods.
        If entries IsNot Nothing Then
            For Each entry In entries
                Select Case entry.State
                    Case EntityState.Added
                        entry.State = EntityState.Detached
                    Case EntityState.Modified
                        entry.CurrentValues.SetValues(entry.OriginalValues)
                        entry.State = EntityState.Unchanged
                    Case EntityState.Deleted
                        entry.State = EntityState.Unchanged
                End Select
            Next
        End If
    End Sub
#End Region
    Public Function GetRelatedEntities(Of T As Class)(db As HaleMRIContext, propertyName As String, key As Object) As List(Of T)
        ' Returns a list of entities of type T that match the specified property name and key.
        ' This function is used to retrieve entities from the database context based on a specific property and key.
        Dim qry = db.Set(Of T)().AsQueryable()
        Dim param = Expression.Parameter(GetType(T), "x")
        Dim propExp As MemberExpression = Expression.Property(param, propertyName)
        Dim propExpression As Expression
        If propExp.Type.IsGenericType AndAlso propExp.Type.GetGenericTypeDefinition() Is GetType(Nullable(Of)) Then
            ' Handle nullable entity member types
            Dim filter = Expression.Constant(Convert.ChangeType(key, propExp.Type.GetGenericArguments()(0)))
            Dim typeFilter As Expression = Expression.Convert(filter, propExp.Type)
            propExpression = Expression.Equal(propExp, typeFilter)
        Else
            ' Handle non-nullable entity member types
            propExpression = Expression.Equal(propExp, Expression.Constant(key))
        End If
        Dim exp = Expression.Lambda(Of Func(Of T, Boolean))(propExpression, param)
        Return qry.Where(exp).ToList()
    End Function

#Region "Customer Queries"
    Public Function QryCustomerNameExists(ByVal db As HaleMRIContext, ByVal customerName As FormattableString) As Boolean
        'Returns TRUE if a customer with the specified name exists in the database,
        'else returns FALSE.
        Return db.Customers _
            .Any(Function(c) c.CustomerName = customerName.ToString)
    End Function
    Public Function QryCustomerIdExists(ByVal db As HaleMRIContext, ByVal customerID As Integer) As Boolean
        'Returns TRUE if a customer with the specified ID exists in the database,
        'else returns FALSE.
        Return db.Customers _
            .Any(Function(c) c.Id = customerID.ToString)
    End Function
    Public Function QryCustomersByName(ByRef db As HaleMRIContext, Optional ByVal customerName As FormattableString = Nothing, Optional ByVal includeVessels As Boolean = False) As List(Of Customer)
        ' This query retrieves customers optionally by name and optionally includes their associated vessels.
        Dim qry = From c In db.Customers
                  Select c
        If includeVessels Then qry = qry.Include(Function(c) c.Vessels)
        If customerName IsNot Nothing Then qry = qry.Where(Function(c) c.CustomerName = customerName.ToString)
        Return qry.AsNoTracking.ToList()
    End Function
    Public Function QryCustomersByID(ByRef db As HaleMRIContext, Optional ByVal customerID As Integer = 0, Optional ByVal includeVessels As Boolean = False) As List(Of Customer)
        ' This query retrieves customers optionally by id and optionally includes their associated vessels.
        Dim qry = From c In db.Customers
                  Select c
        If includeVessels Then qry = qry.Include(Function(c) c.Vessels)
        If customerID <> 0 Then qry = qry.Where(Function(c) c.Id = customerID.ToString)
        Return qry.ToList()
    End Function
#End Region
#Region "Vessel Queries"
    Public Function QryVesselNameExists(ByRef db As HaleMRIContext, ByVal vesselName As FormattableString) As Boolean
        ' Returns TRUE if a vessel with the specified name exists in the database,
        ' else returns FALSE.
        Return db.Vessels _
            .Any(Function(v) v.VesselName = vesselName.ToString)
    End Function
    Public Function QryVesselIdExists(ByRef db As HaleMRIContext, ByVal vesselID As Integer) As Boolean
        ' Returns TRUE if a vessel with the specified ID exists in the database,
        ' else returns FALSE.
        Return db.Vessels _
            .Any(Function(v) v.Id = vesselID.ToString)
    End Function
    Public Function QryEmployeeNameExists(ByVal db As HaleMRIContext, ByVal employeeName As FormattableString) As Boolean
        'Returns TRUE if an employee with the specified name exists in the database,
        'else returns FALSE.
        Return db.Employees _
            .Any(Function(c) c.EmployeeName = employeeName.ToString)
    End Function
    Public Function QryManufacturerNameExists(ByRef db As HaleMRIContext, ByVal manufacturerName As FormattableString) As Boolean
        'Returns TRUE if a manufacturer with the specified name exists in the database,
        'else returns FALSE.
        Return db.Manufacturers _
            .Any(Function(m) m.ManufacturerName = manufacturerName.ToString)
    End Function
    Public Function QryVesselsByName(ByRef db As HaleMRIContext, Optional ByVal vesselName As FormattableString = Nothing, Optional ByVal includeJobs As Boolean = False) As List(Of Vessel)
        ' This query retrieves vessels optionally by name and optionally includes their associated jobs.
        Dim qry = From v In db.Vessels
                  Select v
        If includeJobs Then qry = qry.Include(Function(v) v.Jobs)
        If vesselName IsNot Nothing Then qry = qry.Where(Function(v) v.VesselName = vesselName.ToString)
        Return qry.ToList()
    End Function
    Public Function QryVesselsById(ByRef db As HaleMRIContext, Optional ByVal vesselID As Integer = 0, Optional ByVal includeJobs As Boolean = False) As List(Of Vessel)
        ' This query retrieves vessels optionally by id and optionally includes their associated jobs.
        Dim qry = From v In db.Vessels
                  Select v
        If includeJobs Then qry = qry.Include(Function(v) v.Jobs)
        If vesselID <> 0 Then qry = qry.Where(Function(v) v.Id = vesselID.ToString)
        Return qry.ToList()
    End Function
    Public Function QryVesselsByCustomerName(ByRef db As HaleMRIContext, Optional ByVal customerName As FormattableString = Nothing, Optional ByVal includeJobs As Boolean = False) As List(Of Vessel)
        ' This query retrieves vessels optionally by customer name and optionally includes their associated jobs.
        Dim qry = From v In db.Vessels
                  Select v
        If includeJobs Then qry = qry.Include(Function(v) v.Jobs)
        If customerName IsNot Nothing Then qry = qry.Where(Function(v) v.Customer.CustomerName = customerName.ToString)
        Return qry.ToList()
    End Function
    Public Function QryVesselsByCustomerId(ByRef db As HaleMRIContext, Optional ByVal customerID As Integer = 0, Optional ByVal includeJobs As Boolean = False) As List(Of Vessel)
        ' This query retrieves vessels optionally by customer id and optionally includes their associated jobs.
        Dim qry = From v In db.Vessels
                  Select v
        If includeJobs Then qry = qry.Include(Function(v) v.Jobs)
        If customerID <> 0 Then qry = qry.Where(Function(v) v.CustomerId = customerID.ToString)
        Return qry.ToList()
    End Function
#End Region
#Region "Job Queries"
    Public Function QryJobNumberExists(ByRef db As HaleMRIContext, ByVal jobNumber As Integer) As Boolean
        ' Returns TRUE if a job with the specified job number exists in the database,
        ' else returns FALSE.
        Return db.Jobs _
            .Any(Function(j) j.JobNumber = jobNumber.ToString)
    End Function
    Public Function QryJobIdExists(ByRef db As HaleMRIContext, ByVal jobID As Integer) As Boolean
        ' Returns TRUE if a job with the specified ID exists in the database,
        ' else returns FALSE.
        Return db.Jobs _
            .Any(Function(j) j.Id = jobID.ToString)
    End Function
    Public Function QryJobsByVesselId(ByRef db As HaleMRIContext, Optional ByVal vesselID As Integer = 0, Optional ByVal includeJobDetails As Boolean = False) As List(Of Job)
        ' This query retrieves jobs optionally by vessel id and optionally includes their associated job details.
        Dim qry = From j In db.Jobs
                  Select j
        If includeJobDetails Then qry = qry.Include(Function(j) j.JobDetails)
        If vesselID <> 0 Then qry = qry.Where(Function(j) j.VesselId = vesselID.ToString)
        Return qry.ToList()
    End Function
    Public Function QryJobsByVesselName(ByRef db As HaleMRIContext, Optional ByVal vesselName As FormattableString = Nothing, Optional ByVal includeJobDetails As Boolean = False) As List(Of Job)
        ' This query retrieves jobs optionally by vessel name and optionally includes their associated job details.
        Dim qry = From j In db.Jobs
                  Select j
        If includeJobDetails Then qry = qry.Include(Function(j) j.JobDetails)
        If vesselName IsNot Nothing Then qry = qry.Where(Function(j) j.Vessel.VesselName = vesselName.ToString)
        Return qry.AsNoTracking.ToList()
    End Function
    Public Function QryJobsByJobNumber(ByRef db As HaleMRIContext, Optional ByVal jobNumber As Integer = 0, Optional ByVal includeJobDetails As Boolean = False) As List(Of Job)
        ' This query retrieves jobs optionally by job number and optionally includes their associated job details.
        Dim qry = From j In db.Jobs
                  Select j
        If includeJobDetails Then qry = qry.Include(Function(j) j.JobDetails)
        If jobNumber <> 0 Then qry = qry.Where(Function(j) j.JobNumber = jobNumber.ToString)
        Return qry.ToList()
    End Function
    Public Function QryJobsById(ByRef db As HaleMRIContext, Optional ByVal jobID As Integer = 0, Optional ByVal includeJobDetails As Boolean = False) As List(Of Job)
        ' This query retrieves jobs optionally by id and optionally includes their associated job details.
        Dim qry = From j In db.Jobs
                  Select j
        If includeJobDetails Then qry = qry.Include(Function(j) j.JobDetails)
        If jobID <> 0 Then qry = qry.Where(Function(j) j.Id = jobID.ToString)
        Return qry.ToList()
    End Function
    Public Function QryJobsByCustomerName(ByRef db As HaleMRIContext, Optional ByVal customerName As FormattableString = Nothing, Optional ByVal includeJobDetails As Boolean = False) As List(Of Job)
        ' This query retrieves jobs optionally by customer name and optionally includes their associated job details.
        Dim qry = From j In db.Jobs
                  Select j
        If includeJobDetails Then qry = qry.Include(Function(j) j.JobDetails)
        If customerName IsNot Nothing Then qry = qry.Where(Function(j) j.Vessel.Customer.CustomerName = customerName.ToString)
        Return qry.ToList()
    End Function
    Public Function QryJobsByCustomerId(ByRef db As HaleMRIContext, Optional ByVal customerID As Integer = 0, Optional ByVal includeJobDetails As Boolean = False) As List(Of Job)
        ' This query retrieves jobs optionally by customer id and optionally includes their associated job details.
        Dim qry = From j In db.Jobs
                  Select j
        If includeJobDetails Then qry = qry.Include(Function(j) j.JobDetails)
        If customerID <> 0 Then qry = qry.Where(Function(j) j.Vessel.CustomerId = customerID.ToString)
        Return qry.ToList()
    End Function
#End Region
#Region "Job Detail Queries"
    Public Function QryJobDetailsByJobId(ByRef db As HaleMRIContext, Optional ByVal jobId As Integer = 0, Optional ByVal includeMeasurements As Boolean = False) As List(Of JobDetail)
        ' This query retrieves job details optionally by job id number and optionally includes their associated measurements.
        Dim qry = From jd In db.JobDetails
                  Select jd
        If includeMeasurements Then
            qry = qry.Include(Function(jd) jd.CellMeasurements) _
                     .Include(Function(jd) jd.ExtremeMeasurements) _
                     .Include(Function(jd) jd.RadiusMeasurements)
        End If
        If jobId <> 0 Then qry = qry.Where(Function(jd) jd.JobId = jobId.ToString)
        Return qry.ToList()
    End Function
    Public Function QryJobDetailsById(ByRef db As HaleMRIContext, Optional ByVal jobDetailID As Integer = 0, Optional ByVal includeMeasurements As Boolean = False) As List(Of JobDetail)
        ' This query retrieves job details optionally by id and optionally includes their associated measurements.
        Dim qry = From jd In db.JobDetails
                  Select jd
        If includeMeasurements Then
            qry = qry.Include(Function(jd) jd.CellMeasurements) _
                     .Include(Function(jd) jd.ExtremeMeasurements) _
                     .Include(Function(jd) jd.RadiusMeasurements)
        End If
        If jobDetailID <> 0 Then qry = qry.Where(Function(jd) jd.Id = jobDetailID.ToString)
        Return qry.ToList()
    End Function
    Public Function QryJobDetailsByJobNumber(ByRef db As HaleMRIContext, Optional ByVal jobNumber As Integer = 0, Optional ByVal includeMeasurements As Boolean = False) As List(Of JobDetail)
        ' This query retrieves job details optionally by job number and optionally includes their associated measurements.
        Dim qry = From jd In db.JobDetails
                  Select jd
        If includeMeasurements Then
            qry = qry.Include(Function(jd) jd.CellMeasurements) _
                     .Include(Function(jd) jd.ExtremeMeasurements) _
                     .Include(Function(jd) jd.RadiusMeasurements)
        End If
        If jobNumber <> 0 Then qry = qry.Where(Function(jd) jd.Job.JobNumber = jobNumber.ToString)
        Return qry.ToList()
    End Function
#End Region
#Region "Workstation Queries"
    Public Function QryWorkstationCalibration(ByVal db As HaleMRIContext, ByVal hostName As FormattableString) As Workstation
        ' This query retrieves the named workstation (which consists of calibration data).
        Return db.Workstations.FirstOrDefault(Function(ws) ws.Hostname = hostName.ToString)
    End Function
    Public Function QryWorkstations(ByVal db As HaleMRIContext) As List(Of Workstation)
        ' This query retrieves all workstations.
        Return db.Workstations.ToList()
    End Function
#End Region
    Private Sub Test()
        Using db As New HaleMRIContext
            'Dim c As String = "Mr. Dude"
            'Dim ci As Integer = 5
            'Dim v As String = "Boat XXX"
            'Dim vi As Integer = 5
            'Dim jn As Integer = 12345
            Dim ji As Integer = 1
            'Dim ce1 As Boolean = QryCustomerNameExists(db, FormatString(c))
            'Dim ce2 As Boolean = QryCustomerNameExists(db, FormatString("Mr. Dude"))
            'Dim ce3 As Boolean = QryCustomerIdExists(db, ci)
            'Dim ce4 As Boolean = QryCustomerIdExists(db, 5)
            'Dim c1 As List(Of Customer) = QryCustomersByName(db, FormatString(c), True)
            'Dim c2 As List(Of Customer) = QryCustomersByID(db, ci, True)
            'Dim c3 As List(Of Customer) = QryCustomersByName(db, FormatString("Mr. Dude"), True)
            'Dim c4 As List(Of Customer) = QryCustomersByID(db, 5, True)
            'Dim w As Workstation = QryWorkstationCalibration(db, FormatString(My.Computer.Name))
            'Dim v1 As List(Of Vessel) = QryVesselsByName(db, FormatString(v), True)
            'Dim v2 As List(Of Vessel) = QryVesselsById(db, vi, True)
            'Dim v3 As List(Of Vessel) = QryVesselsByName(db, FormatString("Boat 42"), True)
            'Dim v4 As List(Of Vessel) = QryVesselsById(db, 5, True)
            'Dim v5 As List(Of Vessel) = QryVesselsByCustomerName(db, FormatString(c), True)
            'Dim v6 As List(Of Vessel) = QryVesselsByCustomerId(db, ci, True)
            'Dim j1 As List(Of Job) = QryJobsByJobNumber(db, jn, True)
            'Dim j2 As List(Of Job) = QryJobsByJobNumber(db, 12345, True)
            'Dim j3 As List(Of Job) = QryJobsById(db, ji, True)
            'Dim j4 As List(Of Job) = QryJobsById(db, 1, True)
            'Dim j5 As List(Of Job) = QryJobsByVesselId(db, vi, True)
            'Dim j6 As List(Of Job) = QryJobsByVesselName(db, FormatString(v), True)
            'Dim jd1 As List(Of JobDetail) = QryJobDetailsByJobNumber(db, jn, True)
            Dim jd2 As List(Of JobDetail) = QryJobDetailsByJobId(db, ji, True)
            Debug.Print(db.Customers.Count)
        End Using
    End Sub
End Module
