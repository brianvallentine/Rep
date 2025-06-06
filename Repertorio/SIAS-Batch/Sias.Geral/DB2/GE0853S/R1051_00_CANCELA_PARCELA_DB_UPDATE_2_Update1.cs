using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0853S
{
    public class R1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1 : QueryBasis<R1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCOBVA
				SET SITUACAO = '2'
				WHERE  NRCERTIF =  '{this.V0HISC_NRCERTIF}'
				AND NRPARCEL =  '{this.V0HISC_NRPARCEL}'
				AND SITUACAO IN ( ' ' , '0' , '5' , X'00' )";

            return query;
        }
        public string V0HISC_NRCERTIF { get; set; }
        public string V0HISC_NRPARCEL { get; set; }

        public static void Execute(R1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1 r1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1)
        {
            var ths = r1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}