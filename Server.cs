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

        //Empiezo los servicios del servidor
        StartService();

        //Mientras sea TRUE el servidor se mantiene PRENDÍO
        while (bServerOn)
        {
            network_service.CheckConnection();
            network_service.CheckMessage();
            network_service.DisconnectClients();
        }


        void StartService()
        {

            //Servicios de red
            network_service.StartNetworkService();
        }

    }

}