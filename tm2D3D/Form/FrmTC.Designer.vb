<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTC
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
        Me.MouseHook1 = New WindowsHookLib.MouseHook()
        Me.docaoreal = New System.Windows.Forms.TextBox()
        Me.donghiengreal = New System.Windows.Forms.TextBox()
        Me.AxTEInformationWindowEx1 = New AxTerraExplorerX.AxTEInformationWindowEx()
        Me.AxTE3DWindowEx1 = New AxTerraExplorerX.AxTE3DWindowEx()
        CType(Me.AxTEInformationWindowEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxTE3DWindowEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'docaoreal
        '
        Me.docaoreal.Location = New System.Drawing.Point(198, 431)
        Me.docaoreal.Name = "docaoreal"
        Me.docaoreal.Size = New System.Drawing.Size(100, 20)
        Me.docaoreal.TabIndex = 3
        Me.docaoreal.Visible = False
        '
        'donghiengreal
        '
        Me.donghiengreal.Location = New System.Drawing.Point(324, 431)
        Me.donghiengreal.Name = "donghiengreal"
        Me.donghiengreal.Size = New System.Drawing.Size(100, 20)
        Me.donghiengreal.TabIndex = 4
        Me.donghiengreal.Visible = False
        '
        'AxTEInformationWindowEx1
        '
        Me.AxTEInformationWindowEx1.Enabled = True
        Me.AxTEInformationWindowEx1.Location = New System.Drawing.Point(545, 120)
        Me.AxTEInformationWindowEx1.Name = "AxTEInformationWindowEx1"
        Me.AxTEInformationWindowEx1.Size = New System.Drawing.Size(192, 192)
        Me.AxTEInformationWindowEx1.TabIndex = 2
        Me.AxTEInformationWindowEx1.Visible = False
        '
        'AxTE3DWindowEx1
        '
        Me.AxTE3DWindowEx1.Enabled = True
        Me.AxTE3DWindowEx1.Location = New System.Drawing.Point(304, 129)
        Me.AxTE3DWindowEx1.Name = "AxTE3DWindowEx1"
        Me.AxTE3DWindowEx1.Size = New System.Drawing.Size(192, 192)
        Me.AxTE3DWindowEx1.TabIndex = 1
        Me.AxTE3DWindowEx1.Visible = False
        '
        'FrmTC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.donghiengreal)
        Me.Controls.Add(Me.docaoreal)
        Me.Controls.Add(Me.AxTEInformationWindowEx1)
        Me.Controls.Add(Me.AxTE3DWindowEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmTC"
        Me.Text = "trinhchieu"
        CType(Me.AxTEInformationWindowEx1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxTE3DWindowEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AxTE3DWindowEx1 As AxTerraExplorerX.AxTE3DWindowEx
    Friend WithEvents AxTEInformationWindowEx1 As AxTerraExplorerX.AxTEInformationWindowEx
    Friend WithEvents MouseHook1 As WindowsHookLib.MouseHook
    Friend WithEvents docaoreal As TextBox
    Friend WithEvents donghiengreal As TextBox
End Class
