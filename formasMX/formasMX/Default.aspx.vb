Imports System.Net.Mail


Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'No se hace nada
        End If
    End Sub

    Protected Sub enviar_Click(sender As Object, e As EventArgs) Handles enviar.Click
        Try
            'Se envia el correo electronico
            enviaCorreo()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub limpiaControles()
        Try
            'msg.Text = String.Empty
            name.Text = String.Empty
            'subject.Text = String.Empty
            email.Text = String.Empty
        Catch ex As Exception

        End Try
    End Sub

    Private Sub enviaCorreo()
        Try

            If validaCampos() Then
                Dim msgMail = New MailMessage()
                Dim myMessage = New MailMessage()
                Dim mySmtpClient = New SmtpClient()

                Dim destinatarios() As String = ConfigurationManager.AppSettings.Item("destinatarios").Split(",")

                

                'Dim myCredential = New System.Net.NetworkCredential("infopos@merza.com", "gP&M3RzA2018.")
                Dim myCredential = New System.Net.NetworkCredential(ConfigurationManager.AppSettings.Item("user"), ConfigurationManager.AppSettings.Item("pass"))
                myMessage.From = New MailAddress(ConfigurationManager.AppSettings.Item("user"), "Formas MX")
                ' myMessage.To.Add("lnavarro@merza.com")

                For Each correo In destinatarios 'Se agrega el destinatario administrador de los pedidos
                    If correo.Trim <> "" Then myMessage.To.Add(correo.Trim)
                Next

                myMessage.Subject = "¡Ústed tiene un nuevo mensaje recibido desde el sitio Formas MX"
                myMessage.IsBodyHtml = True
                'Dim mensajeCorreo As String = "<div align=""center""><img src=""http://www.formas.mx/img/formas_2.jpg"" width=""640"" height=""315""  /><p><h1>¡Nuevo mensaje recibido!</h1></p>" _
                '                           & "<p>Recibido el día: " & Now.Date.ToString("dd/MM/yyyy") & "</p>" _
                '                           & "<p>&nbsp;</p>" _
                '                           & "<p>Hola, <strong>" & name.Text & "</strong> envío un mensaje:<br />" _
                '                           & "<p><strong>" & msg.Text & "</strong></p>" _
                '                           & "<p><strong>Email:</strong></p>" _
                '                           & "<p>" & email.Text & "</p><br />" _
                '                           & "<br />" _
                '                           & "<strong>Saludos,</strong><br />" _
                '                           & "<strong>Equipo Formas MX.</strong><br /></div>"

                Dim mensajeCorreo As String = "<div align=""center""><img src=""http://www.formas.mx/img/formas_2.jpg"" width=""640"" height=""315""  /><p><h1>¡Nuevo mensaje recibido!</h1></p>" _
                                           & "<p>Recibido el día: " & Now.Date.ToString("dd/MM/yyyy") & "</p>" _
                                           & "<p>&nbsp;</p>" _
                                           & "<p>Hola, <strong>" & name.Text & "</strong> envío un mensaje:<br />" _
                                           & "<p><strong>Email:</strong></p>" _
                                           & "<p>" & email.Text & "</p><br />" _
                                           & "<br />" _
                                           & "<strong>Saludos,</strong><br />" _
                                           & "<strong>Equipo Formas MX.</strong><br /></div>"

                myMessage.Body = mensajeCorreo
                'mySmtpClient.Host = "smtp.gmail.com"
                mySmtpClient.Host = ConfigurationManager.AppSettings.Item("host")
                mySmtpClient.EnableSsl = ConfigurationManager.AppSettings.Item("ssl")
                'mySmtpClient.Port = 587

                mySmtpClient.Port = ConfigurationManager.AppSettings.Item("puerto")
                mySmtpClient.UseDefaultCredentials = False
                mySmtpClient.Credentials = myCredential
                mySmtpClient.ServicePoint.MaxIdleTime = 1

                mySmtpClient.Send(myMessage)
                myMessage.Dispose()

                If Request.Browser.IsMobileDevice Then
                    procesoStatusContainer.Visible = True
                    imgEnviado.Visible = True
                Else
                    procesoStatusContainer.Visible = True
                    procesoStatusContainer.CssClass = "alert-success"
                    procesoStatus.Visible = True
                    procesoStatus.Text = "¡Mensaje enviado con exito!"
                End If

                limpiaControles()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            procesoStatusContainer.Visible = True
            procesoStatus.Visible = True
            procesoStatus.Text = ex.Message
        End Try
    End Sub

    Private Function validaCampos() As Boolean
        Try
            validaCampos = False
            'If name.Text = String.Empty OrElse subject.Text = String.Empty OrElse email.Text = String.Empty Or msg.Text = String.Empty Then
            'If name.Text = String.Empty OrElse email.Text = String.Empty Or msg.Text = String.Empty Then
            If name.Text = String.Empty OrElse email.Text = String.Empty Then
                validaCampos = False
            End If
            validaCampos = True
        Catch ex As Exception
            validaCampos = False
        End Try
    End Function


End Class