﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results {
    public class DataResult<T> : Result, IDataResult<T> {
        public T Data { get; }

        public bool Success { get; }

        public string Message { get; }

        public DataResult(T data, bool success, string message) : base(success, message) {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success) {
            Data = data;
        }
    }
}