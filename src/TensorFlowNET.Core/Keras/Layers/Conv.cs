﻿using System;
using System.Collections.Generic;
using System.Text;
using Tensorflow.Keras.Engine;
using Tensorflow.Operations.Activation;

namespace Tensorflow.Keras.Layers
{
    public class Conv : Tensorflow.Layers.Layer
    {
        protected int rank;
        protected int filters;
        protected int[] kernel_size;
        protected int[] strides;
        protected string padding;
        protected string data_format;
        protected int[] dilation_rate;
        protected IActivation activation;
        protected bool use_bias;
        protected IInitializer kernel_initializer;
        protected IInitializer bias_initializer;

        public Conv(int rank, 
            int filters,
            int[] kernel_size,
            int[] strides = null,
            string padding = "valid",
            string data_format = null,
            int[] dilation_rate = null,
            IActivation activation = null,
            bool use_bias = true,
            IInitializer kernel_initializer = null,
            IInitializer bias_initializer = null,
            bool trainable = true, 
            string name = null) : base(trainable: trainable, name: name)
        {
            this.rank = rank;
            this.filters = filters;
            this.kernel_size = kernel_size;
            this.strides = strides;
            this.padding = padding;
            this.data_format = data_format;
            this.dilation_rate = dilation_rate;
            this.activation = activation;
            this.use_bias = use_bias;
            this.kernel_initializer = kernel_initializer;
            this.bias_initializer = bias_initializer;
            input_spec = new InputSpec(ndim: rank + 2);
        }

        protected override void build(TensorShape input_shape)
        {
            int channel_axis = data_format == "channels_first" ? 1 : -1;
            int input_dim = input_shape.Dimensions[input_shape.NDim - 1];
            var kernel_shape = new int[] { kernel_size[0], kernel_size[1], input_dim, filters };
            add_weight(name: "kernel", 
                shape: kernel_shape,
                initializer: kernel_initializer,
                trainable: true,
                dtype: _dtype);
        }
    }
}
