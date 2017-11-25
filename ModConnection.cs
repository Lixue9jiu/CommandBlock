using System;
using System.Reflection;
using System.Collections.Generic;
namespace CommandBlock
{
    public static class ModConnection
    {
		public static IEnumerator<TypeInfo> GetBlockEnumerator()
		{
			var list = new List<TypeInfo>();
			list.AddRange(typeof(Game.BlocksManager).Assembly.DefinedTypes);
			list.AddRange(typeof(ModConnection).Assembly.DefinedTypes);
			return list.GetEnumerator();
		}

		public static int[] GetElectricBlocks()
		{
			return new int[] {
				133,
				140,
				137,
				143,
				156,
				134,
				135,
				145,
				224,
				146,
				157,
				180,
				181,
				183,
				138,
				139,
				141,
				142,
				184,
				187,
				186,
				188,
				144,
				151,
				179,
				152,
				182,
				185,
				56,
				57,
				58,
				83,
				84,
				166,
				194,
				86,
				63,
				97,
				98,
				210,
				211,
				105,
				106,
				107,
				234,
				235,
				236,
				147,
				153,
				154,
				223,
				155,
				120,
				121,
				199,
				216,
				227,
				237,
				501
			};
		}
    }
}
