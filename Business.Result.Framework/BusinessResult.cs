
#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Business.Result.Framework
{
    /// <summary>
    /// Clase encargada de encapsular todas las operaciones en la capa de negocio.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class BusinessResult<T>
    {
        /// <summary>
        /// Construtor de la clase
        /// </summary>
        public BusinessResult()
        {

        }

        /// <summary>
        /// Excepción que se genera al momento de un error
        /// </summary>
        /// No se esta utilizando en ningun lado esta propiedad
        //public Exception Error { get; }

        /// <summary>
        /// Resultado de la operación
        /// </summary>
        [DataMember]
        public T Result { get; set; }

        /// <summary>
        /// Fecha en que se ejecututó la operación
        /// </summary>
        [DataMember]
        public DateTime Date { get; }

        /// <summary>
        /// Mensaje de la operación
        /// </summary>
        [DataMember]
        public String Message { get; set; }

        /// <summary>
        /// Excepción retornada despues de una operación que no fue exitosa.
        /// </summary>
        [DataMember]
        public string Exception { get; set; }

        /// <summary>
        /// Determina si la operación fué o no exitosa
        /// </summary>
        [DataMember]
        public bool SuccessfulOperation { get; set; }

        /// <summary>
        /// Método utilitario para construir una instancia de BusinessResult en caso de que la operación haya sido exitosa
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static BusinessResult<T> Success(T result, string message)
        {
            return new BusinessResult<T>
            {
                Message = message,
                SuccessfulOperation = true,
                Result = result
            };
        }

        /// <summary>
        /// Método utilitario para construir una instancia de BusinessResult en caso de que la operación haya sido errónea
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static BusinessResult<T> Issue(T result, string message, Exception ex)
        {
            return new BusinessResult<T>
            {
                Message = message,
                SuccessfulOperation = false,
                Result = result,
                Exception = ex.ToString()
            };
        }
    }
}
