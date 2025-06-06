using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0850B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NRTIT,
            A.OPCAOPAG
            INTO :V0HCOB-NRTIT,
            :V0HCOB-OPCAOPAG
            FROM SEGUROS.V0HISTCOBVA A
            WHERE A.NRCERTIF = :V0HCOB-NRCERTIF
            AND A.NRPARCEL = :V0HCOB-NRPARCELMAX
            AND A.NRTIT =
            (SELECT MIN(B.NRTIT)
            FROM SEGUROS.V0HISTCOBVA B
            WHERE B.NRCERTIF = :V0HCOB-NRCERTIF
            AND B.NRPARCEL = :V0HCOB-NRPARCELMAX
            AND B.SITUACAO IN ( ' ' , '0' , '5' )
            AND B.VLPRMTOT =
            (SELECT MIN(C.VLPRMTOT)
            FROM SEGUROS.V0HISTCOBVA C
            WHERE C.NRCERTIF = :V0HCOB-NRCERTIF
            AND C.NRPARCEL = :V0HCOB-NRPARCELMAX
            AND C.VLPRMTOT > 0
            AND C.SITUACAO IN ( ' ' , '0' , '5' )))
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.NRTIT
							,
											A.OPCAOPAG
											FROM SEGUROS.V0HISTCOBVA A
											WHERE A.NRCERTIF = '{this.V0HCOB_NRCERTIF}'
											AND A.NRPARCEL = '{this.V0HCOB_NRPARCELMAX}'
											AND A.NRTIT =
											(SELECT MIN(B.NRTIT)
											FROM SEGUROS.V0HISTCOBVA B
											WHERE B.NRCERTIF = '{this.V0HCOB_NRCERTIF}'
											AND B.NRPARCEL = '{this.V0HCOB_NRPARCELMAX}'
											AND B.SITUACAO IN ( ' ' 
							, '0' 
							, '5' )
											AND B.VLPRMTOT =
											(SELECT MIN(C.VLPRMTOT)
											FROM SEGUROS.V0HISTCOBVA C
											WHERE C.NRCERTIF = '{this.V0HCOB_NRCERTIF}'
											AND C.NRPARCEL = '{this.V0HCOB_NRPARCELMAX}'
											AND C.VLPRMTOT > 0
											AND C.SITUACAO IN ( ' ' 
							, '0' 
							, '5' )))";

            return query;
        }
        public string V0HCOB_NRTIT { get; set; }
        public string V0HCOB_OPCAOPAG { get; set; }
        public string V0HCOB_NRPARCELMAX { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1();
            var i = 0;
            dta.V0HCOB_NRTIT = result[i++].Value?.ToString();
            dta.V0HCOB_OPCAOPAG = result[i++].Value?.ToString();
            return dta;
        }

    }
}