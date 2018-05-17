﻿using Stratis.SmartContracts.Core;
using Stratis.SmartContracts.Core.State;
using Xunit;

namespace Stratis.Bitcoin.Features.SmartContracts.Tests
{
    public class RLPLListTests
    {
        /*
         * This reproduces a bug found on the alpha testnet. It occurs specifically when a prefix number is serialized that is more than one byte long.
         * It comes out in the wrong endianness.
         */

        [Fact]
        public void RLPLList_KnownBug_DoesntThrowOutOfIndexException()
        {
            byte[] problematic = "F90111A0EB7C78245D7069F0C1A02F4A7A2FC57CBF8D049D7BDD0E538DEA349D0F1A65BCA010CD44FDE2C6A8D3204430562DB1032A3EABCB9D1E0F17FD307D2117EE7D016C8080A095D20F8EDF2B5CFC919CDEAB7C5AD2201BDCFE9AA1850C6B657335B35D781880A09295ED172EC417B1E2EC7E478A8E9BD3A1987A4A178324FBBFC0CD9A2823B6FA8080A0D3A7CBD5758A436CEF50D94163DC091B2226978468D0653300D06671E3E930B680808080A009B3A0D67AB0510EB21E8FB41C3250B854C35C3A810D764584EAA1E1AB90EC55A0963FB740F22284560D8171691D19AACE365C6DFAD13CFBBB0E3C60EF3426C008A0F5B24949400B950EF5BE6BB06421BA31D10E0F6F948C8CC46FEF419EAA0FF2B080".HexToByteArray();
            RLPLList.DecodeLazyList(problematic);
        }
    }
}
