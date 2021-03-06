using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UMS.Client.Core.Enums;

namespace UMS.Client.Main.Helpers
{
    public class SocketHelper
    {
        public static HubConnection newhubConnection;
        public static bool connected => newhubConnection.State == HubConnectionState.Connected;

        //If you want to change them make it Timespan. This is for the countdown
        public static int[] RetryIntervals = new int[] { 0, 2, 10, 30 };

        public static void ListenEventFromOutside(ISnackbar snackBar,
                                                  SocketMessageType socketMessage,
                                                  string snackBarText)
        {
            newhubConnection.On(socketMessage.ToString(), async () =>
            {
                snackBar.Add($"{snackBarText}", Severity.Success, options => options.Onclick = snackbar => Task.CompletedTask);
            });
        }

        public static void DisposeSocket()
        {
            if (newhubConnection != null)
            {
                newhubConnection.Remove(SocketMessageType.NewEventReleased.ToString());
            }
        }
    }
}