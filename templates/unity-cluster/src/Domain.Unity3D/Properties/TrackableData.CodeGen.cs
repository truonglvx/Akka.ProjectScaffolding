﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by TrackableData.CodeGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using TrackableData;
using ProtoBuf;

#region IUserData

namespace Domain
{
    [ProtoContract]
    public partial class TrackableUserData : IUserData
    {
        [IgnoreDataMember]
        public IPocoTracker<IUserData> Tracker { get; set; }

        [IgnoreDataMember]
        public bool Changed { get { return Tracker != null && Tracker.HasChange; } }

        ITracker ITrackable.Tracker
        {
            get
            {
                return Tracker;
            }
            set
            {
                var t = (IPocoTracker<IUserData>)value;
                Tracker = t;
            }
        }

        ITracker<IUserData> ITrackable<IUserData>.Tracker
        {
            get
            {
                return Tracker;
            }
            set
            {
                var t = (IPocoTracker<IUserData>)value;
                Tracker = t;
            }
        }

        public ITrackable GetChildTrackable(object name)
        {
            switch ((string)name)
            {
                default:
                    return null;
            }
        }

        public IEnumerable<KeyValuePair<object, ITrackable>> GetChildTrackables(bool changedOnly = false)
        {
            yield break;
        }

        public static class PropertyTable
        {
            public static readonly PropertyInfo Nickname = typeof(IUserData).GetProperty("Nickname");
            public static readonly PropertyInfo RegisterTime = typeof(IUserData).GetProperty("RegisterTime");
        }

        private string _Nickname;

        [ProtoMember(1)] 
        public string Nickname
        {
            get
            {
                return _Nickname;
            }
            set
            {
                if (Tracker != null && Nickname != value)
                    Tracker.TrackSet(PropertyTable.Nickname, _Nickname, value);
                _Nickname = value;
            }
        }

        private DateTime _RegisterTime;

        [ProtoMember(2)] 
        public DateTime RegisterTime
        {
            get
            {
                return _RegisterTime;
            }
            set
            {
                if (Tracker != null && (RegisterTime != value || RegisterTime.Kind != value.Kind))
                    Tracker.TrackSet(PropertyTable.RegisterTime, _RegisterTime, value);
                _RegisterTime = value;
            }
        }
    }

    [ProtoContract]
    public class TrackableUserDataTrackerSurrogate
    {
        [ProtoMember(1)] public EnvelopedObject<string> Nickname;
        [ProtoMember(2)] public EnvelopedObject<DateTime> RegisterTime;

        [ProtoConverter]
        public static TrackableUserDataTrackerSurrogate Convert(TrackablePocoTracker<IUserData> tracker)
        {
            if (tracker == null)
                return null;

            var surrogate = new TrackableUserDataTrackerSurrogate();
            foreach(var changeItem in tracker.ChangeMap)
            {
                switch (changeItem.Key.Name)
                {
                    case "Nickname":
                        surrogate.Nickname = new EnvelopedObject<string> { Value = (string)changeItem.Value.NewValue };
                        break;
                    case "RegisterTime":
                        surrogate.RegisterTime = new EnvelopedObject<DateTime> { Value = (DateTime)changeItem.Value.NewValue };
                        break;
                }
            }

            return surrogate;
        }

        [ProtoConverter]
        public static TrackablePocoTracker<IUserData> Convert(TrackableUserDataTrackerSurrogate surrogate)
        {
            if (surrogate == null)
                return null;

            var tracker = new TrackablePocoTracker<IUserData>();
            if (surrogate.Nickname != null)
                tracker.ChangeMap.Add(TrackableUserData.PropertyTable.Nickname, new TrackablePocoTracker<IUserData>.Change { NewValue = surrogate.Nickname.Value });
            if (surrogate.RegisterTime != null)
                tracker.ChangeMap.Add(TrackableUserData.PropertyTable.RegisterTime, new TrackablePocoTracker<IUserData>.Change { NewValue = surrogate.RegisterTime.Value });
            return tracker;
        }
    }
}

#endregion
#region IUserContext

namespace Domain
{
    [ProtoContract]
    public partial class TrackableUserContext : IUserContext
    {
        [IgnoreDataMember]
        private TrackableUserContextTracker _tracker;

        [IgnoreDataMember]
        public TrackableUserContextTracker Tracker
        {
            get
            {
                return _tracker;
            }
            set
            {
                _tracker = value;
                Data.Tracker = value?.DataTracker;
                Notes.Tracker = value?.NotesTracker;
            }
        }

        public bool Changed { get { return Tracker != null && Tracker.HasChange; } }

        ITracker ITrackable.Tracker
        {
            get
            {
                return Tracker;
            }
            set
            {
                var t = (TrackableUserContextTracker)value;
                Tracker = t;
            }
        }

        ITracker<IUserContext> ITrackable<IUserContext>.Tracker
        {
            get
            {
                return Tracker;
            }
            set
            {
                var t = (TrackableUserContextTracker)value;
                Tracker = t;
            }
        }

        IContainerTracker<IUserContext> ITrackableContainer<IUserContext>.Tracker
        {
            get
            {
                return Tracker;
            }
            set
            {
                var t = (TrackableUserContextTracker)value;
                Tracker = t;
            }
        }

