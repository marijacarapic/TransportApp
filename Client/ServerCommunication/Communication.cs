using Client.GuiController;
using Common.Communication;
using Common.Domen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.ServerCommunication
{
    public class Communication
    {
        
            private static Communication instance;

            private Communication() { }

            public static Communication Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Communication();
                    }
                    return instance;
                }
            }

            private Socket socket;
            private Sender sender;
            private Receiver receiver;
            public void Connect()
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("127.0.0.1", 9999);
                sender = new Sender(socket);
                receiver = new Receiver(socket);
            }

        public AdministratorTransporta Login(AdministratorTransporta administrator)
        {
            Request request = new Request()
            {
                Operation = Operation.Login,
                Argument = new AdministratorTransporta { Username = administrator.Username, Password = administrator.Password }
            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (AdministratorTransporta)r.Result;
        }

        public List<TipVozila> UcitajListuTipVozila()
        {
            Request request = new Request()
            {
                Operation = Operation.UcitajListuTipVozila
            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (List<TipVozila>)r.Result;
        }

        public List<Grad> UcitajListuGradova()
        {
            Request request = new Request()
            {
                Operation = Operation.UcitajListuGradova
            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (List<Grad>)r.Result;
        }

        public List<TipSadrzajTransporta> UcitajListuTipSadrzajTransporta()
        {
            Request request = new Request()
            {
                Operation = Operation.UcitajListuTipSadrzajTransporta
            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (List<TipSadrzajTransporta>)r.Result;
        }

        public void DodajVozilo(Vozilo vozilo)
        {
            Request request = new Request
            {
                Operation = Operation.DodajVozilo,
                Argument = vozilo
            };
            sender.Send(request);
            Response r =  receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
        }

        public List<Vozilo> UcitajListuVozila()
        {
            Request request = new Request()
            {
                Operation = Operation.UcitajListuVozila
            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (List<Vozilo>)r.Result;
        }

        public void ObrisiVozilo(Vozilo vozilo)
        {
            Request request = new Request
            {
                Operation = Operation.ObrisiVozilo,
                Argument = vozilo
            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;

        }

        public List<Vozilo> UcitajListuVozilaPoTipuSadrzajaTransporta(TipSadrzajTransporta tipSadrzajTransporta)
        {
            Request request = new Request()
            {
                Operation = Operation.UcitajListuVozilaPoTipuSadrzajaTransporta,
                Argument = tipSadrzajTransporta
            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (List<Vozilo>)r.Result;
        }

        public void DodajUgovor(UgovorTransporta ugovorTransporta)
        {
            Request request = new Request
            {
                Operation = Operation.DodajUgovorTransporta,
                Argument = ugovorTransporta
            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if(r.Exception != null) throw r.Exception;
        }

        public List<UgovorTransporta> UcitajListuUgovoraTransporta()
        {
            Request request = new Request()
            {
                Operation = Operation.UcitajListuUgovoraTransporta,
                
            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (List<UgovorTransporta>)r.Result;
        }

        public List<UgovorTransporta> PretraziUgovoreTransporta(string pretraga)
        {
            Request request = new Request()
            {
                Operation = Operation.PretraziUgovoreTransporta,
                Argument = pretraga

            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (List<UgovorTransporta>)r.Result;
        }

        public List<StavkaTransporta> PretraziStavkeTransporta(DateTime datum)
        {
            Request request = new Request()
            {
                Operation = Operation.PretraziStavkeTransporta,
                Argument = datum

            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (List<StavkaTransporta>)r.Result;
        }

        public UgovorTransporta UcitajUgovorTransporta(int idUgovorTransporta)
        {
            Request request = new Request()
            {
                Operation = Operation.UcitajJedanUgovor,
                Argument = idUgovorTransporta

            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if(r.Exception != null) throw r.Exception;
            return (UgovorTransporta)r.Result;
        }

        public void IzmeniStavkuTransporta(StavkaTransporta stavka)
        {
            Request request = new Request
            {
                Operation = Operation.IzmeniStavkuTransporta,
                Argument = stavka

            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
        }

        public List<Vozilo> PretraziVozila(TipVozila tip)
        {
            Request request = new Request
            {
                Operation = Operation.PretraziVozila,
                Argument = tip

            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (List<Vozilo>)r.Result; 
        }

        public List<TipSadrzajTransporta> UcitajListuTipSadrzajTransportaPoVozilu(Vozilo vozilo)
        {
            Request request = new Request
            {
                Operation = Operation.UcitajListuTipSadrzajTransportaPoVozilu,
                Argument = vozilo

            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (List<TipSadrzajTransporta>)r.Result;
        }

        public void IzmeniVozilo(Vozilo vozilo)
        {
            Request request = new Request
            {
                Operation = Operation.IzmeniVozilo,
                Argument = vozilo

            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
        }

        public bool ProveraDostupnostiVozila(StavkaTransporta stavka)
        {
            Request request = new Request
            {
                Operation = Operation.ProveraDostupnostiVozila,
                Argument = stavka

            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (bool)r.Result;
        }

        public Vozilo UcitajVozilo(Vozilo vozilo)
        {
            Request request = new Request
            {
                Operation = Operation.UcitajVozilo,
                Argument = vozilo

            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (Vozilo)r.Result;
        }

        public StavkaTransporta UcitajStavkuTransporta(StavkaTransporta stavka)
        {
            Request request = new Request
            {
                Operation = Operation.UcitajStavkuTransporta,
                Argument = stavka

            };
            sender.Send(request);
            Response r = receiver.Receive<Response>();
            if (r.Exception != null) throw r.Exception;
            return (StavkaTransporta)r.Result;
        }
    }
}
