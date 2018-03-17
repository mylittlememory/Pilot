using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Data;
using Mono.Data.SqliteClient;



public class DBManager : MonoBehaviour {

    private void Start()
    {

    }

    void CreateTable(string sql)
    {
        string conn = "URI=file:" + Application.persistentDataPath + "/testDB.s3db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        IDbCommand dbcmd = dbconn.CreateCommand();
        //string sqlQuery;
        //sqlQuery = "CREATE TABLE TEMP(";
        //sqlQuery += "ID INT PRIMARY KEY NOT NULL,";
        //sqlQuery += "NAME TEXT NOT NULL";
        //sqlQuery += ");";

        dbcmd.CommandText = sql;
        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    void InsertData(string sql)
    {
        string conn = "URI=file:" + Application.persistentDataPath + "/testDB.s3db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        IDbCommand dbcmd = dbconn.CreateCommand();
        //string sqlQuery;
        //sqlQuery = "INSERT INTO TEMP (ID,NAME) ";
        //sqlQuery += "VALUES(2,'Paul');";

        dbcmd.CommandText = sql;
        dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    void SelectData(string sql)
    {
        string conn = "URI=file:" + Application.persistentDataPath + "/testDB.s3db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        IDbCommand dbcmd = dbconn.CreateCommand();
        //string sqlQuery = "SELECT * FROM TEMP;";
        dbcmd.CommandText = sql;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int ID = reader.GetInt32(0);
            string Name = reader.GetString(1);
            Debug.Log("ID= " + ID + " NAME= " + Name);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
