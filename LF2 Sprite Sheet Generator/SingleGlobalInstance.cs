﻿using System;
using System.Reflection;                //Assembly
using System.Runtime.InteropServices;   //GuidAttribute
using System.Security.AccessControl;    //MutexAccessRule
using System.Security.Principal;        //SecurityIdentifier
using System.Threading;                 //Mutex

namespace NX
{
	class SingleGlobalInstance : IDisposable
	{
		bool hasHandle = false;
		Mutex mutex;

		private void InitMutex()
		{
			string appGuid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value;
			string mutexId = string.Format("Global\\{{{0}}}", appGuid);
			mutex = new Mutex(false, mutexId);

			var allowEveryoneRule = new MutexAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), MutexRights.FullControl, AccessControlType.Allow);
			var securitySettings = new MutexSecurity();
			securitySettings.AddAccessRule(allowEveryoneRule);
			mutex.SetAccessControl(securitySettings);
		}

		public SingleGlobalInstance(int timeOut)
		{
			InitMutex();
			try
			{
				if (timeOut < 0)
					hasHandle = mutex.WaitOne(Timeout.Infinite, false);
				else
					hasHandle = mutex.WaitOne(timeOut, false);

				if (hasHandle == false)
					throw new TimeoutException("Timeout waiting for exclusive access on SingleInstance");
			}
			catch (AbandonedMutexException)
			{
				hasHandle = true;
			}
		}

		public void Dispose()
		{
			if (mutex != null)
			{
				if (hasHandle)
					mutex.ReleaseMutex();
				mutex.Close();
			}
		}
	}
}
