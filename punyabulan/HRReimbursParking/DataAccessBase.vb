Imports System
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Security.Cryptography
Public Class DataAccessBase
    Dim _connectionString As String = ""

#Region " Public Properties "

    ''' <summary>
    ''' Gets or sets the string used to open a SQL Server database.
    ''' </summary>
    ''' <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
    Public Property ConnectionString() As String
        Get
            Return _connectionString
        End Get
        Set(ByVal value As String)
            _connectionString = value
        End Set
    End Property

#End Region
#Region "Assign Parameters"

    Private Sub AssignParameters(ByVal cmd As SqlCommand, ByVal parameterValues() As Object)
        If Not (cmd.Parameters.Count - 1 = parameterValues.Length) Then Throw New ApplicationException("Stored procedure's parameters and parameter values does not match.")
        Dim i As Integer
        For Each param As SqlParameter In cmd.Parameters
            If Not (param.Direction = ParameterDirection.Output) AndAlso Not (param.Direction = ParameterDirection.ReturnValue) Then
                param.Value = parameterValues(i)
                i += 1
            End If
        Next

    End Sub

    Private Sub AssignParameters(ByVal cmd As SqlCommand, ByVal cmdParameters() As SqlParameter)
        If (cmdParameters Is Nothing) Then Exit Sub
        For Each p As SqlParameter In cmdParameters
            cmd.Parameters.Add(p)
        Next
    End Sub

#End Region
#Region " FillDataset "
    ''' <summary>
    ''' Adds or refreshes rows in the System.Data.DataSet to match those in the data source using the System.Data.DataSet name, and creates a System.Data.DataTable named "Table."
    ''' </summary>
    ''' <param name="cmd">The Transact-SQL statement or stored procedure to execute at the data source.</param>
    ''' <param name="cmdType">A value indicating how the System.Data.SqlClient.SqlCommand.CommandText property is to be interpreted.</param>
    ''' <param name="parameters">The parameters of the Transact-SQL statement or stored procedure.</param>
    ''' <returns>A System.Data.Dataset object.</returns>
    Public Function FillDataset(ByVal conn As String, ByVal cmd As String, ByVal cmdType As CommandType, Optional ByVal parameters() As SqlParameter = Nothing) As DataTable
        Dim connection As SqlConnection = Nothing
        Dim command As SqlCommand = Nothing
        Dim sqlda As SqlDataAdapter = Nothing
        Dim res As New DataTable
        Try
            connection = New SqlConnection(conn)
            command = New SqlCommand(cmd, connection)
            command.CommandType = cmdType
            AssignParameters(command, parameters)
            sqlda = New SqlDataAdapter(command)

            command.CommandTimeout() = 7200

            sqlda.Fill(res)
        Catch ex As Exception
            Throw New Data.DataException(ex.Message, ex.InnerException)
        Finally
            If Not (connection Is Nothing) Then connection.Dispose()
            If Not (command Is Nothing) Then command.Dispose()
            If Not (sqlda Is Nothing) Then sqlda.Dispose()
        End Try
        Return res
    End Function

#End Region

#Region "Execute Non Query"

    Public Function ExecuteNonQuery(ByVal conn As String, ByVal cmd As String, ByVal cmdType As CommandType, Optional ByVal parameters() As SqlParameter = Nothing) As Integer
        Dim connection As SqlConnection = Nothing
        Dim transaction As SqlTransaction = Nothing
        Dim command As SqlCommand = Nothing
        Dim res As Integer = -1
        Try

            connection = New SqlConnection(conn)
            command = New SqlCommand(cmd, connection)
            command.CommandType = cmdType
            Me.AssignParameters(command, parameters)
            connection.Open()
            'transaction = connection.BeginTransaction()
            'command.Transaction = transaction
            res = command.ExecuteNonQuery()
            'transaction.Commit()
        Catch ex As Exception
            'If Not (transaction Is Nothing) Then
            '    transaction.Rollback()
            'End If
            'Throw New Data.DataException(ex.Message, ex.InnerException)
            Throw New Exception(ex.Message, ex.InnerException)
        Finally
            If Not (connection Is Nothing) AndAlso (connection.State = ConnectionState.Open) Then connection.Close()
            If Not (command Is Nothing) Then command.Dispose()
            If Not (transaction Is Nothing) Then transaction.Dispose()
        End Try
        Return res
    End Function


#End Region
End Class
