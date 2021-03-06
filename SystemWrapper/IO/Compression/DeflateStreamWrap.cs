﻿using System;
using System.IO.Compression;
using SystemInterface.IO;
using SystemInterface.IO.Compression;

namespace SystemWrapper.IO.Compression
{
    /// <summary>
    /// Description of DeflateStreamWrap.
    /// </summary>
    public class DeflateStreamWrap : IDeflateStream
    {
        #region Constructors and Initializers

        /// <summary>
        /// Creates an uninitialized version of DeflateStreamWrap.
        /// </summary>
        public DeflateStreamWrap()
        {
            // this constructor assumes caller will make a subsequent call to Initialize
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemWrapper.IO.Compression.DeflateStreamWrap"/> class.
        /// </summary>
        /// <param name="stream">The stream to compress or decompress.</param>
        /// <param name="mode">One of the CompressionMode values that indicates the action to take.</param>
        public DeflateStreamWrap(IStream stream, CompressionMode mode)
        {
            Initialize(stream, mode);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SystemWrapper.IO.Compression.DeflateStreamWrap"/> class.
        /// </summary>
        /// <param name="stream">The stream to compress or decompress.</param>
        /// <param name="mode">One of the CompressionMode values that indicates the action to take.</param>
        public void Initialize(IStream stream, CompressionMode mode)
        {
            DeflateStreamInstance = new DeflateStream(stream.StreamInstance, mode);
        }

        #endregion Constructors and Initializers

        /// <inheritdoc />
        public DeflateStream DeflateStreamInstance { get; private set; }

        /// <inheritdoc />
        public int Read(byte[] array, int offset, int count)
        {
            return DeflateStreamInstance.Read(array, offset, count);
        }

        /// <inheritdoc />
        public void Write(byte[] array, int offset, int count)
        {
            DeflateStreamInstance.Write(array, offset, count);
        }

        public void CopyTo(IStream destination)
        {
            DeflateStreamInstance.CopyTo(destination.StreamInstance);
        }

        /// <inheritdoc />
        public void Flush()
        {
            DeflateStreamInstance.Flush();
        }

        /// <inheritdoc />
        public void Close()
        {
            DeflateStreamInstance.Close();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Indicates whether or not unmanaged resources should be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            DeflateStreamInstance.Dispose();
        }
    }
}
