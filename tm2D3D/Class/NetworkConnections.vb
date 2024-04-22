Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Web.Script.Serialization

Public Class NetworkMessage
#Disable Warning IDE0140 ' Simplify object initialization
#Disable Warning IDE0017 ' Simplify object initialization
    Public Property ClientIP() As String
        Get
            Return m_ClientIP
        End Get
        Set(value As String)
            m_ClientIP = value
        End Set
    End Property
    Private m_ClientIP As String
    Public Property Command() As String
        Get
            Return m_Command
        End Get
        Set(value As String)
            m_Command = value
        End Set
    End Property
    Private m_Command As String
    Public Property Parameters() As List(Of String)
        Get
            Return m_Parameters
        End Get
        Set(value As List(Of String))
            m_Parameters = value
        End Set
    End Property
    Private m_Parameters As List(Of String)
End Class

Public Class NetworkCommunication
    Public IsServer As Boolean = False
    Private isStopServer As Boolean = False
    Public Event IncomedMessage As EventHandler
    Public Event ConnectedClient As EventHandler
#Disable Warning IDE0044 ' Simplify object initialization
    Private ConnectRequestString As String = "RequestConnectToServer"
    Private server As TcpListener = Nothing
    Private Clients As New List(Of String)
#Enable Warning IDE0044 ' Simplify object initialization


    Public Property NetworkPort() As Integer
        Get
            Return m_NetworkPort
        End Get
        Set(value As Integer)
            m_NetworkPort = value
        End Set
    End Property
    Private m_NetworkPort As Integer
    Private m_limitClient As Integer = 12

    Public Property LimitClient() As Integer
        Get
            Return Me.m_limitClient
        End Get
        Set(value As Integer)
            Me.m_limitClient = value
        End Set
    End Property

    Public Property ServerIP() As String
        Get
            Return m_ServerIP
        End Get
        Set(value As String)
            m_ServerIP = value
        End Set
    End Property

    Private m_ServerIP As String

    Public Sub New(port As Integer)
        Me.NetworkPort = port
        server = New TcpListener(IPAddress.Parse(GetCurrentIP()), Me.NetworkPort)
        Me.Clients = New List(Of String)()
    End Sub

    Public Sub StartServer()
        Me.server.Start()
        Me.isStopServer = False
        Me.Clients.Add(Me.GetCurrentIP())
        For i As Integer = 0 To Me.LimitClient - 1
            Dim th As New Thread(AddressOf ServiceServer)
            th.Start()
        Next
    End Sub

    Public Sub StopServer()
        Try
            Me.server.Stop()
            Me.Clients.Clear()
            Me.isStopServer = True
        Catch ex As Exception
            ' LogError(ex.Message)
        End Try

    End Sub

    Public Sub SendMessage(mess As NetworkMessage)
        SendMessage(mess, Me.ServerIP)
    End Sub

    Public Sub SendMessage(netMessage As NetworkMessage, ipAddress__1 As String)
        SendMessage(netMessage, IPAddress.Parse(ipAddress__1))
    End Sub

    Public Sub SendMessage(netMessage As NetworkMessage, ipAddress As IPAddress)
        Dim client As New TcpClient()
        Dim array As Byte() = Encoding.ASCII.GetBytes(Serialize(netMessage))
        Try
            client.Connect(ipAddress, Me.NetworkPort)
            client.Client.Send(array)
        Catch ex As Exception

        End Try
        client.Close()
    End Sub

    Public Sub RequestConnect(ipAddress As String)
        Me.ServerIP = ipAddress
        Dim netMess As NetworkMessage = New NetworkMessage()
        netMess.ClientIP = Me.GetCurrentIP()
        netMess.Command = Me.ConnectRequestString
        SendMessage(netMess, ipAddress)
    End Sub

    Private Sub ServiceServer()
        While Not Me.isStopServer
            Dim serverSoc As Socket = Me.server.AcceptSocket()
            Try
                Dim stream As New NetworkStream(serverSoc)
                'Dim bytes As Byte() = New Byte(255) {}
                'Dim i As Integer
                'Dim data As String = String.Empty
                'data = System.Text.Encoding.ASCII.GetString(bytes, 0, i)
                Dim myCompleteMessage As StringBuilder = New StringBuilder()
                If stream.CanRead Then
                    Dim myReadBuffer(serverSoc.ReceiveBufferSize) As Byte

                    Dim numberOfBytesRead As Integer = 0
                    ' Incoming message may be larger than the buffer size. 
                    Do
                        numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length)
                        myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead))
                    Loop While stream.DataAvailable
                End If
                stream.Close()
                Dim message As NetworkMessage = Deserialize(myCompleteMessage.ToString())

                If Not Me.Clients.Contains(message.ClientIP) Then
                    Me.Clients.Add(message.ClientIP)
                End If
                If Not (message.Command = Me.ConnectRequestString) Then
                    If message.ClientIP <> Me.GetCurrentIP() Then
                        RaiseEvent IncomedMessage(message, Nothing)
                    End If
                    If (Me.IsServer) Then
                        SendMessageToAnotherClient(message)
                    End If
                Else
                    RaiseEvent ConnectedClient(message, Nothing)
                End If
            Catch ex As Exception
                ' LogError(ex.ToString())
            End Try
        End While
    End Sub

    Private Sub SendMessageToAnotherClient(mess As NetworkMessage)
        For i As Integer = 0 To Me.Clients.Count - 1
            If Me.Clients(i) <> mess.ClientIP AndAlso Me.Clients(i) <> GetCurrentIP() Then
                Try
                    SendMessage(mess, Me.Clients(i))
                Catch ex As Exception
                    '  LogError(ex.Message)
                    'LogError(mess.Parameters(0))
                End Try
            End If
        Next
    End Sub

    'Private Sub LogError()
    '    '   MsgBox("LAN không ổn định")
    '    '  MsgBox(message)
    'End Sub

    Private Function Deserialize(data As String) As NetworkMessage
        Dim ser As New JavaScriptSerializer()
        Dim reader As New StringReader(data)
        Return ser.Deserialize(Of NetworkMessage)(data)
    End Function

    Private Function Serialize(net As NetworkMessage) As String
        Dim ser As New JavaScriptSerializer()
        'Dim ser As New XmlSerializer(GetType(NetworkMessage))
        Dim sb As New StringBuilder()
        ser.Serialize(net, sb)
        Dim result As String = sb.ToString()
        Return result
    End Function

    Public Function GetCurrentIP() As String
        Dim host As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim localIP As String = String.Empty
        For Each ip As IPAddress In host.AddressList
            If ip.AddressFamily.ToString() = "InterNetwork" Then
                localIP = ip.ToString()
            End If
        Next
        Return localIP
    End Function

    'Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
    '    target = value
    '    Return value
    'End Function
#Enable Warning IDE0140 ' Simplify object initialization
#Enable Warning IDE0017 ' Simplify object initialization
End Class
