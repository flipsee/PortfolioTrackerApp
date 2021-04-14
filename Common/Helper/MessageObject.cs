using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
    public interface IMessageObject
    {
        List<Message> Errors { get; }
        List<Message> Warnings { get; }
        List<Message> Confirmations { get; }
        List<Message> Informations { get; }
        Exception Exception { get; }
        bool ProcessingStatus { get; }
        bool HasError { get; }
        string ErrorText { get; }

        void AddException(Exception ex);
        void AddMessage(Message msg);
        void AddMessage(MessageType type, string code, string desc, string field = "");
        void AddMessage(IMessageObject msg);
        void AddMessage(List<IMessageObject> msgList);        
    }

    /// <summary>
    /// this class merge the MessageObject and ValidationResult from the standard template.
    /// </summary>
    public class MessageObject<T> : IMessageObject
    {
        public List<Message> Errors { get; }
        public List<Message> Warnings { get; }
        public List<Message> Confirmations { get; }
        public List<Message> Informations { get; }
        public Exception Exception { get; private set; }
        public T Data { get; set; }
        public bool ProcessingStatus { get; private set; } = true;

        public MessageObject()
        {
            this.Errors = new List<Message>();
            this.Warnings = new List<Message>();
            this.Confirmations = new List<Message>();
            this.Informations = new List<Message>();
        }

        public MessageObject(T Data) : this()
        {
            this.Data = Data;
        }

        public void AddException(Exception ex)
        {
            this.Exception = ex;
            this.ProcessingStatus = false;
        }

        public void AddMessage(Message msg)
        {
            switch (msg.Type)
            {
                case MessageType.Error:
                    this.Errors.Add(msg);
                    this.ProcessingStatus = false;
                    break;
                case MessageType.Warning:
                    this.Warnings.Add(msg);
                    break;
                case MessageType.Confirmation:
                    this.Confirmations.Add(msg);
                    break;
                default:
                    this.Informations.Add(msg);
                    break;
            }
        }

        public void AddMessage(MessageType type, string code, string desc, string field = "")
        {
            AddMessage(new Message(type, code, desc, field));
        }

        public void AddMessage(IMessageObject msg)
        {
            this.Errors.AddRange(msg.Errors);
            this.Warnings.AddRange(msg.Warnings);
            this.Confirmations.AddRange(msg.Confirmations);
            this.Informations.AddRange(msg.Informations);
            if (this.Exception == null)
                this.Exception = msg.Exception;

            if (this.ProcessingStatus && !msg.ProcessingStatus)
                this.ProcessingStatus = msg.ProcessingStatus;
        }

        public void AddMessage(List<IMessageObject> msgList)
        {
            if (msgList != null && msgList.Count > 0)
                foreach (var msg in msgList)
                    AddMessage(msg);
        }

        public bool HasError
        {
            get { return this.Errors.Count > 0;}            
        }

        public string ErrorText
        {
            get 
            {
                StringBuilder result = new StringBuilder();
                if (this.Errors != null && this.Errors.Count > 0)
                    foreach (var err in this.Errors)
                    {
                        result.Append(err.Description + ";");
                    }                        
                return result.ToString();
            }            
        }
    }

    public class Message
    {
        /// <summary>
        /// when used internally this will returns as Enum, but when seriliazed we want it to render as a string of the enum
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageType Type { get; }

        public string Code { get; }
        public string Description { get; }
        public string Field { get; } = string.Empty;

        public Message(MessageType type, string code, string desc, string field = "")
        {
            this.Type = type;
            this.Code = code;
            this.Description = desc;
            this.Field = field;
        }
    }

    public enum MessageType
    {
        Error,
        Warning,
        Information,
        Confirmation
    }
}
