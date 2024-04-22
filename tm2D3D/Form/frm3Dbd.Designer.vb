<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm3Dbd
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm3Dbd))
        Me.AxTEInformationWindowEx1 = New AxTerraExplorerX.AxTEInformationWindowEx()
        Me.AxTE3DWindowEx1 = New AxTerraExplorerX.AxTE3DWindowEx()
        Me.MenuClose = New System.Windows.Forms.MenuStrip()
        Me.mnuMax = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMini = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.AxTEInformationWindowEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxTE3DWindowEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuClose.SuspendLayout()
        Me.SuspendLayout()
        '
        'AxTEInformationWindowEx1
        '
        Me.AxTEInformationWindowEx1.Enabled = True
        Me.AxTEInformationWindowEx1.Location = New System.Drawing.Point(624, 33)
        Me.AxTEInformationWindowEx1.Name = "AxTEInformationWindowEx1"
        Me.AxTEInformationWindowEx1.Size = New System.Drawing.Size(192, 192)
        Me.AxTEInformationWindowEx1.TabIndex = 1
        '
        'AxTE3DWindowEx1
        '
        Me.AxTE3DWindowEx1.Enabled = True
        Me.AxTE3DWindowEx1.Location = New System.Drawing.Point(406, 45)
        Me.AxTE3DWindowEx1.Name = "AxTE3DWindowEx1"
        Me.AxTE3DWindowEx1.Size = New System.Drawing.Size(192, 192)
        Me.AxTE3DWindowEx1.TabIndex = 0
        Me.AxTE3DWindowEx1.Visible = False
        '
        'MenuClose
        '
        Me.MenuClose.BackColor = System.Drawing.Color.DarkSlateGray
        Me.MenuClose.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuClose.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MenuClose.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMax, Me.mnuMini})
        Me.MenuClose.Location = New System.Drawing.Point(0, 0)
        Me.MenuClose.Name = "MenuClose"
        Me.MenuClose.Padding = New System.Windows.Forms.Padding(4, 1, 0, 1)
        Me.MenuClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MenuClose.Size = New System.Drawing.Size(62, 30)
        Me.MenuClose.Stretch = False
        Me.MenuClose.TabIndex = 1739
        Me.MenuClose.Text = "MenuStrip1"
        '
        'mnuMax
        '
        Me.mnuMax.AutoSize = False
        Me.mnuMax.Font = New System.Drawing.Font("Webdings", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.mnuMax.ForeColor = System.Drawing.Color.White
        Me.mnuMax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mnuMax.Name = "mnuMax"
        Me.mnuMax.Size = New System.Drawing.Size(28, 28)
        Me.mnuMax.Text = ""
        '
        'mnuMini
        '
        Me.mnuMini.AutoSize = False
        Me.mnuMini.Font = New System.Drawing.Font("Webdings", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.mnuMini.ForeColor = System.Drawing.Color.White
        Me.mnuMini.Name = "mnuMini"
        Me.mnuMini.Size = New System.Drawing.Size(28, 28)
        Me.mnuMini.Text = ""
        '
        'Frm3Dbd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(952, 450)
        Me.Controls.Add(Me.MenuClose)
        Me.Controls.Add(Me.AxTEInformationWindowEx1)
        Me.Controls.Add(Me.AxTE3DWindowEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm3Dbd"
        Me.Text = "2D3DBd"
        CType(Me.AxTEInformationWindowEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxTE3DWindowEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuClose.ResumeLayout(False)
        Me.MenuClose.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AxTE3DWindowEx1 As AxTerraExplorerX.AxTE3DWindowEx
    Friend WithEvents AxTEInformationWindowEx1 As AxTerraExplorerX.AxTEInformationWindowEx
    Friend WithEvents MenuClose As MenuStrip
    Friend WithEvents mnuMax As ToolStripMenuItem
    Friend WithEvents mnuMini As ToolStripMenuItem
End Class
