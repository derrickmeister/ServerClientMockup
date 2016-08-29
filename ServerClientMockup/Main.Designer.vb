<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnTestKeyboard = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnTestKeyboard
        '
        Me.btnTestKeyboard.Location = New System.Drawing.Point(207, 12)
        Me.btnTestKeyboard.Name = "btnTestKeyboard"
        Me.btnTestKeyboard.Size = New System.Drawing.Size(259, 54)
        Me.btnTestKeyboard.TabIndex = 5
        Me.btnTestKeyboard.TabStop = False
        Me.btnTestKeyboard.Text = "Test Keyboard"
        Me.btnTestKeyboard.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 536)
        Me.Controls.Add(Me.btnTestKeyboard)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnTestKeyboard As Button
End Class
