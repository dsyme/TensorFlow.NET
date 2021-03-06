﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tensorflow.Keras.Engine
{
    /// <summary>
    /// Specifies the ndim, dtype and shape of every input to a layer.
    /// </summary>
    public class InputSpec
    {
        public int ndim;

        public InputSpec(TF_DataType dtype = TF_DataType.DtInvalid, 
            int? ndim = null)
        {
            this.ndim = ndim.Value;
        }
    }
}
