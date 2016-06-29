using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Agilis.Outbound
{
    public class PositionService
    {
        static Dictionary<int, EntityPosition> positions = new Dictionary<int, EntityPosition>();
        static Timer broadcastTimer;

        BinaryFormatter formatter;
        MemoryStream memoryStream;
        UDPBroadcaster broadcaster;

        public PositionService()
        {
            formatter = new BinaryFormatter();
            broadcaster = new UDPBroadcaster();


        }

        void Broadcast(Object positionDictionary)
        {
            if (!(positionDictionary is Dictionary<int, EntityPosition>))
                throw new InvalidDataException("Broadcast of invalid type attempted");

            lock(positionDictionary)
                formatter.Serialize(memoryStream, positionDictionary);
            
            System.Diagnostics.Debug.WriteLine("derp");
            broadcaster.Broadcast(memoryStream.ToArray());
            
        }

        public static void Start()
        {
            var thisService = new PositionService();
            broadcastTimer = new Timer(thisService.Broadcast, positions, 1000, 1000);

        }

        public static void Stop()
        {
            broadcastTimer.Dispose();
        }

        public static void updatePositions(int id, EntityPosition position)
        {
            positions[id] = position;
        }
    }
}