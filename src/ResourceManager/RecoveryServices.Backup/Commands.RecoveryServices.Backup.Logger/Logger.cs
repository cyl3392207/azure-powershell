﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup
{
    public class Logger
    {
        private Action<string> writeWarningAction;

        private Action<string> writeDebugAction;

        private Action<string> writeVerboseAction;

        private Action<ErrorRecord> throwTerminatingErrorAction;

        public static Logger Instance { get; set; }

        public Logger(Action<string> writeWarning,
                      Action<string> writeDebug,
                      Action<string> writeVerbose,
                      Action<ErrorRecord> throwTerminatingError)
        {
            writeWarningAction = writeWarning;
            writeDebugAction = writeDebug;
            writeVerboseAction = writeVerbose;
            throwTerminatingErrorAction = throwTerminatingError;
        }

        public void WriteVerbose(string text)
        {
            writeVerboseAction(text);
        }

        public void WriteDebug(string text)
        {
            writeDebugAction(text);
        }

        public void WriteWarning(string text)
        {
            writeWarningAction(text);
        }

        public void ThrowTerminatingError(ErrorRecord errorRecord)
        {
            throwTerminatingErrorAction(errorRecord);
        }
    }
}