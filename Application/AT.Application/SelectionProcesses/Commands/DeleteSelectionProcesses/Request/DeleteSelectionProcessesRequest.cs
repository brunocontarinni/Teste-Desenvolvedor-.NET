using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using MediatR;

namespace AT.Application.SelectionProcesses.Commands.DeleteSelectionProcesses
{
    public class DeleteSelectionProcessesRequest : IRequest
    {
        public long ID { get; set; }
    }
}