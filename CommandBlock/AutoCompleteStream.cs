using System;
using System.Linq;
using System.Collections.Generic;

namespace Game
{
    public class AutoCompleteStream
    {
        public interface IAutoCompleteReciver
        {
            void Error(string msg);
            void ProvideAny(Type t);
            void ProvideBool();
            void ProvideInt();
            void ProvideFloat();
            void ProvideString();
            void ProvideEnum(IEnumerable<string> enums);
            void CompleteEnum(string str, IEnumerable<string> enums);
        }

        readonly IAutoCompleteReciver reciver;
        readonly CommandStream stream;

        public CommandStream CommandStream
        {
            get
            {
                return stream;
            }
        }

        public IAutoCompleteReciver Reciver
        {
            get
            {
                return reciver;
            }
        }

        public AutoCompleteStream(CommandStream stream, IAutoCompleteReciver reciver)
        {
            this.stream = stream;
            this.reciver = reciver;
        }

        public AutoCompleteStream Any(Type t)
        {
            try
            {
                stream.Next(t);
            }
            catch (Exception e)
            {
                if (e is ArgNotFoundException)
                {
                    reciver.ProvideAny(t);
                }
                else
                {
                    reciver.Error(e.Message);
                }
                throw new SilentException();
            }
            return this;
        }

        public AutoCompleteStream String()
        {
            try
            {
                stream.NextString();
            }
            catch (ArgNotFoundException)
            {
                reciver.ProvideString();
                throw new SilentException();
            }
            return this;
        }

        public AutoCompleteStream Bool()
        {
            try
            {
                stream.NextBool();
            }
            catch (Exception e)
            {
                if (e is WrongArgTypeException)
                {
                    reciver.Error(e.Message);
                }
                else if (e is ArgNotFoundException)
                {
                    reciver.ProvideBool();
                }
                throw new SilentException();
            }
            return this;
        }

        public AutoCompleteStream Int()
        {
            try
            {
                stream.NextInt();
            }
            catch (Exception e)
            {
                if (e is WrongArgTypeException)
                {
                    reciver.Error(e.Message);
                }
                else if (e is ArgNotFoundException)
                {
                    reciver.ProvideInt();
                }
                throw new SilentException();
            }
            return this;
        }

        public AutoCompleteStream Float()
        {
            try
            {
                stream.NextFloat();
            }
            catch (Exception e)
            {
                if (e is WrongArgTypeException)
                {
                    reciver.Error(e.Message);
                }
                else if (e is ArgNotFoundException)
                {
                    reciver.ProvideFloat();
                }
                throw new SilentException();
            }
            return this;
        }

        public AutoCompleteStream Enum(IEnumerable<string> strs)
        {
            try
            {
                var str = stream.NextString();
                if (!strs.Contains(str))
                {
                    reciver.CompleteEnum(str, strs);
                    throw new SilentException();
                }
            }
            catch (ArgumentException)
            {
                reciver.ProvideEnum(strs);
                throw new SilentException();
            }
            return this;
        }

        public AutoCompleteStream Point3()
        {
            try
            {
                stream.NextPoint3();
            }
            catch (Exception e)
            {
                if (e is WrongArgTypeException)
                {
                    reciver.Error(e.Message);
                }
                else if (e is ArgNotFoundException)
                {
                    reciver.ProvideInt();
                }
                throw new SilentException();
            }
            return this;
        }

        public AutoCompleteStream Vector3()
        {
            try
            {
                stream.NextVector3();
            }
            catch (Exception e)
            {
                if (e is WrongArgTypeException)
                {
                    reciver.Error(e.Message);
                }
                else if (e is ArgNotFoundException)
                {
                    reciver.ProvideFloat();
                }
                throw new SilentException();
            }
            return this;
        }
    }
}
