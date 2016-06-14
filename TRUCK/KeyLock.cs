using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TRUCK
{
	/// <summary>
	/// A class to interface to the Microcomputer Applications Inc. Keylock dongle. This code has only
	/// been tested with the USB version - variations may be needed to work with the parallel port dongle version.
	/// To use this class, the KL2DLL32.DLL file must be somewhere the application's EXE can find it (eg: in the
	/// working directory when the application is run, or in the windows system directory).
	/// </summary>
	///                               
	public class Keylock
	{
		/// <summary>
		/// Platform invoke declaration for Keylock interface KFUNC function.
		/// </summary>
		[DllImport("KL2DLL32.DLL", CharSet=CharSet.Auto)]
		private static extern uint KFUNC(int arg1,int arg2,int arg3,int arg4);
		/// <summary> 
		/// The following codes are assigned by the dongle vendor to GE Salem. We can
		/// get a specific set of codes for one product only, or a single code set that
		/// refers to GE Salem in general, and then make distinctions between products
		/// by storing proprietary data in the dongle's non-volatile RAM.
		/// </summary>
        /// 
        //private static short ReturnValue1;
        //private static short ReturnValue2;

        public static ushort ValidateCode1 = 0XF606;		// These three codes passed to the dongle as the first part
        public static ushort ValidateCode2 = 0XD564;		// of its authentication sequence.
        public static ushort ValidateCode3 = 0X9D62;

        public static ushort ClientIDCode1 = 0X5EA9;		// These values are returned by the dongle as the result of the authentication 
        public static ushort ClientIDCode2 = 0XD3BF;		// sequence. We should check that the returned value matches these values. 

        public static ushort ReadCode1 = 0X9ACC;		// These values must be passed to the dongle to authorize read operations
        private static ushort ReadCode2 = 0X42CD;		// of its non-volatile RAM.
        private static ushort ReadCode3 = 0XAE8A;

        private static ushort WriteCode1 = 0XB68B;		// These values must be passed to the dongle to authorize write operations
        private static ushort WriteCode2 = 0XB137;		// to its non-volatile RAM.
        private static ushort WriteCode3 = 0XF859;
        
/*                                        (FOXBASE/PRO)
                            SIGNED        UNSIGNED
              HEX           DECIMAL       DECIMAL

ValidateCode1 F606          -2554          62982 
ValidateCode2 D564          -10908         54628 
ValidateCode3 9D62          -25246         40290 
ClientIDCode1 5EA9           24233         24233 
ClientIDCode2 D3BF          -11329         54207 
ReadCode1     9ACC          -25908         39628 
ReadCode2     42CD           17101         17101 
ReadCode3     4E8A           20106         20106 
WriteCode1    B68B          -18805         46731 
WriteCode2    B137          -20169         45367 
WriteCode3    F859          -1959          63577 */

		/// <summary>
		/// The following function (operation) codes are used as the first argument to the KFUNC() interface function in the DLL
		/// to specify the desired operation to perform.
		/// </summary>
        private static ushort KLCheck = 1;
        private static ushort ReadAuth = 2;
        private static ushort GetSN = 3;
        private static ushort GetVarWord = 4;
        private static ushort WriteAuth = 5;
        private static ushort WriteVarWord = 6;
		//private static ushort DecrementMem=		7;
		//private static ushort SetExpDate=      10;



		private static ushort RotateLeft(ushort val,int n)
		{
			int ival=((int)val)<<n;
			return (ushort)((ival & 0xffff) | (ival>>16));
		}
		
		/// <summary>
		/// Checks for presence of dongle. Note that using this function resets read/write authorization
		/// state bits in the dongle, so read/write must be re-authorized after calls to this function.
		/// </summary>
		/// <returns>true if the dongle is present and the authorization sequence passes.</returns>
		public static bool IsPresent()
		{
			// First call DLL with 3 validate codes
            try
            {
                uint retval = KFUNC(KLCheck, ValidateCode1, ValidateCode2, ValidateCode3);
                ushort retLow = (ushort)(retval & 0xffff);
                ushort retHigh = (ushort)(retval >> 16);
                // Next call DLL with first call result processed with canned logic
                retval = KFUNC(RotateLeft(retLow, retHigh & 7) ^ ReadCode3 ^ retHigh, RotateLeft(retHigh, retLow & 15), (ushort)(retLow ^ retHigh), 0);
                retLow = (ushort)(retval & 0xffff);
                retHigh = (ushort)(retval >> 16);
                // If all is well, the returned value will match the client id code.
                if (retLow == ClientIDCode1 && retHigh == ClientIDCode2)
                    return true;
                return false;
            }
            catch (System.DllNotFoundException ex)
            {
                MessageBox.Show(ex.Message,"Error KeyLock:");
                return false;
            }
		}

        /// <summary>
        /// 
        /// </summary>
		public static void Reset()
		{
			uint retval=KFUNC(KLCheck,0,0,0);
		}

		/// <summary>
		/// Authorizes read operations on the dongle's non-volatile RAM. This must be called after
		/// calling IsPresent() which resets the dongle's internal read authorization state.
		/// </summary>
		/// <returns></returns>
        /// 
		public static void AuthorizeRead()
		{
			KFUNC(ReadAuth,ReadCode1,ReadCode2,ReadCode3);
		}

		/// <summary>
		/// Authorizes write operations on the dongle's non-volatile RAM. This must be called after
		/// calling IsPresent() which resets the dongle's internal write authorization state.
		/// </summary>
		/// <returns></returns>
		public static void AuthorizeWrite()
		{
			KFUNC(WriteAuth,WriteCode1,WriteCode2,WriteCode3);
		}

		/// <summary>
		/// Reads the 16-bit serial number from the dongle
		/// </summary>
		/// <returns></returns>
        /// 
		public static ushort ReadSerialNo()
		{
			uint retval=KFUNC(GetSN,0,0,0);
			return (ushort)retval;
		}

		/// <summary>
		/// Reads a 16-bit value from one of the 56 registers in the dongle's non-volatile RAM.
		/// </summary>
		/// <returns></returns>
		public static ushort ReadRegister(int reg)
		{
			if (reg<0 && reg>55)
				return 0;
			uint retval=KFUNC(GetVarWord,reg,0,0);
			return (ushort)retval;
		}

		/// <summary>
		/// Writes a 16-bit value to one of the 56 registers in the dongle's non-volatile RAM.
		/// </summary>
		/// <returns></returns>
		public static void WriteRegister(int reg,ushort val)
		{
			if (reg<0 && reg>55)
				return;
			KFUNC(WriteVarWord,reg,val,0);
		}
	}
}
