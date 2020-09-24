﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MagicGradients.Animation
{
    [ContentProperty(nameof(Animation))]
    public class AnimateTrigger : IMarkupExtension<TriggerBase>
    {
        public Timeline Animation { get; set; }
        public BindingBase IsRunning { get; set; }

        public TriggerBase ProvideValue(IServiceProvider serviceProvider)
        {
            var trigger = new DataTrigger(typeof(GradientView))
            {
                Binding = IsRunning, 
                Value = true
            };

            trigger.EnterActions.Add(new BeginAnimation { Animation = Animation });
            trigger.ExitActions.Add(new EndAnimation { Animation = Animation });

            return trigger;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}
