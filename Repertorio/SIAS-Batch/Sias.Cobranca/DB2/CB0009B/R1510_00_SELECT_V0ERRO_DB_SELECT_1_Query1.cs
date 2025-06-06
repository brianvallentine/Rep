using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0009B
{
    public class R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1 : QueryBasis<R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :V0ERRO-COUNT :VIND-COUNT
            FROM SEGUROS.VG_CRITICA_PROPOSTA A,
            SEGUROS.VG_DM_MSG_CRITICA B
            WHERE A.NUM_CERTIFICADO = :V0BILH-NUMBIL
            AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' )
            AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA
            AND B.COD_TP_MSG_CRITICA <> 3
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.VG_CRITICA_PROPOSTA A
							,
											SEGUROS.VG_DM_MSG_CRITICA B
											WHERE A.NUM_CERTIFICADO = '{this.V0BILH_NUMBIL}'
											AND A.STA_CRITICA IN ( '0' 
							, '1' 
							, '2' 
							, '4' 
							, '5' 
							, '8' )
											AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA
											AND B.COD_TP_MSG_CRITICA <> 3
											WITH UR";

            return query;
        }
        public string V0ERRO_COUNT { get; set; }
        public string VIND_COUNT { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1 Execute(R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1 r1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1)
        {
            var ths = r1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1510_00_SELECT_V0ERRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ERRO_COUNT = result[i++].Value?.ToString();
            dta.VIND_COUNT = string.IsNullOrWhiteSpace(dta.V0ERRO_COUNT) ? "-1" : "0";
            return dta;
        }

    }
}