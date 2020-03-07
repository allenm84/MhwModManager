using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MHWModManager.Annotations;

namespace MHWModManager
{
    public class MhwMod : INotifyPropertyChanged
    {
        private readonly MhwInstall _mhwInstall;
        private readonly FileInfo _archiveFile;

        private MhwModFile[] _mapping;
    private bool? _isInstalled = null;

        public MhwMod(MhwInstall install, FileInfo info)
        {
            _mhwInstall = install;
            _archiveFile = info;
            InitializeModFileMap();
        }

        public string Name => _archiveFile.Name;

        public bool? IsInstalled
        {
            get => _isInstalled;
            set
            {
                _isInstalled = value;
                OnPropertyChanged();
            }
        }

        private async void InitializeModFileMap()
        {
            _mapping = await CreateModFileMap();
            IsInstalled = _mapping.All(f => f.Exists);
        }

        private async Task<MhwModFile[]> CreateModFileMap()
        {
            var (succeeded, archive) = await Archive.Extract(_archiveFile);
            return !succeeded 
                ? Array.Empty<MhwModFile>() 
                : MapFilesToInstall(archive, _mhwInstall).ToArray();
        }
        
        private static IEnumerable<MhwModFile> MapFilesToInstall(DirectoryInfo modFilesDir, MhwInstall monsterHunter)
        {
            var installedFiles = monsterHunter.ToLookup(f => f.Name);
            foreach (var modFile in modFilesDir.EnumerateFiles("*.*", SearchOption.AllDirectories))
            {
                var matches = installedFiles[modFile.Name];
                var exactMatch =
                    matches.SingleOrDefault(installedFile => FileSystem.AreFilesEqual(installedFile, modFile));
                yield return new MhwModFile(modFile, exactMatch);
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}