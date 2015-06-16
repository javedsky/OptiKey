﻿using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading;
using System.Windows;
using JuliusSweetland.OptiKey.Enums;
using JuliusSweetland.OptiKey.Models;

namespace JuliusSweetland.OptiKey.Services
{
    public interface IDictionaryService : INotifyErrors
    {
        void LoadDictionary();
        bool ExistsInDictionary(string entryToFind);
        IEnumerable<DictionaryEntry> GetAllEntries();
        IEnumerable<DictionaryEntry> GetAutoCompleteSuggestions(string root);
        void AddNewEntryToDictionary(string entry);
        void RemoveEntryFromDictionary(string entry);
        void IncrementEntryUsageCount(string entry);
        void DecrementEntryUsageCount(string entry);
        List<string> MapCaptureToEntries(List<Timestamped<PointAndKeyValue>> timestampedPointAndKeyValues,
            string reducedCapture, bool firstSequenceLetterIsReliable, bool lastSequenceLetterIsReliable, 
            ref CancellationTokenSource cancellationTokenSource, Action<Exception> exceptionHandler);
        Tuple<List<Point>, FunctionKeys?, string, List<string>> MapCaptureToEntries(
            List<Timestamped<PointAndKeyValue>> timestampedPointAndKeyValues, 
            int sequenceThreshold, string reliableFirstLetter, string reliableLastLetter,
            ref CancellationTokenSource cancellationTokenSource, Action<Exception> exceptionHandler);
    }
}
