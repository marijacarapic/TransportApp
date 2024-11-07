using System;
using Common;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels;
using Common.Communication;
using System.Diagnostics;
using System.IO;
using Common.Domen;

namespace Server
{
    internal class ClientHandler
    {

        private readonly Socket socket;
        private Sender sender;
        private Receiver receiver;

        public ClientHandler(Socket socket)
        {
            this.socket = socket;
            sender = new Sender(socket);
            receiver = new Receiver(socket);
        }

        public void HandleRequests()
        {
            try
            {
                while (true)
                {
                    Request r = receiver.Receive<Request>();
                    Response response = ProcessRequest(r);
                    sender.Send(response);
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
            }
            catch (IOException ex)
            {
                Debug.WriteLine(">>>" + ex.Message);
            }
        }


        public Response ProcessRequest(Request request)
        {
            Response response = new Response();
            try
            {
                switch (request.Operation)
                {
                    case Operation.Login:
                        response.Result = Controller.Instance.Login((AdministratorTransporta)request.Argument);
                        break;
                    case Operation.UcitajListuTipVozila:
                        response.Result = Controller.Instance.UcitajListuTipVozila();
                        break;
                    case Operation.UcitajListuGradova:
                        response.Result = Controller.Instance.UcitajListuGradova();
                        break;
                    case Operation.UcitajListuTipSadrzajTransporta:
                        response.Result = Controller.Instance.UcitajListuTipSadrzajTransporta();
                        break;
                    case Operation.DodajVozilo:
                        Controller.Instance.SacuvajVozilo((Vozilo)request.Argument);
                        break;
                    case Operation.UcitajListuVozila:
                        response.Result = Controller.Instance.UcitajListuVozila();
                        break;
                    case Operation.UcitajListuVozilaPoTipuSadrzajaTransporta:
                        response.Result = Controller.Instance.UcitajListuVozilaPoTipuSadrzajaTransporta((TipSadrzajTransporta)request.Argument);
                        break;
                    case Operation.ObrisiVozilo:
                        Controller.Instance.ObrisiVozilo((Vozilo)request.Argument);
                        break;
                    case Operation.DodajUgovorTransporta:
                        Controller.Instance.SacuvajUgovor((UgovorTransporta)request.Argument);
                        break;
                    case Operation.UcitajListuUgovoraTransporta:
                        response.Result = Controller.Instance.UcitajListuUgovoraTransporta();
                        break;
                    case Operation.PretraziUgovoreTransporta:
                        response.Result = Controller.Instance.PretraziUgovoreTransporta((string)request.Argument);
                        break;
                    case Operation.PretraziStavkeTransporta:
                        response.Result = Controller.Instance.PretraziStavkeTransporta((DateTime)request.Argument);
                        break;
                    case Operation.UcitajJedanUgovor: 
                        response.Result = Controller.Instance.UcitajJedanUgovor((int)request.Argument);
                        break;
                    case Operation.IzmeniStavkuTransporta:
                        Controller.Instance.IzmeniStavkuTransporta((StavkaTransporta)request.Argument);
                        break;
                    case Operation.PretraziVozila:
                        response.Result = Controller.Instance.PretraziVozila((TipVozila)request.Argument);
                        break;
                    case Operation.UcitajListuTipSadrzajTransportaPoVozilu:
                        response.Result = Controller.Instance.UcitajListuTipSadrzajTransportaPoVozilu((Vozilo)request.Argument);
                        break;
                    case Operation.IzmeniVozilo:
                        Controller.Instance.IzmeniVozilo((Vozilo)request.Argument);
                        break;
                    case Operation.ProveraDostupnostiVozila:
                        response.Result = Controller.Instance.ProveraDostupnostiVozila((StavkaTransporta)request.Argument);
                        break;
                    case Operation.UcitajVozilo:
                        response.Result = Controller.Instance.UcitajVozilo((Vozilo)request.Argument);
                        break;
                    case Operation.UcitajStavkuTransporta:
                        response.Result = Controller.Instance.UcitajStavkuTransporta((StavkaTransporta)request.Argument);
                        break;

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(">>>" + ex.Message);
                response.Exception = ex;
            }
            return response;
        }
    }

}

