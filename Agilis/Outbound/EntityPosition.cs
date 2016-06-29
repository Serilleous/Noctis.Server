using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agilis.Outbound
{
    public struct EntityPosition
    {
        /// <summary>
        /// Position X
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Position Y
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Position Z
        /// </summary>
        public int Z { get; set; }
        
        /// <summary>
        /// Quaterion X
        /// </summary>
        public short x { get; set; }
        /// <summary>
        /// Quaterion Y
        /// </summary>
        public short y { get; set; }
        /// <summary>
        /// Quaternion Z
        /// </summary>
        public short z { get; set; }
        /// <summary>
        /// Quaternion W
        /// </summary>
        public short w { get; set; }
    }
}