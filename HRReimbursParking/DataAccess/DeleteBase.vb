Imports System.Configuration
Imports System.Data.SqlClient
Public Class DeleteBase
    Dim Conn As String = ConfigurationManager.ConnectionStrings("ConSql").ToString
    Dim DataAccess As New DataAccessBase
#Region "Constanta"

    Dim const_sp_Delete_Menu As String = "sp_ReportApp_Delete_Menu"
    Dim const_sp_DEL_USER_MATRIX As String = "sp_DEL_USER_MATRIX"
#End Region
    Public Function Del_USER_MATRIX(ByVal _USERNAME As String) As Integer

        Dim int_i As Integer

        Dim oParam(0) As SqlParameter

        oParam(0) = New SqlClient.SqlParameter("@USERNAME", SqlDbType.VarChar)
        oParam(0).Value = CType(_USERNAME, String)

        Dim _connectionString As String = conn

        int_i = DataAccess.ExecuteNonQuery(_connectionString, const_sp_DEL_USER_MATRIX, CommandType.StoredProcedure, oParam)

        Return int_i

    End Function
End Class
