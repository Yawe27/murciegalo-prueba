using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using Mono.Data.Sqlite;
using System;
using System.Data;

public class DataRanking : MonoBehaviour
{
    int kill;
    string nombre;
    string rutaDB;
    string strConexion;
    string DBfile = "MurcielagoKill.sqlite";
    public TMPro.TextMeshProUGUI pos;

    IDbConnection dbConnection;
    IDbCommand dbComand;
    IDataReader reader;



 
    void Start()
    {
        meterNombre();
        MostrarRanking();
    }

        public void meterNombre() 
    {
        nombre = SaveProject.Instance.LoadGame();
        kill = PlayerPrefs.GetInt("kill");
        InsertScore(nombre, kill);
    }

    public void MostrarRanking()
    {

        ObtenerRanking();

        CerrarDB();


    }

    void CerrarDB()
    {

        //cerrar

        dbComand.Dispose();
        dbComand = null;
        dbConnection.Close();
        dbConnection = null;
    }

    private void ObtenerRanking()
    {

        AbrirDB();

        dbComand = dbConnection.CreateCommand();

        string sqlQuery = "select * from Ranking order by score DESC limit 10";

        dbComand.CommandText = sqlQuery;

        reader = dbComand.ExecuteReader();


        int index = 1;

        while (reader.Read())
        {
            string name = reader["Name"].ToString();

            int score = Convert.ToInt32(reader["Score"]);

            pos.text = pos.text + "\n" + "Nº " + (index++).ToString() + " - " + name + " - " + score.ToString();

        }

        reader.Close();
        reader = null;

    }



    public void InsertScore(string name, float score)
    {

        AbrirDB();

        dbComand = dbConnection.CreateCommand();

        string sqlQuery = "INSERT INTO Ranking (Name, Score) values( \"" + name + "\", \"" + score + "\")";

        dbComand.CommandText = sqlQuery;
        dbComand.ExecuteScalar();

        CerrarDB();

    }








    void AbrirDB()
    {

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            rutaDB = Application.dataPath + "/StreamingAssets/" + DBfile;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {

            rutaDB = Application.persistentDataPath + "/" + DBfile;

            if (!File.Exists(rutaDB))
            {
                WWW loadDB = new WWW("jar;file://" + Application.dataPath + DBfile);

                while (!loadDB.isDone)
                {

                }
                File.WriteAllBytes(rutaDB, loadDB.bytes);
            }

        }

        // crear y abrir conexion
        rutaDB = Application.dataPath + "/StreamingAssets/" + DBfile;
        strConexion = "URI=file:" + rutaDB;
        dbConnection = new SqliteConnection(strConexion);

        dbConnection.Open();
        //CreateTable();
    }
}
