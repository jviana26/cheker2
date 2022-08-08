using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Dominio
{
    
    public class Usb
    {

        /// <summary>
        /// obtiene las usb de la computadora
        /// </summary>
        /// <returns></returns>
        public List<USBInfo> GetUSBDevices()
        {

            //creamos una lista de USBInfo
            List<USBInfo> lstDispositivos = new List<USBInfo>();

            //creamos un ManagementObjectCollection para obtener nuestros dispositivos
            ManagementObjectCollection collection;

            //utilizando la WMI clase Win32_USBHub obtenemos todos los dispositivos USB
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))

                //asignamos los dispositivos a nuestra coleccion
                collection = searcher.Get();

            //recorremos la colección
            foreach (var device in collection)
            {
                //asignamos el dispositivo a nuestra lista
                lstDispositivos.Add(new USBInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }

            //liberamos el objeto collection
            collection.Dispose();
            //regresamos la lista
            return lstDispositivos;
        }
    }
    /// <summary>
    /// clase para guardar las especificaciones de los dispositivos
    /// </summary>
    public class USBInfo
    {

        //constructor
        public USBInfo(string deviceID, string pnpDeviceID, string description)
        {
            this.DeviceID = deviceID;
            this.PnpDeviceID = pnpDeviceID;
            this.Description = description;
        }

        /// <summary>
        /// Device ID
        /// </summary>
        public string DeviceID { get; private set; }

        /// <summary>
        /// Pnp Device Id
        /// </summary>
        public string PnpDeviceID { get; private set; }

        /// <summary>
        /// Descripción del dispositivo o nombre
        /// </summary>
        public string Description { get; private set; }
    }
}