        public ITrackable GetChildTrackable(object name)
        {
            switch ((string)name)
            {
                case "Data":
                    return Data as ITrackable;
                case "Notes":
                    return Notes as ITrackable;
                default:
                    return null;
            }
        }

        public IEnumerable<KeyValuePair<object, ITrackable>> GetChildTrackables(bool changedOnly = false)
        {
            var trackableData = Data as ITrackable;
            if (trackableData != null && (changedOnly == false || trackableData.Changed))
                yield return new KeyValuePair<object, ITrackable>("Data", trackableData);
            var trackableNotes = Notes as ITrackable;
            if (trackableNotes != null && (changedOnly == false || trackableNotes.Changed))
                yield return new KeyValuePair<object, ITrackable>("Notes", trackableNotes);
        }

        private TrackableUserData _Data = new TrackableUserData();

        [ProtoMember(1)] 
        public TrackableUserData Data
        {
            get
            {
                return _Data;
            }
            set
            {
                if (_Data != null)
                    _Data.Tracker = null;
                if (value != null)
                    value.Tracker = Tracker?.DataTracker;
                _Data = value;
            }
        }

        TrackableUserData IUserContext.Data
        {
            get { return _Data; }
            set { _Data = (TrackableUserData)value; }
        }

        private TrackableDictionary<int, string> _Notes = new TrackableDictionary<int, string>();

        [ProtoMember(2)] 
        public TrackableDictionary<int, string> Notes
        {
            get
            {
                return _Notes;
            }
            set
            {
                if (_Notes != null)
                    _Notes.Tracker = null;
                if (value != null)
                    value.Tracker = Tracker?.NotesTracker;
                _Notes = value;
            }
        }

        TrackableDictionary<int, string> IUserContext.Notes
        {
            get { return _Notes; }
            set { _Notes = (TrackableDictionary<int, string>)value; }
        }
    }

    [ProtoContract]
    public class TrackableUserContextTracker : IContainerTracker<IUserContext>
    {
        [ProtoMember(1)] 
        public TrackablePocoTracker<IUserData> DataTracker { get; set; } = new TrackablePocoTracker<IUserData>();
        [ProtoMember(2)] 
        public TrackableDictionaryTracker<int, string> NotesTracker { get; set; } = new TrackableDictionaryTracker<int, string>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("{ ");
            var first = true;
            if (DataTracker != null && DataTracker.HasChange)
            {
                if (first)
                    first = false;
                else
                    sb.Append(", ");
                sb.Append("Data:");
                sb.Append(DataTracker);
            }

            if (NotesTracker != null && NotesTracker.HasChange)
            {
                if (first)
                    first = false;
                else
                    sb.Append(", ");
                sb.Append("Notes:");
                sb.Append(NotesTracker);
            }

            sb.Append(" }");
            return sb.ToString();
        }

        public bool HasChange
        {
            get
            {
                return
                    (DataTracker != null && DataTracker.HasChange) ||
                    (NotesTracker != null && NotesTracker.HasChange) ||
                    false;
            }
        }

        public event TrackerHasChangeSet HasChangeSet
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        public void Clear()
        {
            if (DataTracker != null)
                DataTracker.Clear();
            if (NotesTracker != null)
                NotesTracker.Clear();
        }

        public void ApplyTo(object trackable)
        {
            ApplyTo((IUserContext)trackable);
        }

        public void ApplyTo(IUserContext trackable)
        {
            if (DataTracker != null)
                DataTracker.ApplyTo(trackable.Data);
            if (NotesTracker != null)
                NotesTracker.ApplyTo(trackable.Notes);
        }

        public void ApplyTo(ITracker tracker)
        {
            ApplyTo((TrackableUserContextTracker)tracker);
        }

        public void ApplyTo(ITracker<IUserContext> tracker)
        {
            ApplyTo((TrackableUserContextTracker)tracker);
        }

        public void ApplyTo(TrackableUserContextTracker tracker)
        {
            if (DataTracker != null)
                DataTracker.ApplyTo(tracker.DataTracker);
            if (NotesTracker != null)
                NotesTracker.ApplyTo(tracker.NotesTracker);
        }

        public void RollbackTo(object trackable)
        {
            RollbackTo((IUserContext)trackable);
        }

        public void RollbackTo(IUserContext trackable)
        {
            if (DataTracker != null)
                DataTracker.RollbackTo(trackable.Data);
            if (NotesTracker != null)
                NotesTracker.RollbackTo(trackable.Notes);
        }

        public void RollbackTo(ITracker tracker)
        {
            RollbackTo((TrackableUserContextTracker)tracker);
        }

        public void RollbackTo(ITracker<IUserContext> tracker)
        {
            RollbackTo((TrackableUserContextTracker)tracker);
        }

        public void RollbackTo(TrackableUserContextTracker tracker)
        {
            if (DataTracker != null)
                DataTracker.RollbackTo(tracker.DataTracker);
            if (NotesTracker != null)
                NotesTracker.RollbackTo(tracker.NotesTracker);
        }
    }
}

#endregion
