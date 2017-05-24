<?php
    require_once (dirname(__FILE__) .  "/mysqlconnector.php");
    require_once (dirname(__FILE__) .  "/carbite.php");

    function insetToMySql($req,$res){
        
        $connector = new MySqlConnector("localhost", "root","root", "test");
        $status = $connector->Connect();

        if ($status === TRUE){
            $connector->Query("CREATE TABLE IF NOT EXISTS TEST (ID INT PRIMARY KEY , NAME TEXT)");
            $connector->Query("INSERT INTO TEST VALUES(1, 'test')");

            $connector->Disconnect();
            $res->Set("Operation Successful");
        } else {
            $res->Set("Error occured while connecting : $status");
        }
    }


    Carbite::GET("/test", "insetToMySql");
    Carbite::Start();
?>