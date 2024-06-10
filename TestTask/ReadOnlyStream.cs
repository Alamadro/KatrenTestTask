using System;
using System.IO;

namespace TestTask
{
    public class ReadOnlyStream : IReadOnlyStream
    {
        //private Stream _localStream;
        private readonly StreamReader _localStreamReader;
        /// <summary>
        /// Конструктор класса. 
        /// Т.к. происходит прямая работа с файлом, необходимо 
        /// обеспечить ГАРАНТИРОВАННОЕ закрытие файла после окончания работы с таковым!
        /// </summary>
        /// <param name="fileFullPath">Полный путь до файла для чтения</param>
        public ReadOnlyStream(string fileFullPath)
        {
            //IsEof = false;

            // TODO : Заменить на создание реального стрима для чтения файла!
            try
            {
                _localStreamReader = new StreamReader(fileFullPath);
            }
            catch (Exception)
            {
                throw;
            }
        }
                
        /// <summary>
        /// Флаг окончания файла.
        /// </summary>
        public bool IsEof
        {
            get => _localStreamReader == null || _localStreamReader.EndOfStream;// TODO : Заполнять данный флаг при достижении конца файла/стрима при чтении
        }

        public void Close()
        {
            _localStreamReader?.Close();
        }

        /// <summary>
        /// Ф-ция чтения следующего символа из потока.
        /// Если произведена попытка прочитать символ после достижения конца файла, метод 
        /// должен бросать соответствующее исключение
        /// </summary>
        /// <returns>Считанный символ.</returns>
        public char ReadNextChar()
        {
            // TODO : Необходимо считать очередной символ из _localStream
            if(!IsEof)
            {
                return (char)_localStreamReader.Read();
            }
            return '\0';
        }

        /// <summary>
        /// Сбрасывает текущую позицию потока на начало.
        /// </summary>
        public void ResetPositionToStart()
        {
            if (_localStreamReader == null)
            {
                return;
            }
            _localStreamReader.BaseStream.Position = 0;
        }
    }
}
