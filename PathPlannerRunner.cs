using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using ExileCore;

namespace ExpeditionIcons;

public class PathPlannerRunner
{
    private readonly CancellationTokenSource _cts = new CancellationTokenSource();
    public bool IsRunning => _task is { IsCompleted: false };
    public (List<Vector2> Path, double Score, int Iteration, double LastGenerationTime)[] BestValues;
    public List<Vector2> CurrentBestPath => BestValues?.MaxBy(x => x.Score).Path;
    public double CurrentBestScore => BestValues?.Max(x => x.Score) ?? 0;

    private Task _task;

    public void Start(PlannerSettings settings, ExpeditionEnvironment environment, SoundController soundController)
    {
        _task = Run(settings, environment, soundController);
    }

    private async Task Run(PlannerSettings settings, ExpeditionEnvironment environment, SoundController soundController)
    {
        var threadCount = Math.Max(settings.SearchThreads.Value, 1);
        BestValues = new (List<Vector2> Path, double Score, int Iteration, double LastGenerationTime)[threadCount];
        var tasks = new List<Task>();
        for (int i = 0; i < threadCount; i++)
        {
            var ii = i;
            tasks.Add(Task.Run(() =>
            {
                try
                {
                    var p = new PathPlanner(settings);
                    var sw = Stopwatch.StartNew();
                    var iterationSw = Stopwatch.StartNew();
                    foreach (var bestPath in p.GetBestPathSeries(environment))
                    {
                        BestValues[ii] = (bestPath.Points, bestPath.Score, BestValues[ii].Iteration + 1, iterationSw.Elapsed.TotalMilliseconds);
                        iterationSw.Restart();
                        if (sw.Elapsed.TotalSeconds >= settings.MaximumGenerationTimeSeconds.Value ||
                            _cts.IsCancellationRequested)
                        {
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    DebugWindow.LogError($"Expedition search thread failed: {ex}");
                }
            }));
        }

        try
        {
            await Task.WhenAll(tasks);
        }
        finally
        {
            DebugWindow.LogMsg("ExpeditionIcons PathPlanner finished.");
            if (settings.PlaySoundOnFinish)
            {
                soundController.PlaySound("attention");
            }
        }
    }

    public void Stop() => _cts.Cancel();
}