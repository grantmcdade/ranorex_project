﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace aqua.UntitledNamespace2961
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the MainRecordingRepository element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    [RepositoryFolder("bbc7e263-7ad2-4527-bb5a-2bb47b55e98b")]
    public partial class MainRecordingRepository : RepoGenBaseFolder
    {
        static MainRecordingRepository instance = new MainRecordingRepository();

        /// <summary>
        /// Gets the singleton class instance representing the MainRecordingRepository element repository.
        /// </summary>
        [RepositoryFolder("ea287554-6ceb-4edf-84bc-8b6ef276aacb")]
        public static MainRecordingRepository Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public MainRecordingRepository() 
            : base("MainRecordingRepository", "/", null, 0, false, "ea287554-6ceb-4edf-84bc-8b6ef276aacb", ".\\RepositoryImages\\MainRecordingRepositoryea287554-6ceb-4edf-84bc-8b6ef276aacb.rximgres")
        {
        }

#region Variables

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("bbc7e263-7ad2-4527-bb5a-2bb47b55e98b")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    public partial class MainRecordingRepositoryFolders
    {
    }
#pragma warning restore 0436
}