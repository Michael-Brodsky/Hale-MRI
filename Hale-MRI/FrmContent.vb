Public Class FrmContent
    Inherits FrmDatabaseForm

    Protected mContent As ToolStripContentPanel

    Public Overridable ReadOnly Property Content As ToolStripContentPanel
        Get
            Return mContent
        End Get
    End Property
End Class