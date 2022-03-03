using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;

namespace Igtampe.BasicRender {

    /// <summary>Class that can handle all tasks handed to it sequentially.</summary>
    public class DrawThread {

        /// <summary>Collection of tasks that need to be executed</summary>
        private readonly ConcurrentQueue<Task> Tasks;

        /// <summary>Handle that's set when the drawthread should actually *do* something</summary>
        private readonly AutoResetEvent Handle;

        /// <summary>Whether or not a cancellation is pending</summary>
        private bool StopPending = false;

        /// <summary>Inner task handling the execution of the given tasks</summary>
        private Task T;

        /// <summary>Status of the inner task of drawing</summary>
        public TaskStatus Status => T != null ? T.Status : TaskStatus.Created; //Que belleza *chefs kiss*

        /// <summary>Count of remaining tasks</summary>
        public int TaskCount => Tasks.Count;

        /// <summary>Creates a Draw Thread</summary>
        public DrawThread() {
            Handle = new AutoResetEvent(false);
            Tasks = new ConcurrentQueue<Task>();
        }

        /// <summary>Enqueues a task to the drawthread</summary>
        /// <param name="T"></param>
        public void AddDrawTask(Task T) {
            Tasks.Enqueue(T);
            Handle.Set();
        }

        /// <summary>Enqueues an action as a task to the drawthread</summary>
        /// <param name="A"></param>
        public void AddDrawTask(Action A) {
            if (StopPending) { throw new InvalidOperationException("You cannot add any more tasks if this thread is about to be cancelled"); }
            Tasks.Enqueue(new Task(A));
            Handle.Set();
        }

        /// <summary>Starts the drawthread</summary>
        public void Start() {
            if (T != null && T.Status != TaskStatus.RanToCompletion) { throw new InvalidOperationException("Drawthread is already running"); }
            T = new Task(() => Loop());
            T.Start();
        }

        /// <summary>Stops the drawthread asynchronously (essentially only sends call to make cancellation)</summary>
        public void StopAsync() => StopPending = true;

        /// <summary>Stops and resets the drawthread</summary>
        public void Stop() {
            StopAsync();
            T.Wait();
        }

        /// <summary>Main loop for the drawthread</summary>
        private void Loop() {
            while (!StopPending) {
                Handle.WaitOne();
                while (!Tasks.IsEmpty) {
                    if (Tasks.TryDequeue(out Task R)) {
                        R.RunSynchronously();
                        R.Dispose(); //Dispose task once it's complete
                    }
                }
                Handle.Reset();
            }

            StopPending = false;
        }
    }
}
