Public Class frmHaleMRI
    Private m_frmCustomers As New frmCustomers
    Private m_frmVessels As New frmVessels
    Private m_frmManufacturers As New frmManufacturers
    Private m_frmPropellers As New frmPropellers
    Private m_frmJobs As New frmJobs

    Private Sub frmHaleMRI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CustomersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomersToolStripMenuItem.Click
        m_frmCustomers.Show()
    End Sub

    Private Sub JobsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JobsToolStripMenuItem.Click
        m_frmJobs.Show()
    End Sub

    Private Sub VesselsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VesselsToolStripMenuItem.Click
        m_frmVessels.Show()
    End Sub

    Private Sub PropellersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropellersToolStripMenuItem.Click
        m_frmPropellers.Show()
    End Sub

    Private Sub ManufacturersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManufacturersToolStripMenuItem.Click
        m_frmManufacturers.Show()
    End Sub

    Private Sub frmHaleMRI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        m_frmCustomers.Close()
        m_frmVessels.Close()
        m_frmManufacturers.Close()
        m_frmPropellers.Close()
        m_frmJobs.Close()
        m_frmCustomers.Dispose()
        m_frmVessels.Dispose()
        m_frmManufacturers.Dispose()
        m_frmPropellers.Dispose()
        m_frmJobs.Dispose()
    End Sub
End Class
