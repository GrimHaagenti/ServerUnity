using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Server
{
    static void Main(string[] args)
    {

        bool bServerOn = true;

        //Instancio los servicios de red del servidor
        NetworkManager network_service = new NetworkManager();
        Database_Manager database_manager = Database_Manager._DB_MANAGER;

        //Empiezo los servicios del servidor
        StartService();

        //Mientras sea TRUE el servidor se mantiene PRENDÍO
        while (bServerOn)
        {

            //Network Service
            network_service.CheckConnection();
            network_service.CheckMessage();
            network_service.DisconnectClients();

            //Database Services

        }


        void StartService()
        {

            //Servicios de red
            network_service.StartNetworkService();
            //Servicio de base de Datos
            database_manager.StartDatabaseService();
        }

    }

}