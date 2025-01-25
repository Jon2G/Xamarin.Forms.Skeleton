using System.Threading.Tasks;
using AsyncAwaitBestPractices;

#if NET6_0_OR_GREATER
namespace Maui.Skeleton.Animations
#else
namespace Xamarin.Forms.Skeleton.Animations
#endif
{
    public abstract class BaseAnimation : IAnimation
    {
        public uint Interval { get; set; }
        public double Parameter { get; set; }

        protected abstract Task<bool> Animate(BindableObject bindable);

        protected abstract Task StopAnimation(BindableObject bindable);

        public void Start(BindableObject bindable)
        {
            Task.Run(async () => { await this.Run(bindable); }).SafeFireAndForget();
        }

        public void Stop(BindableObject bindable)
        {
            Task.Run(async () => { await this.StopAnimation(bindable); }).SafeFireAndForget();
        }

        private async Task<bool> Run(BindableObject bindable)
        {
            if (Skeleton.GetCancelAnimation(bindable))
            {
                Skeleton.SetAnimating(bindable, false);
                return false;
            }
            else
            {
                Skeleton.SetAnimating(bindable, true);
                await Animate(bindable);
                return await Run(bindable);
            }
        }
    }
}